using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Entities
{
    public class tipo_servicio
    {
        [Key]
        public int id_tipo_servicio { get; set; }
        public string? nombre { get; set; }
        public bool activo { get; set; }  
        public DateTime fecha_desactivacion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_ultima_modificacion { get; set; }
        public string? creado_por { get; set; }
        public string? modificado_por { get; set; }
    }
}
