<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GestisciProdotti.aspx.cs" Inherits="GestisciProdotti" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="col-xs-12">
        Aggiungi qui i nuovi prodotti
   <asp:GridView ID="grvProdotti" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="grvStudentDetails_RowDeleting" ShowFooter="True" Style="text-align: left" Width="95%" >
                   <Columns>
                       <asp:BoundField DataField="RowNumber" HeaderText="Nr." />
                          <asp:TemplateField HeaderText="Codice">
                           <ItemTemplate>
                               <asp:TextBox Width="80%" ID="txtCodice" runat="server" ></asp:TextBox>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Descrizione">
                           <ItemTemplate>
                               <asp:TextBox Width="80%" ID="txtDesc" runat="server" ></asp:TextBox>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Prezzo">
                           <ItemTemplate>
                               <asp:TextBox Width="80%" ID="txtPrezzo" runat="server" ></asp:TextBox>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Quantità">
                           <ItemTemplate>
                               <asp:TextBox Width="80%" ID="txtQta" runat="server"></asp:TextBox>
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
            <br /><br />
        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click" Text="Salva dati" />
    </div>
    <div class="col-xs-5" style="margin-top:2%">
      <h4> Seleziona qui il prodotto da gestire <asp:DropDownList ID="drpProdotti" runat="server" Width="40%" DataSourceID="SqlDataSource1" DataTextField="Descrizione" DataValueField="Descrizione"></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ContabilitàDBConnectionString %>" SelectCommand="SELECT [Descrizione] FROM [Prodotti] WHERE ([COD_Azienda] = @COD_Azienda)">
            <SelectParameters>
                <asp:SessionParameter Name="COD_Azienda" SessionField="Azienda" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
          </h4>
    </div>
    <div class="col-xs-12" style="margin-top:2%">
    <div class="col-xs-4">
        Aggiungi quantità <asp:TextBox ID="txtAgg" runat="server" TextMode="Number"></asp:TextBox><br /><br />
        <asp:Button ID="btnAgg" CssClass="btn btn-primary" runat="server" Width="100%" Text="Aggiungi" OnClick="btnAgg_Click" />
    </div>
    <div class="col-xs-4">
        Modifica prezzo <asp:TextBox ID="txtPrez" runat="server" TextMode="Number"></asp:TextBox><br /><br />
        <asp:Button ID="btnPrez" CssClass="btn btn-primary" runat="server" Width="100%" Text="Modifica" OnClick="btnPrez_Click" />
    </div>
    <div class="col-xs-4">
        <asp:Button ID="btnElimina" CssClass="btn btn-primary" runat="server" Width="100%" Text="Elimina prodotto" OnClick="btnElimina_Click" />
    </div>
    </div>   
</asp:Content>