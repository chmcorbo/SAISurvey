using System.Collections.Generic;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate.Repositorios;

namespace SAISurvey.Persistence.nHibernate.Controladores
{
    public class ControladorAluno : ControladorGenerico<Aluno>
    {
        private IRepositorioAluno _repAluno;

        public ControladorAluno()
        {
            Conexao = new Persistence.nHibernate.ConectionManager();
            _repAluno = new RepositorioAluno(Conexao);
            Repositorio = _repAluno;
        }
        public Aluno ObterPorMatricula(string pMatricula)
        {
            return _repAluno.ObterPorMatricula(pMatricula);
        }
        public IList<Aluno> ObterPorNome(string pNome)
        {
            return _repAluno.ObterPorNome(pNome);
        }
    }
}
