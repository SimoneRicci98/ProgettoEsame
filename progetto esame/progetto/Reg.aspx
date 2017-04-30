<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reg.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Reg" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="content1">
    <div class="col-md-offset-2">
   <div class="col-md-12" style="margin-top:3%">
    <div class="col-md-1">
        <div class="row">
           <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
            <br />
        </div>
        <div class="row" style="margin-top:2%">
           <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
           </div>
    </div>
           <div class="col-md-3">
        <div class="row">
                    <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
        </div>
        <div class="row" style="margin-top:2%">
                    <asp:TextBox ID="TxtPass" runat="server" TextMode="Password"></asp:TextBox>
        </div>
    </div>
    </div>
          <p>
             &nbsp;&nbsp; <asp:Button ID="Button1" runat="server" Text="Entra" OnClick="Button1_Click" />
              &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblErr" runat="server"></asp:Label>
         </p>
 <div class="col-md-offset-3" style="font-size:18px">
            <asp:Label ID="lblReg" runat="server" Text="Non hai un account? Registrati!"></asp:Label>
             </div>
        <div class="col-md-12" style="margin-top:3%">
            <div class="col-md-1">
        <div class="row">
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
                    <asp:TextBox ID="txtPswReg" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        </div>
    </div>
    </div>

</asp:Content>