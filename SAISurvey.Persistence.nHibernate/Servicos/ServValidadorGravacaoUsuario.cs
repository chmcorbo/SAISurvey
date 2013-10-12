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
    public class ServValidadorGravacaoUsuario : IServValidadorGravacaoUsuario
    {
        private RepositorioUsuario repositorioUsuario;
        
        public ServValidadorGravacaoUsuario()
        {
            repositorioUsuario = new RepositorioUsuario();
        }

        public ServValidadorGravacaoUsuario(RepositorioUsuario pRepositorioUsuario)
        {
            repositorioUsuario = pRepositorioUsuario;
        }

        public bool Execute(Usuario pUsuario)
        {
            if (String.IsNullOrEmpty(pUsuario.Login))
                throw new ExLoginNaoInformado("Login de usuário não encontrado.");

            if (String.IsNullOrEmpty(pUsuario.Senha))
                throw new ExSenhaNaoInformada("Senha não informada.");

            Usuario usuario = repositorioUsuario.ObterPorLogin(pUsuario.Login);

            if (usuario!=null && usuario.ID!=pUsuario.ID)
                throw new ExLoginExistenteUsuario("Login de usuário existente");

            return true;
        }
    }
}
