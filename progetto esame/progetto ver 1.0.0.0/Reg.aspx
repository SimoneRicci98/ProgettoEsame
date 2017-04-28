<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reg.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Reg" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="content1">
<div class="col-md-12" style="margin-top:3%">
    <div class="col-md-2">
        <div class="row">
           <asp:Label ID="Label3" runat="server" Text="Nome"></asp:Label>
        </div>
        <div class="row" style="margin-top:3%">
           <asp:Label ID="Label4" runat="server" Text="Cognome"></asp:Label>
        </div>
        <div class="row" style="margin-top:3%">
           <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
            <br />
        </div>
        <div class="row" style="margin-top:3%">
           <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
        </div>

    </div>
           <div class="col-md-3">
        <div class="row">
                    <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
        </div>
        <div class="row" style="margin-top:2%">
                    <asp:TextBox ID="TxtPass" runat="server"></asp:TextBox>
        </div>
        <div class="row" style="margin-top:2%">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
        <div class="row" style="margin-top:2%">
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
        </div>
    </div>
</asp:Content>