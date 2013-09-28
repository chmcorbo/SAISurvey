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
            Map(m => m.Sala).Length(5);
            Map(m => m.Data_Inicio);
            Map(m => m.Data_Fim);
            References(m => m.Professor);
            References(m => m.Bloco).Not.Nullable();
            HasMany(m => m.Alunos);
            
            Table("TB_MODULO");
        }
    }
}
