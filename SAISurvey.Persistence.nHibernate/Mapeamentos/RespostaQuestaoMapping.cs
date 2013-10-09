using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SAISurvey.Dominio.Modelo;

namespace SAISurvey.Persistence.nHibernate.Mapeamentos
{
    public class RespostaQuestaoMapping : ClassMap<RespostaQuestao>
    {
        public RespostaQuestaoMapping()
        {
            Id(r => r.ID).Index("PK_RESPOSTA_QUESTAO").Length(40);
            References(r => r.Questao).Column("Id_Questao").Cascade.None();
            References(r => r.Resposta).Column("Id_Resposta").Cascade.None();
            Table("TB_RESPOSTA_QUESTAO");
        }
    }
}
