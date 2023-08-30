using RegistroAveriasApi.Core.Dtos;
using RegistroAveriasApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Interfaces
{
    public interface IEstadoAveriasRepository
    {
        Task<IReadOnlyList<estado>> GetAllAsync();
        Task<estado> GetEstadoAveriaByIdAsync(int codigo);
        void  addEstadoAveria(CreateEstadoAveriaDto estadoAveria);
        void  update(int codigo, EstadoAveriaUpdateDto estadoAveria);
        Task<int> deleteEstadoAveria(int codigo);
    }
}
