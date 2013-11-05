<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroAvaliacao.aspx.cs" Inherits="SAISurvey.Web.Administracao.Pages.CadastroAvaliacao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 650px;
        }
        .style3
        {
            width: 368px;
        }
        .style4
        {
            width: 87px;
        }
        .style7
        {
            width: 60px;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>
        Cadastro de Avaliação
    </h2>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
         <table class="style1">
            <tr>
                <td class="style4">
                    ID</td>
                <td class="style3">
                    <asp:Label ID="lbID" runat="server" CssClass="textEntry" Text="ID"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    Objetivo</td>
                <td class="style3">
                    <asp:TextBox ID="txtObjetivo" runat="server" Width="360px" MaxLength="50" 
                        AutoPostBack="True"></asp:TextBox>
                </td>
                <td style="margin-left: 40px">
                    <asp:RequiredFieldValidator ID="rfvObjetivoRequerido" runat="server" 
                      ControlToValidate="txtObjetivo" CssClass="LabelValidation" 
                      ErrorMessage="Objetivo não informado">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Data inicial
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtDataInicial" runat="server" Width="360px" 
                        CssClass="textEntry" MaxLength="50"></asp:TextBox>
                </td>
                <td style="margin-left: 40px">
                    <asp:RequiredFieldValidator ID="rfvDataInicialRequerida" runat="server" 
                      ControlToValidate="txtDataInicial" CssClass="LabelValidation" 
                      ErrorMessage="Data inicial não informada">*</asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td class="style4">
                    Data final
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtDataFinal" runat="server" Width="360px" 
                        CssClass="textEntry" MaxLength="50"></asp:TextBox>
                </td>
                <td style="margin-left: 40px">
                    <asp:RequiredFieldValidator ID="rfvDataFinalRequerida" runat="server" 
                      ControlToValidate="txtDataFinal" CssClass="LabelValidation" 
                      ErrorMessage="Data final não informada">*</asp:RequiredFieldValidator>
                </td>
            </tr>

            
            <tr>
                <td class="style4">
                    Curso</td>
                <td class="style3">
                    <asp:DropDownList ID="ddlCurso" runat="server" Height="19px" Width="364px" 
                        onselectedindexchanged="ddlCurso_SelectedIndexChanged" 
                        AppendDataBoundItems="True" AutoPostBack="True">
                        <asp:ListItem Value="0">Selecione</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="margin-left: 40px">
                    &nbsp;</td>
            </tr>

            <tr>
                <td class="style4">
                    Bloco</td>
                <td class="style3">
                    <asp:DropDownList ID="ddlBloco" runat="server" Height="19px" Width="364px" 
                        onselectedindexchanged="ddlBloco_SelectedIndexChanged" 
                        AppendDataBoundItems="True" AutoPostBack="True">
                        <asp:ListItem Value="0">Selecione</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="margin-left: 40px">
                    &nbsp;</td>
            </tr>

            <tr>
                <td class="style4">
                    Módulo</td>
                <td class="style3">
                    <asp:DropDownList ID="ddlModulo" runat="server" Height="19px" Width="364px" 
                        AppendDataBoundItems="True" 
                        onselectedindexchanged="ddlModulo_SelectedIndexChanged" 
                        AutoPostBack="True">
                        <asp:ListItem Value="0">Selecione</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="margin-left: 40px">
                    &nbsp;</td>
            </tr>
            
             <tr>
                 <td class="style4">
                     Turma</td>
                 <td class="style3">
                     <asp:DropDownList ID="ddlTurma" runat="server" AppendDataBoundItems="True" 
                         Height="19px" Width="364px">
                         <asp:ListItem Value="0">Selecione</asp:ListItem>
                     </asp:DropDownList>
                 </td>
                 <td style="margin-left: 40px">
                     <asp:RequiredFieldValidator ID="rfvTurmaRequerido" runat="server" 
                         ControlToValidate="ddlTurma" CssClass="LabelValidation" 
                         ErrorMessage="Turma não informada">*</asp:RequiredFieldValidator>
                 </td>
             </tr>
            
            <tr>
                <td colspan="3">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        CssClass="LabelValidation" DisplayMode="List" />
                    <br />
                    <asp:Label ID="lbMessagem" runat="server" CssClass="LabelValidation" 
                        Text="lbMessagem" Visible="False"></asp:Label>
                </td>
            </tr>
            </table>
            
            <br />
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
             CellPadding="4" 
             EmptyDataText="Nenhum questão definida para essa avaliação" ForeColor="#333333" 
             GridLines="None" Width="655px" PageSize="5" AllowPaging="True" 
             DataSourceID="ObjectDataSource1">
             <AlternatingRowStyle BackColor="White" />
             <Columns>
                 <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
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
             SelectMethod="ListarQuestoes" 
             TypeName="SAISurvey.Web.Administracao.Pages.CadastroAvaliacao">
         </asp:ObjectDataSource>
            
            <br />

            <table>
            <tr>
                <td class="style7">
                    <asp:Button ID="btnGravar" runat="server" Text="Gravar" 
                        onclick="btnGravar_Click" />
                </td>
                <td>
                    <asp:Button ID="btnDefinirQuestoes" runat="server" 
                        onclick="btnDefinirQuestoes_Click" Text="Definir questões" Width="110px" />
                </td>
                <td class="style7">
                    <asp:Button ID="btnVoltar" runat="server" CausesValidation="False" 
                        Text="Voltar" Width="56px" onclick="btnVoltar_Click" />
                </td>
            </tr>
            </table>

    
     </ContentTemplate>
    </asp:UpdatePanel>


    
    
    


</asp:Content>
 