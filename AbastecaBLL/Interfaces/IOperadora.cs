using AbastecaDTO;
using AbastecaDTO.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaBLL.Interfaces
{
    public interface IOperadora
    {
        Response Insert(OperadoraCreatDTO dto);
        Response List();
        Response GetByID(int id);
        Response Update(OperadoraUpdateDTO dto);
        Response Delete(int id);
    }
}
