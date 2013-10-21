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
        IRepositorioProfessor repositorio;
        Professor objeto;
        Professor objetoRecuperado;

        public ProfessorTeste()
        {
            repositorio = new RepositorioProfessor();
        }

        public Boolean CargaInicial()
        {
            Boolean erro = false;

            try
            {
                objeto = new Professor();
                objeto.Matricula = "100001";
                objeto.Nome = "Ubirajara Júnior";
                repositorio.Adicionar(objeto);

                objeto = new Professor();
                objeto.Matricula = "100002";
                objeto.Nome = "Carlos Pedro Muniz";
                repositorio.Atualizar(objeto);

                objeto = new Professor();
                objeto.Matricula = "100003";
                objeto.Nome = "Michael Santana Cardoso";
                repositorio.Atualizar(objeto);

                objeto = new Professor();
                objeto.Matricula = "100004";
                objeto.Nome = "Anderson Padro Ramos";
                repositorio.Atualizar(objeto);

                objeto = new Professor();
                objeto.Matricula = "100005";
                objeto.Nome = "Elias do Amaral Ventura";
                repositorio.Atualizar(objeto);
            }
            catch
            {
                erro = true;
            }
            return !erro;
        }

        [Test]
        public void a_Obter_Professor_por_ID()
        {
            if (repositorio.ListarTudo().Count() == 0)
                CargaInicial();
            objeto = repositorio.ListarTudo().FirstOrDefault();
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }

    }
}
