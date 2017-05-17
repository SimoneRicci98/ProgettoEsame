<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AreaPersonale.aspx.cs" Inherits="AreaPersonale" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="row">
            <div class="col-md-3">
                Ragione Sociale :
                <br />
                <asp:Label ID="lblRagSoc" runat="server"></asp:Label>
                <br />
            </div> 
        </div><br />
        <div class="row">
            <div class="col-md-3">
                Nome e cognome :<br />
                <asp:Label ID="lblNomCog" runat="server"></asp:Label>
                <br />
            </div> 
            <div class="col-md-3">
                P.IVA :<br />
                <asp:Label ID="lblPartitaIva" runat="server"></asp:Label>
                <br />
            </div>
            <div class="col-md-3">
                COD Fiscale :<br />
                <asp:Label ID="lblCodFisc" runat="server"></asp:Label>
                <br />
            </div>
        </div><br />
        <div class="row">
            <div class="col-md-5">
                Indirizzo :<br />
                <asp:Label ID="lblIndirizzo" runat="server"></asp:Label>
                <br />
            </div>   
        </div><br />
        <div class="row">
            <div class="col-md-3">Cap :<br />
                <asp:Label ID="lblCap" runat="server"></asp:Label>
                <br />
            </div>
            <div class="col-md-3">Provincia :<br />
                <asp:Label ID="lblProvincia" runat="server"></asp:Label>
                <br />
            </div><br />
            <div class="row">
            <div class="col-md-3">Regione :<br />
                <asp:Label ID="lblRegione" runat="server"></asp:Label>
                <br />
            </div>
            <div class="col-md-3">Nazione :<br />
                <asp:Label ID="lblNazione" runat="server"></asp:Label>
                <br />
            </div>
            </div>
            </div><br />
        <div class="row">
            <div class="col-md-3">
                Telefono :<br />
                <asp:Label ID="lblTelefono" runat="server"></asp:Label>
                <br />
            </div>
        </div><br />
        <div class="row">
            <div class="col-md-3">
                Numero Cellulare :<br />
                <asp:Label ID="lblNumCell" runat="server"></asp:Label>
                <br />
            </div><br />
            <div class="col-md-3">
                Email :<br />
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
                <br />
            </div><br />
            <div class="col-md-3">
                Password :<br />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
&nbsp;<asp:Button ID="btnChiudi0" runat="server" OnClick="btnChiudi_Click" Text="Visualizza/nascondi password" CssClass="btn btn-primary" />
            </div>
        </div>

</asp:Content>