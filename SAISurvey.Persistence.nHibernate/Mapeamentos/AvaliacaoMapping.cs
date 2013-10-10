using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SAISurvey.Dominio.Modelo;


namespace SAISurvey.Persistence.nHibernate.Mapeamentos
{
    public class AvaliacaoMapping : ClassMap<Avaliacao>
    {
        public AvaliacaoMapping()
        {
            Id(a => a.ID).Index("PK_AVALIACAO").Length(40);
            Map(a => a.Objetivo).Length(50);
            Map(a => a.Data_Inicio);
            Map(a => a.Data_Fim);
            References(a => a.Turma).Column("ID_Turma").Cascade.All();
            HasManyToMany(a => a.Questoes).Table("TB_AVALIACAO_QUESTAO").Cascade.All();
            Table("TB_AVALIACAO");
        }
    }
}
