<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsUsuarios.aspx.cs" Inherits="SAISurvey.Web.Administracao.Pages.ConsUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Pesquisar Usuários
    </h2>
    <table class="style1">
        <tr>
            <td>
                Nome</td>
            <td class="style2">
                <asp:TextBox ID="txtNome" runat="server" Width="359px"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnProcurar" runat="server" CssClass="submitButton" 
                    Text="Procurar" onclick="btnProcurar_Click" />
                <asp:Button ID="btnNovo" runat="server" Text="Novo" 
                    Width="71px" onclick="btnNovo_Click" />
            </td>
        </tr>
    </table>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" Width="567px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Login" HeaderText="Login" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:HyperLinkField DataNavigateUrlFields="ID" 
                    DataNavigateUrlFormatString="~/Pages/CadastroUsuario.aspx?id={0}" 
                    HeaderText="Operação 1" Text="Editar" />
                <asp:HyperLinkField DataNavigateUrlFields="id" 
                    DataNavigateUrlFormatString="~/Pages/ExcluirUsuario.aspx?id={0}" 
                    HeaderText="Operação 2" Text="Excluir" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>

</asp:Content>
