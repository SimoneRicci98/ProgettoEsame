<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Assistenza.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Assistenza" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
        <div class="row">
            <div class="col-xs-6">
                <div class="row">
        <div class="col-xs-10">
            <span class="glyphicon glyphicon-pencil"></span>&nbsp Scegli qui il tipo del problema
            <asp:Dropdownlist ID="drpOggetto" runat="server" CssClass="form-control" OnTextChanged="txtOggetto_TextChanged">
                <asp:ListItem>Fattura (stampa)</asp:ListItem>
                <asp:ListItem>Fattura (creazione)</asp:ListItem>
                <asp:ListItem>Prima nota</asp:ListItem>
                <asp:ListItem>Visualizzazione clienti o fornitori</asp:ListItem>
                <asp:ListItem>Giornale</asp:ListItem>
                <asp:ListItem>Altro</asp:ListItem>
            </asp:Dropdownlist><br />
        </div>
        </div>
        <div class="row"><div class="col-xs-10">
            <span class="glyphicon glyphicon-pencil"></span>&nbsp Scrivi qui la descrizione del problema riscontrato <br />
            <asp:TextBox ID="txtMsg" Width="100%"  runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control"></asp:TextBox>            
        </div>
        </div><br />
         <div class="col-xs-4">
            <asp:Button ID="btnInvia" Width="30%" runat="server" Text="Invia" OnClick="btnInvia_Click" CssClass="btn btn-primary" />
        </div>
            </div>
    <div class="col-xs-6">
        <asp:Image ImageAlign="Right" ID="Image1" runat="server" ImageUrl="~/Immagini/assistenza.png" Height="300px" Width="300px" />
    </div>
            </div>
</asp:Content>