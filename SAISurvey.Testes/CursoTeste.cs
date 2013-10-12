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
    public class CursoTeste
    {
        RepositorioCurso repositorio;
        Curso objeto;
        Curso objetoRecuperado;

        public CursoTeste()
        {
            repositorio = new RepositorioCurso();
        }

        public Curso Incluir_Cursos_Sem_Bloco()
        {
            objeto = new Curso() { Descricao = "MIT em Gestão de Bancos de Dados com Oracle" };
            repositorio.Adicionar(objeto);
            return objeto;
        }

        public Curso Incluir_Curso_Com_Bloco_Sem_Modulo()
        {
            objeto = new Curso() { Descricao = "MBA em Gestão de Sistemas de Informação com SAP" };
            objeto.AdicionarBloco("Gestão de Resultados");
            objeto.AdicionarBloco("Processos Organizacionais Estratégicos");
            repositorio.Adicionar(objeto);
            return objeto;
        }

        public Curso Incluir_Curso_Com_Bloco_Com_Modulo()
        {
            objeto = new Curso() { Descricao = "Pós-graduação MIT em Engenharia de Software com .NET" };
            objeto.AdicionarBloco("Engenharia de Software")
                .AdicionarModulo("Engenharia de Software Aplicada")
                .AdicionarModulo("Processos de Desenvolvimento de Software")
                .AdicionarModulo("Métricas de Desenvolvimento de Software")
                .AdicionarModulo("Fechamento");
            objeto.AdicionarBloco("Desenvolvimento Orientado a Objetos com .NET")
                .AdicionarModulo("Análise e Projeto de Sistemas Orientados a Objetos")
                .AdicionarModulo("Programação Orientada a Objetos com C#")
                .AdicionarModulo("Desenvolvimento de Aplicações com .NET")
                .AdicionarModulo("Persistência de Dados com .NET");
                
            objeto.AdicionarBloco("Desenvolvimento Web com .NET")
                .AdicionarModulo("Desenvolvimento de Aplicações Web com .NET")
                .AdicionarModulo("Desenvolvimento Web com WCF e WWF")
                .AdicionarModulo("Tópicos Avançados");
            repositorio.Adicionar(objeto);
            return objeto;
        }


        [Test]
        public void a_Incluir_Cursos_Sem_Bloco()
        {
            objeto = Incluir_Cursos_Sem_Bloco();
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }

        [Test]
        public void b_Incluir_Cursos_Com_Bloco_Sem_Modulo()
        {
            objeto = Incluir_Curso_Com_Bloco_Sem_Modulo();
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }

        [Test]
        public void d_Incluir_Cursos_Com_Bloco_Com_Modulo()
        {
            objeto = Incluir_Curso_Com_Bloco_Com_Modulo();
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }


        [Test]
        public void e_Atualizar_Curso()
        {
            objeto = repositorio.ObterPorDescricao("MBA em Gestão de Sistemas de Informação com SAP").FirstOrDefault();
            
            if (objeto == null)
                objeto = Incluir_Curso_Com_Bloco_Sem_Modulo();

            objeto.Descricao = "MBA em Gestão de Sistemas de Informação com TOTVS";

            repositorio.Atualizar(objeto);

            objetoRecuperado = repositorio.ObterPorID(objeto.ID);

            Assert.AreEqual(objeto.Descricao, objetoRecuperado.Descricao);
        }

        [Test]
        public void f_Atualizar_Bloco_de_Curso()
        {
            objeto = repositorio.ObterPorDescricao("MBA em Gestão de Sistemas de Informação com SAP").FirstOrDefault();
            if (objeto == null)
                objeto = Incluir_Curso_Com_Bloco_Sem_Modulo();

            Bloco bloco = objeto.Blocos.FirstOrDefault();

            objeto.ExcluirBloco(bloco.Descricao);

            objeto.AdicionarBloco("ERP SAP");

            repositorio.Atualizar(objeto);

            Bloco blocoRecuperado = objeto.Blocos.Where(c => c.Descricao == "ERP SAP").FirstOrDefault();

            Assert.AreEqual("ERP SAP", blocoRecuperado.Descricao);
        }

        [Test]
        public void g_Excluir_Bloco_de_Curso()
        {
            objeto = repositorio.ListarTudo().Where(c => c.Descricao == "MBA em Gestão de Sistemas de Informação com SAP").FirstOrDefault();
            if (objeto == null)
                objeto = Incluir_Curso_Com_Bloco_Sem_Modulo();

            objeto.ExcluirBloco("Processos Organizacionais Estratégicos");

            repositorio.Atualizar(objeto);

            Bloco bloco = objeto.Blocos.Where(b => b.Descricao == "Processos Organizacionais Estratégicos").FirstOrDefault();

            Assert.IsNull(bloco);
        }


        [Test]
        public void h_Excluir_Curso()
        {
            objeto = Incluir_Curso_Com_Bloco_Sem_Modulo();
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
            repositorio.Excluir(objeto);
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.Null(objetoRecuperado);
        }



    }
}
