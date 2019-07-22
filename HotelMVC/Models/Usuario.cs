using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelMVC
{
    [MetadataType(typeof(UsuarioMetaData))]
    public partial class Usuario
    {

    }
    public class UsuarioMetaData
    {
        [Required (ErrorMessage = "Campo Requerido.")]
        [Display (Name = "Nombre de Usuario")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Campo Requerido.")]
        public string Clave { get; set; }

    }
}