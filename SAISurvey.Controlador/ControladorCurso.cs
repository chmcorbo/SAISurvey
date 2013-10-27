using System;
using System.Collections.Generic;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate.Repositorios;

namespace SAISurvey.Controlador
{
    public class ControladorCurso : ControladorGenerico<Curso>
    {
        IRepositorioCurso _repCurso;

        public ControladorCurso()
        {
            Conexao = new Persistence.nHibernate.ConectionManager();
            _repCurso = new RepositorioCurso(Conexao);
            Repositorio = _repCurso;
        }

        public IList<Curso> ObterPorDescricao(string pDescricaoCurso)
        {
            return _repCurso.ObterPorDescricao(pDescricaoCurso);
        }

        public IList<Modulo> ObterModulosPorDescricao(string pDescricaoModulo)
        {
            return _repCurso.ObterModulosPorDescricao(pDescricaoModulo);
        }

        public Modulo ObterCursoPorIDModulo(String pID_Modulo)
        {
            return _repCurso.ObterCursoPorIDModulo(pID_Modulo);
        }
    }
}
