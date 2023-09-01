using RegistroAveriasApi.Core.Dtos;
using RegistroAveriasApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Interfaces
{
    public interface IAveriaRepository
    {
        Task<IReadOnlyList<ListaAverias>> GetAllAsync();
        Task<AveriaDetalle> GetAveriaByIdAsync(int id_averia);
        void addAveria(CreateAveriasRequest averiaRegistro);

        ////void updateAveria(UpdateAveriaDto updateAveriaDto);
        Task<int> deleteAveria(int id_averia);
    }
}
