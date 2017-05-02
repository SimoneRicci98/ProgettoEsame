<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AggiungiAnagrafica.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="AggiungiAnagrafica" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
     <div class="row" style="text-align:center">Inserisci dati</div>
        <div class="row">
            <div class="col-md-6">
                <asp:Label ID="lblCliFor" runat="server"></asp:Label>
            &nbsp;<br />
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <br />
            </div> 
            <div class="col-md-6">
                Ragione Sociale
                <br />
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <br />
            </div> 
        </div>
        <div class="row">
            <div class="col-md-6">
                Nome e cognome&nbsp;<br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                <br />
            </div> 
            <div class="col-md-6">
                P.IVA<br />
                &nbsp;
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                <br />
            </div> 
        </div>
        <div class="row">
            <div class="col-md-6">
                COD Fiscale<br />
                &nbsp;
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                <br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                Indirizzo<br />
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                <br />
            </div>   
        </div>
        <div class="row">
            <div class="col-md-3">Nazione<br />
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                <br />
            </div>
            <div class="col-md-3">Regione<br />
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                <br />
            </div>
            <div class="col-md-3">Provincia<br />
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                <br />
            </div>
            <div class="col-md-3">Cap<br />
            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                <br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                Telefono<br />
            <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                <br />
            </div>
            <div class="col-md-6">
                Fax<br />
            <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                <br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                Numero Cellulare<br />
            <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                <br />
            </div>
            <div class="col-md-6">
                Email<br />
            <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
                <br />
            </div>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Inserisci" />
    </div>
</asp:Content>