﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SAISurvey.Dominio.Excecoes;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate;
using SAISurvey.Persistence.nHibernate.Controladores;
using SAISurvey.Persistence.nHibernate.Repositorios;

namespace SAISurvey.Testes
{
    [TestFixture]
    public class AvaliacaoTeste 
    {
        Avaliacao objeto;
        Avaliacao objetoRecuperado;
        
        ConectionManager conexao = new ConectionManager();
        ControladorAvaliacao controlador;
        IRepositorioTurma repositorioTurma;
        IRepositorioQuestao repositorioQuestao;

        public AvaliacaoTeste()
        {
            controlador = new ControladorAvaliacao();
            conexao = new ConectionManager();
            repositorioTurma = new RepositorioTurma(conexao);
            repositorioQuestao = new RepositorioQuestao(conexao);
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
            RepositorioCurso repositorioCurso = new RepositorioCurso(conexao);
            Avaliacao avaliacao = new Avaliacao();
            avaliacao.Objetivo = "Pesquisa de satisfação";
            avaliacao.Data_Inicio = DateTime.Parse("21/10/2013 08:00:00");
            avaliacao.Data_Fim = DateTime.Parse("05/11/2013 23:59:00");
            avaliacao.Turma = repositorioTurma.ListarTudo().FirstOrDefault();
            return avaliacao;
        }

        private Avaliacao IncluirAvaliacaoComTurmaComQuestoes()
        {
            RepositorioCurso repositorioCurso = new RepositorioCurso(conexao);
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
            controlador.Adicionar(IncluirAvaliacao());
            return true;
        }

        [Test]
        public void a_IncluirAvaliacaoSemTurmaSemQuestoes()
        {
            objeto = IncluirAvaliacaoSemTurmaSemQuestoes();
            controlador.Adicionar(objeto);
            objetoRecuperado = controlador.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }

        [Test]
        public void b_IncluirAvaliacaoSemTurmaComQuestoes()
        {
            IRepositorioAvaliacao repositorio = new RepositorioAvaliacao(conexao);
            objeto = IncluirAvaliacaoSemTurmaComQuestoes();
            Assert.Throws<ExAvaliacaoSemTurma>(delegate { repositorio.Adicionar(objeto); });
        }

        [Test]
        public void c_IncluirAvaliacaoComTurmaSemQuestoes()
        {
            IRepositorioAvaliacao repositorio = new RepositorioAvaliacao(conexao);
            objeto = IncluirAvaliacaoComTurmaSemQuestoes();
            Assert.Throws<ExAvaliacaoSemTurma>(delegate { repositorio.Adicionar(objeto); });
        }

        [Test]
        public void d_IncluirAvaliacaoComTurmaComQuestoes()
        {
            objeto = IncluirAvaliacaoComTurmaComQuestoes();
            controlador.Adicionar(objeto);
            objetoRecuperado = controlador.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
            Assert.IsTrue(objetoRecuperado.Questoes.Count() > 0);
            Assert.IsNotNull(objetoRecuperado.Turma);
        }

        [Test]
        public void e_Alterar_Avaliacao()
        {
            IRepositorioQuestao repositorioQuestao = new RepositorioQuestao(conexao);
            objeto = IncluirAvaliacaoComTurmaSemQuestoes();
            controlador.Adicionar(objeto);
            String id = objeto.ID;
            objeto.Objetivo = "Identificar oportunidades de melhorias";
            objeto.Questoes = repositorioQuestao.ListarTudo().ToList();
            controlador.Atualizar(objeto);
            objetoRecuperado = controlador.ObterPorID(objeto.ID);
            Assert.AreEqual(objetoRecuperado.Objetivo, objeto.Objetivo);
            Assert.AreEqual(objetoRecuperado.Questoes.Count(), repositorioQuestao.ListarTudo().Count());
            /*******************************************************************/
        }

        [Test]
        public void f_Alterar_Avaliacao_Sem_Turma()
        {
            /*******************************************************************/
            IRepositorioAvaliacao repositorio = new RepositorioAvaliacao(conexao);
            objeto = IncluirAvaliacaoSemTurmaComQuestoes();
            Assert.Throws<ExAvaliacaoSemTurma>(delegate { repositorio.Adicionar(objeto);});
            /*******************************************************************/
        }

        [Test]
        public void g_Alterar_Avaliacao_Periodo_Invalido()
        {
            /*******************************************************************/
            IRepositorioAvaliacao repositorio = new RepositorioAvaliacao(conexao);
            objeto = IncluirAvaliacaoComTurmaComQuestoes();
            objeto.Data_Inicio = null;
            Assert.Throws<ExAvaliacaoPeriodoInvalido>(delegate { repositorio.Adicionar(objeto); });
            /*******************************************************************/
        }

        [Test]
        public void h_Alterar_Avaliacao_Sem_Objetivo()
        {
            /*******************************************************************/
            IRepositorioAvaliacao repositorio = new RepositorioAvaliacao(conexao);
            objeto = IncluirAvaliacaoComTurmaComQuestoes();
            objeto.Objetivo = String.Empty;
            Assert.Throws<ExAvaliacaoPeriodoInvalido>(delegate { repositorio.Adicionar(objeto); });
            /*******************************************************************/
        }

        [Test]
        public void i_Alterar_Avaliacao_Sem_Questoes()
        {
            /*******************************************************************/
            IRepositorioAvaliacao repositorio = new RepositorioAvaliacao(conexao);
            objeto = IncluirAvaliacaoComTurmaSemQuestoes();
            Assert.Throws<ExAvaliacaoPeriodoInvalido>(delegate { repositorio.Adicionar(objeto); });
            /*******************************************************************/
        }


        [Test]
        public void j_Excluir_AvaliacaoSemTurmaSemQuestões()
        {
            objeto = IncluirAvaliacaoSemTurmaSemQuestoes();
            objetoRecuperado = controlador.ObterPorID(objeto.ID);
            controlador.Excluir(objeto);
            Assert.IsNull(controlador.ObterPorID(objeto.ID));
        }

        [Test]
        public void l_Excluir_AvaliacaoSemTurmaComQuestões()
        {
            objeto = IncluirAvaliacaoSemTurmaComQuestoes();
            objetoRecuperado = controlador.ObterPorID(objeto.ID);
            controlador.Excluir(objeto);
            Assert.IsNull(controlador.ObterPorID(objeto.ID));
        }

        [Test]
        public void m_Excluir_AvaliacaoComTurmaSemQuestões()
        {
            objeto = IncluirAvaliacaoComTurmaSemQuestoes();
            objetoRecuperado = controlador.ObterPorID(objeto.ID);
            controlador.Excluir(objeto);
            Assert.IsNull(controlador.ObterPorID(objeto.ID));
        }
        
        [Test]
        public void n_Excluir_AvaliacaoComTurmaComQuestões()
        {
            objeto = IncluirAvaliacaoComTurmaComQuestoes();
            objetoRecuperado = controlador.ObterPorID(objeto.ID);
            controlador.Excluir(objeto);
            Assert.IsNull(controlador.ObterPorID(objeto.ID));
        }
    }
}
