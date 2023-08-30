using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Entities
{
    public class fichas
    {
        [Key]
        public int id_ficha { get; set; }
        public string? descripcion { get; set; }
        public bool activo { get; set; } 
    }
}
