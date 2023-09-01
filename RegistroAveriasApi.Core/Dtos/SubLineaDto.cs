using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Dtos
{
    public class SubLineaDto
    {
        [Required]
        [JsonProperty("id")]
        public int IdSubLinea { get; set; }
        [Required]
        [JsonProperty("titulo")]
        public string? DescripcionSubLinea { get; set; }
    }
}
