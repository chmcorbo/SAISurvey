﻿using System;
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
            Map(a => a.ConviteEnviado).Length(1);
            References<Turma>(a => a.Turma).ForeignKey("FK_AVALIACAO_MODULO").Column("ID_Turma");
            HasManyToMany(a => a.Questoes).Table("TB_AVALIACAO_QUESTAO");
            Table("TB_AVALIACAO");
        }
    }
}
