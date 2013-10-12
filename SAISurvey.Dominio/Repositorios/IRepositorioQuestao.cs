using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Modelo;


namespace SAISurvey.Dominio.Repositorios
{
    public interface IRepositorioQuestao : IRepositorioGenerico<Questao>
    {
        IList<Questao> ObterPorDescricao(String pDescricao);
    }
}
