using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Entities
{
    public class seguimiento
    {
        [Key]
        public int id_seguimieto { get; set; }
        public int id_averia { get; set; }
        public int id_criticidad { get; set; }
        public int id_estado { get; set; }
        public string? observacion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public string? creado_por { get; set; }
    }
}
