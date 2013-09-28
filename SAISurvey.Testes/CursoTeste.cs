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
    public class CursoTeste
    {
        IRepositorioGenerico<Curso> repositorio;
        Curso objeto;
        Curso objetoRecuperado;

        public CursoTeste()
        {
            repositorio = new RepositorioGenerico<Curso>();
        }

        public Curso Incluir_Cursos_Sem_Bloco_Sem_Modulo()
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
            objeto = new Curso() { Descricao = "MIT em Engenharia de Software com .NET" };
            Bloco bloco = objeto.AdicionarBloco("Engenharia de software");
            bloco.AdicionarModulo("Engenharia de Software aplicada");
            bloco.AdicionarModulo("Processos de Desenvolvimento de Software:");
            bloco.AdicionarModulo("Métricas de Desenvolvimento de Software:");
            
           
            bloco = objeto.AdicionarBloco("Desenvolvimento Orientado a Objetos com .NET");
            bloco.AdicionarModulo("Análise e Projeto de Sistemas Orientados a Objetos");
            bloco.AdicionarModulo("Programação Orientada a Objetos com C#");
            bloco.AdicionarModulo("Desenvolvimento de Aplicações com .NET");
            bloco.AdicionarModulo("Persistência de Dados com .NET");


            bloco = objeto.AdicionarBloco("Desenvolvimento Web com .NET");
            bloco.AdicionarModulo("Desenvolvimento de Aplicações Web com .NET");
            bloco.AdicionarModulo("Desenvolvimento Web com WCF e WWF");
            bloco.AdicionarModulo("Tópicos Avançados");

            bloco = objeto.AdicionarBloco("Fechamento");
            bloco.AdicionarModulo("TCC");

            repositorio.Adicionar(objeto);
            return objeto;
        }

        [Test]
        public void a_Incluir_Cursos_Sem_Bloco_Sem_Modulo()
        {
            objeto = Incluir_Cursos_Sem_Bloco_Sem_Modulo();
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
        public void c_Incluir_Curso_Com_Bloco_Com_Modulo()
        {
            objeto = Incluir_Curso_Com_Bloco_Com_Modulo();
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }

        [Test]
        public void d_Atualizar_Curso()
        {
            objeto = repositorio.ListarTudo().Where(c => c.Descricao == "MBA em Gestão de Sistemas de Informação com SAP").FirstOrDefault();
            if (objeto == null)
                objeto = Incluir_Curso_Com_Bloco_Sem_Modulo();

            objeto.Descricao = "MBA em Gestão de Sistemas de Informação com TOTVS";

            repositorio.Atualizar(objeto);

            objetoRecuperado = repositorio.ObterPorID(objeto.ID);

            Assert.AreEqual(objeto.Descricao, objetoRecuperado.Descricao);
        }

        [Test]
        public void e_Excluir_Curso()
        {
            objeto=Incluir_Curso_Com_Bloco_Com_Modulo();
            /*foreach (Bloco bloco in objeto.Blocos)
            {
                foreach (Modulo modulo in bloco.Modulos)
                {
                    bloco.ExcluirModulo(modulo.Descricao);
                    repositorio.Atualizar(objeto);
                }
                objeto.ExcluirBloco(bloco.Descricao);
                repositorio.Atualizar(objeto);
            }*/
            repositorio.Excluir(objeto);
        }

        [Test]
        public void f_Atualizar_Bloco_de_Curso()
        {
            objeto = repositorio.ListarTudo().Where(c => c.Descricao == "MBA em Gestão de Sistemas de Informação com SAP").FirstOrDefault();
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
        public void h_Atualizar_Modulo_Bloco_Curso()
        {
            // Criar um método para atualizar bloco e atualizar módulo.

            objeto = repositorio.ListarTudo().Where(c => c.Descricao == "MIT em Engenharia de Software com .NET").FirstOrDefault();
            if (objeto == null)
                objeto = Incluir_Curso_Com_Bloco_Com_Modulo();

            
            Modulo modulo = objeto.Blocos.Where(b => b.Descricao == "Fechamento").FirstOrDefault().Modulos.Where(m => m.Descricao=="TCC").FirstOrDefault();
        }

    }
}
