using System;
using System.Collections.Generic;

namespace FullTextElasticSearch.Repository.Classes.Fulltext
{
    public class DocumentoDaIndicizzare
    {
        public string IdDocumento { get; set; }
        public string Descrizione { get; set; }
        public Nullable<System.DateTime> Dal { get; set; }
        public Nullable<System.DateTime> Al { get; set; }
        public Nullable<int> CodiceClasse { get; set; }
        public string DescrizioneClasse { get; set; }
        public string CodiceTabella { get; set; }
        public string CodiceTipo { get; set; }
        public string DescrizioneTipo { get; set; }
        public string CodiceSottotipo { get; set; }
        public string DescrizioneSottotipo { get; set; }
        public Nullable<int> Destinazione { get; set; }
        public string Testo { get; set; }
        public string Titolo { get; set; }
        public string Oggetto { get; set; }
        public string Comando { get; set; }
        public DateTime DataScadenza { get; set; }
        public Nullable<System.DateTime> DataUltimaCompilazione { get; set; }
        public Nullable<decimal> Peso { get; set; }
        public ICollection<ArticoloDocumentoDaIndicizzare> Articoli { get; set; }
        public string Tag { get; set; }
    }
}
