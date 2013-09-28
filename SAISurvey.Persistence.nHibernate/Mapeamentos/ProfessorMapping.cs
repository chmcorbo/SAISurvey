using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SAISurvey.Dominio.Modelo;

namespace SAISurvey.Persistence.nHibernate.Mapeamentos
{
    public class ProfessorMapping : ClassMap<Professor>
    {
        public ProfessorMapping()
        {
            Id(a => a.ID).Index("PK_PROFESSOR").Length(40);
            Map(a => a.Matricula).Length(6);
            Map(a => a.Nome).Length(50);
            Table("TB_PROFESSOR");
        }
    }
}
