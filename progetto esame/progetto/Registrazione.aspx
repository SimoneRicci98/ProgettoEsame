<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registrazione.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Registrazione" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="col-md-offset-3" style="font-size:18px">
            <asp:Label ID="lblReg" runat="server" Text="Non hai un account? Registrati!"></asp:Label>
             </div>
        <div class="col-md-12" style="margin-top:3%">
            <div class="col-md-1">
        <div class="row">
        <div class="row" style="margin-top:2%">
           <asp:Label ID="Label1" runat="server" Text="Nome"></asp:Label>
        </div>
        <div class="row" style="margin-top:2%">
           <asp:Label ID="Label2" runat="server" Text="Cognome"></asp:Label>
        </div>
           <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
            <br />
        </div>
        <div class="row" style="margin-top:2%">
           <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
        </div>
    </div>
           <div class="col-md-3">
        <div class="row">
            <asp:TextBox ID="txtEmailReg" runat="server"></asp:TextBox>
        </div>
        <div class="row" style="margin-top:2%">
            <asp:TextBox ID="txtPswReg" runat="server" ></asp:TextBox>
        </div>
        <div class="row" style="margin-top:2%">
            <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
        </div>
        <div class="row" style="margin-top:2%">
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        </div>
    </div>
</asp:Content>