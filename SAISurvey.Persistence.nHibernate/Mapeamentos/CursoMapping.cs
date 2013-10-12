using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SAISurvey.Dominio.Modelo;

namespace SAISurvey.Persistence.nHibernate.Mapeamentos
{
    public class CursoMapping : ClassMap<Curso>
    {
        public CursoMapping()
        {
            Id(c => c.ID).Index("PK_CURSO").Length(40);
            Map(c => c.Descricao).Length(70);
            HasMany(c => c.Blocos).Cascade.All();
            Table("TB_CURSO");
        }
    }
}
