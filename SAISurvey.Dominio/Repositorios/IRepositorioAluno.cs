using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Modelo;

namespace SAISurvey.Dominio.Repositorios
{
    public interface IRepositorioAluno : IRepositorioGenerico<Aluno>
    {
        Aluno ObterPorMatricula(String pMatricula);
        IList<Aluno> ObterPorNome(String pNome);
    }
}
