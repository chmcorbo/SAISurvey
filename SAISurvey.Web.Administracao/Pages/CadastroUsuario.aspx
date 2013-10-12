<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroUsuario.aspx.cs" Inherits="SAISurvey.Web.Administracao.Pages.CadastroUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>
        Cadastro de Usuário
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
                Login</td>
            <td class="style2">
                <asp:TextBox ID="txtLogin" runat="server" Width="358px" 
                    CssClass="textEntry" MaxLength="20"></asp:TextBox>
            </td>
            <td style="margin-left: 40px">
                <asp:RequiredFieldValidator ID="rfvLoginRequerido" runat="server" 
                  ControlToValidate="txtLogin" CssClass="LabelValidation" 
                  ErrorMessage="RequiredFieldValidator">Login não informado</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Nome</td>
            <td class="style2">
                <asp:TextBox ID="txtNome" runat="server" Width="360px" 
                    CssClass="textEntry" MaxLength="50"></asp:TextBox>
            </td>
            <td style="margin-left: 40px">
                <asp:RequiredFieldValidator ID="rfvNomeRequerido" runat="server" 
                  ControlToValidate="txtNome" CssClass="LabelValidation" 
                  ErrorMessage="RequiredFieldValidator">Nome de usuário não informado</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Administrador</td>
            <td class="style2">
                <asp:DropDownList ID="ddlAdministrador" runat="server">
                    <asp:ListItem Value="S">Sim</asp:ListItem>
                    <asp:ListItem Selected="True" Value="N">Não</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="margin-left: 40px">
                &nbsp;</td>
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
