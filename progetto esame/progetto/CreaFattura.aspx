<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreaFattura.aspx.cs" UnobtrusiveValidationMode="none" MasterPageFile="~/MasterPage.master" Inherits="EmettiFattura" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <div class="col-md-3">
            Selezionare cliente 
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="RagioneSociale" DataValueField="RagioneSociale">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ContabilitàDBConnectionString %>" SelectCommand="SELECT [RagioneSociale] FROM [Clienti] WHERE ([COD_Azienda] = @COD_Azienda)">
                <SelectParameters>
                    <asp:SessionParameter Name="COD_Azienda" SessionField="ID_Azienda" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <div class="col-md-3">

            Oggetto&nbsp;&nbsp;
            <asp:TextBox ID="txtOggetto" runat="server"></asp:TextBox>

        </div>
        <div class="col-md-6">

            Fattura numero&nbsp;
            <asp:TextBox ID="txtNumero" runat="server" Width="27px"></asp:TextBox>
            &nbsp;del
            <asp:TextBox ID="txtData" runat="server" TextMode="DateTime"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-12">
        Tipo di pagamento&nbsp;
        <asp:TextBox ID="txtPagamento" runat="server"></asp:TextBox>
    </div>
        <div class="col-md-12">

               <asp:GridView ID="grvPrimaNota" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="grvStudentDetails_RowDeleting" ShowFooter="True" Style="text-align: left" Width="97%">
                   <Columns>
                       <asp:BoundField DataField="RowNumber" HeaderText="Nr." />
                          <asp:TemplateField HeaderText="Codice articolo">
                           <ItemTemplate>
                               <asp:TextBox ID="txtCodArt" runat="server" ></asp:TextBox>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Descrizione">
                           <ItemTemplate>
                               <asp:TextBox ID="txtDesc" runat="server" ></asp:TextBox>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Quantità">
                           <ItemTemplate>
                               <asp:TextBox ID="txtQta" runat="server" ></asp:TextBox>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Prezzo unitario">
                           <ItemTemplate>
                               <asp:TextBox ID="txtPrezzo" runat="server" ></asp:TextBox>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Sconto">
                           <ItemTemplate>
                               <asp:TextBox ID="txtSconto" runat="server" ></asp:TextBox>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Importo">
                           <ItemTemplate>
                               <asp:TextBox ID="txtImporto" runat="server"></asp:TextBox>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Iva">
                           <ItemTemplate>
                               <asp:DropDownList ID="drpIva" runat="server">
                                   <asp:ListItem Value="4">4</asp:ListItem>
                                   <asp:ListItem Value="10">10</asp:ListItem>
                                   <asp:ListItem Value="22">22</asp:ListItem>
                               </asp:DropDownList>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="drpIva" ErrorMessage="*"  InitialValue="Select"></asp:RequiredFieldValidator>
                           </ItemTemplate>
                           <FooterStyle HorizontalAlign="Right" />
                           <FooterTemplate>
                               <asp:Button CssClass="btn btn-primary" ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="Aggiungi nuova riga" />
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
        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click" Text="Salva" />
    </div>
</asp:Content>