using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Dtos
{
    public class ConductorDto
    {
        [Required]
        [JsonProperty("id")]
        public int id_conductor { get; set; }
        [Required]
        [JsonProperty("titulo")]
        public string? nombre_conductor { get; set; }
    }
}
