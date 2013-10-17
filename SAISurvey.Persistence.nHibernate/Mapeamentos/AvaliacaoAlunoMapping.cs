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
            Map(a => a.Fechada).Length(1);
            References<Aluno>(a => a.Aluno).Not.Nullable().ForeignKey("FK_AVALIACAO_ALUNO_ALUNO").Column("ID_Aluno");
            References<Avaliacao>(a => a.Avaliacao).Not.Nullable().ForeignKey("FK_AVALIACAO_ALUNO_AVALIACAO").Column("ID_Avaliacao");
            HasMany<RespostaQuestao>(a => a.RespostasQuestoes).Cascade.AllDeleteOrphan();
            Table("TB_AVALIACAO_ALUNO");
        }
    }
}
