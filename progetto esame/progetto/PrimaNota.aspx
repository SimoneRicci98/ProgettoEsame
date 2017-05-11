<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrimaNota.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="PrimaNota" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript">
        function openWindowcli() {
            <%Session["Operazione"] = "cli"; %>
            window.open('AggiungiAnagrafica.aspx','PopUp','width=1000,height=500,menubar=yes,toolbar=yes,resizable=no');
        }
        function openWindowfor() {
            <%Session["Operazione"] = "for";%>
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
                Dati obbligatori
            </div>
        </div>
        <div class="row" style="margin-top:2%">
            <div class="col-md-12">
               <asp:gridview ID="Gridview1" runat="server" ShowFooter="True" AutoGenerateColumns="False" OnRowCommand="ButtonAdd_Click" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnSelectedIndexChanged="Gridview1_SelectedIndexChanged1">
        
                   <AlternatingRowStyle BackColor="White" />
                   <Columns>
        
        
        
        
       <asp:TemplateField HeaderText="Tipo">
            <ItemTemplate>
                <asp:DropDownList ID="comboTipo" runat="server" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:DropDownList>
            </ItemTemplate>
       <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="IVA">
            <ItemTemplate>
                <asp:DropDownList ID="comboIVA" runat="server" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:DropDownList>
            </ItemTemplate>
       <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Imponibile">
            <ItemTemplate>
                 <asp:TextBox ID="TextBox3" Text="0" runat="server" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:TextBox>
            </ItemTemplate>
            <FooterStyle HorizontalAlign="Right" />
            <FooterTemplate>
             <asp:Button ID="ButtonAdd" runat="server" Text="Aggiungi una riga" cssClass="btn btn-primary"/>
            </FooterTemplate>
       <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Importo iva" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                       <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                       <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                       <ItemTemplate>
                        <asp:Label ID="lblImpoIva" runat="server" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:Label>
                       </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Conto di mastro">
                           <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                        <asp:DropDownList ID="comboConto" runat="server" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:DropDownList>
                       </ItemTemplate>
                       </asp:TemplateField>
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
</asp:gridview>
            </div>
        </div>
    </div>
</asp:Content>