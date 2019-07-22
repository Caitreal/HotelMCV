using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelMVC
{
    [MetadataType(typeof(ReservaMetaData))]

    public partial class Reserva
    {
    }

    public class ReservaMetaData
    {
        [Required(ErrorMessage = "Campo Requerido.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Campo Requerido.")]
        [Display(Name = "Fecha Inicio")]
        public System.DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "Campo Requerido.")]
        [Display(Name = "Cantidad de Noches")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Debe ser mayor a 1")]
        public int NumeroNoches { get; set; }

        [Required(ErrorMessage = "Campo Requerido.")]
        [Range(1,Int32.MaxValue, ErrorMessage = "Debe ser mayor a 1")]
        [Display(Name = "Cantidad de Personas")]
        public int CantidadPersonas { get; set; }
    }

}