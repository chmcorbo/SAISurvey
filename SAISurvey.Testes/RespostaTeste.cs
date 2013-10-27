using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate;
using SAISurvey.Persistence.nHibernate.Controladores;
using SAISurvey.Persistence.nHibernate.Repositorios;


namespace SAISurvey.Testes
{
    [TestFixture]
    public class RespostaTeste
    {
        Resposta resposta;
        Resposta respostaRecuperada;
        ControladorResposta controlador;

        public RespostaTeste()
        {
            controlador = new ControladorResposta();
        }

        public Boolean CargaInicial()
        {
            Boolean erro = false;
            try
            {
                resposta = new Resposta();
                resposta.Descricao = "Concordo totalmente";
                resposta.Ordem = 1;
                controlador.Adicionar(resposta);

                resposta = new Resposta();
                resposta.Descricao = "Concordo";
                resposta.Ordem = 2;
                controlador.Adicionar(resposta);

                resposta = new Resposta();
                resposta.Descricao = "Não concordo nem discordo";
                resposta.Ordem = 3;
                controlador.Adicionar(resposta);

                resposta = new Resposta();
                resposta.Descricao = "Discordo";
                resposta.Ordem = 4;
                controlador.Adicionar(resposta);

                resposta = new Resposta();
                resposta.Descricao = "Discordo totalmente";
                resposta.Ordem = 5;
                controlador.Adicionar(resposta);

                resposta = new Resposta();
                resposta.Descricao = "Não sei avaliar";
                resposta.Ordem = 6;
                controlador.Adicionar(resposta);
            }
            catch
            {
                erro = true;
            }
            return !erro;
        }

        [Test]
        public void a_Incluir_Resposta()
        {
            resposta = new Resposta();
            resposta.Descricao = "Totalmente satisfeito";
            controlador.Adicionar(resposta);
            respostaRecuperada = controlador.ObterPorID(resposta.ID);
            Assert.AreSame(resposta, respostaRecuperada);
        }

        [Test]
        public void b_Alterar_Resposta()
        {
            if (controlador.ListarTudo().Count() == 0)
                CargaInicial();

            resposta = controlador.ListarTudo().LastOrDefault();
            resposta.Descricao = "Satisfeitíssimo";
            controlador.Atualizar(resposta);
            respostaRecuperada = controlador.ObterPorID(resposta.ID);
            Assert.AreEqual(resposta.Descricao, respostaRecuperada.Descricao);
        }

        [Test]
        public void c_Excluir_Resposta()
        {
            if (controlador.ListarTudo().Count() == 0)
                CargaInicial();

            resposta = controlador.ListarTudo().LastOrDefault();
            controlador.Excluir(resposta);
            respostaRecuperada = controlador.ObterPorID(resposta.ID);
            Assert.IsNull(respostaRecuperada);
        }
    }
}
