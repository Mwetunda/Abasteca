using AbastecaDTO;
using AbastecaDTO.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaBLL.Interfaces
{
    public interface IUsuario
    {
        Response Insert(UsuarioDTOcriar dto);
        Response List(int page, int take, string filtro = null);
        Response GetByID(Guid id);
        Response Update(UsuarioUpdateDTO dto);
        Response Delete(Guid id);

        Response Login(UsuarioDTOlogin dto, string secret);
        Response UpdatePassword(string Registrationkey, string newPassword);
        Response RequestRecoveryPassword(string email);
    }
}
