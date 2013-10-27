using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate;
using SAISurvey.Persistence.nHibernate.Controladores;
using SAISurvey.Persistence.nHibernate.Repositorios;

namespace SAISurvey.Testes
{
    [TestFixture]
    public class QuestaoTeste
    {
        Questao questao;
        Questao questaoRecuperada;
        ControladorQuestao controlador;

        public QuestaoTeste()
        {
            controlador = new ControladorQuestao();
        }

        public Boolean CargaInicial()
        {
            Boolean erro = false;
            try
            {
                questao = new Questao();
                questao.Descricao = "Até agora, o curso está atingindo as minhas expectativas";
                controlador.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "Até agora, eu indicaria o curso para um amigo.";
                controlador.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "Até agora, o curso me parece voltado para as necessidades do mercado.";
                controlador.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "Até agora, a coordenação pedagógica parece comprometida com a qualidade do curso.";
                controlador.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "Até agora, minha turma parece proporcionar um networking relevante para a minha carreira.";
                controlador.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "Até agora, o atendimento de Secretaria que recebi está atingindo as minhas expectivas.";
                controlador.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "O professor contribuiu para o meu aprendizado.";
                controlador.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "O professor é atencioso e esteve disponível para tirar duvídas.";
                controlador.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "O professor aproveitou bem os recursos da sala de aula.";
                controlador.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "O professor utilizou o moodle e outros recursos didáticos para ajudar no meu aprendizado";
                controlador.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "O professor aproveitou bem o tempo em sala de aula.";
                controlador.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "Gostaria de cursos outro módulos com esse professor.";
                controlador.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "Eu adquiri as competências propostas para o módulo.";
                controlador.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "O módulo foi útil para o meu crescimento profissional.";
                controlador.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "A carga horária fo módulo foi apropriada.";
                controlador.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "O acervo da biblioteca atendeu as necessidades desse modulo.";
                controlador.Adicionar(questao);

                questao = new Questao();
                questao.Descricao = "A configuração do(s) computador(es) e equipamentos da sala de aula de aula e a qualidade " +
                    " do suporte foi apropriada.";
                controlador.Adicionar(questao);
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
            controlador.Adicionar(questao);
            questaoRecuperada = controlador.ObterPorID(questao.ID);
            Assert.AreSame(questao, questaoRecuperada);
        }
        [Test]
        public void b_Alterar_Questao()
        {
            if (controlador.ListarTudo().Count() == 0)
                CargaInicial();

            questao = controlador.ListarTudo().FirstOrDefault();
            questao.Descricao = "Qual é a sua nota para o esse módulo?";
            controlador.Atualizar(questao);
            questaoRecuperada = controlador.ObterPorID(questao.ID);
            Assert.AreEqual(questao.Descricao, questaoRecuperada.Descricao);
        }

        [Test]
        public void c_Excluir_Questao()
        {
            if (controlador.ListarTudo().Count() == 0)
                CargaInicial();

            questao = controlador.ListarTudo().FirstOrDefault();
            controlador.Excluir(questao);
            questaoRecuperada = controlador.ObterPorID(questao.ID);
            Assert.IsNull(questaoRecuperada);
        }



    }
}
