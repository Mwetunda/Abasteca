using AbastecaBLL.Interfaces;
using AbastecaDAL.EFC;
using AbastecaDAL.Entidades;
using AbastecaDTO;
using AbastecaDTO.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaBLL.Negocio
{
    public class OperadoraBLL:IOperadora
    {
        private AbastecaContext context;
        private readonly ILogger<OperadoraBLL> logger;

        private Operadora operadora;

        public OperadoraBLL(AbastecaContext _context, ILogger<OperadoraBLL> _logger)
        {
            context = _context;
            logger = _logger;
        }
        public Response Insert(OperadoraCreatDTO dto)
        {
            var res = new Response();
            operadora = new Operadora();

            try
            {
                operadora.Nome = dto.Nome;

                context.Operadoras.Add(operadora);
                context.SaveChanges();

                return res.Good(Recursos.MessagemSucesso.MS01);
            }
            catch (Exception e)
            {
                logger.LogError(e, Recursos.MessagemErro.ME01);
                return res.Bad(Recursos.MessagemErro.ME01);
            }
        }

        public Response List()
        {
            var resposta = new Response();

            try
            {
                var lista = context.Operadoras.Include(x => x.Bombas).AsNoTracking().AsQueryable();

                var operadoras = lista.Select(x => new Operadora
                {
                    OperadoraID = x.OperadoraID,
                    Nome = x.Nome,
                }).OrderBy(x => x.Nome);

                return resposta.Good(operadoras);
            }
            catch (Exception e)
            {
                logger.LogError(e, Recursos.MessagemErro.ME04);
                return resposta.Bad(Recursos.MessagemErro.ME04);
            }
        }

        public Response GetByID(int id)
        {
            var res = new Response();

            try
            {
                var operadora = context.Operadoras.First(x => x.OperadoraID == id);

                if (operadora != null)
                {
                    return res.Good(operadora);
                }

                return res.Bad(Recursos.MessagemErro.ME05);
            }
            catch (Exception e)
            {
                logger.LogError(e, Recursos.MessagemErro.ME05);
                return res.Bad(Recursos.MessagemErro.ME05);
            }
        }

        public Response Update(OperadoraUpdateDTO dto)
        {
            var res = new Response();

            try
            {
                var operadora = context.Operadoras.FirstOrDefault(x => x.OperadoraID == dto.OperadoraID);

                if (operadora == null)
                {
                    return res.Bad("");
                }

                operadora.Nome = dto.Nome;

                context.Update(operadora);
                context.SaveChanges();

                return res.Good(Recursos.MessagemSucesso.MS02);
            }
            catch (Exception e)
            {
                logger.LogError(e, Recursos.MessagemErro.ME02);
                return res.Bad(Recursos.MessagemErro.ME02);
            }
        }

        public Response Delete(int id)
        {
            var res = new Response();

            try
            {
                var operadora = context.Operadoras.First(x => x.OperadoraID == id);

                if (operadora != null)
                {
                    context.Entry(operadora).State = EntityState.Deleted;

                    context.SaveChanges();

                    return res.Good(Recursos.MessagemSucesso.MS03);
                }

                return res.Bad(Recursos.MessagemErro.ME03);

            }
            catch (Exception e)
            {
                logger.LogError(e, Recursos.MessagemErro.ME03);
                return res.Bad(Recursos.MessagemErro.ME03);
            }
        }
    }
}
