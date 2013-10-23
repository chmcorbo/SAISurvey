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
                throw new ExUsuarioNaoEncontrado();

            if (usuario.Senha != pSenha)
                throw new ExSenhaUsuarioInvalida();

            if (usuario.Administrador == "N")
                throw new ExUsuarioNaoAdministrador();

            return usuario;
        }
    }
}
