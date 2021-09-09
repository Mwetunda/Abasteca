using AbastecaDTO;
using AbastecaDTO.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaBLL.Interfaces
{
    public interface IProvincia
    {
        Response Insert(ProvinciaCreatDTO dto);
        Response List();
        Response GetByID(int id);
        Response Update(ProvinciaUpdateDTO dto);
        Response Delete(int id);
    }
}
