using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Modelo;

namespace SAISurvey.Dominio.Repositorios
{
    public interface IRepositorioAvaliacao : IRepositorioGenerico<Avaliacao>
    {
        IList<Avaliacao> ListarPorPeriodo(DateTime pDataInicial, DateTime pDataFinal);
        IList<Avaliacao> ListarSemConvite(DateTime pDataReferencia);
    }
}
