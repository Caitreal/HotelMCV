using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelMVC
{
    [MetadataType(typeof(CalificacionMetaData))]
    public partial class Calificacion
    {
    }
    public class CalificacionMetaData
    {
        [Required(ErrorMessage ="Campo requerido")]
        [Range(1,5,ErrorMessage ="Se califica de 1 a 5")]
        [Display(Name ="Valoración")]
        public int Valoracion { get; set; }
    }
}