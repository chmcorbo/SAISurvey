using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Modelo;

namespace SAISurvey.Dominio.Repositorios
{
    public interface IRepositorioTurma : IRepositorioGenerico<Turma>
    {
        IList<Turma> ListarPorModulo(String pID_Modulo);
    }
}
