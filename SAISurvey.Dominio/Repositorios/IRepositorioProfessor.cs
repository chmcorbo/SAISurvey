using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Modelo;

namespace SAISurvey.Dominio.Repositorios
{
    public interface IRepositorioProfessor : IRepositorioGenerico<Professor>
    {
        Professor ObterPorMatricula(String pMatricula);
        IList<Professor> ObterPorNome(String pNome);
    }
}
