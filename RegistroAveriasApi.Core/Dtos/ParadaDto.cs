using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Dtos
{
    public class ParadaDto
    {
        [Required]
        [JsonProperty("id")]
        public int IdParada { get; set; }
        [Required]
        [JsonProperty("titulo")]
        public string? nombreParada { get; set; }
    }
}
