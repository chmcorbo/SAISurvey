﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate.Repositorios;
using SAISurvey.Web.Administracao.Modelo;
using SAISurvey.Web.Administracao.IPages;

namespace SAISurvey.Web.Administracao.Pages
{
    public partial class EditarQuestao : System.Web.UI.Page
    {
        private TipoOperacaoUsuario _operacao = TipoOperacaoUsuario.Incluir;
        private String _id = String.Empty;
        private IRepositorioQuestao _repositorio;
        private Questao _objeto;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != "0")
                {
                    _id = Request.QueryString["id"];
                    _operacao = TipoOperacaoUsuario.Editar;
                    _repositorio = new RepositorioQuestao();
                    _objeto = _repositorio.ObterPorID(_id);
                }
                else
                {
                    _operacao = TipoOperacaoUsuario.Incluir;
                    _objeto = new Questao();
                }
                Session["operacaoUsuario"]=_operacao;
                Session["questao"]=_objeto;
                BindToUI(_objeto);
            }
        }

        private void BindToUI(Questao pObjeto)
        {
            lbID.Text = pObjeto.ID;
            txtDescricao.Text = pObjeto.Descricao;
        }

        private Questao BindToModel()
        {
            Questao questao = (Questao)Session["questao"];
            questao.Descricao = txtDescricao.Text;
            return questao;
        }

        private void Gravar(Questao pObjeto)
        {
            _repositorio = new RepositorioQuestao();
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
            Response.Redirect("~/Pages/ConsQuestoes.aspx");
        }
    }
}