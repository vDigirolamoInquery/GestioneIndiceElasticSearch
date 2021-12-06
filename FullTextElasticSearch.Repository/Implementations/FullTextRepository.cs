using FullTextElasticSearch.EntityFramework;
using FullTextElasticSearch.Repository.Classes.Fulltext;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace FullTextElasticSearch.Repository.Implementations
{
    public class FullTextRepository
    {
        public IList<DocumentoDaIndicizzare> DocumentiDaIndicizzare(int skip, int take, int prodotto)
        {
            using (var context = new TAMONE_DOCEntities())
            {
                context.Database.CommandTimeout = 60 * 5;
                var documenti = context.spFullTextIndicizzaDocumenti(skip, take, prodotto).ToList();
                var esito = new ObjectParameter("esito", 0);
                var descrizioneEsito = new ObjectParameter("descrizioneEsito", string.Empty);
                var documentidaIndicizzare = new List<DocumentoDaIndicizzare>();
                foreach (var documento in documenti)
                {
                    var documentoDaIndicizzare = new DocumentoDaIndicizzare()
                    {
                        IdDocumento = documento.IdDocumento,
                        Al = documento.Al,
                        Articoli = new List<ArticoloDocumentoDaIndicizzare>(),
                        CodiceClasse = documento.CodiceClasse,
                        CodiceSottotipo = documento.CodiceSottotipo,
                        CodiceTabella = documento.CodiceTabella,
                        CodiceTipo = documento.CodiceTipo,
                        Dal = documento.Dal,
                        DataScadenza = documento.DataScadenza.Value,
                        DataUltimaCompilazione = documento.DataUltimaCompilazione,
                        Descrizione = documento.Descrizione,
                        DescrizioneClasse = documento.DescrizioneClasse,
                        DescrizioneSottotipo = documento.DescrizioneSottotipo,
                        DescrizioneTipo = documento.DescrizioneTipo,
                        Destinazione = documento.Destinazione,
                        Oggetto = documento.Oggetto,
                        Comando = documento.Comando,
                        Peso = documento.Peso,
                        Testo = documento.Testo,
                        Titolo = documento.Titolo
                    };
                    var tag = context.spFullTextTagDocumento(documento.IdDocumento, esito, descrizioneEsito).ToArray();
                    var articoli = context.spFullTextArticoliDocumento(documento.IdDocumento, esito, descrizioneEsito).ToList();

                    documentoDaIndicizzare.Tag = string.Join(" ", tag.Select(t => t));
                    documentoDaIndicizzare.Articoli = articoli.Select(a => new ArticoloDocumentoDaIndicizzare() { 
                        Nome = a.Nome,
                        Segnalibro = a.Segnalibro,
                        Testo = a.Nome + " " + a.Tag
                    }).ToList();

                    documentidaIndicizzare.Add(documentoDaIndicizzare);
                }
                return documentidaIndicizzare;
            }
        }

        public IList<DocumentoDaIndicizzare> ScadenzeDaIndicizzare(int skip, int take, int prodotto)
        {
            using (var context = new TAMONE_DOCEntities())
            {
                context.Database.CommandTimeout = 60 * 5;
                var documenti = context.spFullTextIndicizzaScadenze(skip, take, prodotto).ToList();
                var esito = new ObjectParameter("esito", 0);
                var descrizioneEsito = new ObjectParameter("descrizioneEsito", string.Empty);
                var documentidaIndicizzare = new List<DocumentoDaIndicizzare>();
                foreach (var documento in documenti)
                {
                    var documentoDaIndicizzare = new DocumentoDaIndicizzare()
                    {
                        IdDocumento = documento.IdDocumento,
                        Al = documento.Al,
                        Articoli = new List<ArticoloDocumentoDaIndicizzare>(),
                        CodiceClasse = documento.CodiceClasse,
                        CodiceSottotipo = documento.CodiceSottotipo,
                        CodiceTabella = documento.CodiceTabella,
                        CodiceTipo = documento.CodiceTipo,
                        Dal = documento.Dal,
                        DataScadenza = documento.DataScadenza.Value,
                        DataUltimaCompilazione = documento.DataUltimaCompilazione,
                        Descrizione = documento.Descrizione,
                        DescrizioneClasse = documento.DescrizioneClasse,
                        DescrizioneSottotipo = documento.DescrizioneSottotipo,
                        DescrizioneTipo = documento.DescrizioneTipo,
                        Destinazione = documento.Destinazione,
                        Oggetto = documento.Oggetto,
                        Comando = documento.Comando,
                        Peso = documento.Peso,
                        Testo = documento.Testo,
                        Titolo = documento.Titolo
                    };
                    var tag = context.spFullTextTagDocumento(documento.IdDocumento, esito, descrizioneEsito).ToArray();
                    var articoli = context.spFullTextArticoliDocumento(documento.IdDocumento, esito, descrizioneEsito).ToList();

                    documentoDaIndicizzare.Tag = string.Join(" ", tag.Select(t => t));
                    documentoDaIndicizzare.Articoli = articoli.Select(a => new ArticoloDocumentoDaIndicizzare()
                    {
                        Nome = a.Nome,
                        Segnalibro = a.Segnalibro,
                        Testo = a.Nome + " " + a.Tag
                    }).ToList();

                    documentidaIndicizzare.Add(documentoDaIndicizzare);
                }
                return documentidaIndicizzare;
            }
        }

        public IList<DocumentoDaIndicizzare> DocumentoDaAggiornare(string idDocumento)
        {
            using (var context = new TAMONE_DOCEntities())
            {
                context.Database.CommandTimeout = 60 * 5;
                var esito = new ObjectParameter("esito", 0);
                var descrizioneEsito = new ObjectParameter("descrizioneEsito", string.Empty);
                var documenti = context.spFullTextApriDocumento(idDocumento, esito, descrizioneEsito).ToList();
                var documentidaIndicizzare = new List<DocumentoDaIndicizzare>();
                foreach (var documento in documenti)
                {
                    var documentoDaIndicizzare = new DocumentoDaIndicizzare()
                    {
                        IdDocumento = documento.IdDocumento,
                        Al = documento.Al,
                        Articoli = new List<ArticoloDocumentoDaIndicizzare>(),
                        CodiceClasse = documento.CodiceClasse,
                        CodiceSottotipo = documento.CodiceSottotipo,
                        CodiceTabella = documento.CodiceTabella,
                        CodiceTipo = documento.CodiceTipo,
                        Dal = documento.Dal,
                        DataUltimaCompilazione = documento.DataUltimaCompilazione,
                        DataScadenza = documento.DataScadenza,
                        Descrizione = documento.Descrizione,
                        DescrizioneClasse = documento.DescrizioneClasse,
                        DescrizioneSottotipo = documento.DescrizioneSottotipo,
                        DescrizioneTipo = documento.DescrizioneTipo,
                        Destinazione = documento.Destinazione,
                        Oggetto = documento.Oggetto,
                        Comando = documento.Comando,
                        Peso = documento.Peso,
                        Testo = documento.Testo,
                        Titolo = documento.Titolo
                    };
                    var tag = context.spFullTextTagDocumento(documento.IdDocumento, esito, descrizioneEsito).ToArray();
                    var articoli = context.spFullTextArticoliDocumento(documento.IdDocumento, esito, descrizioneEsito).ToList();

                    documentoDaIndicizzare.Tag = string.Join(" ", tag.Select(t => t));
                    documentoDaIndicizzare.Articoli = articoli.Select(a => new ArticoloDocumentoDaIndicizzare()
                    {
                        Nome = a.Nome,
                        Segnalibro = a.Segnalibro,
                        Testo = a.Nome + " " + a.Tag
                    }).ToList();
                    documentidaIndicizzare.Add(documentoDaIndicizzare);
                }
                return documentidaIndicizzare;
            }
        }
        
        public int? ContaDocumentiDaIndicizzare(bool seScadenzario, int prodotto)
        {
            using (var context = new TAMONE_DOCEntities())
            {
                if (seScadenzario)
                {
                    return context.spFullTextIndicizzaScadenzeTotale(prodotto).FirstOrDefault();
                }
                return context.spFullTextIndicizzaDocumentiTotale(prodotto).FirstOrDefault();
            }
        }
    }
}
