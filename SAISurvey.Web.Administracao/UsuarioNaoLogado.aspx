<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioNaoLogado.aspx.cs" Inherits="SAISurvey.Web.Administracao.UsuárioNaoLogado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<p>
  &nbsp;</p>
    <p style="text-align: center">
        <asp:Label ID="Label1" runat="server" CssClass="failureNotification" 
            Text="Usuário não logado no sistema"></asp:Label>
</p>
    <p style="text-align: center">
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Voltar" />
</p>
</asp:Content>
