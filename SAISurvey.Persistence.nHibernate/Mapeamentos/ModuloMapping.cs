using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SAISurvey.Dominio.Modelo;

namespace SAISurvey.Persistence.nHibernate.Mapeamentos
{
    public class ModuloMapping : ClassMap<Modulo>
    {
        public ModuloMapping()
        {
            Id(m => m.ID).Index("PK_MODULO").Length(40);
            Map(m => m.Descricao).Length(70);
            References(m => m.Bloco).Not.Nullable();
            Table("TB_MODULO");
        }
    }
}
