using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate.Repositorios;

namespace SAISurvey.Persistence.nHibernate.Controladores
{
    public class ControladorAvaliacaoAluno : ControladorGenerico<AvaliacaoAluno>
    {
        private IRepositorioAvaliacaoAluno _repAvaliacaoAluno;

        public ControladorAvaliacaoAluno()
        {
            Conexao = new ConectionManager();
            _repAvaliacaoAluno = new RepositorioAvaliacaoAluno(Conexao);
            Repositorio = _repAvaliacaoAluno;

        }

        public void Fechar(AvaliacaoAluno pAvaliacaoAluno)
        {
            try
            {
                Conexao.BeginTransaction();
                _repAvaliacaoAluno.Fechar(pAvaliacaoAluno);
                Conexao.CommitTransaction();
            }
            catch (Exception ex)
            {
                Conexao.RollbackTransaction();
                throw new Exception(ex.Message);
            }
        }

        public List<Resposta> ListarRespostas()
        {
            IRepositorioResposta _repResposta = new RepositorioResposta(Conexao);
            return _repResposta.ListarTudo().OrderBy(r => r.Ordem).ToList();
        }
    }
}
