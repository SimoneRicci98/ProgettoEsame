<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Assistenza.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Assistenza" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <div class="row">
        <div class="col-xs-4">
            Scrivi qui il tipo del problema <asp:TextBox ID="txtOggetto" runat="server" CssClass="form-control" OnTextChanged="txtOggetto_TextChanged"></asp:TextBox><br />
        </div>
    </div>
        <div class="row">
        <div class="col-xs-4">
            Scrivi qui la descrizione del problema riscontrato <br />
            <asp:TextBox ID="txtMsg" Width="100%"  runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>            
        </div>
    </div><br />
    <div class="row">
        <div class="col-xs-4">
            <asp:Button ID="btnInvia" Width="30%" runat="server" Text="Invia" OnClick="btnInvia_Click" CssClass="btn btn-primary" />
        </div>
    </div>
    <div class="col-xs-offset-6 col-xs-4">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Data/Immagini/computer per assistenza email.png" />
    </div>
</asp:Content>