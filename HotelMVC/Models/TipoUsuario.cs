using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelMVC
{ 
    [MetadataType(typeof(TipoUsuarioMetaData))]
    public partial class TipoUsuario
    {
    }
    public class TipoUsuarioMetaData
    {
        [Required(ErrorMessage = "Campo Requerido.")]
        public string Nombre { get; set; }
    }
}