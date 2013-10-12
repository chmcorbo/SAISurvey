using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Modelo;
using FluentNHibernate.Mapping;

namespace SAISurvey.Persistence.nHibernate.Mapeamentos
{
    public class UsuarioMapping : ClassMap<Usuario>
    {
        public UsuarioMapping()
        {
            Id(u => u.ID).Index("PK_USUARIO").Length(40);
            Map(u => u.Login).Length(20);
            Map(u => u.Nome).Length(50);
            Map(u => u.Senha).Length(10);
            Map(u => u.Administrador).Length(1).Not.Nullable();
            Table("TB_USUARIO");
        }
    }
}
