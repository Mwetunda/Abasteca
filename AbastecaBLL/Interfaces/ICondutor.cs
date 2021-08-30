using AbastecaDTO;
using AbastecaDTO.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaBLL.Interfaces
{
    public interface ICondutor
    {
        Response Insert(CondutorDTO dto, int UserId);
        Response List(int page, int take, string filtro = null);
        Response GetByID(int id);
        Response Update(CondutorDTO dto);
        Response Delete(int id);
    }
}
