using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate.Repositorios;

namespace SAISurvey.Persistence.nHibernate.Controladores
{
    public class ControladorAvaliacao : ControladorGenerico<Avaliacao>
    {
        private IRepositorioAvaliacao _repAvaliacao;

        public ControladorAvaliacao()
        {
            Conexao = new ConectionManager();
            _repAvaliacao = new RepositorioAvaliacao(Conexao);
            Repositorio = _repAvaliacao;
        }

        public virtual List<Avaliacao> ListarPorPeriodo(DateTime pDataInicial, DateTime pDataFinal)
        {
            return _repAvaliacao.ListarPorPeriodo(pDataInicial, pDataFinal).ToList();
        }

        public List<Avaliacao> ListarSemConvite(DateTime pDataReferencia)
        {
            return _repAvaliacao.ListarSemConvite(pDataReferencia).ToList();
        }


    }
}
