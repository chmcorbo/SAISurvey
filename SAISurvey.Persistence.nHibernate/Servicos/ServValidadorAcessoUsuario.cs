using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Servicos;
using SAISurvey.Dominio.Excecoes;
using SAISurvey.Persistence.nHibernate.Repositorios;

namespace SAISurvey.Persistence.nHibernate.Servicos
{
    public class ServValidadorAcessoUsuario : IServValidadorAcessoUsuario
    {
        public Usuario Execute(string pLogin, String pSenha)
        {
            RepositorioUsuario repositorio = new RepositorioUsuario();
            Usuario usuario = repositorio.ObterPorLogin(pLogin);
            if (usuario == null)
                throw new ExUsuarioNaoEncontrado("Login de usuário não encontrado");

            if (usuario.Senha != pSenha)
                throw new ExSenhaUsuarioInvalida("Senha informada inválida");

            if (usuario.Administrador == "N")
                throw new ExUsuarioNaoAdministrador("O usuário não é um administrador");

            return usuario;
        }
    }
}
