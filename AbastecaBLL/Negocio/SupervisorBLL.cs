using AbastecaBLL.Helpers;
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
    public class SupervisorBLL:ISupervisor
    {
        private AbastecaContext context;
        private readonly ILogger<SupervisorBLL> logger;

        private Supervisor supervisor;

        public SupervisorBLL(AbastecaContext _context, ILogger<SupervisorBLL> _logger)
        {
            context = _context;
            logger = _logger;
        }

        public Response Insert(SupervisorDTO dto, int userId, int bombasId)
        {
            var res = new Response();
            supervisor = new Supervisor();

            try
            {
                supervisor.UsuarioID = userId;
                supervisor.BombaID = bombasId;

                context.Supervisors.Add(supervisor);
                context.SaveChanges();

                return res.Good(Recursos.MessagemSucesso.MS01);
            }
            catch (Exception e)
            {
                logger.LogError(e, Recursos.MessagemErro.ME01);
                return res.Bad(Recursos.MessagemErro.ME01);
            }
        }
        public Response GetByID(int id)
        {
            throw new NotImplementedException();
        }
        public Response List(int page, int take, string filtro = null)
        {
            var resposta = new Response();

            try
            {
                var lista = context.Supervisors
                .Include(x => x.Usuario)
                .AsNoTracking()
                .AsQueryable();

                lista = lista.Where(x => x.Usuario.Perfil == 1);

                var supervisores = lista.Select(x => new SupervisorDTO
                {
                    SupervisorID = x.SupervisorID,
                    Usuario = new UsuarioDTO
                    {
                        UsuarioID = x.Usuario.UsuarioID,
                        Nome = x.Usuario.Nome,
                        Telefone = x.Usuario.Telefone,
                        email = x.Usuario.email,
                        Estado = x.Usuario.Estado,
                        DataUltimoLogin = x.Usuario.DataUltimoLogin,
                        DataActualizacao = x.Usuario.DataActualizacao,
                        DataCadastro = x.Usuario.DataCadastro,
                    }
                }).OrderBy(x => x.Usuario.Nome).Paginar(page, take);

                return resposta.Good(supervisores);
            }
            catch(Exception e)
            {
                logger.LogError(e, Recursos.MessagemErro.ME04);
                return resposta.Bad(Recursos.MessagemErro.ME04);
            }
        }

        public Response Update(SupervisorDTO dto)
        {
            throw new NotImplementedException();
        }
        public Response Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
