<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsAvaliacao.aspx.cs" Inherits="SAISurvey.Web.Administracao.Pages.ConsAvaliacao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>
        Pesquisar Avaliação
    </h2>
    <table class="style1">
        <tr>
            <td>
                Período
            </td>
            <td class="style2">
                <asp:TextBox ID="txtDataInicial" runat="server" Width="115px">01/01/2013</asp:TextBox>
            </td>
            <td> à </td>
            <td class="style2">
                <asp:TextBox ID="txtDataFinal" runat="server" Width="115px">31/12/2013</asp:TextBox>
            </td>

            <td>
                <asp:Button ID="btnProcurar" runat="server" CssClass="submitButton" 
                    Text="Procurar" onclick="btnProcurar_Click" />
                <asp:Button ID="btnNovo" runat="server" Text="Novo" 
                    Width="71px" onclick="btnNovo_Click" />
            </td>
        </tr>
    </table>
    <br /> 
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" Width="918px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Objetivo" HeaderText="Objetivo" />
                <asp:BoundField DataField="Turma.Modulo.Bloco.Curso.Descricao" 
                    HeaderText="Curso" />
                <asp:BoundField DataField="Turma.Descricao" HeaderText="Turma" />
                <asp:BoundField DataField="Data_Inicio" HeaderText="Data Inicial" />
                <asp:BoundField DataField="Data_Fim" HeaderText="Data Final" />
                <asp:HyperLinkField DataNavigateUrlFields="ID" 
                    DataNavigateUrlFormatString="~/Pages/CadastroAvaliacao.aspx?id={0}" 
                    HeaderText="Operação 1" Text="Editar" />
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
