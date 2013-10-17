<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlterarSenhaUsuario.aspx.cs" Inherits="SAISurvey.Web.Administracao.Pages.AlterarSenhaUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 766px;
        }
        .style2
        {
        }
        .style3
        {
            width: 302px;
        }
        .style4
        {
            width: 137px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>
        Alterar senha do usuário
    </h2>
    <table class="style1">
    <tr>
        <td class="style4">
            ID</td>
        <td class="style3">
            <asp:Label ID="lbID" runat="server" CssClass="textEntry" Text="ID"></asp:Label>
        </td>
        <td class="style3">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style4">
            Login</td>
        <td class="style3">
            <asp:Label ID="lbLogin" runat="server" CssClass="textEntry" 
                Text="Login"></asp:Label>
        </td>
        <td class="style3">
            &nbsp;</td>
    </tr>
        <tr>
        <td class="style4">
            Nome</td>
        <td class="style3">
            <asp:Label ID="lbNome" runat="server" CssClass="textEntry" 
                Text="Nome"></asp:Label>
        </td>
        <td class="style3">
            &nbsp;</td>
    </tr>
    
    <tr>
        <td class="style4">
            Administrador</td>
        <td class="style3">
            <asp:Label ID="lbAdministrador" runat="server" CssClass="textEntry" 
                Text="Administrador"></asp:Label>
        </td>
        <td class="style3">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style4">
            
            Senha nova</td>
        <td>
            
            <asp:TextBox ID="txtSenha" runat="server" CausesValidation="True" 
                CssClass="textEntry" MaxLength="20" TextMode="Password" Width="288px"></asp:TextBox>
            
        </td>
        <td>
            
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtSenha" CssClass="LabelValidation" 
                ErrorMessage="rfvSenhaNovaRequerida">Nova senha não informada</asp:RequiredFieldValidator>
            
        </td>
    </tr>
    <tr>
        <td class="style4">
            
            Confirma nova senha
            
        </td>
        <td>
            
            <asp:TextBox ID="txtConfirmaSenha" runat="server" CausesValidation="True" 
                MaxLength="20" TextMode="Password" Width="286px"></asp:TextBox>
            
        </td>
        <td>
            
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtSenha" CssClass="LabelValidation" 
                ErrorMessage="rfvConfirmaSenhaRequerida">Confirmação de senha não preenchida.</asp:RequiredFieldValidator>
            
        </td>
    </tr>
    <tr>
        <td colspan="3" class="style2">
            
            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                ControlToCompare="txtSenha" ControlToValidate="txtConfirmaSenha" 
                CssClass="LabelValidation" ErrorMessage="cvSenhasNaoConferem">Senhas não conferem</asp:CompareValidator>
            
            <br />
            <asp:Label ID="lbMessagem" runat="server" CssClass="LabelValidation" 
                Text="lbMessagem" Visible="False"></asp:Label>
            
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:Button ID="btnGravar" runat="server" Text="Gravar"  Width="64px" 
                onclick="btnGravar_Click" />
            &nbsp;<asp:Button ID="btnVoltar" runat="server" Text="Voltar"  Width="64px" 
                onclick="btnVoltar_Click" />
        </td>
    </tr>
    </table>


</asp:Content>
