<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Giornale.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Giornale" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <div class="row">Azienda&nbsp;
            <asp:Label ID="lblAzienda" runat="server"></asp:Label>
        </div>
        <div class="row">Partita Iva&nbsp;
            <asp:Label ID="lblPartitaIva" runat="server"></asp:Label>
        </div>
        <div class="row">Cod. Fiscale&nbsp;
            <asp:Label ID="lblCodFisc" runat="server"></asp:Label>
        </div>
        <div class="row">IIndirizzo&nbsp;
            <asp:Label ID="lblIndirizzo" runat="server"></asp:Label>
        </div>
    </div>
    <div class="col-md-12">

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="NumDoc" HeaderText="Numero documento" />
                <asp:BoundField DataField="Proto" HeaderText="Protocollo" />
                <asp:BoundField DataField="ContoMastro" HeaderText="Conto di mastro" />
                <asp:BoundField DataField="Desc" HeaderText="Descrizione" />
                <asp:BoundField DataField="Dare" HeaderText="Dare" />
                <asp:BoundField DataField="Avere" HeaderText="Avere" />
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

    </div>
</asp:Content>