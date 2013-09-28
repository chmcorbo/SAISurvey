using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SAISurvey.Dominio.Modelo;

namespace SAISurvey.Persistence.nHibernate.Mapeamentos
{
    public class RespostaMapping : ClassMap<Resposta>
    {
        public RespostaMapping()
        {
            Id(r => r.ID).Index("PK_RESPOSTA").Length(40);
            Map(r => r.Descricao).Length(100);
            Table("TB_RESPOSTA");
        }
    }
}
