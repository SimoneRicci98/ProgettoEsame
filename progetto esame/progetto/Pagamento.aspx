<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Pagamento.aspx.cs" Inherits="Pagamento" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="col-xs-offset-4 col-xs-4">
    <div class="panel" style="padding:15px;background-color:rgba(156, 196, 216, 0.32)">
Selezionare metodo pagamento:
         <br />
        <asp:RadioButton CssClass="radio-inline" ID="rdbVisa" Text="Visa" runat="server" GroupName="Pagamento" />
        <asp:RadioButton CssClass="radio-inline" ID="rdbMastercard" Text="Mastercard" runat="server" GroupName="Pagamento" />
        <asp:RadioButton CssClass="radio-inline" ID="rdbPayPal" Text="Paypal" runat="server" GroupName="Pagamento" />
        <asp:RadioButton CssClass="radio-inline" ID="rdbMaestro" Text="Maestro" runat="server" GroupName="Pagamento" /><br /><br />
        Imettere codice:<br />
        <asp:TextBox ID="txtCodice" TextMode="Number" runat="server">
        </asp:TextBox><asp:label ID="lblErrCod" runat="server"></asp:label><br /><br />

        Data di scadenza:<br />
        <asp:TextBox ID="txtGiorno" TextMode="Number" runat="server" Width="35px"></asp:TextBox>&nbsp / &nbsp
        <asp:TextBox ID="txtMese" TextMode="Number" runat="server" Width="35px"></asp:TextBox><asp:label ID="lblErrData" runat="server"></asp:label><br /><br />
        CVV:<br />
        <asp:TextBox ID="txtCVV" TextMode="Number" runat="server" Width="50px"></asp:TextBox><asp:label ID="lblErrCVV" runat="server"></asp:label><br /><br />

        <asp:Button ID="btnContinua" CssClass="btn btn-primary" OnClick="btnContinua_Click" runat="server" Text="Continua" />
     </div> 
     </div>
         
</asp:Content>