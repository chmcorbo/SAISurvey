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
    public class ModuloTeste
    {
        RepositorioModulo repositorio;
        Modulo objeto = null;
        Modulo objetoRecuperado = null;

        public ModuloTeste()
        {
            repositorio = new RepositorioModulo();
        }

        public Curso Incluir_Curso()
        {
            RepositorioCurso repositorioCurso = new RepositorioCurso();
            Curso curso = new Curso() { Descricao = "MIT em Engenharia de Software com .NET" };
            Bloco bloco = curso.AdicionarBloco("Engenharia de software");
            bloco = curso.AdicionarBloco("Desenvolvimento Orientado a Objetos com .NET");
            bloco = curso.AdicionarBloco("Desenvolvimento Web com .NET");
            bloco = curso.AdicionarBloco("Fechamento");
            repositorioCurso.Adicionar(curso);
            return curso;
        }

        public void Incluir_Modulo()
        {
            /*Curso curso = new Curso() { Descricao = "MIT em Engenharia de Software com .NET" };

            Bloco bloco = curso.AdicionarBloco("Engenharia de software");

            objeto = new Modulo(bloco);
            objeto.


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
            return objeto;*/

        }

        public void a_Inclusao_Modulo()
        {
            /*Curso curso;
            RepositorioCurso repositorioCurso = new RepositorioCurso();

            curso = repositorioCurso.ObterPorDescricao("MIT em Engenharia de Software com .NET").FirstOrDefault();

            if (curso == null)
            {
                CursoTeste cursoTeste = new CursoTeste();
                curso = cursoTeste.Incluir_Curso_Com_Bloco_Com_Modulo();
            }

            objeto = new Modulo(
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
            */

        }

    }
}
