using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Dtos
{
    public class SeguimientoDto
    {
        [Required]
        [JsonProperty("id")]
        public int id_seguimieto { get; set; }
        [JsonProperty("estado")]
        public EstadoDto? Estado { get; set; }
        [JsonProperty("observacion")]
        public string? Observacion { get; set; }
        [JsonProperty("fecha")]
        public DateTime fecha_creacion { get; set; }
        [JsonProperty("usuario")]
        public string? creado_por { get; set; }
    }
}
