<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AggiungiAnagrafica.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="AggiungiAnagrafica" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
     <div class="row" style="text-align:center">Inserisci dati</div>
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="lblCliFor" runat="server"></asp:Label>
            <br />
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <br />
            </div> 
            <div class="col-md-3">
                Ragione Sociale
                <br />
                <asp:TextBox ID="txtRagSoc" runat="server"></asp:TextBox>
                <br />
            </div> 
        </div>
        <div class="row">
            <div class="col-md-3">
                Nome e cognome<br />
            <asp:TextBox ID="txtNomCog" runat="server"></asp:TextBox>
                <br />
            </div> 
            <div class="col-md-3">
                P.IVA<br />
                <asp:TextBox ID="txtPIva" runat="server"></asp:TextBox>
                <br />
            </div> 
        </div>
        <div class="row">
            <div class="col-md-3">
                COD Fiscale<br />
                <asp:TextBox ID="txtCodF" runat="server"></asp:TextBox>
                <br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                Indirizzo<br />
            <asp:TextBox ID="txtIndirizzo" runat="server" Width="100%"></asp:TextBox>
                <br />
            </div>   
        </div>
        <div class="row">
            <div class="col-md-3">Nazione<br />
            <asp:TextBox ID="txtNaz" runat="server"></asp:TextBox>
                <br />
            </div>
            <div class="col-md-3">Regione<br />
            <asp:TextBox ID="txtReg" runat="server"></asp:TextBox>
                <br />
            </div>
            <div class="row">
            <div class="col-md-3">Provincia<br />
            <asp:TextBox ID="txtProv" runat="server"></asp:TextBox>
                <br />
            </div>
            <div class="col-md-3">Cap<br />
            <asp:TextBox ID="txtCap" runat="server"></asp:TextBox>
                <br />
            </div>
            </div>
            </div>
        <div class="row">
            <div class="col-md-3">
                Telefono<br />
            <asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
                <br />
            </div>
            <div class="col-md-3">
                Fax<br />
            <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                <br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                Numero Cellulare<br />
            <asp:TextBox ID="txtNUmCell" runat="server"></asp:TextBox>
                <br />
            </div>
            <div class="col-md-3">
                Email<br />
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <br />
            </div>
        </div> <br />
        <asp:Button ID="Button1" runat="server" Text="Inserisci" OnClick="Button1_Click" />
    </div>
</asp:Content>