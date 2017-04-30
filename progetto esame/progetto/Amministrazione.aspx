<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Amministrazione.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Amministrazione" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <div class="col-md-3">
            <asp:Label ID="lblDomande" runat="server" Text="Domande degli utenti"></asp:Label>
            <br />
            <asp:ListBox ID="lstDomande" runat="server" OnTextChanged="lstDomande_SelectedITemChanged"></asp:ListBox>
            <br />
            <asp:Button ID="btnSeleziona" runat="server" OnClick="btnSeleziona_Click" Text="Seleziona" />
            <asp:Label ID="lblbErr" runat="server" ForeColor="Red"></asp:Label>
        </div>
        <div class="col-md-3">

            <asp:Label ID="lblRisp" runat="server" Text="Rispondi a: "></asp:Label>
            <br />
            <asp:Label ID="lblDomandaDa" runat="server" Text="A questa domanda: "></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox>
            <br />
            <asp:Button ID="btnRisp" runat="server" OnClick="btnRisp_Click" Text="Rispondi" />

        </div>
    </div>
</asp:Content>