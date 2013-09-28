using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SAISurvey.Dominio.Modelo;


namespace SAISurvey.Persistence.nHibernate.Mapeamentos
{
    public class BlocoMapping : ClassMap<Bloco>
    {
        public BlocoMapping()
        {
            Id(b => b.ID).Index("PK_BLOCO").Length(40);
            Map(b => b.Descricao).Length(70);
            References(b => b.Curso);
            Table("TB_BLOCO");
        }
    }
}
