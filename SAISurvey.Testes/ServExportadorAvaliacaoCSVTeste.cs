using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Dominio.Servicos;
using SAISurvey.Persistence.nHibernate;
using SAISurvey.Persistence.nHibernate.Repositorios;
using SAISurvey.Persistence.nHibernate.Servicos;
using NUnit.Framework;
using System.Configuration;

namespace SAISurvey.Testes
{
    [TestFixture]
    public class ServExportadorAvaliacaoCSVTeste
    {
        ConectionManager _conexao;
        IRepositorioGenerico<AvaliacaoAluno> repositorio;
        IRepositorioGenerico<AvaliacaoAluno> repositorioAvaliacaoAluno;
        IServExportadorAvaliacaoCSV servExportadorAvaliacaoCSV;

        public ServExportadorAvaliacaoCSVTeste()
        {
            _conexao = new ConectionManager();
            repositorio = new RepositorioGenerico<AvaliacaoAluno>(_conexao);
            repositorioAvaliacaoAluno = new RepositorioGenerico<AvaliacaoAluno>(_conexao);
            servExportadorAvaliacaoCSV = new ServExportadorAvaliacaoCSV(ConfigurationManager.AppSettings["CaminhoExportacaoCSV"]);
        }

        [Test]
        public void a_ExportarAvaliacao()
        {
            AvaliacaoAlunoTeste avaliacaoAlunoTeste = new AvaliacaoAlunoTeste();
            AvaliacaoAluno avaliacaoAluno = avaliacaoAlunoTeste.IncluirAvaliacaoAluno();
            Assert.IsTrue(servExportadorAvaliacaoCSV.Execute(avaliacaoAluno));
        }
    
    }
}
