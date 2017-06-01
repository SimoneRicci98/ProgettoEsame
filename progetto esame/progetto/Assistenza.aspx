<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Assistenza.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Assistenza" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-6">
            Scrivi qui il tipo del problema <asp:TextBox ID="txtOggetto" runat="server" CssClass="form-control"></asp:TextBox><br />
        </div>
    </div>
        <div class="row">
        <div class="col-md-4">
            Scrivi qui la descrizione del problema riscontrato <br />
            <asp:TextBox ID="txtMsg" Width="100%"  runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>            
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Button ID="btnInvia" Width="30%" runat="server" Text="Invia" OnClick="btnInvia_Click" />
        </div>
    </div>
</asp:Content>