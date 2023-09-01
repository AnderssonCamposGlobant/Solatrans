using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Dtos
{
    public class AdjuntoDto
    {
        [Required]
        [JsonProperty("id")]
        public int IdAdjunto { get; set; }

        [JsonProperty("nombre")]
        public string? Nombre { get; set; }
   
        [JsonProperty("file_b64")]
        public string? FileBase { get; set; }
    }
}
