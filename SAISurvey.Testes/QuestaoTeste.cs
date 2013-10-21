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

        public Boolean CargaInicial()
        {
            Boolean erro = false;
            try
            {
                questao = new Questao();
                questao.Descricao = "Até agora, o curso está atingindo as minhas expectativas";
                repositorio.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "Até agora, eu indicaria o curso para um amigo.";
                repositorio.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "Até agora, o curso me parece voltado para as necessidades do mercado.";
                repositorio.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "Até agora, a coordenação pedagógica parece comprometida com a qualidade do curso.";
                repositorio.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "Até agora, minha turma parece proporcionar um networking relevante para a minha carreira.";
                repositorio.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "Até agora, o atendimento de Secretaria que recebi está atingindo as minhas expectivas.";
                repositorio.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "O professor contribuiu para o meu aprendizado.";
                repositorio.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "O professor é atencioso e esteve disponível para tirar duvídas.";
                repositorio.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "O professor aproveitou bem os recursos da sala de aula.";
                repositorio.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "O professor utilizou o moodle e outros recursos didáticos para ajudar no meu aprendizado";
                repositorio.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "O professor aproveitou bem o tempo em sala de aula.";
                repositorio.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "Gostaria de cursos outro módulos com esse professor.";
                repositorio.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "Eu adquiri as competências propostas para o módulo.";
                repositorio.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "O módulo foi útil para o meu crescimento profissional.";
                repositorio.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "A carga horária fo módulo foi apropriada.";
                repositorio.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "O acervo da biblioteca atendeu as necessidades desse modulo.";
                repositorio.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "A configuração do(s) computador(es) e equipamentos da sala de aula de aula e a qualidade " +
                    " do suporte foi apropriada.";
                repositorio.Adicionar(questao);
            }
            catch
            {
                erro = true;
            }

            return !erro;
        }

        [Test]
        public void a_Incluir_Questao()
        {
            CargaInicial();
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
                CargaInicial();

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
                CargaInicial();

            questao = repositorio.ListarTudo().FirstOrDefault();
            repositorio.Excluir(questao);
            questaoRecuperada = repositorio.ObterPorID(questao.ID);
            Assert.IsNull(questaoRecuperada);
        }



    }
}
