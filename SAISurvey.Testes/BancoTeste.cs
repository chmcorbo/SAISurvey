using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Persistence.nHibernate.Repositorio;
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
    }
}
