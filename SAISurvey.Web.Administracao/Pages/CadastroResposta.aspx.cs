﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAISurvey.Web.Administracao.IPages;
using SAISurvey.Web.Administracao.Modelo;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate.Repositorios;

namespace SAISurvey.Web.Administracao.Pages
{
    public partial class CadastroResposta : System.Web.UI.Page, IPaginaCadastroPadrao<Resposta>
    {
        private TipoOperacaoUsuario _operacao = TipoOperacaoUsuario.Incluir;
        private String _id = String.Empty;
        private IRepositorioResposta _repositorio;
        private Resposta _objeto;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != "0")
                {
                    _id = Request.QueryString["id"];
                    _operacao = TipoOperacaoUsuario.Editar;
                    _repositorio = new RepositorioResposta();
                    _objeto = _repositorio.ObterPorID(_id);
                }
                else
                {
                    _operacao = TipoOperacaoUsuario.Incluir;
                    _objeto = new Resposta();
                }
                Session["operacaoUsuario"] = _operacao;
                Session["resposta"] = _objeto;
                BindToUI(_objeto);
            }
        }

        public void BindToUI(Resposta pObjeto)
        {
            lbID.Text = pObjeto.ID;
            txtDescricao.Text = pObjeto.Descricao;
        }

        public Resposta BindToModel()
        {
            Resposta resposta = (Resposta)Session["resposta"];
            resposta.Descricao = txtDescricao.Text;
            return resposta;
        }

        public void Gravar(Resposta pObjeto)
        {
            _repositorio = new RepositorioResposta();
            _operacao = (TipoOperacaoUsuario)Session["operacaoUsuario"];
            if (_operacao == TipoOperacaoUsuario.Incluir)
                _repositorio.Adicionar(pObjeto);
            else
                _repositorio.Atualizar(pObjeto);
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                _objeto = BindToModel();
                Gravar(_objeto);
                btnVoltar_Click(sender, e);
            }
            catch (Exception ex)
            {
                lbMessagem.Visible = true;
                lbMessagem.Text = ex.Message;
            }

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/ConsRespostas.aspx");
        }
    }
}