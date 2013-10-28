<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SAISurvey.Web.Questionario._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">
        function Check(textBox, maxLength) {
            if (textBox.value.length > maxLength) {
                alert("O texto não poderá superior a " + maxLength + " caracteres");
                textBox.value = textBox.value.substr(0, maxLength);
            }
        }        
    </script>
    <style type="text/css">
        .style1
    {
        width: 86%;
    }
    .style2
    {
        width: 73px;
    }
        .style3
        {
            width: 100%;
        }
        .newStyle1
        {
            border: thin solid #000084;
        }
        .style4
        {
            width: 698px;
        }
        .newStyle2
        {
            border-width: thin;
            border-style: solid;
            border-color: #000084;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table class="newStyle2">
        <tr>
            <td class="style2">
                Curso</td>
            <td class="style4">
                <asp:Label ID="lbCurso" runat="server" Text="lbCurso"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Módulo</td>
            <td class="style4">
                <asp:Label ID="lbModulo" runat="server" Text="lbModulo"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Turma</td>
            <td class="style4">
                <asp:Label ID="lbTurma" runat="server" Text="lbTurma"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Professor</td>
            <td class="style4">
                <asp:Label ID="lbProfessor" runat="server" Text="lbProfessor"></asp:Label>
            </td>
        </tr>
</table>
    
    <br />


    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" DataSourceID="ObjectDataSource1" GridLines="Vertical" 
        AllowPaging="True" PageSize="6" ondatabound="GridView1_DataBound" 
    onpageindexchanging="GridView1_PageIndexChanging">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="hdfID" runat="server" 
                        Value='<%# Eval("Questao.ID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Questao.Descricao" HeaderText="Questão" />
            <asp:TemplateField HeaderText="Resposta1">
                <ItemTemplate>
                    <asp:RadioButton Visible="true" ID="rbResposta1"  runat="server" GroupName="Resposta" 
                    AutoPostBack="false" OnCheckedChanged="rbResposta_CheckedChanged"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Resposta2">
                <ItemTemplate>
                    <asp:RadioButton ID="rbResposta2" runat="server" GroupName="Resposta" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Resposta3">
                <ItemTemplate>
                    <asp:RadioButton ID="rbResposta3" runat="server" GroupName="Resposta" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Resposta4">
                <ItemTemplate>
                    <asp:RadioButton ID="rbResposta4" runat="server" GroupName="Resposta" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Resposta5">
                <ItemTemplate>
                    <asp:RadioButton ID="rbResposta5" runat="server" GroupName="Resposta" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Resposta6">
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
        SelectMethod="ListarQuestoes" 
        TypeName="SAISurvey.Web.Questionario._Default" 
        DataObjectTypeName="RespostaQuestao">
    </asp:ObjectDataSource>
    <table class="style3">
        <tr>
            <td>
                Comentário</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtComentarios" runat="server" Height="50px"  
                    TextMode="MultiLine" Width="923px" 
                    onkeyUp="javascript:Check(this, 255);"
                    onchange="javascript:Check(this, 255);" ></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <table class="style1">
        <tr>
            <td>
                <asp:Button ID="btnSalvarContinuar" runat="server" Text="Salvar e continuar" 
                    Width="200px" onclick="btnSalvarContinuar_Click" />
            </td>
            <td>
                <asp:Button ID="btnSalvarFechar" runat="server" Text="Salvar e terninar depois" 
                    Width="200px" onclick="btnSalvarFechar_Click" />
            </td>
            <td>
                <asp:Button ID="btnSalvarEncerrar" runat="server" Text="Salvar e terminar" 
                    Width="200px" onclick="btnSalvarEncerrar_Click" />
            </td>
            <td>
                <asp:Button ID="btnDescartarResponderDepois" runat="server" 
                    Text="Descartar e terminar depois" Width="200px" 
                    onclick="btnDescartarResponderDepois_Click" />
            </td>
        </tr>
    </table>


</asp:Content>
