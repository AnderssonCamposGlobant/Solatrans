using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Dtos
{
    public class TipoAveriaDto
    {
        [Required]
        [JsonProperty("id")]
        public int IdTipoAveria { get; set; }
        [Required]
        [JsonProperty("titulo")]
        public string? nombre { get; set; }
    }
}
