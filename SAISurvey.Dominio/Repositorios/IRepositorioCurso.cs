using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Modelo;


namespace SAISurvey.Dominio.Repositorios
{
    public interface IRepositorioCurso : IRepositorioGenerico<Curso>
    {
        IList<Curso> ObterPorDescricao(String pDescricaoCurso);
        IList<Modulo> ObterModulosPorDescricao(String pDescricaoModulo);
        Modulo ObterCursoPorIDModulo(String pID_Modulo);
    }
}
