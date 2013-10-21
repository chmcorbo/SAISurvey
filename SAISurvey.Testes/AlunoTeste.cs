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

        public Boolean CargaInicial()
        {
            Boolean erro = false;

            try
            {
                aluno = new Aluno();
                aluno.Matricula = "900001";
                aluno.Nome = "Carlos Henrique Meireles Corbo";
                aluno.Email = "chmcorbo@gmail.com";
                repositorio.Adicionar(aluno);

                aluno = new Aluno();
                aluno.Matricula = "900002";
                aluno.Nome = "Tatiana Moreira da Silva Corbo";
                aluno.Email = "tmscorbo@gmail.com";
                repositorio.Adicionar(aluno);

                aluno = new Aluno();
                aluno.Matricula = "900003";
                aluno.Nome = "Ricardo Coelho da Silva";
                aluno.Email = "rcoelhorj01@gmail.com";
                repositorio.Adicionar(aluno);

                aluno = new Aluno();
                aluno.Matricula = "900004";
                aluno.Nome = "Ana Carolina Moreira";
                aluno.Email = "krol.moreira201102@gmail.com";
                repositorio.Adicionar(aluno);
            }
            catch
            {
                erro = true;
            }

            return !erro;
        }

        [Test]
        public void a_Obter_Aluno_por_ID()
        {
            if (repositorio.ListarTudo().Count() == 0)
                CargaInicial();
            aluno = repositorio.ListarTudo().FirstOrDefault();
            alunoRecuperado = repositorio.ObterPorID(aluno.ID);
            Assert.AreSame(aluno, alunoRecuperado);
        }
    }
}
