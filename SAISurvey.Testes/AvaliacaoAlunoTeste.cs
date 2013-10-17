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
                alunoTeste.IncluirAlunos();
            }

            RepositorioResposta repositorioResposta = new RepositorioResposta();

            if (repositorioResposta.ListarTudo().Count() == 0)
            {
                RespostaTeste respostaTeste = new RespostaTeste();
                respostaTeste.IncluirResposta();
            }

            AvaliacaoTeste avaliacaoTeste = new AvaliacaoTeste();
            Avaliacao avaliacao = avaliacaoTeste.IncluirAvaliacaoComModuloComQuestoes();
            RepositorioAvaliacao repositorioAvalicao = new RepositorioAvaliacao();
            repositorioAvalicao.Adicionar(avaliacao);

            objeto = new AvaliacaoAluno();
            objeto.Aluno = repositorioAluno.ListarTudo().First();
            objeto.Avaliacao = avaliacao;


            return objeto;
        }

        [Test]
        public void a_Incluir_AvaliacaoAluno()
        {
            objeto = IncluirAvaliacao();

            Int32 contador = 0;
            RepositorioResposta repositorioResposta = new RepositorioResposta();
            List<Resposta> respostas = repositorioResposta.ListarTudo().ToList();

            foreach (Questao questao in objeto.Avaliacao.Questoes)
            {
                respostas = respostas.Skip(contador).Take(1).ToList();
                Resposta resposta = respostas.Skip(contador).Take(1).FirstOrDefault();
                objeto.AdicionarRespostaQuestao(questao, resposta);
            }

            repositorio.Adicionar(objeto);
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }

        [Test]
        public void b_Alterar_AvaliacaoAluno()
        {
            objeto = IncluirAvaliacao();

            Int32 contador = 0;
            RepositorioResposta repositorioResposta = new RepositorioResposta();
            List<Resposta> respostas = repositorioResposta.ListarTudo().ToList();

            foreach (Questao questao in objeto.Avaliacao.Questoes)
            {
                Resposta resposta = respostas.Skip(contador).Take(1).FirstOrDefault();
                objeto.AdicionarRespostaQuestao(questao, resposta);
            }

            repositorio.Atualizar(objeto);

            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }
    }
}
