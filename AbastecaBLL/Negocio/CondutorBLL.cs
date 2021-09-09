using AbastecaBLL.Interfaces;
using AbastecaDTO;
using AbastecaDTO.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaBLL.Negocio
{
    public class CondutorBLL:ICondutor
    {
        public Response Insert(CondutorDTO dto, int userId)
        {
            throw new NotImplementedException();
        }
        public Response GetByID(int id)
        {
            throw new NotImplementedException();
        }
        public Response List(int page, int take, string filtro = null)
        {
            throw new NotImplementedException();
        }

        public Response Update(CondutorDTO dto)
        {
            throw new NotImplementedException();
        }
        public Response Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
