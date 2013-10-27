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
    public class ServValidadorConsistenciaUsuario : IServValidadorConsistenciaUsuario
    {
        private ConectionManager _conexao;
        private RepositorioUsuario _repositorioUsuario;
        
        public ServValidadorConsistenciaUsuario(ConectionManager pConexao)
        {
            _conexao = pConexao;
            _repositorioUsuario = new RepositorioUsuario(_conexao);
        }

        public ServValidadorConsistenciaUsuario(ConectionManager pConexao, RepositorioUsuario pRepositorioUsuario)
        {
            _conexao = pConexao;
            _repositorioUsuario = pRepositorioUsuario;
        }

        public bool Execute(Usuario pUsuario)
        {
            if (String.IsNullOrEmpty(pUsuario.Login))
                throw new ExLoginNaoInformado();

            if (String.IsNullOrEmpty(pUsuario.Senha))
                throw new ExSenhaNaoInformada();

            Usuario usuario = _repositorioUsuario.ObterPorLogin(pUsuario.Login);

            if (usuario!=null && usuario.ID!=pUsuario.ID)
                throw new ExLoginExistenteUsuario();

            return true;
        }
    }
}
