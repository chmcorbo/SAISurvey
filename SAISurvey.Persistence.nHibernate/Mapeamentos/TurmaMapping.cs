using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Modelo;
using FluentNHibernate.Mapping;

namespace SAISurvey.Persistence.nHibernate.Mapeamentos
{
    public class TurmaMapping : ClassMap<Turma>
    {
        public TurmaMapping()
        {
            Id(t => t.ID).Index("PK_TURMA").Length(40);
            Map(t => t.Descricao).Length(50);
            Map(t => t.Sala).Length(4);
            Map(t => t.Data_Inicio);
            Map(t => t.Data_Fim);
            References(t => t.Modulo).Column("Id_Modulo");
            References(t => t.Professor).Column("Id_Professor");
            HasMany(t => t.Alunos);
            Table("TB_TURMA");
        }
    }
}
