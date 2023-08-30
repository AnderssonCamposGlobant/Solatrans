using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Entities
{
    public class empresa
    {
        [Key]
        public int id_empresa { get; set; }
        public string? nombre_empresa { get; set; }
        public string? descripcion_empresa { get; set; }
        public string? codigo_empresa_origen { get; set; }
        public string? codigo_concesion_origen { get; set; }
        public int? cabecera { get; set; }
        public bool activo { get; set; }    
        public DateTime fecha_desactivacion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_ultima_modificacion { get; set; }
        public string creado_por { get; set; }
        public string modificado_por { get; set; }
        public string? url_seguimiento { get; set; }
    }
}
