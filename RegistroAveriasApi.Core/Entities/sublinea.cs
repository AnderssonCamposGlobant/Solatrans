using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Entities
{
    public class sublinea
    {
        [Key]
        public int id_sublinea { get; set; }
        public int id_linea { get; set; }
        public int codigo_sublinea { get; set; }
        public string? nombre_sublinea { get; set; }
        public double kilometros { get; set; }
        public int? id_empresa { get; set; }
        public bool activo { get; set; }    
        public DateTime fecha_desactivacion { get; set; }
        public DateTime fecha_ultima_modificacion { get; set; }
    }
}
