<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreaFattura.aspx.cs" UnobtrusiveValidationMode="none" MasterPageFile="~/MasterPage.master" Inherits="EmettiFattura" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-12">
        <div class="col-xs-3">
            Selezionare cliente 
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="sqlEstraiClienti" DataTextField="RagioneSociale" DataValueField="RagioneSociale" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:SqlDataSource ID="sqlEstraiClienti" runat="server" ConnectionString="<%$ ConnectionStrings:ContabilitàDBConnectionString %>" SelectCommand="SELECT [RagioneSociale] FROM [Clienti] WHERE ([COD_Azienda] = @COD_Azienda)">
                <SelectParameters>
                    <asp:SessionParameter Name="COD_Azienda" SessionField="Azienda" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <div class="col-xs-3">

            Oggetto&nbsp;&nbsp;
            <asp:TextBox ID="txtOggetto" runat="server" OnTextChanged="txtOggetto_TextChanged"></asp:TextBox>

        </div>
        <div class="col-xs-6" style="margin-top:1%">
            Fattura numero&nbsp;<asp:TextBox ID="txtNumero" runat="server" Width="5%" OnTextChanged="txtNumero_TextChanged"></asp:TextBox>
            &nbsp;&nbsp;del&nbsp;
            <asp:TextBox ID="txtData" runat="server" TextMode="Date" Width="20%" OnTextChanged="txtData_TextChanged"></asp:TextBox>
        &nbsp;<asp:Label ID="lblErrNum" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </div>
    <div class="col-xs-12">
        Tipo di pagamento&nbsp;
        <asp:TextBox ID="txtPagamento" runat="server" Width="30%"></asp:TextBox>
        <br />
        <br />
    </div>
        <div class="col-xs-12">
               <asp:GridView ID="grvPrimaNota" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="grvStudentDetails_RowDeleting" ShowFooter="True" Style="text-align: left" Width="70%">
                   <Columns>
                       <asp:BoundField DataField="RowNumber" HeaderText="Nr." />
                         <asp:TemplateField HeaderText="Prodotto">
                           <ItemTemplate>
                               <asp:DropDownList ID="drpProd" runat="server" >
                               </asp:DropDownList>
                            </ItemTemplate>
                             </asp:TemplateField>
                       <asp:TemplateField HeaderText="Quantità">
                           <ItemTemplate>
                               <asp:TextBox Width="90%" ID="txtQta" runat="server" ></asp:TextBox>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Sconto">
                           <ItemTemplate>
                               <asp:TextBox Width="90%" ID="txtSconto" runat="server" ></asp:TextBox>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Iva">
                           <ItemTemplate>
                               <asp:DropDownList ID="drpIva" runat="server" >
                                   <asp:ListItem Value="0">0</asp:ListItem>
                                   <asp:ListItem Value="4">4</asp:ListItem>
                                   <asp:ListItem Value="10">10</asp:ListItem>
                                   <asp:ListItem Value="22">22</asp:ListItem>
                               </asp:DropDownList>
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
               Funzioni momentaneamente non disponibili<br />
        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click" Text="Salva" Enabled="False" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnVisual" runat="server" CssClass="btn btn-primary" Text="Visualizza" Enabled="False" OnClick="btnVisual_Click" />
    </div>
</asp:Content>