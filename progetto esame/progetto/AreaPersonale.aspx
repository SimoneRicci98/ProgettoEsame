<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AreaPersonale.aspx.cs" Inherits="AreaPersonale" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-12" style="font-size:16px">
        <div class="row">
        
            <div class="col-xs-9" >
                Ragione Sociale :
                <br />
                <asp:Label ID="lblRagSoc" runat="server" CssClass="label label-primary"></asp:Label>
                <br />
            </div>
            <div class="col-xs-3">
            <asp:Image ID="Image1" runat="server" ImageAlign="Bottom" ImageUrl="~/Immagini/Documentale.png" Width="100px" Height="100px"/>
        </div>
        </div><br />
        <div class="row">
            <div class="col-xs-3">
                Nome e cognome :<br />
                <asp:Label ID="lblNomCog" runat="server" CssClass="label label-primary"></asp:Label>
                <br />
            </div> 
            <div class="col-xs-3">
                P.IVA :<br />
                <asp:Label ID="lblPartitaIva" runat="server" CssClass="label label-primary"></asp:Label>
                <br />
            </div>
            <div class="col-xs-3">
                COD Fiscale :<br />
                <asp:Label ID="lblCodFisc" runat="server" CssClass="label label-primary"></asp:Label>
                <br />
            </div>
        </div><br />
        <div class="row">
            <div class="col-xs-5">
                Indirizzo :<br />
                <asp:Label ID="lblIndirizzo" runat="server" CssClass="label label-primary"></asp:Label>
                <br />
            </div>   
        </div><br />
        <div class="row">
            <div class="col-xs-3">Cap :<br />
                <asp:Label ID="lblCap" runat="server" CssClass="label label-primary"></asp:Label>
                <br />
            </div>
            <div class="col-xs-3">Provincia :<br />
                <asp:Label ID="lblProvincia" runat="server" CssClass="label label-primary"></asp:Label>
                <br />
            </div>
            <div class="row">
            <div class="col-xs-3">Regione :<br />
                <asp:Label ID="lblRegione" runat="server" CssClass="label label-primary"></asp:Label>
                <br />
            </div>
            <div class="col-xs-3">Nazione :<br />
                <asp:Label ID="lblNazione" runat="server" CssClass="label label-primary"></asp:Label>
                <br />
            </div>
            </div>
            </div>
        <br />
        <div class="row">
            <div class="col-xs-3">
                Telefono :<br />
                <asp:Label ID="lblTelefono" runat="server" CssClass="label label-primary"></asp:Label>
            </div>
        </div><br />
        <div class="row">
            <div class="col-xs-3">
                Numero Cellulare :<br />
                <asp:Label ID="lblNumCell" runat="server" CssClass="label label-primary"></asp:Label>
            </div>
            <div class="col-xs-3">
                Email :<br />
                <asp:Label ID="lblEmail" runat="server" CssClass="label label-primary"></asp:Label>
            </div>
            <div class="col-xs-6">
                <div class="col-xs-4">
                    Vecchia password :
                    <asp:TextBox ID="txtVecchiaPassword" runat="server" TextMode="Password" CssClass="form-control" ></asp:TextBox>
                </div>
                <div class="col-xs-4">
                    Nuova password
                    <asp:TextBox ID="txtNuovaPassword" runat="server" TextMode="Password" CssClass="form-control" ></asp:TextBox>
                </div>
                <div class="col-xs-4">
                    Conferma password
                    <asp:TextBox ID="txtConferma" runat="server" TextMode="Password" CssClass="form-control" ></asp:TextBox>
                </div><br />
                <div class="col-xs-7" style="margin-top:2%">
                <asp:Button ID="btnModifica" runat="server" OnClick="btnChiudi_Click" Text="Modifica password" CssClass="btn btn-primary" />
                    &nbsp&nbsp
                    <asp:Label ID="lblOperazione" runat="server"></asp:Label>
                </div>
                
            </div>
        </div>
    </div>
</asp:Content>