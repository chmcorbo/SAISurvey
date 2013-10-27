using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate.Repositorios;


namespace SAISurvey.Persistence.nHibernate.Controladores
{
    public class ControladorTurma : ControladorGenerico<Turma>
    {
        private IRepositorioTurma _repTurma;

        public ControladorTurma()
        {
            Conexao = new ConectionManager();
            _repTurma = new RepositorioTurma(Conexao);
            Repositorio = _repTurma;
        }

        public IList<Turma> ListarPorModulo(String pID_Modulo)
        {
            return _repTurma.ListarPorModulo(pID_Modulo);
        }
    }
}
