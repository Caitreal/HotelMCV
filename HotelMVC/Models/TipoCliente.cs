using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelMVC
{
    [MetadataType(typeof(TipoClienteMetaData))]
    public partial class TipoCliente
    {

    }
    public class TipoClienteMetaData
    {
        [Required(ErrorMessage = "Campo Requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo Requerido.")]
        public int Descuento { get; set; }
    }
}