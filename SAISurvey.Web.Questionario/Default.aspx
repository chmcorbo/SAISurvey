<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SAISurvey.Web.Questionario._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
    {
        width: 86%;
    }
    .style2
    {
        width: 73px;
    }
</style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>
    <table class="style1">
        <tr>
            <td class="style2">
                Curso</td>
            <td>
                <asp:Label ID="lbCurso" runat="server" Text="lbCurso"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Módulo</td>
            <td>
                <asp:Label ID="lbModulo" runat="server" Text="lbModulo"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Turma</td>
            <td>
                <asp:Label ID="lbTurma" runat="server" Text="lbTurma"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Aluno</td>
            <td>
                <asp:Label ID="lbAluno" runat="server" Text="lbAluno"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Professor</td>
            <td>
                <asp:Label ID="lbProfessor" runat="server" Text="lbProfessor"></asp:Label>
            </td>
        </tr>
</table>
    
    <br />


    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" DataSourceID="ObjectDataSource1" GridLines="Vertical" 
        AllowPaging="True" PageSize="6">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:BoundField DataField="ID" Visible="False" />
            <asp:BoundField DataField="Questao.Descricao" HeaderText="Questão" 
                SortExpression="ID" />
            <asp:TemplateField HeaderText="Concordo Totalmente">
                <HeaderTemplate>
                    <asp:Label ID="lbResposta1" runat="server" Text="lbResposta1"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:RadioButton Visible="true" ID="rbResposta1"  runat="server" GroupName="Resposta" 
                    AutoPostBack="false" OnCheckedChanged="rbResposta_CheckedChanged"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Concordo">
                <HeaderTemplate>
                    <asp:Label ID="lbResposta2" runat="server" Text="lbResposta2"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:RadioButton ID="rbResposta2" runat="server" GroupName="Resposta" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Não concordo nem discordo">
                <HeaderTemplate>
                    <asp:Label ID="lbResposta3" runat="server" Text="lbResposta3"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:RadioButton ID="rbResposta3" runat="server" GroupName="Resposta" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Discordo">
                <HeaderTemplate>
                    <asp:Label ID="lbResposta4" runat="server" Text="lbResposta4"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:RadioButton ID="rbResposta4" runat="server" GroupName="Resposta" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Discordo Totalmente">
                <HeaderTemplate>
                    <asp:Label ID="lbResposta5" runat="server" Text="lbResposta5"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:RadioButton ID="rbResposta5" runat="server" GroupName="Resposta" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Não sei avaliar">
                <HeaderTemplate>
                    <asp:Label ID="lbResposta6" runat="server" Text="lbResposta6"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:RadioButton ID="rbResposta6" runat="server" GroupName="Resposta" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="ListarQuestoes" TypeName="SAISurvey.Web.Questionario._Default">
    </asp:ObjectDataSource>
    <br />
    <table class="style1">
        <tr>
            <td>
                <asp:Button ID="btnSalvarContinuar" runat="server" Text="Salvar e continuar" 
                    Width="200px" />
            </td>
            <td>
                <asp:Button ID="btnSalvarFechar" runat="server" Text="Salvar e fechar" 
                    Width="200px" />
            </td>
            <td>
                <asp:Button ID="btnSalvarEncerrar" runat="server" Text="Salvar e encerrar" 
                    Width="200px" />
            </td>
            <td>
                <asp:Button ID="btnDescartarResponderDepois" runat="server" 
                    Text="Descartar e responder depois" Width="200px" 
                    onclick="btnDescartarResponderDepois_Click" />
            </td>
        </tr>
    </table>


</asp:Content>
