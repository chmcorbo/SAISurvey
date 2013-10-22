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
    public class AvaliacaoAlunoTeste
    {

        IRepositorioGenerico<AvaliacaoAluno> repositorio;
        AvaliacaoAluno objeto;
        AvaliacaoAluno objetoRecuperado;


        public AvaliacaoAlunoTeste()
        {
            repositorio = new RepositorioGenerico<AvaliacaoAluno>();
        }

        public AvaliacaoAluno IncluirAvaliacao()
        {
            RepositorioAluno repositorioAluno = new RepositorioAluno();
            if (repositorioAluno.ListarTudo().Count() == 0)
            {
                AlunoTeste alunoTeste = new AlunoTeste();
                alunoTeste.CargaInicial();
            }
            /***************************************************************************/
            RepositorioResposta repositorioResposta = new RepositorioResposta();
            if (repositorioResposta.ListarTudo().Count() == 0)
            {
                RespostaTeste respostaTeste = new RespostaTeste();
                respostaTeste.CargaInicial();
            }
            /***************************************************************************/
            AvaliacaoTeste avaliacaoTeste = new AvaliacaoTeste();
            Avaliacao avaliacao = avaliacaoTeste.IncluirAvaliacao();
            RepositorioAvaliacao repositorioAvalicao = new RepositorioAvaliacao();
            repositorioAvalicao.Adicionar(avaliacao);
            /***************************************************************************/
            objeto = new AvaliacaoAluno();
            objeto.Aluno = repositorioAluno.ListarTudo().First();
            objeto.Avaliacao = avaliacao;
            objeto.Comentarios = "Secretaria atende de forma ineficiente.";
            /***************************************************************************/
            return objeto;
        }
        private void IncluirQuestoes(AvaliacaoAluno pAvaliacaoAluno)
        {
            Int32 contador = 0;

            RepositorioResposta repositorioResposta = new RepositorioResposta();
            List<Resposta> respostas = repositorioResposta.ListarTudo().ToList();

            foreach (Questao questao in objeto.Avaliacao.Questoes)
            {
                Resposta resposta = respostas.Skip(contador).Take(1).FirstOrDefault();
                objeto.AdicionarRespostaQuestao(questao, resposta);
                contador++;
                if (contador > 5)
                    contador = 0;
            }
        }

        public Boolean CargaInicial()
        {
            Boolean _erro = true;
            objeto = IncluirAvaliacao();
            IncluirQuestoes(objeto);
            repositorio.Adicionar(objeto);
            _erro = false;
            return !_erro;
        }

        [Test]
        public void a_Incluir_AvaliacaoAluno()
        {
            objeto = IncluirAvaliacao();
            IncluirQuestoes(objeto);
            repositorio.Adicionar(objeto);
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }

        [Test]
        public void b_Alterar_AvaliacaoAluno()
        {
            objeto = IncluirAvaliacao();
            IncluirQuestoes(objeto);
            repositorio.Adicionar(objeto);
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            RepositorioResposta repositorioResposta = new RepositorioResposta();
            List<Resposta> respostas = repositorioResposta.ListarTudo().ToList();
            Int32 contador = 0;
            foreach (Questao questao in objetoRecuperado.Avaliacao.Questoes)
            {
                Resposta resposta = respostas.Reverse<Resposta>().Skip(contador).Take(1).FirstOrDefault();
                objetoRecuperado.AdicionarRespostaQuestao(questao, resposta);
                contador++;
                if (contador > 5)
                    contador = 0;
            }
            repositorio.Atualizar(objetoRecuperado);
            objeto = repositorio.ObterPorID(objetoRecuperado.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }
    }
}
