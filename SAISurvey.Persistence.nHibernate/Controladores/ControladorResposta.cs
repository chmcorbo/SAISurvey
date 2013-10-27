using System.Collections.Generic;
using System.Linq;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate.Repositorios;

namespace SAISurvey.Persistence.nHibernate.Controladores
{
    public class ControladorResposta : ControladorGenerico<Resposta>
    {
        private IRepositorioResposta _repResposta;

        public ControladorResposta()
        {
            Conexao = new Persistence.nHibernate.ConectionManager();
            _repResposta = new RepositorioResposta(Conexao);
            Repositorio = _repResposta;
        }

        public override List<Resposta> ListarTudo()
        {
            return _repResposta.ListarTudo().OrderBy(r => r.Ordem).ToList();
        }

        public List<Resposta> ObterPorDescricao(string pDescricao)
        {
            return _repResposta.ObterPorDescricao(pDescricao).ToList();
        }

    }
}
