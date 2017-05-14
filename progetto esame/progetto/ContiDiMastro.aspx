<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContiDiMastro.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="ContiDiMastro" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        
               <asp:GridView ID="grvPrimaNota" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="grvStudentDetails_RowDeleting" ShowFooter="True" Style="text-align: left" Width="97%" >
                   <Columns>
                       <asp:BoundField DataField="RowNumber" HeaderText="Nr." />
                       <asp:TemplateField HeaderText="codice">
                           <ItemTemplate>
                               <asp:TextBox ID="txtCodice" runat="server" ></asp:TextBox>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Nome">
                           <ItemTemplate>
                               <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
                           </ItemTemplate>
                           <FooterStyle HorizontalAlign="Right" />
                           <FooterTemplate>
                               <asp:Button ID="ButtonAdd" CssClass="btn btn-primary" runat="server" OnClick="ButtonAdd_Click" Text="Aggiungi una riga" />
                           </FooterTemplate>
                       </asp:TemplateField>
                       <asp:CommandField ShowDeleteButton="True" />
                   </Columns>
                   <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                   <RowStyle BackColor="#EFF3FB" />
                   <EditRowStyle BackColor="#2461BF" />
                   <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                   <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                   <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                   <AlternatingRowStyle BackColor="White" />
               </asp:GridView>
        
                <br />
        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click" Text="Salva dati" />
        
    </div>
</asp:Content>