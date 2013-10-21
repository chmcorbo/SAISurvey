<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SelecionarQuestoes.aspx.cs" Inherits="SAISurvey.Web.Administracao.Pages.SelecionarQuestoes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <style type="text/css">
        .style1
        {
            width: 60%;
        }
        .style2
        {
            width: 489px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Pesquisar Questões
    </h2>
    <table class="style1">
        <tr>
            <td>
                Descrição</td>
            <td class="style2">
                <asp:TextBox ID="txtDescricao" runat="server" Width="370px"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnProcurar" runat="server" 
                    Text="Procurar" onclick="btnProcurar_Click" Width="62px" />
            </td>
            <td>
                <asp:Button ID="btnVoltar" runat="server" onclick="btnVoltar_Click" 
                    Text="Voltar" />
            </td>
        </tr>
    </table>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="Horizontal" Width="771px" 
            AllowPaging="True" DataSourceID="ObjectDataSource1" PageSize="6">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="cbTituloSelecionado" runat="server" 
                            oncheckedchanged="cbTituloSelecionado_CheckedChanged" Text="Tudo" 
                            AutoPostBack="True" Width="65px" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbLinhaSelecionada" runat="server" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:BoundField DataField="Descricao" HeaderText="Descrição" >
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="ID" HeaderText="ID" >
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
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
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="ObterPorDescricao" 
            TypeName="SAISurvey.Persistence.nHibernate.Repositorios.RepositorioQuestao">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtDescricao" Name="pDescricao" 
                    PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Button ID="btnAdicionarQuestoesSelecionadas" runat="server" 
            onclick="btnAdicionarQuestoesSelecionadas_Click" 
            Text="Adicionar as questões selecionadas na avaliação" Width="307px" />
        <br />
    </div>

</asp:Content>
