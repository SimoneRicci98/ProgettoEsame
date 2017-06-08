<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Seleziona.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Fatturazione" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-12">
        <div class="col-xs-4"><div class="col-xs-12" style="border:solid 1px blue; align-items:center">
            <asp:LinkButton ID="btnFatt" runat="server" CssClass="btn btn-link" OnClick="btnFatt_Click" Width="100%"><span class="glyphicon glyphicon-plus"></span>&nbsp Crea fattura</asp:LinkButton>
            </div></div>
        <div class="col-xs-4"><div class="col-xs-12" style="border:solid 1px blue; align-items:center">
        <asp:LinkButton ID="btnPrimaNota" runat="server" CssClass="btn btn-link" Width="100%" OnClick="btnPrimaNota_Click"><span class="glyphicon glyphicon-list"></span>&nbsp Prima nota</asp:LinkButton>
            </div></div>
        <div class="col-xs-4"><div class="col-xs-12" style="border:solid 1px blue; align-items:center">
            <asp:LinkButton ID="btnGiornale" runat="server" CssClass="btn btn-link" OnClick="btnGiornale_Click" Width="100%"><span class="glyphicon glyphicon-book"></span>&nbsp Visualizza giornale</asp:LinkButton>
            </div></div>
        </div>
    <div class="col-xs-12" style="margin-top:2%">
        <div class="col-xs-4"><div class="col-xs-12" style="border:solid 1px blue; align-items:center">
        <asp:LinkButton ID="btnContiMastro" runat="server" CssClass="btn btn-link" OnClick="btnContiMastro_Click" Width="100%"><span class="glyphicon glyphicon-plus"></span>&nbsp Aggiungi conto di mastro</asp:LinkButton>
        </div></div>
        <div class="col-xs-4"><div class="col-xs-12" style="border:solid 1px blue; align-items:center">
        <asp:LinkButton ID="btnAreaPers" runat="server" CssClass="btn btn-link" OnClick="btnAreaPers_Click" Width="100%"><span class="glyphicon glyphicon-user"></span>&nbsp Area personale</asp:LinkButton>
            </div></div>
        <div class="col-xs-4"><div class="col-xs-12" style="border:solid 1px blue; align-items:center">
            <asp:LinkButton ID="btnAssistenza" runat="server" CssClass="btn btn-link" OnClick="btnAssistenza_Click" Width="100%"><span class="glyphicon glyphicon-pencil"></span>&nbsp Assistenza via email</asp:LinkButton>
            <br />
            </div></div>
    </div>
    <div class="col-xs-12" style="margin-top:2%">
        <div class="col-xs-4"><div class="col-xs-12" style="border:solid 1px blue; align-items:center">
                <asp:LinkButton ID="btnCli" runat="server" CssClass="btn btn-link" Width="100%" OnClick="btnCli_Click"><span class="glyphicon glyphicon-zoom-in"></span>&nbsp Visualizza i tuoi clienti</asp:LinkButton>    
            </div></div>
        <div class="col-xs-4"><div class="col-xs-12" style="border:solid 1px blue; align-items:center">
                <asp:LinkButton ID="btnFor" runat="server" CssClass="btn btn-link" Width="100%" OnClick="btnFor_Click"><span class="glyphicon glyphicon-zoom-in"></span>&nbsp Visualizza i tuoi fornitori</asp:LinkButton>    
        </div></div>
        <div class="col-xs-4"><div class="col-xs-12" style="border:solid 1px blue; align-items:center">
            <asp:LinkButton ID="btnProd" runat="server" CssClass="btn btn-link" Width="100%" OnClick="btnProd_Click"><span class="glyphicon glyphicon-zoom-in"></span>&nbsp Visualizza i tuoi prodotti</asp:LinkButton>
        </div></div>
    </div>
    <div class="col-xs-12" style="margin-top:2%">
         <%=htmlStr()%>
    </div>
</asp:Content>