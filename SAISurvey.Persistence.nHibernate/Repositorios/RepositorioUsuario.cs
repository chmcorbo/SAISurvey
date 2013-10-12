using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Dominio.Servicos;
using SAISurvey.Persistence.nHibernate.Servicos;

namespace SAISurvey.Persistence.nHibernate.Repositorios
{
    public class RepositorioUsuario : RepositorioGenerico<Usuario>, IRepositorioUsuario
    {
        public Usuario ObterPorLogin(string pLogin)
        {
            IQueryOver<Usuario> queryOver = Session.QueryOver<Usuario>()
                .Where(u => u.Login==pLogin);
            return queryOver.List<Usuario>().FirstOrDefault();
        }

        public override void Adicionar(Usuario pEntidadeBase)
        {
            IServValidadorGravacaoUsuario servValidadorGravacaoUsuario = new ServValidadorGravacaoUsuario(this);
            if (servValidadorGravacaoUsuario.Execute(pEntidadeBase))
                base.Adicionar(pEntidadeBase);
        }

        public override void Atualizar(Usuario pEntidadeBase)
        {
            IServValidadorGravacaoUsuario servValidadorGravacaoUsuario = new ServValidadorGravacaoUsuario(this);
            if (servValidadorGravacaoUsuario.Execute(pEntidadeBase))
                base.Atualizar(pEntidadeBase);
        }

        public IList<Usuario> ListarPorNome(string pNome)
        {
            IQueryOver<Usuario> queryOver = Session.QueryOver<Usuario>()
                .WhereRestrictionOn(c => c.Nome)
                .IsLike("%" + pNome + "%")
                .OrderBy(c => c.Nome).Asc;
            return queryOver.List<Usuario>();
        }
    }
}
