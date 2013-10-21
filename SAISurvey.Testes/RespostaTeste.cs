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
    public class RespostaTeste
    {
        RepositorioResposta repositorio;
        Resposta resposta;
        Resposta respostaRecuperada;

        public RespostaTeste()
        {
            repositorio = new RepositorioResposta();
        }

        public Boolean CargaInicial()
        {
            Boolean erro = false;
            try
            {
                resposta = new Resposta();
                resposta.Descricao = "Concordo totalmente";
                repositorio.Adicionar(resposta);

                resposta = new Resposta();
                resposta.Descricao = "Concordo";
                repositorio.Adicionar(resposta);

                resposta = new Resposta();
                resposta.Descricao = "Não concordo nem discordo";
                repositorio.Adicionar(resposta);

                resposta = new Resposta();
                resposta.Descricao = "Discordo";
                repositorio.Adicionar(resposta);

                resposta = new Resposta();
                resposta.Descricao = "Discordo totalmente";
                repositorio.Adicionar(resposta);

                resposta = new Resposta();
                resposta.Descricao = "Não sei avaliar";
                repositorio.Adicionar(resposta);
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
            repositorio.Adicionar(resposta);
            respostaRecuperada = repositorio.ObterPorID(resposta.ID);
            Assert.AreSame(resposta, respostaRecuperada);
        }

        [Test]
        public void b_Alterar_Resposta()
        {
            if (repositorio.ListarTudo().Count() == 0)
                CargaInicial();

            resposta = repositorio.ListarTudo().LastOrDefault();
            resposta.Descricao = "Satisfeitíssimo";
            repositorio.Atualizar(resposta);
            respostaRecuperada = repositorio.ObterPorID(resposta.ID);
            Assert.AreEqual(resposta.Descricao, respostaRecuperada.Descricao);
        }

        [Test]
        public void c_Excluir_Resposta()
        {
            if (repositorio.ListarTudo().Count() == 0)
                CargaInicial();

            resposta = repositorio.ListarTudo().LastOrDefault();
            repositorio.Excluir(resposta);
            respostaRecuperada = repositorio.ObterPorID(resposta.ID);
            Assert.IsNull(respostaRecuperada);
        }
    }
}
