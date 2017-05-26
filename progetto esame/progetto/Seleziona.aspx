<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Seleziona.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Fatturazione" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <div class="col-md-4"><div class="col-md-12" style="border:solid 1px blue; align-items:center">
            <asp:Button ID="btnFatt" runat="server" CssClass="btn btn-link" Text="Crea fattura" OnClick="btnFatt_Click" Width="100%" />
            </div></div>
        <div class="col-md-4"><div class="col-md-12" style="border:solid 1px blue; align-items:center">
            <asp:Button ID="btnPrimaNota" runat="server" CssClass="btn btn-link" Height="36px" Text="Prima nota" Width="100%" OnClick="btnPrimaNota_Click" />
            </div></div>
        <div class="col-md-4"><div class="col-md-12" style="border:solid 1px blue; align-items:center">
            <asp:Button ID="btnGiornale" runat="server" CssClass="btn btn-link" Text="Visualizza giornale" OnClick="btnGiornale_Click" Width="100%" />
            </div></div>
        </div>
    <div class="col-md-12" style="margin-top:2%">
        <div class="col-md-4"><div class="col-md-12" style="border:solid 1px blue; align-items:center">
            <asp:Button ID="btnContiMastro" runat="server" CssClass="btn btn-link" Text="Aggiungi conto di mastro" OnClick="btnContiMastro_Click" Width="100%" />
            </div></div>
        <div class="col-md-4"><div class="col-md-12" style="border:solid 1px blue; align-items:center">
            <asp:Button ID="btnAreaPers" runat="server" CssClass="btn btn-link" Text="Area personale" OnClick="btnAreaPers_Click" Width="100%" />
            </div></div>
        <div class="col-md-4"><div class="col-md-12" style="border:solid 1px blue; align-items:center">
            <asp:Button ID="btnAssistenza" runat="server" CssClass="btn btn-link" Text="Assistenza via email" OnClick="btnAssistenza_Click" Width="100%" />
            <br />
            <asp:Label ID="lblVers" runat="server" Text="Questa funzione è disponibile solo nella versione completa" Visible="False"></asp:Label>
            </div></div>
    </div>
</asp:Content>