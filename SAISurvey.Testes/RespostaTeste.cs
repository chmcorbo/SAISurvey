using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate.Repositorio;


namespace SAISurvey.Testes
{
    [TestFixture]
    public class RespostaTeste
    {
        IRepositorioGenerico<Resposta> repositorio;
        Resposta resposta;
        Resposta respostaRecuperada;

        public RespostaTeste()
        {
            repositorio = new RepositorioGenerico<Resposta>();
        }

        public void IncluirResposta()
        {
            resposta = new Resposta();
            resposta.Descricao = "Totalmente insatisfeito";
            repositorio.Atualizar(resposta);

            resposta = new Resposta();
            resposta.Descricao = "Insatisfeito";
            repositorio.Atualizar(resposta);

            resposta = new Resposta();
            resposta.Descricao = "Não tenho como avaliar";
            repositorio.Atualizar(resposta);

            resposta = new Resposta();
            resposta.Descricao = "Satisfeito";
            repositorio.Atualizar(resposta);
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
                IncluirResposta();

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
                IncluirResposta();

            resposta = repositorio.ListarTudo().LastOrDefault();
            repositorio.Excluir(resposta);
            respostaRecuperada = repositorio.ObterPorID(resposta.ID);
            Assert.IsNull(respostaRecuperada);
        }
    }
}
