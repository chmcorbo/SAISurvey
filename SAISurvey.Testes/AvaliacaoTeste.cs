using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SAISurvey.Dominio.Excecoes;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate;
using SAISurvey.Persistence.nHibernate.Repositorios;

namespace SAISurvey.Testes
{
    [TestFixture]
    public class AvaliacaoTeste 
    {
        ConectionManager conexao = new ConectionManager();
        IRepositorioAvaliacao repositorio;
        IRepositorioTurma repositorioTurma;
        IRepositorioGenerico<Questao> repositorioQuestao;
        Avaliacao objeto;
        Avaliacao objetoRecuperado;

        public AvaliacaoTeste()
        {
            conexao = new ConectionManager();
            repositorio = new RepositorioAvaliacao(conexao);
            repositorioTurma = new RepositorioTurma();
            repositorioQuestao = new RepositorioQuestao();
        }

        public void VerificaTurmaCadastrada()
        {
            if (repositorioTurma.ListarTudo().Count() == 0)
            {
                TurmaTeste turmaTeste = new TurmaTeste();
                turmaTeste.Incluir_Turmas();
            }
        }

        private void VerificaQuestoesCadastradas()
        {
            if (repositorioQuestao.ListarTudo().Count() == 0)
            {
                QuestaoTeste questaoTeste = new QuestaoTeste();
                questaoTeste.CargaInicial();
            }
        }

        private Avaliacao IncluirAvaliacaoSemTurmaSemQuestoes()
        {
            Avaliacao avaliacao = new Avaliacao();
            avaliacao.Objetivo = "Pesquisa de satisfação";
            avaliacao.Data_Inicio = DateTime.Parse("24/10/2013");
            avaliacao.Data_Fim = DateTime.Parse("09/01/2014");
            return avaliacao;
        }

        private Avaliacao IncluirAvaliacaoSemTurmaComQuestoes()
        {
            Avaliacao avaliacao = new Avaliacao();
            avaliacao.Objetivo = "Pesquisa de satisfação";
            avaliacao.Data_Inicio = DateTime.Parse("10/10/2013");
            avaliacao.Data_Fim = DateTime.Parse("25/10/2013");
            avaliacao.Questoes = repositorioQuestao.ListarTudo().ToList();
            return avaliacao;
        }

        private Avaliacao IncluirAvaliacaoComTurmaSemQuestoes()
        {
            VerificaTurmaCadastrada();
            RepositorioCurso repositorioCurso = new RepositorioCurso();
            Avaliacao avaliacao = new Avaliacao();
            avaliacao.Objetivo = "Pesquisa de satisfação";
            avaliacao.Data_Inicio = DateTime.Parse("21/10/2013 08:00:00");
            avaliacao.Data_Fim = DateTime.Parse("05/11/2013 23:59:00");
            avaliacao.Turma = repositorioTurma.ListarTudo().FirstOrDefault();
            return avaliacao;
        }

        private Avaliacao IncluirAvaliacaoComTurmaComQuestoes()
        {
            IRepositorioGenerico<Questao> repositorioQuestao = new RepositorioGenerico<Questao>();
            RepositorioCurso repositorioCurso = new RepositorioCurso();
            if (repositorioQuestao.ListarTudo().Count() == 0)
            {
                QuestaoTeste questaoTeste = new QuestaoTeste();
                questaoTeste.CargaInicial();
            }

            Avaliacao avaliacao = new Avaliacao();
            avaliacao.Objetivo = "Pesquisa de satisfação";
            avaliacao.Data_Inicio = DateTime.Parse("22/10/2013 08:00:00");
            avaliacao.Data_Fim = DateTime.Parse("31/10/2013 23:59:00");
            avaliacao.Questoes = repositorioQuestao.ListarTudo().ToList();
            avaliacao.Turma = repositorioTurma.ListarTudo().FirstOrDefault();
            return avaliacao;
        }

        public Avaliacao IncluirAvaliacao()
        {
            return IncluirAvaliacaoComTurmaComQuestoes();
        }

        public Boolean CargaInicial()
        {
            repositorio.Adicionar(IncluirAvaliacao());
            return true;
        }

        [Test]
        public void a_IncluirAvaliacaoSemTurmaSemQuestoes()
        {
            objeto = IncluirAvaliacaoSemTurmaSemQuestoes();
            repositorio.Adicionar(objeto);
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }

        [Test]
        public void b_IncluirAvaliacaoSemTurmaComQuestoes()
        {
            objeto = IncluirAvaliacaoSemTurmaComQuestoes();
            repositorio.Adicionar(objeto);
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
            Assert.IsTrue(objetoRecuperado.Questoes.Count() > 0);
        }

