<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrimaNota.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="PrimaNota" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript">
            function openWindow() {
            window.open('AggiungiAnagrafica.aspx','PopUp','width=1000,height=500,menubar=yes,toolbar=yes,resizable=no');
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
                   <input id="Button1" type="button" language="javascript" onclick="return openWindow()" value="Aggiungi cliente" <%Session["Operazione"] = "cli"; %> />
                   </div>
                   <div class="col-md-6">
                    <asp:RadioButton ID="radioFornitore" runat="server" GroupName="ClienteFornitore" Text="Fornitore" />
                       <br />
                       <asp:DropDownList ID="DropDownList2" runat="server">
                       </asp:DropDownList>
                       <br />
                   <input id="Button2" type="button" language="javascript" onclick="return openWindow()" value="Aggiungi  fornitore" <%Session["Operazione"] = "for"; %>/></div>

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
               <asp:gridview ID="Gridview1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
        <Columns>
        <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />
        <asp:TemplateField HeaderText="Header 1">
            <ItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Header 2">
            <ItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Header 3">
            <ItemTemplate>
                 <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </ItemTemplate>
            <FooterStyle HorizontalAlign="Right" />
            <FooterTemplate>
             <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" />
            </FooterTemplate>
        </asp:TemplateField>
        </Columns>
</asp:gridview>
            </div>
        </div>
    </div>
</asp:Content>