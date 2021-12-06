
using System;
using System.Collections.Generic;

namespace FullTextElasticSearch.Server.Classes
{
    public class DocumentoElasticSearch
    {
        public string IdDocumento { get; set; }
        public string Descrizione { get; set; }
        public DateTime Dal { get; set; }
        public DateTime Al { get; set; }
        public int CodiceClasse { get; set; }
        public string DescrizioneClasse { get; set; }
        public string CodiceTipo { get; set; }
        public string CodiceTabella { get; set; }
        public string DescrizioneTipo { get; set; }
        public string CodiceSottotipo { get; set; }
        public string DescrizioneSottotipo { get; set; }
        public int Destinazione { get; set; }
        public string Testo { get; set; }
        public string Titolo { get; set; }
        public string Oggetto { get; set; }
        public string Comando { get; set; }
        public string Argomenti { get; set; }
        public DateTime? DataUltimaCompilazione { get; set; }
        public DateTime DataScadenza { get; set; }
        public decimal? Peso { get; set; }
        public ICollection<ArticoloElasticSearch> Articoli { get; set; }
    }
}
