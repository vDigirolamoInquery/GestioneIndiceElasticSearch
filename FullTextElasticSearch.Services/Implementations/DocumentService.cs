using FullTextElasticSearch.Log4Net;
using FullTextElasticSearch.Repository.Classes.Fulltext;
using FullTextElasticSearch.Repository.Implementations;
using FullTextElasticSearch.Server;
using FullTextElasticSearch.Server.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FullTextElasticSearch.Services.Implementations
{
    public class DocumentService
    {
        private readonly FullTextRepository _documentRepository = new FullTextRepository();
        private readonly ConnectionToEs _connectionToEs = new ConnectionToEs();
        private readonly Logger<DocumentService> Logger = new Logger<DocumentService>();

        public bool CreaNuovoIndice()
        {
            try
            {
                Logger.Info("Creazione indice in corso...");
                _connectionToEs.CreateIndex();
                Logger.Info("Indice creato correttamente");
                return true;
            }
            catch (System.Exception ex)
            {
                Logger.Error("Errore durante la creazione dell'indice", ex);
                throw ex;
            }
        }
        public bool IndicizzaDocumenti(int prodotto)
        {
            try
            {
                var pageIndex = 0;
                var pageSize = 500;
                var totals = _documentRepository.ContaDocumentiDaIndicizzare(false, prodotto).Value;
                Logger.Info(string.Format("Totale documenti da indicizzare: {0}", totals));
                var pages = (decimal)totals / (decimal)pageSize;
                var pageCount = Math.Ceiling(pages);
                Logger.Info(string.Format("Pagine calcolate -> grandezza pagina: 500; numero pagine: {0}; ", pageCount));
                while (pageIndex < pageCount)
                {
                    var documentiDaIndicizzare = _documentRepository.DocumentiDaIndicizzare((pageIndex++) * pageSize, pageSize, prodotto);
                    Logger.Info(string.Format("Pagina {0} di {1}. Documenti da indicizzare: {2}", pageIndex, pageCount, documentiDaIndicizzare.Count));
                    var documentiElasticSearch = new List<DocumentoElasticSearch>();
                    foreach (var documento in documentiDaIndicizzare)
                    {
                        documentiElasticSearch.Add(ConversioneDocumentoElasticSearch(documento));
                    }
                    var documentiIndicizzati = _connectionToEs.IndicizzaDocumenti(documentiElasticSearch);
                    Logger.Info(string.Format("Documenti indicizzati: {0}", documentiIndicizzati));
                }
                return true;
            }
            catch (System.Exception ex)
            {
                Logger.Error("Errore durante l'indicizzazione dei documenti", ex);
                throw ex;
            }
        }

        public bool IndicizzaScadenze(int prodotto)
        {
            try
            {
                var pageIndex = 0;
                var pageSize = 500;
                var totals = _documentRepository.ContaDocumentiDaIndicizzare(true, prodotto).Value;
                Logger.Info(string.Format("Totale scadenze da indicizzare: {0}", totals));
                var pages = (decimal)totals / (decimal)pageSize;
                var pageCount = Math.Ceiling(pages);
                Logger.Info(string.Format("Pagine calcolate -> grandezza pagina: 500; numero pagine: {0}; ", pageCount));
                while (pageIndex < pageCount)
                {
                    var scadenzeDaIndicizzare = _documentRepository.ScadenzeDaIndicizzare((pageIndex++) * pageSize, pageSize, prodotto);
                    Logger.Info(string.Format("Pagina {0} di {1}. Scadenze da indicizzare: {2}", pageIndex, pageCount, scadenzeDaIndicizzare.Count));
                    var documentiElasticSearch = new List<DocumentoElasticSearch>();
                    foreach (var scadenza in scadenzeDaIndicizzare)
                    {
                        documentiElasticSearch.Add(ConversioneDocumentoElasticSearch(scadenza));
                    }
                    var documentiIndicizzati = _connectionToEs.IndicizzaDocumenti(documentiElasticSearch);
                    Logger.Info(string.Format("Scadenze indicizzate: {0}", documentiIndicizzati));
                }
                return true;
            }
            catch (System.Exception ex)
            {
                Logger.Error("Errore durante l'indicizzazione delle scadenze", ex);
                throw ex;
            }
        }

        public bool AggiornaDocumento(string idDocumento)
        {
            try
            {
                var documentiDaAggiornare = _documentRepository.DocumentoDaAggiornare(idDocumento);
                if (!documentiDaAggiornare.Any())
                {
                    Logger.Info(string.Format("Nessun documento da modificare/cancellare con idDocumento {0}", idDocumento));
                    return false;
                }
                EliminaDocumento(idDocumento);
                foreach (var documento in documentiDaAggiornare)
                {
                    Logger.Info(string.Format("Documento da modificare: {0} -> {1}>{2}>{3}", documento.Titolo, documento.DescrizioneClasse, documento.DescrizioneTipo, documento.DescrizioneSottotipo));
                    var esito = _connectionToEs.AggiornaDocumenti(ConversioneDocumentoElasticSearch(documento));
                    if (esito)
                    {
                        Logger.Info("Documento modificato con successo");
                    }
                    else
                    {
                        Logger.Info("Documento non modificato");
                    }
                }
                return true;
            }
            catch (System.Exception ex)
            {
                Logger.Error("Errore durante l'aggiornamento dei documenti", ex);
                throw ex;
            }
        }
        public bool EliminaDocumento(string idDocumento)
        {
            try
            {
                Logger.Info(string.Format("Id documento da eliminare: {0}", idDocumento));
                var count = _connectionToEs.EliminaDocumenti(idDocumento);
                Logger.Info(string.Format("Documenti eliminati: {0}", count));
                return true;
            }
            catch (System.Exception ex)
            {
                Logger.Error("Errore durante l'aggiornamento dei documenti", ex);
                throw ex;
            }
        }
        public static DocumentoElasticSearch ConversioneDocumentoElasticSearch(DocumentoDaIndicizzare documentoFullText)
        {
            return new DocumentoElasticSearch()
            {
                IdDocumento = documentoFullText.IdDocumento,
                CodiceClasse = documentoFullText.CodiceClasse.Value,
                DescrizioneClasse = documentoFullText.DescrizioneClasse,
                Destinazione = documentoFullText.Destinazione.Value,
                CodiceSottotipo = documentoFullText.CodiceSottotipo,
                DescrizioneSottotipo = documentoFullText.DescrizioneSottotipo,
                CodiceTabella = documentoFullText.CodiceTabella,
                Al = documentoFullText.Al.Value,
                Dal = documentoFullText.Dal.Value,
                CodiceTipo = documentoFullText.CodiceTipo,
                DescrizioneTipo = documentoFullText.DescrizioneTipo,
                Oggetto = documentoFullText.Oggetto,
                Testo = documentoFullText.Testo,
                Descrizione = documentoFullText.Descrizione,
                Titolo = documentoFullText.Titolo,
                Argomenti = documentoFullText.Tag,
                DataUltimaCompilazione = documentoFullText.DataUltimaCompilazione,
                Peso = documentoFullText.Peso,
                Comando = documentoFullText.Comando,
                DataScadenza = documentoFullText.DataScadenza,
                Articoli = documentoFullText.Articoli.Select(a => new ArticoloElasticSearch()
                {
                    Nome = a.Nome,
                    Segnalibro = a.Segnalibro,
                    Testo = a.Testo
                }).ToList()
            };
        }
    }
}




















































