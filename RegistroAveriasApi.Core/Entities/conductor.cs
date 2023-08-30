using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Entities
{
    public class conductor
    {
        [Key]
        public int id_conductor { get; set; }
        public string? codigo_conductor_origen { get; set; }
        public string? nombre_conductor { get; set; }
        public string? apellidos_conductor { get; set; }
        public int? id_empresa { get; set; }
        public bool activo { get; set; }    
        public DateTime fecha_desactivacion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_ultima_modificacion { get; set; }
        public string? creado_por { get; set; }
        public string? modificado_por { get; set; }
        public bool? flag_pruebas { get; set; }
    }
}
