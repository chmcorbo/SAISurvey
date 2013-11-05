using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Dominio.Servicos;
using SAISurvey.Dominio.Controladores;
using SAISurvey.Persistence.nHibernate;
using SAISurvey.Persistence.nHibernate.Repositorios;
using SAISurvey.Persistence.nHibernate.Servicos;

namespace SAISurvey.Persistence.nHibernate.Controladores
{
    public class ControladorUsuario : ControladorGenerico<Usuario>
    {
        private IRepositorioUsuario _repUsuario;

        public ControladorUsuario() 
        {
            Conexao = new ConectionManager();
            _repUsuario = new RepositorioUsuario(Conexao);
            Repositorio = _repUsuario;
        }
        public Usuario ObterPorLogin(String pLogin)
        {
            return _repUsuario.ObterPorLogin(pLogin);
        }

        public Usuario ValidarAcessoSistema(String pLogin, String pSenha)
        {
            IServValidadorAcessoUsuario servValidadorAcessoUsuario = new ServValidadorAcessoUsuario(Conexao);
            return servValidadorAcessoUsuario.Execute(pLogin, pSenha);
        }

        public List<Usuario> ListarPorNome(String pNome)
        {
            return _repUsuario.ListarPorNome(pNome).ToList();
        }

        public override List<Usuario> ListarTudo()
        {
            return base.ListarTudo().OrderBy(u => u.Nome).ToList();
        }
    }
}
