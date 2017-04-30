<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrimaNota.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="PrimaNota" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <div class="col-md-3">
            <div class="row">
               Data operazione
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <br />
                <br />
            </div>
            <div class="row">
               Data Fattura <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <br />
            </div>
        </div>
    </div>
</asp:Content>