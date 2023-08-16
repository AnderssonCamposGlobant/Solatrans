using RegistroAveriasApi.Core.Dtos;
using RegistroAveriasApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Interfaces
{
    public interface IRolRepository
    {
        Task<IReadOnlyList<roles>> GetAllAsync();
        Task<List<roles>> GetAsync(string nombres);
        Task<int> UpdateAsync(RolesDto role, int rolId);
        void AddRol(RolesDto roleRegistrado);
    }
}
