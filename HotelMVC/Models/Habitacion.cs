using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelMVC
{
    [MetadataType(typeof(HabitacionMetaData))]
    public partial class Habitacion
    {
    }

    public class HabitacionMetaData
    {
        [Required(ErrorMessage = "Precio Requerido.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Debe ser mayor a $1")]
        public int Precio { get; set; }

        [Required(ErrorMessage = "Campo Requerido.")]
        [StringLength(5, ErrorMessage = "Descripcion minimo 5 carácteres")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Tipo de Habitacion")]
        public Nullable<int> TipoHabitacionId { get; set; }
    }
}