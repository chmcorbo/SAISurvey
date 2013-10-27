using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate.Repositorios;

namespace SAISurvey.Persistence.nHibernate.Controladores
{
    public class ControladorProfessor : ControladorGenerico<Professor>
    {
        IRepositorioProfessor _repProfessor;

        public ControladorProfessor()
        {
            Conexao = new Persistence.nHibernate.ConectionManager();
            _repProfessor = new RepositorioProfessor(Conexao);
            Repositorio = _repProfessor;
        }

        public Professor ObterPorMatricula(string pMatricula)
        {
            return _repProfessor.ObterPorMatricula(pMatricula);
        }

        public IList<Professor> ObterPorNome(string pNome)
        {
            return _repProfessor.ObterPorNome(pNome);
        }
    }
}
