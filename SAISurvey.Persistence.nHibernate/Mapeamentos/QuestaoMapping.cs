using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SAISurvey.Dominio.Modelo;

namespace SAISurvey.Persistence.nHibernate.Mapeamentos
{
    public class QuestaoMapping : ClassMap<Questao>
    {
        public QuestaoMapping()
        {
            Id(q => q.ID).Index("Pk_Questao").Length(40);
            Map(q => q.Descricao).Length(100);
            Table("TB_QUESTAO");
        }
    }
}
