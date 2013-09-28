using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Modelo;


namespace SAISurvey.Dominio.Repositorios
{
    public interface IRepositorioCurso : IRepositorioGenerico<Curso>
    {
        IList<Curso> ObterPorDescricao(String pDescricao);
        IList<Bloco> ObterBlocos(Curso pCurso,  String pDescricaoBloco);
        IList<Bloco> ObterBlocos(String pDescricaoBloco);
    }
}
