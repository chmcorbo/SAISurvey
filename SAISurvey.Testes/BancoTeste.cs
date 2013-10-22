using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Persistence.nHibernate.Repositorios;
using NUnit.Framework;

namespace SAISurvey.Testes.Repositorios
{
    [TestFixture]
    public class BancoTeste
    {
        public BancoTeste() { }

        [Test]
        public void a_GerarBanco()
        {
            Assert.IsTrue(Banco.CriarBancoDeDados());
        }

        [Test]
        public void b_Incluir_Aluno()
        {
            AlunoTeste alunoTeste = new AlunoTeste();
            Assert.IsTrue(alunoTeste.CargaInicial());
        }

        [Test]
        public void c_Incluir_Professor()
        {
            ProfessorTeste professorTeste = new ProfessorTeste();
            Assert.IsTrue(professorTeste.CargaInicial());
        }

        [Test]
        public void d_Incluir_Usuario()
        {
            UsuarioTeste usuarioTeste = new UsuarioTeste();
            Assert.IsTrue(usuarioTeste.CargaInicial());
        }

        [Test]
        public void e_Incluir_Cursos()
        {
            CursoTeste cursoTeste = new CursoTeste();
            Assert.IsTrue(cursoTeste.CargaInicial());
        }

        [Test]
        public void f_Incluir_Turma()
        {
            TurmaTeste turmaTeste = new TurmaTeste();
            Assert.IsTrue(turmaTeste.CargaInicial());
        }

        [Test]
        public void g_Incluir_Questoes()
        {
            QuestaoTeste questaoTeste = new QuestaoTeste();
            Assert.IsTrue(questaoTeste.CargaInicial());
        }

        [Test]
        public void h_Incluir_Respostas()
        {
            RespostaTeste respostaTeste = new RespostaTeste();
            Assert.IsTrue(respostaTeste.CargaInicial());
        }

        [Test]
        public void i_Incluir_Avaliacao()
        {
            AvaliacaoTeste avaliacaoTeste = new AvaliacaoTeste();
            Assert.IsTrue(avaliacaoTeste.CargaInicial());
        }
    }
}
