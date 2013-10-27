using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Controladores;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate;
using SAISurvey.Persistence.nHibernate.Controladores;
using SAISurvey.Persistence.nHibernate.Repositorios;

namespace SAISurvey.Testes
{
    [TestFixture]
    public class ProfessorTeste
    {
        Professor objeto;
        Professor objetoRecuperado;
        IControladorGenerico<Professor> controlador;

        public ProfessorTeste()
        {
            controlador = new ControladorGenerico<Professor>();
        }

        private Professor IncluirProfessor()
        {
            Professor professor = new Professor();
            professor.Matricula = "100001";
            professor.Nome = "Ubirajara Júnior";
            return professor;
        }

        public Boolean CargaInicial()
        {
            Boolean erro = false;

            try
            {
                objeto = IncluirProfessor();
                controlador.Adicionar(objeto);

                objeto = new Professor();
                objeto.Matricula = "100002";
                objeto.Nome = "Carlos Pedro Muniz";
                controlador.Adicionar(objeto);

                objeto = new Professor();
                objeto.Matricula = "100003";
                objeto.Nome = "Michael Santana Cardoso";
                controlador.Adicionar(objeto);

                objeto = new Professor();
                objeto.Matricula = "100004";
                objeto.Nome = "Anderson Padro Ramos";
                controlador.Adicionar(objeto);

                objeto = new Professor();
                objeto.Matricula = "100005";
                objeto.Nome = "Elias do Amaral Ventura";
                controlador.Adicionar(objeto);
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
            objeto = IncluirProfessor();
            controlador.Adicionar(objeto);
            objetoRecuperado = controlador.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }
    }
}
