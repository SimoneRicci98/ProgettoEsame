<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Seleziona.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Fatturazione" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-12">
        <div class="col-xs-4"><div class="col-xs-12" style="border:solid 1px blue; align-items:center">
            <asp:Button ID="btnFatt" runat="server" CssClass="btn btn-link" Text="Crea fattura" OnClick="btnFatt_Click" Width="100%" />
            </div></div>
        <div class="col-xs-4"><div class="col-xs-12" style="border:solid 1px blue; align-items:center">
            <asp:Button ID="btnPrimaNota" runat="server" CssClass="btn btn-link" Text="Prima nota" Width="100%" OnClick="btnPrimaNota_Click" />
            </div></div>
        <div class="col-xs-4"><div class="col-xs-12" style="border:solid 1px blue; align-items:center">
            <asp:Button ID="btnGiornale" runat="server" CssClass="btn btn-link" Text="Visualizza giornale" OnClick="btnGiornale_Click" Width="100%" />
            </div></div>
        </div>
    <div class="col-xs-12" style="margin-top:2%">
        <div class="col-xs-4"><div class="col-xs-12" style="border:solid 1px blue; align-items:center">
            <asp:Button ID="btnContiMastro" runat="server" CssClass="btn btn-link" Text="Aggiungi conto di mastro" OnClick="btnContiMastro_Click" Width="100%" />
            </div></div>
        <div class="col-xs-4"><div class="col-xs-12" style="border:solid 1px blue; align-items:center">
            <asp:Button ID="btnAreaPers" runat="server" CssClass="btn btn-link" Text="Area personale" OnClick="btnAreaPers_Click" Width="100%" />
            </div></div>
        <div class="col-xs-4"><div class="col-xs-12" style="border:solid 1px blue; align-items:center">
            <asp:Button ID="btnAssistenza" runat="server" CssClass="btn btn-link" Text="Assistenza via email" OnClick="btnAssistenza_Click" Width="100%" />
            <br />
            </div></div>
    </div>
    <div class="col-xs-12" style="margin-top:2%">
        <div class="col-xs-4"><div class="col-xs-12" style="border:solid 1px blue; align-items:center">
            <asp:Button ID="btnCli" runat="server" CssClass="btn btn-link" Text="Visualizza i tuoi clienti" Width="100%" OnClick="btnCli_Click" />
            </div></div>
        <div class="col-xs-4"><div class="col-xs-12" style="border:solid 1px blue; align-items:center">
            <asp:Button ID="btnFor" runat="server" CssClass="btn btn-link" Text="Visualizza i tuoi fornitori" Width="100%" OnClick="btnFor_Click" />
            </div></div>
        <%=htmlStr()%>
    </div>
</asp:Content>