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
            // Falta Incluir turma
            Avaliacao avaliacao = new Avaliacao();
            avaliacao.Objetivo = "Pesquisa de satisfação";
            avaliacao.Data_Inicio = DateTime.Parse("10/10/2013");
            avaliacao.Data_Fim = DateTime.Parse("05/12/2013");
            avaliacao.Questoes = repositorioQuestao.ListarTudo().ToList();
            return avaliacao;
        }

        public Avaliacao IncluirAvaliacaoComTurmaSemQuestoes()
        {
            // Falta Incluir turma
            IRepositorioGenerico<Turma> repositorioTurma = new RepositorioGenerico<Turma>();
            if (repositorioTurma.ListarTudo().Count() == 0)
            {
                TurmaTeste turmaTeste = new TurmaTeste();
                turmaTeste.Incluir_Turmas();
            }
            Turma turma = repositorioTurma.ListarTudo().FirstOrDefault();
            Avaliacao avaliacao = new Avaliacao();
            avaliacao.Objetivo = "Pesquisa de satisfação";
            avaliacao.Data_Inicio = DateTime.Parse("10/10/2013");
            avaliacao.Data_Fim = DateTime.Parse("05/12/2013");
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


    }
}
