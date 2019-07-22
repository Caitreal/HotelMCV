using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelMVC
{
    [MetadataType(typeof(TipoHabitacionMetaData))]
    public partial class TipoHabitacion
    {
    }
    public class TipoHabitacionMetaData
    {

        [Required(ErrorMessage = "Campo Requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo Requerido.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "debe ser mayor a 1")]
        [Display(Name = "Cantidad de Personas")]
        public int CantidadPersonas { get; set; }
    }
}