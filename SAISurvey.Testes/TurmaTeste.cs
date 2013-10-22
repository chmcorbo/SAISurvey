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
        IRepositorioTurma repositorio;
        IRepositorioProfessor repProfessor;
        IRepositorioAluno repAluno;
        IRepositorioCurso repCurso;

        // Falta incluir os testes fazendo referência obrigatório ao atributo Modulo.
        public TurmaTeste()
        {
            repositorio = new RepositorioTurma();
            repProfessor = new RepositorioProfessor();
            repAluno = new RepositorioAluno();
            repCurso = new RepositorioCurso();
        }

        private void VerificaAlgumCursoCadastrado(IRepositorioCurso repositorioCurso)
        {
            if (repositorioCurso.ListarTudo().Count() == 0)
            {
                CursoTeste cursoTeste = new CursoTeste();
                cursoTeste.CargaInicial();
            }
        }

        private Turma Turma_Engenharia_Quintas_Feiras()
        {
            Professor professor = repProfessor.ObterPorMatricula("100001");
            if (professor == null)
            {
                ProfessorTeste professorTeste = new ProfessorTeste();
                professorTeste.CargaInicial();
                professor = repProfessor.ObterPorMatricula("100001");
            }
            
            Turma turma = new Turma();
            turma.Descricao = "Quintas-feiras";
            turma.Sala = "101";
            turma.Data_Inicio = DateTime.Parse("09/05/2013");
            turma.Data_Fim = DateTime.Parse("18/07/2013");
            turma.Professor = professor;
            turma.Modulo = repCurso.ObterModulosPorDescricao("Persistência de Dados com .NET").FirstOrDefault();
            turma.Alunos.Add(repAluno.ObterPorMatricula("900001"));
            repositorio.Adicionar(turma);
            return turma;
        }

        private Turma Turma_Engenharia_Sabados()
        {
            Professor professor = repProfessor.ObterPorMatricula("100002");
            if (professor == null)
            {
                ProfessorTeste professorTeste = new ProfessorTeste();
                professorTeste.CargaInicial();
                professor = repProfessor.ObterPorMatricula("100002");
            }

            Turma turma = new Turma();
            turma.Descricao = "Sábados";
            turma.Sala = "102";
            turma.Data_Inicio = DateTime.Parse("04/05/2013");
            turma.Data_Fim = DateTime.Parse("06/07/2013");
            turma.Professor = professor;
            turma.Modulo = repCurso.ObterModulosPorDescricao("Persistência de Dados com .NET").FirstOrDefault();
            turma.Alunos.Add(repAluno.ObterPorMatricula("900002"));
            repositorio.Adicionar(turma);
            return turma;
        }

        private Turma Turma_Sistema_Informacao_SAP()
        {
            Professor professor = repProfessor.ObterPorMatricula("100003");
            if (professor == null)
            {
                ProfessorTeste professorTeste = new ProfessorTeste();
                professorTeste.CargaInicial();
                professor = repProfessor.ObterPorMatricula("100003");
            }

            Turma turma = new Turma();
            turma.Descricao = "Quartas-feiras";
            turma.Sala = "203";
            turma.Data_Inicio = DateTime.Parse("08/05/2013");
            turma.Data_Fim = DateTime.Parse("24/07/2013");
            turma.Professor = professor;
            turma.Modulo = repCurso.ObterModulosPorDescricao("BI - Business Intelligence").FirstOrDefault();
            turma.Alunos.Add(repAluno.ObterPorMatricula("900003"));
            repositorio.Adicionar(turma);
            return turma;
        }

        public Boolean CargaInicial()
        {
            Boolean erro = false;
            try
            {
                Turma_Engenharia_Quintas_Feiras();
                Turma_Engenharia_Sabados();
                Turma_Sistema_Informacao_SAP();
            }
            catch
            {
                erro = true;
            }
            return !erro;

        }

        private Turma Incluir_Turma_Sem_Professor_Sem_Aluno()
        {
            // MBA em Gerência de Projetos - Padrão PMI 
            VerificaAlgumCursoCadastrado(repCurso);
            Turma turma = new Turma();
            turma.Sala = "101";
            turma.Data_Inicio = DateTime.Parse("05/09/2013");
            turma.Data_Fim = DateTime.Parse("14/11/2013");
            return turma;
        }

        private Turma Incluir_Turma_Com_Professor_Sem_Aluno()
        {
            // Engenharia de software - Sábados
            Professor professor = repProfessor.ObterPorMatricula("100001");
            if (professor == null)
            {
                ProfessorTeste professorTeste = new ProfessorTeste();
                professorTeste.CargaInicial();
                professor = repProfessor.ObterPorMatricula("100001");
            }
            VerificaAlgumCursoCadastrado(repCurso);

            Turma turma = new Turma();
            turma.Modulo = repCurso.ObterModulosPorDescricao("Persistência de Dados com .NET").FirstOrDefault();
            turma.Sala = "101";
            turma.Data_Inicio = DateTime.Parse("21/09/2013");
            turma.Data_Fim = DateTime.Parse("14/12/2013");
            turma.Professor = professor;
            return turma;
        }

        private Turma Incluir_Turma_Sem_Professor_Com_Aluno()
        {
            // MBA Gestão de Sistemas da Informação com SAP

            Aluno aluno = repAluno.ObterPorMatricula("900001");
            if (aluno == null)
            {
                AlunoTeste alunoTeste = new AlunoTeste();
                alunoTeste.CargaInicial();
                aluno = repAluno.ObterPorMatricula("900001");
            }

            Turma turma = new Turma();
            turma.Modulo = repCurso.ObterModulosPorDescricao("Análise e Projeto de Sistemas Orientados a Objetos").FirstOrDefault();
            turma.Sala = "201";
            turma.Data_Inicio = DateTime.Parse("11/08/2013");
            turma.Data_Fim = DateTime.Parse("11/12/2013");
            turma.Alunos.Add(aluno);
            return turma;
        }

        private Turma Incluir_Turma_Com_Professor_Com_Aluno()
        {
            Professor professor = repProfessor.ObterPorMatricula("100001");
            if (professor == null)
            {
                ProfessorTeste professorTeste = new ProfessorTeste();
                professorTeste.CargaInicial();
                professor = repProfessor.ObterPorMatricula("100001");
            }

            IRepositorioAluno repAluno = new RepositorioAluno();
            Aluno aluno = repAluno.ObterPorMatricula("900001");
            if (aluno == null)
            {
                AlunoTeste alunoTeste = new AlunoTeste();
                alunoTeste.CargaInicial();
                aluno = repAluno.ObterPorMatricula("900001");
            }

            Turma turma = new Turma();
            turma.Sala = "201";
            turma.Modulo = repCurso.ObterModulosPorDescricao("Desenvolvimento Web com WCF e WWF").FirstOrDefault();
            turma.Data_Inicio = DateTime.Parse("05/09/2013");
            turma.Data_Fim = DateTime.Parse("14/11/2013");
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
