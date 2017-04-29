<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="_Default" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="content1">
    <div class="col-md-12">
        <div class="col-md-4">
            
            <asp:TextBox ID="txtUtente" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtDomanda" runat="server" OnTextChanged="TextBox2_TextChanged" TextMode="MultiLine" Width="122px"></asp:TextBox>
            
        </div>
        <div class="col-md-4">
            qui le possibilità di acquisti con le relative caratteristiche 
        </div>
        <div class="col-md-4">
            qui ci va la zona per chiedere aiuto
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" OnClientClick="OnClientClick = "return confirm('Are you sure you want to delete?');" Text="Button" />
        </div>
    </div>
</asp:Content>