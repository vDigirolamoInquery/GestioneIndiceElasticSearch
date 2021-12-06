using Elasticsearch.Net;
using FullTextElasticSearch.Log4Net;
using FullTextElasticSearch.Server.Classes;
using FullTextElasticSearch.Utils.Classes;
using Nest;
using System;
using System.Collections.Generic;

namespace FullTextElasticSearch.Server
{
    public class ConnectionToEs
    {
        private readonly string _defaultIndex = AllConstants.ElasticSearchDefaultIndex;
        private readonly Logger<ConnectionToEs> Logger = new Logger<ConnectionToEs>();
        private ElasticClient GetEsClient()
        {
            var settings = new ConnectionSettings(new Uri(AllConstants.ElasticSearchDefaultServer));
            if (bool.Parse(AllConstants.ElasticSearchBasicAuthEnabled))
            {
                settings.BasicAuthentication(AllConstants.ElasticSearchBasicAuthUsername, AllConstants.ElasticSearchBasicAuthPassword);
            }
            settings.DisableAutomaticProxyDetection(bool.Parse(AllConstants.ElasticSearchDisableAutomaticProxyDetection));//BDC-338
            settings.DefaultIndex(_defaultIndex);
            return new ElasticClient(settings);
        }
        public ElasticClient CreateIndex()
        {
            var esClient = GetEsClient();
            esClient.Indices.Delete(Indices.Index(_defaultIndex.ToLowerInvariant()));

            var filters = new[] { "lowercase", "italian_elision", "asciifolding" }; //"italian_stemmer" "italian_stop" 
            var articles = new[] { "c", "l", "all", "dall", "dell",
                                   "nell", "sull", "coll", "pell",
                                   "gl", "agl", "dagl", "degl", "negl",
                                   "sugl", "un", "m", "t", "s", "v", "d" };
            if (!esClient.Indices.Exists(_defaultIndex.ToLowerInvariant()).Exists)
            {
                esClient.Indices.Create(_defaultIndex, index => index
                        .Settings(settings => settings
                            .Analysis(analisys => analisys
                                .Analyzers(analyzer => analyzer
                                    .Custom("custom", custom => custom
                                        .Tokenizer("standard")
                                        .Filters(filters)))
                                    .TokenFilters(tokenFilters => tokenFilters
                                        //.Stop("italian_stop", stop => stop
                                        //    .StopWords("_italian_"))
                                        //.Stemmer("italian_stemmer", stemmer => stemmer
                                        //    .Language("light_italian"))
                                        .Elision("italian_elision", elision => elision
                                            .ArticlesCase(true)
                                            .Articles(articles))))));
  
                esClient.Map<DocumentoElasticSearch>(m =>
                {
                    var putMappingDescriptor = m.Index(Indices.Index(_defaultIndex)).AutoMap()
                                                                .Properties(prop => prop
                                                                    .Text(text => text
                                                                        .Name(name => name.Testo)
                                                                        .Analyzer("custom")
                                                                        .TermVector(TermVectorOption.WithPositionsOffsets))
                                                                    .Text(x => x.
                                                                        Name(name => name.Argomenti)
                                                                        .Analyzer("custom"))
                                                                    .Keyword(text => text
                                                                        .Name(name => name.CodiceTipo))
                                                                    .Keyword(text => text
                                                                        .Name(name => name.CodiceClasse))
                                                                    .Keyword(text => text
                                                                        .Name(name => name.CodiceSottotipo))
                                                                    .Keyword(text => text
                                                                        .Name(name => name.Descrizione))
                                                                    .Keyword(text => text
                                                                        .Name(name => name.DescrizioneClasse))
                                                                    .Keyword(text => text
                                                                        .Name(name => name.DescrizioneTipo))
                                                                    .Keyword(text => text
                                                                        .Name(name => name.DescrizioneSottotipo))
                                                                    .Keyword(text => text
                                                                        .Name(name => name.Descrizione))
                                                                    .Date(text => text
                                                                        .Name(name => name.Dal))
                                                                    .Date(text => text
                                                                        .Name(name => name.DataUltimaCompilazione))
                                                                    .Date(text => text
                                                                        .Name(name => name.DataScadenza))
                                                                    .Nested<ArticoloElasticSearch>(n => n
                                                                        .Name(name => name.Articoli)
                                                                        .Properties(nProp => nProp
                                                                            .Text(text => text
                                                                                .Name(name => name.Testo)
                                                                                .Analyzer("custom")))));
                    return putMappingDescriptor;
                });
            }
            Logger.Info(string.Format("Indice {0} creato", _defaultIndex.ToLowerInvariant()));
            return esClient;
        }
        public int IndicizzaDocumenti(IList<DocumentoElasticSearch> documents)
        {
            var esClient = GetEsClient();
            var documentiIndicizzati = 0;
            try
            {
                foreach (var documento in documents)
                {
                    var result = esClient.Index<DocumentoElasticSearch>(documento, i => i
                                    .Index(_defaultIndex)
                                    .Id(string.Format("{0}|{1}|{2}|{3}", documento.IdDocumento, documento.CodiceTabella, documento.Dal.ToString("yyyyMMdd"), documento.DataScadenza.ToString("yyyyMMdd")))
                                    .Refresh(Refresh.True));
                    if (result.IsValid)
                    {
                        documentiIndicizzati += 1;
                    }
                }
                return documentiIndicizzati;
            }
            catch (Exception ex)
            {
                Logger.Error("Errore durante l'aggiunta dei documenti all'indice", ex);
                throw ex;
            }
        }
        public bool AggiornaDocumenti(DocumentoElasticSearch documento)
        {
            var esClient = GetEsClient();
            var idDocument = string.Format("{0}|{1}|{2}|{3}", documento.IdDocumento, documento.CodiceTabella, documento.Dal.ToString("yyyyMMdd"), documento.DataScadenza.ToString("yyyyMMdd"));
            try
            {
                var res = esClient.Index<DocumentoElasticSearch>(documento, i => i
                                    .Index(_defaultIndex)
                                    .Id(idDocument)
                                    .Refresh(Refresh.True));
                return res.IsValid;
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("Errore durante indicizzazione documento {0}", documento.IdDocumento), ex);
            }
            return false;
        }
        public long EliminaDocumenti(string idDocumento)
        {
            var esClient = GetEsClient();
            try
            {
                var response = esClient.DeleteByQuery<DocumentoElasticSearch>(i => i.Query(q => q.Match(m => m.Field(f => f.IdDocumento).Query(idDocumento))).Index(_defaultIndex));
                return response.Deleted;
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("Errore durante cancellazione documento {0}", idDocumento), ex);
            }
            return 0;
        }
    }
}