        [Test]
        public void c_IncluirAvaliacaoComTurmaSemQuestoes()
        {
            objeto = IncluirAvaliacaoComTurmaSemQuestoes();
            repositorio.Adicionar(objeto);
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
            Assert.IsNotNull(objetoRecuperado.Turma);
        }

        [Test]
        public void d_IncluirAvaliacaoComTurmaComQuestoes()
        {
            objeto = IncluirAvaliacaoComTurmaComQuestoes();
            repositorio.Adicionar(objeto);
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
            Assert.IsTrue(objetoRecuperado.Questoes.Count() > 0);
            Assert.IsNotNull(objetoRecuperado.Turma);
        }

        [Test]
        public void e_Alterar_Avaliacao()
        {
            IRepositorioGenerico<Questao> repositorioQuestao = new RepositorioGenerico<Questao>();
            objeto = IncluirAvaliacaoComTurmaSemQuestoes();
            repositorio.Adicionar(objeto);
            String id = objeto.ID;
            objeto.Objetivo = "Identificar oportunidades de melhorias";
            objeto.Questoes = repositorioQuestao.ListarTudo().ToList();
            repositorio.Atualizar(objeto);
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreEqual(objetoRecuperado.Objetivo, objeto.Objetivo);
            Assert.AreEqual(objetoRecuperado.Questoes.Count(), repositorioQuestao.ListarTudo().Count());
            /*******************************************************************/
        }

        [Test]
        public void f_Alterar_Avaliacao_Sem_Turma()
        {
            /*******************************************************************/
            IRepositorioGenerico<Questao> repositorioQuestao = new RepositorioGenerico<Questao>();
            objeto = IncluirAvaliacaoSemTurmaComQuestoes();
            Assert.Throws<ExAvaliacaoSemTurma>(delegate { repositorio.Adicionar(objeto);});
            /*******************************************************************/
        }

        [Test]
        public void g_Alterar_Avaliacao_Periodo_Invalido()
        {
            /*******************************************************************/
            IRepositorioGenerico<Questao> repositorioQuestao = new RepositorioGenerico<Questao>();
            objeto = IncluirAvaliacaoComTurmaComQuestoes();
            objeto.Data_Inicio = null;
            Assert.Throws<ExAvaliacaoPeriodoInvalido>(delegate { repositorio.Adicionar(objeto); });
            /*******************************************************************/
        }

        [Test]
        public void h_Alterar_Avaliacao_Sem_Objetivo()
        {
            /*******************************************************************/
            IRepositorioGenerico<Questao> repositorioQuestao = new RepositorioGenerico<Questao>();
            objeto = IncluirAvaliacaoComTurmaComQuestoes();
            objeto.Objetivo = String.Empty;
            Assert.Throws<ExAvaliacaoPeriodoInvalido>(delegate { repositorio.Adicionar(objeto); });
            /*******************************************************************/
        }

        [Test]
        public void i_Alterar_Avaliacao_Sem_Questoes()
        {
            /*******************************************************************/
            IRepositorioGenerico<Questao> repositorioQuestao = new RepositorioGenerico<Questao>();
            objeto = IncluirAvaliacaoComTurmaSemQuestoes();
            Assert.Throws<ExAvaliacaoPeriodoInvalido>(delegate { repositorio.Adicionar(objeto); });
            /*******************************************************************/
        }


        [Test]
        public void j_Excluir_AvaliacaoSemTurmaSemQuestões()
        {
            objeto = IncluirAvaliacaoSemTurmaSemQuestoes();
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            repositorio.Excluir(objeto);
            Assert.IsNull(repositorio.ObterPorID(objeto.ID));
        }

        [Test]
        public void l_Excluir_AvaliacaoSemTurmaComQuestões()
        {
            objeto = IncluirAvaliacaoSemTurmaComQuestoes();
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            repositorio.Excluir(objeto);
            Assert.IsNull(repositorio.ObterPorID(objeto.ID));
        }

        [Test]
        public void m_Excluir_AvaliacaoComTurmaSemQuestões()
        {
            objeto = IncluirAvaliacaoComTurmaSemQuestoes();
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            repositorio.Excluir(objeto);
            Assert.IsNull(repositorio.ObterPorID(objeto.ID));
        }
        
        [Test]
        public void n_Excluir_AvaliacaoComTurmaComQuestões()
        {
            objeto = IncluirAvaliacaoComTurmaComQuestoes();
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            repositorio.Excluir(objeto);
            Assert.IsNull(repositorio.ObterPorID(objeto.ID));
        }
    }
}
