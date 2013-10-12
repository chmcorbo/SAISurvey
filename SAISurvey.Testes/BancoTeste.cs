﻿using System;
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
        public void b_Incluir_Usuario()
        {
            UsuarioTeste usuarioTeste = new UsuarioTeste();
            Assert.IsTrue(usuarioTeste.IncluirUsuarios());
        }
    }
}
