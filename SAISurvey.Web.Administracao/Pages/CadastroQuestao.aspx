<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroQuestao.aspx.cs" Inherits="SAISurvey.Web.Administracao.Pages.EditarQuestao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 97%;
        }
        .style2
        {
            width: 342px;
        }
        .textEntry
        {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Cadastro de Questão
    </h2>
    <table class="style1">
        <tr>
            <td>
                ID</td>
            <td class="style2">
                <asp:Label ID="lbID" runat="server" CssClass="textEntry" Text="ID"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Descrição</td>
            <td class="style2">
                <asp:TextBox ID="txtDescricao" runat="server" Width="676px" 
                    CssClass="textEntry" Height="49px" MaxLength="150" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvUsuarioRequerido" runat="server" 
                  ControlToValidate="txtDescricao" CssClass="LabelValidation" 
                  ErrorMessage="RequiredFieldValidator">Descrição não informada</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lbMessagem" runat="server" CssClass="LabelValidation" 
                    Text="lbMessagem" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnGravar" runat="server" Text="Gravar" 
                    onclick="btnGravar_Click" />
            </td>
            <td class="style2">
                <asp:Button ID="btnVoltar" runat="server" CausesValidation="False" 
                    onclick="btnVoltar_Click" Text="Voltar" Width="56px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

</asp:Content>
