using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaDTO
{
    public class Response
    {
        public bool Exito { get; set; }
        public string Mensagem { get; set; } = "Erro ao realizar operação";
        public object Objeto { get; set; }
        public Response Good(string msg, object obj = null)
        {
            Exito = true;
            Mensagem = msg;
            if (obj != null)
            {
                Objeto = obj;
            }
            return this;
        }
        public Response ErrorResponse(string msg)
        {
            Exito = false;
            Mensagem = msg;
            return this;

        }
        public Response Bad(string msg, object obj = null)
        {
            Exito = false;
            Mensagem = msg;
            if (obj != null)
            {
                Objeto = obj;
            }
            return this;
        }

        public Response Good(object obj)
        {
            Exito = true;
            Mensagem = "Operação realizada com exito";
            if (obj != null)
            {
                Objeto = obj;
            }
            return this;
        }

        public Response Bad(object obj)
        {
            Exito = false;
            if (obj != null)
            {
                Objeto = obj;
            }
            return this;
        }
    }
}
