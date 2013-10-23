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

namespace SAISurvey.Testes
{
    [TestFixture]
    public class ServEnviarConviteAvaliacaoTeste
    {
        IServEnviarConviteAvaliacao servEnviarConviteAvaliacao;
        IRepositorioAvaliacao repositorioAvaliacao;
        public ServEnviarConviteAvaliacaoTeste()
        {
            servEnviarConviteAvaliacao = new ServEnviarConviteAvaliacao();
            repositorioAvaliacao = new RepositorioAvaliacao();
        }

        [Test]
        public void EnviarConvite()
        {
            if (repositorioAvaliacao.ListarTudo().Count() == 0)
            {
                AvaliacaoTeste avaliacaoTeste = new AvaliacaoTeste();
                avaliacaoTeste.IncluirAvaliacao();
            }
            Assert.IsTrue(servEnviarConviteAvaliacao.Execute(DateTime.Now));
        }
    }
}
