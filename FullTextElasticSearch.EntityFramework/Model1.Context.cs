//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FullTextElasticSearch.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TAMONE_DOCEntities : DbContext
    {
        public TAMONE_DOCEntities()
            : base("name=TAMONE_DOCEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<spFullTextApriDocumento_Result> spFullTextApriDocumento(string idDocumento, ObjectParameter esito, ObjectParameter descrizioneEsito)
        {
            var idDocumentoParameter = idDocumento != null ?
                new ObjectParameter("idDocumento", idDocumento) :
                new ObjectParameter("idDocumento", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spFullTextApriDocumento_Result>("spFullTextApriDocumento", idDocumentoParameter, esito, descrizioneEsito);
        }
    
        public virtual ObjectResult<spFullTextArticoliDocumento_Result> spFullTextArticoliDocumento(string idDocumento, ObjectParameter esito, ObjectParameter descrizioneEsito)
        {
            var idDocumentoParameter = idDocumento != null ?
                new ObjectParameter("idDocumento", idDocumento) :
                new ObjectParameter("idDocumento", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spFullTextArticoliDocumento_Result>("spFullTextArticoliDocumento", idDocumentoParameter, esito, descrizioneEsito);
        }
    
        public virtual ObjectResult<string> spFullTextTagDocumento(string idDocumento, ObjectParameter esito, ObjectParameter descrizioneEsito)
        {
            var idDocumentoParameter = idDocumento != null ?
                new ObjectParameter("idDocumento", idDocumento) :
                new ObjectParameter("idDocumento", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("spFullTextTagDocumento", idDocumentoParameter, esito, descrizioneEsito);
        }
    
        public virtual ObjectResult<spFullTextIndicizzaDocumenti_Result> spFullTextIndicizzaDocumenti(Nullable<int> indicePagina, Nullable<int> grandezzaPagina, Nullable<int> destinazione)
        {
            var indicePaginaParameter = indicePagina.HasValue ?
                new ObjectParameter("indicePagina", indicePagina) :
                new ObjectParameter("indicePagina", typeof(int));
    
            var grandezzaPaginaParameter = grandezzaPagina.HasValue ?
                new ObjectParameter("grandezzaPagina", grandezzaPagina) :
                new ObjectParameter("grandezzaPagina", typeof(int));
    
            var destinazioneParameter = destinazione.HasValue ?
                new ObjectParameter("destinazione", destinazione) :
                new ObjectParameter("destinazione", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spFullTextIndicizzaDocumenti_Result>("spFullTextIndicizzaDocumenti", indicePaginaParameter, grandezzaPaginaParameter, destinazioneParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> spFullTextIndicizzaDocumentiTotale(Nullable<int> destinazione)
        {
            var destinazioneParameter = destinazione.HasValue ?
                new ObjectParameter("destinazione", destinazione) :
                new ObjectParameter("destinazione", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spFullTextIndicizzaDocumentiTotale", destinazioneParameter);
        }
    
        public virtual ObjectResult<spFullTextIndicizzaScadenze_Result> spFullTextIndicizzaScadenze(Nullable<int> indicePagina, Nullable<int> grandezzaPagina, Nullable<int> destinazione)
        {
            var indicePaginaParameter = indicePagina.HasValue ?
                new ObjectParameter("indicePagina", indicePagina) :
                new ObjectParameter("indicePagina", typeof(int));
    
            var grandezzaPaginaParameter = grandezzaPagina.HasValue ?
                new ObjectParameter("grandezzaPagina", grandezzaPagina) :
                new ObjectParameter("grandezzaPagina", typeof(int));
    
            var destinazioneParameter = destinazione.HasValue ?
                new ObjectParameter("destinazione", destinazione) :
                new ObjectParameter("destinazione", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spFullTextIndicizzaScadenze_Result>("spFullTextIndicizzaScadenze", indicePaginaParameter, grandezzaPaginaParameter, destinazioneParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> spFullTextIndicizzaScadenzeTotale(Nullable<int> destinazione)
        {
            var destinazioneParameter = destinazione.HasValue ?
                new ObjectParameter("destinazione", destinazione) :
                new ObjectParameter("destinazione", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spFullTextIndicizzaScadenzeTotale", destinazioneParameter);
        }
    }
}
