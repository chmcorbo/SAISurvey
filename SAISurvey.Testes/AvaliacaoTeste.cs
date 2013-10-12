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

        public Avaliacao IncluirAvaliacaoSemTurmaSemQuestoes()
        {
            Avaliacao avaliacao = new Avaliacao();
            avaliacao.Objetivo = "Pesquisa de satisfação";
            avaliacao.Data_Inicio = DateTime.Parse("24/10/2013");
            avaliacao.Data_Fim = DateTime.Parse("09/01/2014");
            return avaliacao;
        }


        public Avaliacao IncluirAvaliacaoSemTurmaComQuestoes()
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

        public Avaliacao IncluirAvaliacaoComTurmaSemQuestoes()
        {
            IRepositorioGenerico<Questao> repositorioQuestao = new RepositorioGenerico<Questao>();
            if (repositorioQuestao.ListarTudo().Count() == 0)
            {
                QuestaoTeste questaoTeste = new QuestaoTeste();
                questaoTeste.IncluirQuestoes();
            }

            IRepositorioGenerico<Turma> repositorioTurma = new RepositorioGenerico<Turma>();
            if (repositorioTurma.ListarTudo().Count() == 0)
            {
                TurmaTeste turmaTeste = new TurmaTeste();
                turmaTeste.Incluir_Turmas();
            }
            Turma turma = repositorioTurma.ListarTudo().FirstOrDefault();
            Avaliacao avaliacao = new Avaliacao();
            avaliacao.Objetivo = "Pesquisa de satisfação";
            avaliacao.Data_Inicio = DateTime.Parse("21/10/2013");
            avaliacao.Data_Fim = DateTime.Parse("13/01/2014");
            avaliacao.Turma = turma;
            return avaliacao;
        }

        public Avaliacao IncluirAvaliacaoComTurmaComQuestoes()
        {
            IRepositorioGenerico<Turma> repositorioTurma = new RepositorioGenerico<Turma>();
            if (repositorioTurma.ListarTudo().Count() == 0)
            {
                TurmaTeste turmaTeste = new TurmaTeste();
                turmaTeste.Incluir_Turmas();
            }
            Turma turma = repositorioTurma.ListarTudo().FirstOrDefault();
            Avaliacao avaliacao = new Avaliacao();
            avaliacao.Objetivo = "Pesquisa de satisfação";
            avaliacao.Data_Inicio = DateTime.Parse("22/10/2013");
            avaliacao.Data_Fim = DateTime.Parse("11/02/2014");
            avaliacao.Turma = turma;
            return avaliacao;
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
        }

        [Test]
        public void c_IncluirAvaliacaoComTurmaSemQuestoes()
        {
            objeto = IncluirAvaliacaoComTurmaSemQuestoes();
            repositorio.Adicionar(objeto);
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }

        [Test]
        public void d_IncluirAvaliacaoComTurmaComQuestoes()
        {
            objeto = IncluirAvaliacaoComTurmaComQuestoes();
            repositorio.Adicionar(objeto);
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }

        [Test]
        public void e_Alterar_Avaliacao()
        {
            IRepositorioGenerico<Questao> repositorioQuestao = new RepositorioGenerico<Questao>();
            objeto = IncluirAvaliacaoComTurmaSemQuestoes();
            repositorio.Adicionar(objeto);
            String id = objeto.ID;
            objeto.Objetivo = "Identificar oportunidades de melhorias";
            objeto.Turma = null;
            objeto.Questoes = repositorioQuestao.ListarTudo().ToList();
            repositorio.Atualizar(objeto);
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreEqual(objetoRecuperado.Objetivo, objeto.Objetivo);
            Assert.AreEqual(objetoRecuperado.Questoes.Count(), repositorioQuestao.ListarTudo().Count());
            Assert.IsNull(objetoRecuperado.Turma);
            /*******************************************************************/
        }

        [Test]
        public void f_Excluir_Avaliacao()
        {
            objeto = IncluirAvaliacaoComTurmaComQuestoes();
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            repositorio.Excluir(objeto);
            Assert.IsNull(repositorio.ObterPorID(objeto.ID));
        }
    }
}
