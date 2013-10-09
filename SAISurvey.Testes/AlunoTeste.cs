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
    public class AlunoTeste
    {
        IRepositorioAluno repositorio;
        Aluno aluno;
        Aluno alunoRecuperado;

        public AlunoTeste()
        {
            repositorio = new RepositorioAluno();
        }

        public void IncluirAlunos()
        {
            aluno = new Aluno();
            aluno.Matricula = "900001";
            aluno.Nome = "Carlos Henrique Meireles Corbo";
            repositorio.Atualizar(aluno);

            aluno = new Aluno();
            aluno.Matricula = "900002";
            aluno.Nome = "Ricardo Coelho da Silva";
            repositorio.Atualizar(aluno);
        }

        [Test]
        public void a_Obter_Aluno_por_ID()
        {
            if (repositorio.ListarTudo().Count() == 0)
                IncluirAlunos();
            aluno = repositorio.ListarTudo().FirstOrDefault();
            alunoRecuperado = repositorio.ObterPorID(aluno.ID);
            Assert.AreSame(aluno, alunoRecuperado);
        }
    }
}
