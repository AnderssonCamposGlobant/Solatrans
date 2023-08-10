using RegistroAveriasApi.Core.Dtos;
using RegistroAveriasApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IReadOnlyList<usuarios>> GetAllAsync();
        Task<List<usuarios>> GetUsuarioByIdAsync(int id_empresa);
        Task<List<usuarios>> GetUsuarioByIdEstado(int id_estado);
        Task<List<usuarios>> GetUsuarioByIdNombres(string nombres);
        void AddUsuario(UsuariosDto usuarioRegistro);
        Task<int> updateUsuario(int id_usuario, UsuariosDto updateUsuario);
        Task<int> deleteUsuarioByIdAsync(int id_usuario);
        Task<int> DeleteUsuario(int id_usuario);
    }
}
