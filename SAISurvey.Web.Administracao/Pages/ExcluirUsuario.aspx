<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExcluirUsuario.aspx.cs" Inherits="SAISurvey.Web.Administracao.Pages.ExcluirUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 609px;
        }
        .style2
        {
            width: 14px;
        }
        .style3
        {
            width: 238px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>
        Excluir Usuário
    </h2>
    <table class="style1">
    <tr>
        <td class="style2">
            ID</td>
        <td class="style3">
            <asp:Label ID="lbID" runat="server" CssClass="textEntry" Text="ID"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style2">
            Login</td>
        <td class="style3">
            <asp:Label ID="lbLogin" runat="server" CssClass="textEntry" 
                Text="Login"></asp:Label>
        </td>
    </tr>
        <tr>
        <td class="style2">
            Nome</td>
        <td class="style3">
            <asp:Label ID="lbNome" runat="server" CssClass="textEntry" 
                Text="Nome"></asp:Label>
        </td>
    </tr>
    
    <tr>
        <td class="style2">
            Administrador</td>
        <td class="style3">
            <asp:Label ID="lbAdministrador" runat="server" CssClass="textEntry" 
                Text="Administrador"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="Label3" runat="server" CssClass="LabelValidation" 
                Text="Tem certeza que deseja eliminar esse registro?"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button ID="btnSim" runat="server" onclick="btnSim_Click" Text="Sim" 
                Width="64px" />
            <asp:Button ID="btnNao" runat="server" onclick="btnNao_Click" Text="Não" 
                Width="64px" />
        </td>
    </tr>
    </table>
 
</asp:Content>
