<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Prodotti.aspx.cs" Inherits="Prodotti" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-12">
        Visualizza i tuoi prodotti
        <asp:GridView ID="grdVisual" runat="server" AutoGenerateColumns="False" Width="95%" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Cod" HeaderText="Codice" />
                <asp:BoundField DataField="Desc" HeaderText="Descrizione" />
                <asp:BoundField DataField="Prez" HeaderText="Prezzo" />
                <asp:BoundField DataField="Qta" HeaderText="Quantità" />
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
        </asp:GridView>
    </div><br /><br />
    <div class="col-xs-3">
        <asp:Button ID="btnGestisci" runat="server" Text="Gestisci e aggiungi prodotti" CssClass="btn btn-primary" OnClick="btnGestisci_Click" />
    </div>
    </asp:Content>