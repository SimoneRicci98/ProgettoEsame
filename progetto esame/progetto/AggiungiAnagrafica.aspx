<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AggiungiAnagrafica.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="AggiungiAnagrafica" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
     <div class="row" style="text-align:center">Inserisci dati</div>
        <div class="row">
            <div class="col-md-6">
                <asp:Label ID="lblCliFor" runat="server"></asp:Label>
            &nbsp;<asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </div> 
            <div class="col-md-6">
                Ragione Sociale
                <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </div> 
        </div>
        <div class="row">
            <div class="col-md-6">
                Nome e cognome&nbsp;
                <asp:TextBox ID="TextBox3" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </div> 
            <div class="col-md-6">
                P.IVA&nbsp;
                <asp:TextBox ID="TextBox4" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </div> 
        </div>
        <div class="row">
            <div class="col-md-6">
                COD Fiscale&nbsp;
                <asp:TextBox ID="TextBox5" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                Indirizzo
                <asp:TextBox ID="TextBox6" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </div>   
        </div>
        <div class="row">
            <div class="col-md-3">Nazione
                <asp:TextBox ID="TextBox7" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </div>
            <div class="col-md-3">Regione
                <asp:TextBox ID="TextBox8" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </div>
            <div class="col-md-3">Provincia
                <asp:TextBox ID="TextBox9" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </div>
            <div class="col-md-3">Cap
                <asp:TextBox ID="TextBox10" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                Telefono
                <asp:TextBox ID="TextBox11" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </div>
            <div class="col-md-6">
                Fax
                <asp:TextBox ID="TextBox12" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                Numero Cellulare
                <asp:TextBox ID="TextBox13" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </div>
            <div class="col-md-6">
                Email
                <asp:TextBox ID="TextBox14" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </div>
        </div>
    </div>
</asp:Content>