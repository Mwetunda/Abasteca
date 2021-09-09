using AbastecaBLL.Helpers;
using AbastecaBLL.Interfaces;
using AbastecaDAL.EFC;
using AbastecaDAL.Entidades;
using AbastecaDTO;
using AbastecaDTO.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaBLL.Negocio
{
    public class UsuarioBLL : IUsuario
    {
        private AbastecaContext context;
        private readonly ILogger<UsuarioBLL> logger;

        private Usuario usuario;

        public UsuarioBLL(AbastecaContext _context, ILogger<UsuarioBLL> _logger)
        {
            context = _context;
            logger = _logger;
        }
        public Response Insert(UsuarioDTOcriar dto)
        {
            var res = new Response();
            usuario = new Usuario();

            try
            {
                usuario.UsuarioID = Guid.NewGuid();
                usuario.Nome = dto.Nome;
                usuario.Telefone = dto.Telefone;
                usuario.email = dto.email;
                usuario.DataCadastro = DateTime.Now;
                usuario.DataActualizacao = DateTime.Now;
                usuario.DataUltimoLogin = DateTime.Now;
                usuario.DataUltimoLogin = DateTime.Now;
                usuario.Senha = dto.Senha.ToSha512Hash();
                usuario.Estado = true;
                usuario.Perfil = dto.Perfil;

                context.Usuarios.Add(usuario);
                context.SaveChanges();

                return res.Good(Recursos.MessagemSucesso.MS01);
            }
            catch (Exception e)
            {
                logger.LogError(e, Recursos.MessagemErro.ME01);
                return res.Bad(Recursos.MessagemErro.ME01);
            }
        }

        public Response List(int page, int take, string filtro = null)
        {
            var resposta = new Response();

            try
            {
                var lista = context.Usuarios.AsNoTracking().AsQueryable();

                var usuarios = lista.Select(x => new UsuarioDTO
                {
                    UsuarioID = x.UsuarioID,
                    Nome = x.Nome,
                    Telefone = x.Telefone,
                    email = x.email,
                    Estado = x.Estado,
                    DataUltimoLogin = x.DataUltimoLogin,
                    DataActualizacao = x.DataActualizacao,
                    DataCadastro = x.DataCadastro,
                    Perfil = x.Perfil

                }).OrderBy(x => x.Nome).Paginar(page, take);

                return resposta.Good(usuarios);
            }
            catch (Exception e)
            {
                logger.LogError(e, Recursos.MessagemErro.ME04);
                return resposta.Bad(Recursos.MessagemErro.ME04);
            }
        }

        public Response GetByID(Guid id)
        {
            var res = new Response();

            try
            {
                var usuario = context.Usuarios.First(x => x.UsuarioID == id);

                if (usuario != null)
                {
                    return res.Good(usuario);
                }

                return res.Bad(Recursos.MessagemErro.ME05);
            }
            catch (Exception e)
            {
                logger.LogError(e, Recursos.MessagemErro.ME05);
                return res.Bad(Recursos.MessagemErro.ME05);
            }
        }

        public Response Update(UsuarioUpdateDTO dto)
        {
            var res = new Response();

            try
            {
                var usuario = context.Usuarios.FirstOrDefault(x => x.UsuarioID == dto.UsuarioID);

                if (usuario == null)
                {
                    return res.Bad("");
                }

                usuario.Nome = dto.Nome;
                usuario.Telefone = dto.Telefone;
                usuario.email = dto.email;
                usuario.DataActualizacao = DateTime.Now;

                context.Update(usuario);
                context.SaveChanges();

                return res.Good(Recursos.MessagemSucesso.MS02);
            }
            catch (Exception e)
            {
                logger.LogError(e, Recursos.MessagemErro.ME02);
                return res.Bad(Recursos.MessagemErro.ME02);
            }
        }

        public Response Delete(Guid id)
        {
            var res = new Response();

            try
            {
                var usuario = context.Usuarios.First(x => x.UsuarioID == id);

                if (usuario != null)
                {
                    context.Entry(usuario).State = EntityState.Deleted;

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

        public Response Login(UsuarioDTOlogin dto, string secret)
        {
            var res = new Response();

            try
            {
                var criptoPass = dto.Senha.ToSha512Hash();

                var usuario = context.Usuarios.FirstOrDefault(x => x.Telefone == dto.Telefone && x.Senha == criptoPass);


                if (usuario == null)
                {
                    return res.Bad(Recursos.MessagemErro.ME06);
                }

                if (!usuario.Estado)
                {
                    return res.Bad(Recursos.MessagemErro.ME07);
                }
                    
                usuario.DataUltimoLogin = DateTime.Now;

                var token = GenerateJwtToken(usuario.UsuarioID, secret);

                context.Update(usuario);
                context.SaveChanges();

                return res.Good(Recursos.MessagemSucesso.MS06, token);
            }
            catch (Exception e)
            {
                logger.LogCritical(e, Recursos.MessagemErro.ME08);
                return res.Bad(Recursos.MessagemErro.ME08);
            }
        }

        public Response RequestRecoveryPassword(string email)
        {
            throw new NotImplementedException();
        }

        public Response UpdatePassword(string Registrationkey, string newPassword)
        {
            throw new NotImplementedException();
        }

        private string GenerateJwtToken(Guid idUsuario, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, idUsuario.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, idUsuario.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
