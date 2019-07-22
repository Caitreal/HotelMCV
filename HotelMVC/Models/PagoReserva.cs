using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelMVC
{
    [MetadataType(typeof(PagoReservaMetaData))]
    public partial class PagoReserva
    {

    }
    public class PagoReservaMetaData
    {
        [Required(ErrorMessage = "Campo Requerido.")]
        public int Pago { get; set; }

        [Required(ErrorMessage = "Campo Requerido.")]
        public DateTime FechaPago { get; set; }
    }
}