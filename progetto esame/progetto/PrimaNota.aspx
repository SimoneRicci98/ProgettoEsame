<%@ Page Language="C#" AutoEventWireup="true" UnobtrusiveValidationMode="none" CodeFile="PrimaNota.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="PrimaNota" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript">
        function openWindowcli() {
            <%Session["Cliente"] = true; %>
            window.open('AggiungiAnagrafica.aspx','PopUp','width=1000,height=500,menubar=yes,toolbar=yes,resizable=no');
        }
        function openWindowfor() {
            <%Session["Fornitore"] = true;%>
            window.open('AggiungiAnagrafica.aspx', 'PopUp', 'width=1000,height=500,menubar=yes,toolbar=yes,resizable=no');
        }
        </script>

    <div class="col-md-12">
            <div class="row">
                <div class="col-md-2">
                     Data operazione
                </div>
               <div class="col-md-3">
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="DateTime"></asp:TextBox> dd/mm/yyyy
               </div>
                <div class="col-md-4">
                    <div class="col-md-6">
                        <asp:RadioButton ID="radioEmessa" runat="server" GroupName="Fattura" Text="Fattura Emessa" />
                    </div>
                    <div class="col-md-6">
                        <asp:RadioButton ID="radioRicevuta" runat="server" GroupName="Fattura" Text="Fattura ricevuta" />
                    </div>
                </div>
                <br />
                <br />
            </div>
            <div class="row">
                <div class="col-md-2">
                    Data Fattura 
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="DateTime"></asp:TextBox> dd/mm/yyyy
                </div>
               <div class="col-md-4">
                   <div class="col-md-6">
                    <asp:RadioButton ID="radioCliente" runat="server" GroupName="ClienteFornitore" Text="Cliente" />
                       <br />
                       <asp:DropDownList ID="DropDownList1" runat="server">
                       </asp:DropDownList>
                   <br />
                   <input id="Button1" type="button" language="javascript" onclick="return openWindowcli()" value="Aggiungi cliente"  />
                   </div>
                   <div class="col-md-6">
                    <asp:RadioButton ID="radioFornitore" runat="server" GroupName="ClienteFornitore" Text="Fornitore" />
                       <br />
                       <asp:DropDownList ID="DropDownList2" runat="server">
                       </asp:DropDownList>
                       <br />
                   <input id="Button2" type="button" language="javascript" onclick="return openWindowfor()" value="Aggiungi  fornitore" />
                   </div>
                </div>
                <br />
            </div>
        <div class="row" style="margin-top:2%">
            <div class="col-md-4">
                N° Documento&nbsp;&nbsp;
                <asp:TextBox ID="txtNumDoc" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-4">
                Protocollo&nbsp;&nbsp;
                <asp:TextBox ID="txtProt" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-4">
                Totale documento&nbsp;&nbsp;
                <asp:TextBox ID="txtTot" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row" style="border-color:red;border:solid;margin-top:2%">
            <div class="col-md-12">
                <div class="col-md-6">
                    Dati obbligatori
                </div>
                <div class="col-md-6">
                    Descrizione &nbsp;&nbsp; <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </div>
                
            </div>
        </div>
        <div class="row" style="margin-top:2%">
            <div class="col-md-12">
        
               <asp:GridView ID="grvPrimaNota" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="grvStudentDetails_RowDeleting" ShowFooter="True" Style="text-align: left" Width="97%">
                   <Columns>
                       <asp:BoundField DataField="RowNumber" HeaderText="Nr." />
                       <asp:TemplateField HeaderText="Conto di mastro">
                           <ItemTemplate>
                               <asp:DropDownList ID="drpConto" runat="server">
                                   <asp:ListItem>Seleziona conto</asp:ListItem>
                                   <asp:ListItem Value="conto1">conto1</asp:ListItem>
                                   <asp:ListItem Value="conto2">conto2</asp:ListItem>
                                   <asp:ListItem Value="conto3">conto3</asp:ListItem>
                               </asp:DropDownList>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="drpIva" ErrorMessage="*" InitialValue="Select"></asp:RequiredFieldValidator>
                           </ItemTemplate>
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="Avere">
                           <ItemTemplate>
                               <asp:TextBox ID="txtAvere" runat="server" ></asp:TextBox>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Dare">
                           <ItemTemplate>
                               <asp:TextBox ID="txtDare" runat="server"></asp:TextBox>
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
                               <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="Add New Row" />
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
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save Data" />
            </div>
        </div>
    </div>
</asp:Content>