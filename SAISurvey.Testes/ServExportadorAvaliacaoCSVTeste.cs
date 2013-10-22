using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Dominio.Servicos;
using SAISurvey.Persistence.nHibernate.Repositorios;
using SAISurvey.Persistence.nHibernate.Servicos;
using NUnit.Framework;
using System.Configuration;

namespace SAISurvey.Testes
{
    [TestFixture]
    public class ServExportadorAvaliacaoCSVTeste
    {
        IRepositorioGenerico<AvaliacaoAluno> repositorio;
        IRepositorioGenerico<AvaliacaoAluno> repositorioAvaliacaoAluno;
        IServExportadorAvaliacaoCSV servExportadorAvaliacaoCSV;

        public ServExportadorAvaliacaoCSVTeste()
        {
            repositorio = new RepositorioGenerico<AvaliacaoAluno>();
            repositorioAvaliacaoAluno = new RepositorioGenerico<AvaliacaoAluno>();
            servExportadorAvaliacaoCSV = new ServExportadorAvaliacaoCSV(ConfigurationManager.AppSettings["CaminhoExportacaoCSV"]);
        }

        [Test]
        public void a_ExportarAvaliacao()
        {
            if (repositorioAvaliacaoAluno.ListarTudo().Count() == 0)
            {
                AvaliacaoAlunoTeste avaliacaoAlunoTeste = new AvaliacaoAlunoTeste();
                avaliacaoAlunoTeste.CargaInicial();
            }
            AvaliacaoAluno avaliacaoAluno = repositorioAvaliacaoAluno.ListarTudo().FirstOrDefault();
            Assert.IsTrue(servExportadorAvaliacaoCSV.Execute(avaliacaoAluno));
        }
    
    }
}
