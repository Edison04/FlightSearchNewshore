//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlightSearhcNewshore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Flight
    {
        public long Id { get; set; }
        public string DepartureStation { get; set; }
        public string ArribalStation { get; set; }
        public System.DateTime DepartureDate { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Currency { get; set; }
        public long IdTransport { get; set; }
    
        public virtual Transport Transport { get; set; }

        
    }
}
