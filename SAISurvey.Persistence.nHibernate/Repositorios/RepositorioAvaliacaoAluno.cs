using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Excecoes;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Dominio.Servicos;
using SAISurvey.Persistence.nHibernate.Servicos;

namespace SAISurvey.Persistence.nHibernate.Repositorios
{
    public class RepositorioAvaliacaoAluno : RepositorioGenerico<AvaliacaoAluno>, IRepositorioAvaliacaoAluno
    {
        public RepositorioAvaliacaoAluno(ConectionManager pConexao)
            : base(pConexao)
        {

        }


        public void Fechar(AvaliacaoAluno pAvaliacaoAluno)
        {
            AvaliacaoAluno avaliacaoAluno = ObterPorID(pAvaliacaoAluno.ID);
            if (avaliacaoAluno == null)
                throw new ExAvaliacaoAlunoInexistente();
            avaliacaoAluno.Fechada = "S";
            Atualizar(avaliacaoAluno);
        }
    }
}
