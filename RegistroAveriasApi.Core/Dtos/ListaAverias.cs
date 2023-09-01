using Newtonsoft.Json;
using RegistroAveriasApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Dtos
{
    public class ListaAverias
    {
        [Required]
        [JsonProperty("id")]
        public int id_averia { get; set; }
        [Required]
        [JsonProperty("descripcion")]
        public string? descripcion { get; set; }
        [Required]
        [JsonProperty("tipo_averia")]
        public TipoAveriaDto? tipo_averia { get; set; }

        [Required]
        [JsonProperty("operador")]
        public OperadorDto? Operador { get; set; }

        [Required]
        [JsonProperty("linea")]
        public LineaDto? Linea { get; set; }

        [Required]
        [JsonProperty("sub_linea")]
        public SubLineaDto? SubLinea { get; set; }

        [Required]
        [JsonProperty("criticidad")]
        public CriticidadDto? criticidad { get; set; }

        [Required]
        [JsonProperty("tipo_servicio")]
        public TipoServicioDto? tipoServicio { get; set; }

        [Required]
        [JsonProperty("placa")]
        public string? placa { get; set; }

        [Required]
        [JsonProperty("ficha_autobus")]
        public string? fichaAutobus { get; set; }

        [Required]
        [JsonProperty("conductor")]
        public ConductorDto? conductor { get; set; }

        [Required]
        [JsonProperty("parada")]
        public ParadaDto? parada { get; set; }

        [Required]
        [JsonProperty("estado")]
        public EstadoDto? estado { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_creacion { get; set; }

        public AdjuntoDto? adjuntos { get; set; }
    }
}
