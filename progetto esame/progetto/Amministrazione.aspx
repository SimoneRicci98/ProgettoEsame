<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Amministrazione.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Amministrazione" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-12">
        <div class="col-xs-3">
            <asp:Label ID="lblDomande" runat="server" Text="Domande degli utenti"></asp:Label>
            <br />
            <br />
            <asp:DropDownList ID="drpDomande" runat="server" CssClass="form-control">
            </asp:DropDownList>
            <br />
            <asp:Button ID="btnSeleziona" runat="server" OnClick="btnSeleziona_Click" Text="Seleziona" CssClass="btn btn-primary" />
            &nbsp;<asp:Label ID="lblbErr" runat="server" CssClass="label label-danger"></asp:Label>
        </div>
        <div class="col-xs-3">

            <asp:Label ID="lblRisp" runat="server" Text="Rispondi a: "></asp:Label>
            <br />
            <asp:Label ID="lblDomandaDa" runat="server" Text="A questa domanda: "></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:Button ID="btnRisp" runat="server" OnClick="btnRisp_Click" Text="Rispondi" CssClass="btn btn-primary" />

        &nbsp;<asp:Label ID="lblSuccess" runat="server" CssClass="label label-success"></asp:Label>

        </div>
    </div><br />
    <div class="col-xs-12" style="margin-top:2%">
        <div class="col-xs-4">
            Scrivere qui la query da eseguire<br />
            <asp:TextBox ID="txtQuery" runat="server" CssClass="form-control" Rows="3" TextMode="MultiLine"></asp:TextBox><br />
            <asp:Button ID="Button1" runat="server" Text="Esegui query" CssClass="btn btn-primary" OnClick="Button1_Click" />
        </div>
        <div class="col-xs-8">
        <asp:GridView ID="grdQuery" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
        <AlternatingRowStyle BackColor="White" />
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
     </div>
</asp:Content>