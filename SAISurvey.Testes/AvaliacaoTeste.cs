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
    public class AvaliacaoTeste 
    {
        IRepositorioAvaliacao repositorio;
        Avaliacao objeto;
        Avaliacao objetoRecuperado;

        public AvaliacaoTeste()
        {
            repositorio = new RepositorioAvaliacao();
        }

        public Curso IncluirCurso()
        {
            Curso curso = new Curso() { Descricao = "MBA em Gestão Empresarial" };
            RepositorioCurso repositorioCurso = new RepositorioCurso();

            curso.AdicionarBloco("Estratégia")
                .AdicionarModulo("Gestão Estratégica")
                .AdicionarModulo("Planejamento Estratégico")
                .AdicionarModulo("Estratégia em Ação")
                .AdicionarModulo("Gestão Financeira")
                .AdicionarModulo("Comunicação Empresarial (Redação e Apresentação)");

            repositorioCurso.Adicionar(curso);
            return curso;

        }

        public Avaliacao IncluirAvaliacaoSemModuloSemQuestoes()
        {
            Avaliacao avaliacao = new Avaliacao();
            avaliacao.Objetivo = "Pesquisa de satisfação";
            avaliacao.Data_Inicio = DateTime.Parse("24/10/2013");
            avaliacao.Data_Fim = DateTime.Parse("09/01/2014");
            return avaliacao;
        }


        public Avaliacao IncluirAvaliacaoSemModuloComQuestoes()
        {
            IRepositorioGenerico<Questao> repositorioQuestao = new RepositorioGenerico<Questao>();
            if (repositorioQuestao.ListarTudo().Count() == 0)
            {
                QuestaoTeste questaoTeste = new QuestaoTeste();
                questaoTeste.IncluirQuestoes();
            }
            
            Avaliacao avaliacao = new Avaliacao();
            avaliacao.Objetivo = "Pesquisa de satisfação";
            avaliacao.Data_Inicio = DateTime.Parse("10/10/2013");
            avaliacao.Data_Fim = DateTime.Parse("05/12/2013");
            avaliacao.Questoes = repositorioQuestao.ListarTudo().ToList();
            return avaliacao;
        }

        public Avaliacao IncluirAvaliacaoComModuloSemQuestoes()
        {
            IncluirCurso();
            RepositorioCurso repositorioCurso = new RepositorioCurso();
            Avaliacao avaliacao = new Avaliacao();
            avaliacao.Objetivo = "Pesquisa de satisfação";
            avaliacao.Data_Inicio = DateTime.Parse("21/10/2013");
            avaliacao.Data_Fim = DateTime.Parse("13/01/2014");
            avaliacao.Modulo = repositorioCurso.ObterModulosPorDescricao("Gestão Estratégica").FirstOrDefault();
            return avaliacao;
        }

        public Avaliacao IncluirAvaliacaoComModuloComQuestoes()
        {
            IRepositorioGenerico<Questao> repositorioQuestao = new RepositorioGenerico<Questao>();
            RepositorioCurso repositorioCurso = new RepositorioCurso();
            if (repositorioQuestao.ListarTudo().Count() == 0)
            {
                QuestaoTeste questaoTeste = new QuestaoTeste();
                questaoTeste.IncluirQuestoes();
            }

            Avaliacao avaliacao = new Avaliacao();
            avaliacao.Objetivo = "Pesquisa de satisfação";
            avaliacao.Data_Inicio = DateTime.Parse("22/10/2013");
            avaliacao.Data_Fim = DateTime.Parse("11/02/2014");
            avaliacao.Questoes = repositorioQuestao.ListarTudo().ToList();
            avaliacao.Modulo = repositorioCurso.ObterModulosPorDescricao("Planejamento Estratégico").FirstOrDefault(); ;
            return avaliacao;
        }

        [Test]
        public void a_IncluirAvaliacaoSemModuloSemQuestoes()
        {
            objeto = IncluirAvaliacaoSemModuloSemQuestoes();
            repositorio.Adicionar(objeto);
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }


        [Test]
        public void b_IncluirAvaliacaoSemModuloComQuestoes()
        {
            objeto = IncluirAvaliacaoSemModuloComQuestoes();
            repositorio.Adicionar(objeto);
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
            Assert.IsTrue(objetoRecuperado.Questoes.Count() > 0);
        }

        [Test]
        public void c_IncluirAvaliacaoComModuloSemQuestoes()
        {
            objeto = IncluirAvaliacaoComModuloSemQuestoes();
            repositorio.Adicionar(objeto);
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
            Assert.IsNotNull(objetoRecuperado.Modulo);
        }

        [Test]
        public void d_IncluirAvaliacaoComModuloComQuestoes()
        {
            objeto = IncluirAvaliacaoComModuloComQuestoes();
            repositorio.Adicionar(objeto);
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
            Assert.IsTrue(objetoRecuperado.Questoes.Count() > 0);
            Assert.IsNotNull(objetoRecuperado.Modulo);
        }

        [Test]
        public void e_Alterar_Avaliacao()
        {
            IRepositorioGenerico<Questao> repositorioQuestao = new RepositorioGenerico<Questao>();
            objeto = IncluirAvaliacaoComModuloSemQuestoes();
            repositorio.Adicionar(objeto);
            String id = objeto.ID;
            objeto.Objetivo = "Identificar oportunidades de melhorias";
            objeto.Modulo = null;
            objeto.Questoes = repositorioQuestao.ListarTudo().ToList();
            repositorio.Atualizar(objeto);
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreEqual(objetoRecuperado.Objetivo, objeto.Objetivo);
            Assert.AreEqual(objetoRecuperado.Questoes.Count(), repositorioQuestao.ListarTudo().Count());
            Assert.IsNull(objetoRecuperado.Modulo);
            /*******************************************************************/
        }


        [Test]
        public void f_Excluir_AvaliacaoSemModuloSemQuestões()
        {
            objeto = IncluirAvaliacaoSemModuloSemQuestoes();
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            repositorio.Excluir(objeto);
            Assert.IsNull(repositorio.ObterPorID(objeto.ID));
        }

        [Test]
        public void f_Excluir_AvaliacaoSemModuloComQuestões()
        {
            objeto = IncluirAvaliacaoSemModuloComQuestoes();
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            repositorio.Excluir(objeto);
            Assert.IsNull(repositorio.ObterPorID(objeto.ID));
        }


        [Test]
        public void f_Excluir_AvaliacaoComModuloSemQuestões()
        {
            objeto = IncluirAvaliacaoComModuloSemQuestoes();
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            repositorio.Excluir(objeto);
            Assert.IsNull(repositorio.ObterPorID(objeto.ID));
        }
        
        
        [Test]
        public void f_Excluir_AvaliacaoComModuloComQuestões()
        {
            objeto = IncluirAvaliacaoComModuloComQuestoes();
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            repositorio.Excluir(objeto);
            Assert.IsNull(repositorio.ObterPorID(objeto.ID));
        }
    }
}
