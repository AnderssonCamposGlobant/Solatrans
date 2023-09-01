using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Dtos
{
    public class LineaDto
    {
        [Required]
        [JsonProperty("id")]
        public int IdLinea { get; set; }
        [Required]
        [JsonProperty("titulo")]
        public string? DescripcionLinea { get; set; }
    }
}
