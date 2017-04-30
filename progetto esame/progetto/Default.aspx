<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="_Default" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="content1">
    <div class="col-md-12">
        <div class="col-md-4">
            
            Inserisci il nome con il quale vuoi essere riconosciuto<br />
            
            <asp:TextBox ID="txtUtente" runat="server" OnTextChanged="txtUtente_TextChanged"></asp:TextBox>
            <asp:Label ID="lblErr2" runat="server" ForeColor="#CC0000"></asp:Label>
            <br />
            Inserisci qui la domanda<br />
            <asp:TextBox ID="txtDomanda" runat="server" OnTextChanged="TextBox2_TextChanged" TextMode="MultiLine" Width="122px" ></asp:TextBox>
            
            <asp:Label ID="lblErr1" runat="server" ForeColor="#CC0000"></asp:Label>
            
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click"  Text="Invia" />
            <br />
            <br />
            <asp:ListBox ID="lstDomande" runat="server" Rows="10" Width="80%"></asp:ListBox>
            
        </div>
        <div class="col-md-4">
            qui le possibilità di acquisti con le relative caratteristiche 
        </div>
        <div class="col-md-4">
            
            Qui rispondo alle vostre domande<br />
            <asp:ListBox ID="lstRisposte" runat="server" Rows="10" Width="80%"></asp:ListBox>
            
            </div>
    </div>

</asp:Content>