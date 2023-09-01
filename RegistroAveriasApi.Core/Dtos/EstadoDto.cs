using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Dtos
{
    public class EstadoDto
    {
        [Required]
        [JsonProperty("id")]
        public int IdEstado { get; set; }
        [Required]
        [JsonProperty("titulo")]
        public string? Nombre { get; set; }
    }
}
