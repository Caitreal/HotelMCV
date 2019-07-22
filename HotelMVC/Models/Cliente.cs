using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelMVC
{ 
    [MetadataType(typeof(ClienteMetaData))]

    public partial class Cliente
    {
    }
    public class ClienteMetaData
    {
        [Required(ErrorMessage = "Campo requerido")]
        public string Rut { get; set; }

    }
}