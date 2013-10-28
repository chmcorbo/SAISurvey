﻿using System.Collections.Generic;
using System.Linq;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate.Repositorios;

namespace SAISurvey.Persistence.nHibernate.Controladores
{
    public class ControladorQuestao : ControladorGenerico<Questao>
    {
        private IRepositorioQuestao _repQuestao;

        public ControladorQuestao()
        {
            Conexao = new Persistence.nHibernate.ConectionManager();
            _repQuestao = new RepositorioQuestao(Conexao);
            Repositorio = _repQuestao;
        }

        public List<Questao> ObterPorDescricao(string pDescricao)
        {
            return _repQuestao.ObterPorDescricao(pDescricao).ToList();
        }
    }
}