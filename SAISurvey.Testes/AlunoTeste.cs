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
    public class AlunoTeste
    {
        Aluno objeto;
        Aluno objetoRecuperado;
        ControladorGenerico<Aluno> controlador;

        public AlunoTeste()
        {
            controlador = new ControladorGenerico<Aluno>();
        }

        private Aluno IncluirAluno()
        {
            objeto = new Aluno();
            objeto.Matricula = "900001";
            objeto.Nome = "Carlos Henrique Meireles Corbo";
            objeto.Email = "chmcorbo@gmail.com";
            return objeto;
        }

        public Boolean CargaInicial()
        {
            Boolean erro = false;

            try
            {
                objeto = IncluirAluno();
                controlador.Adicionar(objeto);

                objeto = new Aluno();
                objeto.Matricula = "900002";
                objeto.Nome = "Tatiana Moreira da Silva Corbo";
                objeto.Email = "chmeireles@hotmail.com";
                controlador.Adicionar(objeto);

                objeto = new Aluno();
                objeto.Matricula = "900003";
                objeto.Nome = "Ricardo Coelho da Silva";
                objeto.Email = "chmcorbo@gmail.com";
                controlador.Adicionar(objeto);

                objeto = new Aluno();
                objeto.Matricula = "900004";
                objeto.Nome = "Ana Carolina Moreira";
                objeto.Email = "krol.moreira201102@gmail.com";
                controlador.Adicionar(objeto);
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
            objeto = IncluirAluno();
            controlador.Adicionar(objeto);
            objetoRecuperado = controlador.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }
    }
}
