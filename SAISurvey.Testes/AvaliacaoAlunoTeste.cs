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
    public class AvaliacaoAlunoTeste
    {
        AvaliacaoAluno objeto;
        AvaliacaoAluno objetoRecuperado;
        ControladorAvaliacaoAluno controlador;
        ConectionManager conexao;
        /*IRepositorioGenerico<AvaliacaoAluno> repositorio;*/
        

        public AvaliacaoAlunoTeste()
        {
            conexao = new ConectionManager();
            controlador = new ControladorAvaliacaoAluno();
        }

        private AvaliacaoAluno NovaAvaliacaoAluno()
        {
            /***************************************************************************/
            RepositorioResposta repositorioResposta = new RepositorioResposta(conexao);
            if (repositorioResposta.ListarTudo().Count() == 0)
            {
                RespostaTeste respostaTeste = new RespostaTeste();
                respostaTeste.CargaInicial();
            }
            /***************************************************************************/
            AvaliacaoTeste avaliacaoTeste = new AvaliacaoTeste();
            Avaliacao avaliacao = avaliacaoTeste.IncluirAvaliacao();
            RepositorioAvaliacao repositorioAvalicao = new RepositorioAvaliacao(conexao);
            repositorioAvalicao.Adicionar(avaliacao);
            /***************************************************************************/
            objeto = new AvaliacaoAluno();
            objeto.Aluno = avaliacao.Turma.Alunos.FirstOrDefault();
            objeto.Avaliacao = avaliacao;
            /***************************************************************************/
            return objeto;
        }
        private void ResponderQuestoes(AvaliacaoAluno pAvaliacaoAluno)
        {
            Int32 contador = 0;

            RepositorioResposta repositorioResposta = new RepositorioResposta(conexao);
            List<Resposta> respostas = repositorioResposta.ListarTudo().ToList();

            foreach (Questao questao in pAvaliacaoAluno.Avaliacao.Questoes)
            {
                Resposta resposta = respostas.Skip(contador).Take(1).FirstOrDefault();
                objeto.AdicionarRespostaQuestao(questao, resposta);
                contador++;
                if (contador > 5)
                    contador = 0;
            }
            pAvaliacaoAluno.Comentarios = "Secretaria atende de forma ineficiente.";
        }

        private void CarregarQuestoesSemResposta(AvaliacaoAluno pAvaliacaoAluno)
        {
            foreach (Questao questao in pAvaliacaoAluno.Avaliacao.Questoes)
            {
                pAvaliacaoAluno.AdicionarRespostaQuestao(questao);
            }
        }

        public AvaliacaoAluno IncluirAvaliacaoAluno()
        {
            AvaliacaoAluno avaliacaoAluno = NovaAvaliacaoAluno();
            ResponderQuestoes(avaliacaoAluno);
            controlador.Adicionar(avaliacaoAluno);
            controlador.Fechar(avaliacaoAluno);
            return avaliacaoAluno;
        }

        public Boolean CargaInicial()
        {
            Boolean _erro = true;
            objeto = NovaAvaliacaoAluno();
            ResponderQuestoes(objeto);
            controlador.Adicionar(objeto);

            objeto = NovaAvaliacaoAluno();
            CarregarQuestoesSemResposta(objeto);
            controlador.Adicionar(objeto);
            _erro = false;
            return !_erro;
        }

        [Test]
        public void a_Incluir_AvaliacaoAluno()
        {
            objeto = NovaAvaliacaoAluno();
            ResponderQuestoes(objeto);
            controlador.Adicionar(objeto);
            objetoRecuperado = controlador.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }

        [Test]
        public void b_Alterar_AvaliacaoAluno()
        {
            objeto = NovaAvaliacaoAluno();
            ResponderQuestoes(objeto);
            controlador.Adicionar(objeto);
            objetoRecuperado = controlador.ObterPorID(objeto.ID);
            RepositorioResposta repositorioResposta = new RepositorioResposta(conexao);
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
            controlador.Atualizar(objetoRecuperado);
            objeto = controlador.ObterPorID(objetoRecuperado.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }
    }
}
