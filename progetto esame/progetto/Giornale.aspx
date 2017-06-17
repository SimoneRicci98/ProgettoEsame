<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Giornale.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Giornale" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-12" style="margin-left:1%">
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
    <div class="col-xs-12" style="margin-left:1%">

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="NumDoc" HtmlEncode="False" HeaderText="Numero documento" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="DataF" HtmlEncode="False" HeaderText="Data fattura" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="DataR" HtmlEncode="False" HeaderText="Data registrazione" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Cliente" HtmlEncode="False" HeaderText="Cliente" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Fornitore" HtmlEncode="False" HeaderText="Fornitore" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ContoMastro" HtmlEncode="False" HeaderText="Conto di mastro" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Proto" HtmlEncode="False" HeaderText="Protocollo" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Desc" HtmlEncode="False" HeaderText="Descrizione" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Dare" HtmlEncode="False" HeaderText="Dare" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Avere" HtmlEncode="False" HeaderText="Avere" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
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
        <div class="col-xs-12" style="text-align:right;position:relative;bottom:0;right:0">
            <asp:Label ID="lblTotDare" runat="server" Text=""></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblTotAvere" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="lblErr" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </div>
</asp:Content>