using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate.Repositorios;


namespace SAISurvey.Testes
{
    [TestFixture]
    public class QuestaoTeste
    {
        IRepositorioQuestao repositorio;
        Questao questao;
        Questao questaoRecuperada;

        public QuestaoTeste()
        {
            repositorio = new RepositorioQuestao();
        }

        public void IncluirQuestoes()
        {
            questao = new Questao();
            questao.Descricao = "O professor utilizou os recursos da sala de aula adequadamente?";
            repositorio.Atualizar(questao);

            questao = new Questao();
            questao.Descricao = "O professor utilizou os recursos do moodle adequadamente?";
            repositorio.Atualizar(questao);
        }

        [Test]
        public void a_Incluir_Questao()
        {
            IncluirQuestoes();
            questao = new Questao();
            questao.Descricao = "O módulo cursado está alinhado com as necessidades do mercado?";
            repositorio.Adicionar(questao);
            questaoRecuperada = repositorio.ObterPorID(questao.ID);
            Assert.AreSame(questao, questaoRecuperada);
        }
        [Test]
        public void b_Alterar_Questao()
        {
            if (repositorio.ListarTudo().Count() == 0)
                IncluirQuestoes();

            questao = repositorio.ListarTudo().FirstOrDefault();
            questao.Descricao = "Qual é a sua nota para o esse módulo?";
            repositorio.Atualizar(questao);
            questaoRecuperada = repositorio.ObterPorID(questao.ID);
            Assert.AreEqual(questao.Descricao, questaoRecuperada.Descricao);
        }

        [Test]
        public void c_Excluir_Questao()
        {
            if (repositorio.ListarTudo().Count() == 0)
                IncluirQuestoes();

            questao = repositorio.ListarTudo().FirstOrDefault();
            repositorio.Excluir(questao);
            questaoRecuperada = repositorio.ObterPorID(questao.ID);
            Assert.IsNull(questaoRecuperada);
        }



    }
}
