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
    class TurmaTeste
    {
        Turma objeto;
        Turma objetoRecuperado;
        RepositorioGenerico<Turma> repositorio;
        IRepositorioProfessor repProfessor;
        IRepositorioAluno repAluno;

        // Falta incluir os testes fazendo referência obrigatório ao atributo Modulo.
        public TurmaTeste()
        {
            repositorio = new RepositorioGenerico<Turma>();
            repProfessor = new RepositorioProfessor();
            repAluno = new RepositorioAluno();
        }

        private Turma Incluir_Turma_Sem_Professor_Sem_Aluno()
        {
            Turma turma = new Turma();
            turma.Sala = "101";
            turma.Data_Inicio = DateTime.Parse("29/09/2013");
            turma.Data_Fim = DateTime.Parse("21/11/2013");
            return turma;
        }

        private Turma Incluir_Turma_Com_Professor_Sem_Aluno()
        {
            Professor professor = repProfessor.ObterPorMatricula("100001");
            if (professor == null)
            {
                ProfessorTeste professorTeste = new ProfessorTeste();
                professorTeste.IncluirProfessores();
                professor = repProfessor.ObterPorMatricula("100001");
            }

            Turma turma = new Turma();
            turma.Sala = "102";
            turma.Data_Inicio = DateTime.Parse("02/09/2013");
            turma.Data_Fim = DateTime.Parse("25/11/2013");
            turma.Professor = professor;
            return turma;
        }

        private Turma Incluir_Turma_Sem_Professor_Com_Aluno()
        {
            Aluno aluno = repAluno.ObterPorMatricula("900001");
            if (aluno == null)
            {
                AlunoTeste alunoTeste = new AlunoTeste();
                alunoTeste.IncluirAlunos();
                aluno = repAluno.ObterPorMatricula("900001");
            }

            Turma turma = new Turma();
            turma.Sala = "103";
            turma.Data_Inicio = DateTime.Parse("28/08/2013");
            turma.Data_Fim = DateTime.Parse("21/11/2013");
            turma.Alunos.Add(aluno);
            return turma;
        }

        private Turma Incluir_Turma_Com_Professor_Com_Aluno()
        {
            Professor professor = repProfessor.ObterPorMatricula("100001");
            if (professor == null)
            {
                ProfessorTeste professorTeste = new ProfessorTeste();
                professorTeste.IncluirProfessores();
                professor = repProfessor.ObterPorMatricula("100001");
            }

            IRepositorioAluno repAluno = new RepositorioAluno();
            Aluno aluno = repAluno.ObterPorMatricula("900001");
            if (aluno == null)
            {
                AlunoTeste alunoTeste = new AlunoTeste();
                alunoTeste.IncluirAlunos();
                aluno = repAluno.ObterPorMatricula("900001");
            }

            Turma turma = new Turma();
            turma.Sala = "104";
            turma.Data_Inicio = DateTime.Parse("28/08/2013");
            turma.Data_Fim = DateTime.Parse("21/11/2013");
            turma.Professor = professor;
            turma.Alunos.Add(aluno);
            return turma;
        }

        public void Incluir_Turmas()
        {
            Turma turma = Incluir_Turma_Sem_Professor_Sem_Aluno();
            repositorio.Adicionar(turma);
            turma = Incluir_Turma_Com_Professor_Sem_Aluno();
            repositorio.Adicionar(turma);
            turma = Incluir_Turma_Sem_Professor_Com_Aluno();
            repositorio.Adicionar(turma);
            turma = Incluir_Turma_Com_Professor_Com_Aluno();
            repositorio.Adicionar(turma);
        }

        [Test]
        public void a_Incluir_Turma_Sem_Professor_Sem_Aluno()
        {
            objeto = Incluir_Turma_Sem_Professor_Sem_Aluno();
            repositorio.Adicionar(objeto);
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }

        [Test]
        public void b_Incluir_Turma_Com_Professor_Sem_Aluno()
        {
            objeto = Incluir_Turma_Com_Professor_Sem_Aluno();
            repositorio.Adicionar(objeto);
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
            Professor professor = repProfessor.ObterPorMatricula("100001");
            Assert.AreEqual(professor.ID, objeto.Professor.ID);
        }

        [Test]
        public void c_Incluir_Turma_Sem_Professor_Com_Aluno()
        {
            objeto = Incluir_Turma_Sem_Professor_Com_Aluno();
            repositorio.Adicionar(objeto);
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto,objetoRecuperado);
            Aluno aluno = repAluno.ObterPorMatricula("900001");
            Assert.AreEqual(aluno.ID,objetoRecuperado.Alunos[0].ID);
        }

        [Test]
        public void d_Incluir_Turma_Com_Professor_Com_Aluno()
        {
            objeto = Incluir_Turma_Com_Professor_Com_Aluno();
            repositorio.Adicionar(objeto);
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
            
            Professor professor = repProfessor.ObterPorMatricula("100001");
            Assert.AreEqual(professor.ID, objetoRecuperado.Professor.ID);

            Aluno aluno = repAluno.ObterPorMatricula("900001");
            Assert.AreEqual(aluno.ID, objetoRecuperado.Alunos[0].ID);
        }

        [Test]
        public void e_Alterar_Turma()
        {
            objeto = Incluir_Turma_Com_Professor_Com_Aluno();
            objeto.Data_Inicio = DateTime.Parse("14/01/2014");
            objeto.Data_Fim = DateTime.Parse("25/03/2014");
            objeto.Professor = null;
            Aluno aluno = objeto.Alunos.Where(a => a.Matricula=="0002").FirstOrDefault();
            objeto.Alunos.Remove(aluno);
            repositorio.Atualizar(objeto);
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }

        [Test]
        public void f_Excluir_Turma()
        {
            objeto = Incluir_Turma_Com_Professor_Com_Aluno();
            repositorio.Excluir(objeto);
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.IsNull(objetoRecuperado);
        }

    }
}
