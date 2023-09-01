using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Dtos
{
    public class OperadorDto
    {
        [Required]
        [JsonProperty("id")]
        public int IdEmpresa { get; set; }
        [Required]
        [JsonProperty("titulo")]
        public string? nombreEmpresa { get; set; }
    }
}
