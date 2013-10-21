using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SAISurvey.Dominio.Modelo;

namespace SAISurvey.Persistence.nHibernate.Mapeamentos
{
    public class AlunoMapping : ClassMap<Aluno>
    {
        public AlunoMapping()
        {
            Id(a => a.ID).Index("PK_ALUNO").Length(40);
            Map(a => a.Matricula).Length(6);
            Map(a => a.Nome).Length(50);
            Map(a => a.Email).Length(100);
            Table("TB_ALUNO");
        }
    }
}
