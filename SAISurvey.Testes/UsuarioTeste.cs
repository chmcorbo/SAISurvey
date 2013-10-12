using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Dominio.Servicos;
using SAISurvey.Dominio.Excecoes;
using SAISurvey.Persistence.nHibernate.Repositorios;
using SAISurvey.Persistence.nHibernate.Servicos;

namespace SAISurvey.Testes
{
    [TestFixture]
    public class UsuarioTeste
    {
        Usuario objeto;
        Usuario objetoRecuperado;
        RepositorioUsuario repositorio;

        public UsuarioTeste()
        {
            repositorio = new RepositorioUsuario();
        }

        private Usuario IncluirUsuario()
        {
            Usuario usuario = new Usuario();
            usuario.Login = "ana.moreira";
            usuario.Nome = "ANA CAROLINA MOREIRA";
            usuario.Senha = "ana1982";
            return usuario;
        }

        public Boolean IncluirUsuarios()
        {
            Boolean erro = false;
            try
            {
                Usuario usuario = new Usuario();
                usuario.Login = "carlos.meireles";
                usuario.Nome = "CARLOS HENRIQUE MEIRELES CORBO";
                usuario.Senha = "nqbx2009";
                usuario.Administrador = "S";
                repositorio.Adicionar(usuario);
                repositorio.Adicionar(IncluirUsuario());
            }
            catch 
            {
                erro = true;
            }
            return !erro;
        }


        [Test]
        public void a_Incluir_Usuario()
        {
            objeto = IncluirUsuario();
            repositorio.Adicionar(objeto);
            objetoRecuperado = repositorio.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }

        [Test]
        public void b_Alterar_Usuario()
        {
            if (repositorio.ObterPorLogin("ana.moreira")==null)
            {
                Usuario usuario = IncluirUsuario();
                repositorio.Adicionar(usuario);
            }
            objeto = repositorio.ObterPorLogin("ana.moreira");

            Assert.IsNotNull(objeto);

            objeto.Nome = "JOSÉ CARLOS CORBO";
            objeto.Login = "jose.corbo";
            repositorio.Atualizar(objeto);
            objetoRecuperado = repositorio.ObterPorLogin("jose.corbo");
            Assert.AreSame(objeto, objetoRecuperado);
        }

        [Test]
        public void d_Validar_Acesso_Usuario_Inexistente()
        {
            objeto = repositorio.ObterPorLogin("glebson.gonzaga");

            if (objeto != null)
                repositorio.Excluir(objeto);

            IServValidadorAcessoUsuario servValidadorAcessoUsuario = new ServValidadorAcessoUsuario();

            Assert.Throws<ExUsuarioNaoEncontrado>(delegate { servValidadorAcessoUsuario.Execute("glebson.gonzaga","mbox"); });
        }

        [Test]
        public void e_Validar_Acesso_Usuario_Senha_Invalida()
        {
            objeto = repositorio.ObterPorLogin("ana.moreira");
            if (objeto == null)
            {
                objeto = IncluirUsuario();
                repositorio.Adicionar(objeto);
            }
            
            IServValidadorAcessoUsuario servValidadorAcessoUsuario = new ServValidadorAcessoUsuario();

            Assert.Throws<ExSenhaUsuarioInvalida>(delegate { servValidadorAcessoUsuario.Execute("ana.moreira", "ana1980"); });
        }

        [Test]
        public void f_Validar_Acesso_Usuario_Nao_Administrador()
        {
            objeto = repositorio.ObterPorLogin("ana.moreira");
            if (objeto == null)
            {
                objeto = IncluirUsuario();
                repositorio.Adicionar(objeto);
            }

            IServValidadorAcessoUsuario servValidadorAcessoUsuario = new ServValidadorAcessoUsuario();

            Assert.Throws<ExUsuarioNaoAdministrador>(delegate { servValidadorAcessoUsuario.Execute("ana.moreira", "ana1982"); });
        }

        [Test]
        public void g_Validar_Gravacao_Usuario_Duplicidade_Login()
        {
            if (repositorio.ObterPorLogin("ana.moreira") == null)
            {
                Usuario usuario = IncluirUsuario();
                repositorio.Adicionar(usuario);
            }

            objeto = new Usuario();
            objeto.Login = "ana.moreira";
            objeto.Nome = "ANA CAROLINA SOARES MOREIRA";
            objeto.Senha = "1111";

            Assert.Throws<ExLoginExistenteUsuario>(delegate { repositorio.Adicionar(objeto); });
        }

        [Test]
        public void g_Validar_Gravacao_Usuario_Login_Nao_Informado()
        {
            objeto = new Usuario();
            Assert.Throws<ExLoginNaoInformado>(delegate { repositorio.Adicionar(objeto); });
        }

        [Test]
        public void g_Validar_Gravacao_Usuario_Senha_Nao_Informado()
        {
            objeto = new Usuario();
            objeto.Login = "jcoliv";
            Assert.Throws<ExSenhaNaoInformada>(delegate { repositorio.Adicionar(objeto); });
        }


    }
}
