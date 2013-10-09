using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Modelo;
using FluentNHibernate.Mapping;

namespace SAISurvey.Persistence.nHibernate.Mapeamentos
{
    public class AvaliacaoAlunoMapping : ClassMap<AvaliacaoAluno>
    {
        public AvaliacaoAlunoMapping()
        {
            // Estudar depois uma forma de criar chaves duplas onde essas tais estão dentro de um objeto declarado na classe;

            Id(a => a.ID).Index("PK_AVALIACAO_ALUNO").Length(40);
            References(a => a.Aluno).Column("ID_Aluno").Cascade.None();
            References(a => a.Avaliacao).Column("ID_Avaliacao").Cascade.None();
            HasMany<RespostaQuestao>(a => a.RespostasQuestoes).Cascade.None();
            Table("TB_AVALIACAO_ALUNO");
        }
    }
}
