using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Dominio.Servicos;
using SAISurvey.Dominio.Excecoes;
using SAISurvey.Persistence.nHibernate;
using SAISurvey.Persistence.nHibernate.Controladores;
using SAISurvey.Persistence.nHibernate.Repositorios;
using SAISurvey.Persistence.nHibernate.Servicos;

namespace SAISurvey.Testes
{
    [TestFixture]
    public class UsuarioTeste
    {
        Usuario objeto;
        Usuario objetoRecuperado;
        ControladorUsuario controlador;

        public UsuarioTeste()
        {
            controlador = new ControladorUsuario();
        }

        private Usuario IncluirUsuario()
        {
            Usuario usuario = new Usuario();
            usuario.Login = "ana.moreira";
            usuario.Nome = "ANA CAROLINA MOREIRA";
            usuario.Senha = "ana1982";
            return usuario;
        }

        public Boolean CargaInicial()
        {
            Boolean erro = false;
            try
            {
                Usuario usuario = new Usuario();
                usuario.Login = "carlos.meireles";
                usuario.Nome = "CARLOS HENRIQUE MEIRELES CORBO";
                usuario.Senha = "nqbx2009";
                usuario.Administrador = "S";
                controlador.Adicionar(usuario);
                controlador.Adicionar(IncluirUsuario());
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
            objeto = controlador.ObterPorLogin("tmscorbo");
            if (objeto != null)
                controlador.Excluir(objeto);

            objeto = new Usuario();
            objeto.Login = "tmscorbo";
            objeto.Nome = "TATIANE MOREIRA DA SILVA CORBO";
            objeto.Senha = "12345";
            objeto.Administrador = "S";
            controlador.Adicionar(objeto);
            objetoRecuperado = controlador.ObterPorID(objeto.ID);
            Assert.AreSame(objeto, objetoRecuperado);
        }

        [Test]
        public void b_Alterar_Usuario()
        {
            objeto = controlador.ObterPorLogin("jose.corbo");
            if (objeto != null)
                controlador.Excluir(objeto);

            objeto = controlador.ObterPorLogin("ana.moreira");

            if (objeto == null)
            {
                Usuario usuario = IncluirUsuario();
                controlador.Adicionar(usuario);
                objeto = controlador.ObterPorLogin("ana.moreira");
            }

            Assert.IsNotNull(objeto);

            objeto.Nome = "JOSÉ CARLOS CORBO";
            objeto.Login = "jose.corbo";
            controlador.Atualizar(objeto);
            objetoRecuperado = controlador.ObterPorLogin("jose.corbo");
            Assert.AreSame(objeto, objetoRecuperado);
        }

        [Test]
        public void d_Validar_Acesso_Usuario_Inexistente()
        {
            objeto = controlador.ObterPorLogin("glebson.gonzaga");

            if (objeto != null)
                controlador.Excluir(objeto);

            Assert.Throws<ExUsuarioNaoEncontrado>(delegate { controlador.ValidarAcessoSistema("glebson.gonzaga", "mbox"); });
        }

        [Test]
        public void e_Validar_Acesso_Usuario_Senha_Invalida()
        {
            objeto = controlador.ObterPorLogin("ana.moreira");
            if (objeto == null)
            {
                objeto = IncluirUsuario();
                controlador.Adicionar(objeto);
            }

            Assert.Throws<ExSenhaUsuarioInvalida>(delegate { controlador.ValidarAcessoSistema("ana.moreira", "ana1980"); });
        }

        [Test]
        public void f_Validar_Acesso_Usuario_Nao_Administrador()
        {
            objeto = controlador.ObterPorLogin("ana.moreira");
            if (objeto == null)
            {
                objeto = IncluirUsuario();
                controlador.Adicionar(objeto);
            }

            Assert.Throws<ExUsuarioNaoAdministrador>(delegate { controlador.ValidarAcessoSistema("ana.moreira", "ana1982"); });
        }

        [Test]
        public void g_Validar_Gravacao_Usuario_Duplicidade_Login()
        {
            ConectionManager conexao = new ConectionManager();
            RepositorioUsuario repositorio = new RepositorioUsuario(conexao);

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
            ConectionManager conexao = new ConectionManager();
            RepositorioUsuario repositorio = new RepositorioUsuario(conexao);

            objeto = new Usuario();
            Assert.Throws<ExLoginNaoInformado>(delegate { repositorio.Adicionar(objeto); });
        }

        [Test]
        public void g_Validar_Gravacao_Usuario_Senha_Nao_Informado()
        {
            ConectionManager conexao = new ConectionManager();
            RepositorioUsuario repositorio = new RepositorioUsuario(conexao);

            objeto = new Usuario();
            objeto.Login = "jcoliv";

            Assert.Throws<ExSenhaNaoInformada>(delegate { repositorio.Adicionar(objeto); });
        }


    }
}
