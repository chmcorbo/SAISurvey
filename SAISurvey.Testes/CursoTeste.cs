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
    public class CursoTeste
    {
        Curso objeto;
        Curso objetoRecuperado;
        ControladorCurso controlador;

        public CursoTeste()
        {
            controlador = new ControladorCurso();
        }

        private Curso Incluir_Curso_Engenharia_Software_NET()
        {
            return Incluir_Curso_Com_Bloco_Com_Modulo();
        }

        private Curso Incluir_Curso_Governanca_TI()
        {
            objeto = new Curso() { Descricao = "MBA em Governança e Melhores Práticas da TI" };
            objeto.AdicionarBloco("Governança de Infraestrutura da TI")
                .AdicionarModulo("Segurança e Continuidade")
                .AdicionarModulo("Modalidades de Sourcing")
                .AdicionarModulo("Sistema de Gestão da Qualidade")
                .AdicionarModulo("Gerenciamento de Serviços de TI");
            
            objeto.AdicionarBloco("Governança de Desenvolvimento de Software")
                .AdicionarModulo("Qualidade de Software")
                .AdicionarModulo("Qualidade na Gestão do Desenvolvimento")
                .AdicionarModulo("Gestão de Processos");

            objeto.AdicionarBloco("Gerência de Projetos")
                .AdicionarModulo("Gestão de Integração e Escopo")
                .AdicionarModulo("Gestão de Tempo, Custo e Qualidade")
                .AdicionarModulo("Gestão de Aquisições e Riscos")
                .AdicionarModulo("Gestão de Comunicação, RH e Aspectos Comportamentais");

            objeto.AdicionarBloco("TI e Negócios")
                .AdicionarModulo("TI e Estratégia")
                .AdicionarModulo("Governança e Controle em TI");

            controlador.Adicionar(objeto);
            return objeto;
        }

        private Curso Incluir_Curso_Gestao_Sistema_Informacao()
        {
            objeto = new Curso() { Descricao = "MBA em Gestão de Sistemas de Informação com SAP" };

            objeto.AdicionarBloco("Gestão de Resultados")
                .AdicionarModulo("TI e Estratégia")
                .AdicionarModulo("Gerenciamento de Processos de Negócios - BPM")
                .AdicionarModulo("Gestão de Pessoas - Mudanças Organizacionais");
            
            objeto.AdicionarBloco("Processos Organizacionais Estratégicos")
                .AdicionarModulo("Gerenciamento de Projetos")
                .AdicionarModulo("Gestão da Implantação de Sistemas de Informação")
                .AdicionarModulo("Processos Organizacionais");

            objeto.AdicionarBloco("ERP SAP")
                .AdicionarModulo("Metodologia ASAP")
                .AdicionarModulo("RH - Recursos Humanos")
                .AdicionarModulo("MM - Gestão de Material")
                .AdicionarModulo("SD - Vendas e Distribuição")
                .AdicionarModulo("PP - Planejamento de Produção")
                .AdicionarModulo("FI - Finanças")
                .AdicionarModulo("CO- Contabilidade")
                .AdicionarModulo("BI - Business Intelligence");

            controlador.Adicionar(objeto);
            return objeto;

        }

        public Boolean CargaInicial()
        {
            Boolean erro = false;
            try
            {
                Incluir_Curso_Engenharia_Software_NET();
                Incluir_Curso_Governanca_TI();
                Incluir_Curso_Gestao_Sistema_Informacao();
            }
            catch
            {
                erro = true;
            }

            return !erro;
        }

        public Curso Incluir_Cursos_Sem_Bloco()
        {
            objeto = new Curso() { Descricao = "MIT em Gestão de Bancos de Dados com Oracle" };
            controlador.Adicionar(objeto);
            return objeto;
        }

        public Curso Incluir_Curso_Com_Bloco_Sem_Modulo()
        {
            objeto = new Curso() { Descricao = "MBA em Gestão de Sistemas de Informação com SAP" };
            objeto.AdicionarBloco("Gestão de Resultados");
            objeto.AdicionarBloco("Processos Organizacionais Estratégicos");
            controlador.Adicionar(objeto);
            return objeto;
        }

        public Curso Incluir_Curso_Com_Bloco_Com_Modulo()
        {
            objeto = new Curso() { Descricao = "MIT em Engenharia de Software com .NET" };
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
            controlador.Adicionar(objeto);
            return objeto;
        }

        [Test]
        public void a_Incluir_Cursos_Sem_Bloco()
        {
            objeto = Incluir_Cursos_Sem_Bloco();
            objetoRecuperado = controlador.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }

        [Test]
        public void b_Incluir_Cursos_Com_Bloco_Sem_Modulo()
        {
            objeto = Incluir_Curso_Com_Bloco_Sem_Modulo();
            objetoRecuperado = controlador.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }

        [Test]
        public void d_Incluir_Cursos_Com_Bloco_Com_Modulo()
        {
            objeto = Incluir_Curso_Com_Bloco_Com_Modulo();
            objetoRecuperado = controlador.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }

        [Test]
        public void e_Atualizar_Curso()
        {
            objeto = controlador.ObterPorDescricao("MBA em Gestão de Sistemas de Informação com SAP").FirstOrDefault();
            
            if (objeto == null)
                objeto = Incluir_Curso_Com_Bloco_Sem_Modulo();

            objeto.Descricao = "MBA em Gestão de Sistemas de Informação com TOTVS";

            controlador.Atualizar(objeto);

            objetoRecuperado = controlador.ObterPorID(objeto.ID);

            Assert.AreEqual(objeto.Descricao, objetoRecuperado.Descricao);
        }

        [Test]
        public void f_Atualizar_Bloco_de_Curso()
        {
            objeto = controlador.ObterPorDescricao("MBA em Gestão de Sistemas de Informação com SAP").FirstOrDefault();
            if (objeto == null)
                objeto = Incluir_Curso_Com_Bloco_Sem_Modulo();

            Bloco bloco = objeto.Blocos.FirstOrDefault();

            objeto.ExcluirBloco(bloco.Descricao);

            objeto.AdicionarBloco("ERP SAP");

            controlador.Atualizar(objeto);

            Bloco blocoRecuperado = objeto.Blocos.Where(c => c.Descricao == "ERP SAP").FirstOrDefault();

            Assert.AreEqual("ERP SAP", blocoRecuperado.Descricao);
        }

        [Test]
        public void g_Excluir_Bloco_de_Curso()
        {
            objeto = controlador.ListarTudo().Where(c => c.Descricao == "MBA em Gestão de Sistemas de Informação com SAP").FirstOrDefault();
            if (objeto == null)
                objeto = Incluir_Curso_Com_Bloco_Sem_Modulo();

            objeto.ExcluirBloco("Processos Organizacionais Estratégicos");

            controlador.Atualizar(objeto);

            Bloco bloco = objeto.Blocos.Where(b => b.Descricao == "Processos Organizacionais Estratégicos").FirstOrDefault();

            Assert.IsNull(bloco);
        }


        [Test]
        public void h_Excluir_Curso()
        {
            objeto = Incluir_Curso_Com_Bloco_Sem_Modulo();
            objetoRecuperado = controlador.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
            controlador.Excluir(objeto);
            objetoRecuperado = controlador.ObterPorID(objeto.ID);
            Assert.Null(objetoRecuperado);
        }



    }
}
