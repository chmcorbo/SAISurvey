<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="SAISurvey.Web.Administracao.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 59%;
        }
        .style2
        {
        }
        .style3
        {
            width: 14px;
        }
        .style4
        {
            width: 94px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Login</h2>
    <p>
        Entre com seu login e senha.</p>
<table class="style1">
    <tr>
        <td class="style4">
            Usuário</td>
        <td class="style3">
            <asp:TextBox ID="txtLogin" runat="server" MaxLength="20" Width="218px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="rfvUsuarioRequerido" runat="server" 
                ControlToValidate="txtLogin" CssClass="LabelValidation" 
                ErrorMessage="RequiredFieldValidator">Usuário não informado</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style4">
            Senha</td>
        <td class="style3">
            <asp:TextBox ID="txtSenha" runat="server" MaxLength="10" TextMode="Password" 
                ToolTip="Digite sua senha" Width="218px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtSenha" CssClass="LabelValidation" 
                ErrorMessage="RequiredFieldValidator">Senha não informada</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style2" colspan="3">
            <asp:Label ID="lbMensagem" runat="server" CssClass="LabelValidation" 
                Text="lbMensagem" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style4">
            &nbsp;</td>
        <td class="style3">
            <asp:Button ID="btnLogin" runat="server" CssClass="submitButton" 
                onclick="btnLogin_Click" Text="Entrar" Width="86px" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
