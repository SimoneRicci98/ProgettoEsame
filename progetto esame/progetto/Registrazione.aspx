﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registrazione.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Registrazione" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="col-xs-offset-3" style="font-size:18px">
            <asp:Label ID="lblReg" runat="server" Text="Non hai un account? Registrati!"></asp:Label>
         <br />
         <br />
         <div class="row">
             <div class="col-xs-2" style="text-align:right">
                 Nome
             </div>
             <div class="col-xs-3">
                 <asp:TextBox ID="txtNome" runat="server" Width="100%" CssClass="form-control"></asp:TextBox>
             </div>
         </div>
         <br />
         <div class="row">
             <div class="col-xs-2" style="text-align:right">
                 Cognome
             </div>
             <div class="col-xs-3">
                 <asp:TextBox ID="txtCognome" runat="server" Width="100%" CssClass="form-control"></asp:TextBox>
             </div>
         </div>
         <br />
         <div class="row">
             <div class="col-xs-2" style="text-align:right">
                 Email
             </div>
             <div class="col-xs-3">
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" Width="100%" CssClass="form-control"></asp:TextBox>
             </div>
         </div>
         <br />
         <div class="row">
             <div class="col-xs-2" style="text-align:right">
                 Password
             </div>
             <div class="col-xs-3">
                 <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Width="100%" CssClass="form-control"></asp:TextBox>
             </div>
         </div>
         <div class="col-xs-3">

             <asp:Button ID="Button1" runat="server" Text="Registrati!" OnClick="Button1_Click" CssClass="btn btn-primary" />

             <asp:Label ID="lblErr" runat="server" ForeColor="Red"></asp:Label>

         </div>
     </div>
</asp:Content>