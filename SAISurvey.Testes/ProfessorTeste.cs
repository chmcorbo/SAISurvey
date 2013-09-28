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
    public class ProfessorTeste
    {
        IRepositorioGenerico<Professor> repositorio;
        Professor objeto;
        Professor objetoRecuperado;

        public ProfessorTeste()
        {
            repositorio = new RepositorioGenerico<Professor>();
        }

        public void IncluirProfessores()
        {
            objeto = new Professor();
            objeto.Matricula = "100001";
            objeto.Nome = "Ubirajara Júnior";
            repositorio.Atualizar(objeto);

            objeto = new Professor();
            objeto.Matricula = "100002";
            objeto.Nome = "Carlos Pedro Muniz";
            repositorio.Atualizar(objeto);

        }

        [Test]
        public void a_Obter_Professor_por_ID()
        {
            if (repositorio.ListarTudo().Count() == 0)
                IncluirProfessores();
            objeto = repositorio.ListarTudo().FirstOrDefault();
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }

    }
}
