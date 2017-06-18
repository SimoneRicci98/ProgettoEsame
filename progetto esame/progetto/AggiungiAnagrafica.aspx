<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AggiungiAnagrafica.aspx.cs" UnobtrusiveValidationMode="None" MasterPageFile="~/MasterPage.master" Inherits="AggiungiAnagrafica" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-12">
     <div class="row" style="text-align:center">
         Inserisci dati
         <asp:Label ID="lblAz" runat="server"></asp:Label>
         <br />
        </div>
        <div class="row">
            <div class="col-xs-3">
                Ragione Sociale
                <br />
                <span class="glyphicon glyphicon-home"></span>&nbsp<asp:TextBox ID="txtRagSoc" runat="server" ValidationGroup="text" CssClass="form-control" Width="40%"></asp:TextBox>
                
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
         runat="server"
         ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtRagSoc" CssClass="alert-danger"></asp:RequiredFieldValidator><br />
            </div> 
        </div>
        <div class="row">
            <div class="col-xs-3">
                Nome e cognome<br />
            <span class="glyphicon glyphicon-user"></span>&nbsp<asp:TextBox ID="txtNomCog" runat="server" ValidationGroup="text" CssClass="form-control" Width="40%"></asp:TextBox>
                
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
         runat="server"
            Text="Compila questo campo"
             ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtNomCog" CssClass="alert-danger">
    </asp:RequiredFieldValidator><br />
            </div> 
            <div class="col-xs-4">
                P.IVA<br />
           <span class="glyphicon glyphicon-credit-card"></span>&nbsp<asp:TextBox ID="txtPIva" runat="server" ValidationGroup="text" CssClass="form-control" Width="40%"></asp:TextBox>
                <asp:Label ID="lblErr0" runat="server"></asp:Label>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
         runat="server"
            Text="Compila questo campo"
             ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtPIva" CssClass="alert-danger">
    </asp:RequiredFieldValidator>&nbsp;
                <br />
            </div> 
        </div>
        <div class="row">
            <div class="col-xs-4">
                COD Fiscale<br />
                <span class="glyphicon glyphicon-credit-card"></span>&nbsp<asp:TextBox ID="txtCodF" runat="server" ValidationGroup="text" CssClass="form-control" Width="40%"></asp:TextBox>    
     <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
         runat="server"
            Text="Compila questo campo"
             ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtCodF" CssClass="alert-danger"></asp:RequiredFieldValidator>&nbsp;
                <asp:Label ID="lblErr1" runat="server" CssClass="alert-danger"></asp:Label>
                <br />
            </div>
        </div>
        <div class="row">
            <div class="col-xs-5">
                Indirizzo<br />
            <span class="glyphicon glyphicon-road"></span>&nbsp<asp:TextBox ID="txtIndirizzo" runat="server" Width="70%" ValidationGroup="text" CssClass="form-control"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
         runat="server"
            Text="Compila questo campo"
             ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtIndirizzo" CssClass="alert-danger">
    </asp:RequiredFieldValidator>
<br />
            </div>   
        </div>
        <div class="row">
            <div class="col-xs-3">Cap<br />
            <span class="glyphicon glyphicon-road"></span>&nbsp<asp:TextBox ID="txtCap" runat="server" ValidationGroup="text" CssClass="form-control" Width="40%"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator9"
         runat="server"
            Text="Compila questo campo"
             ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtCap" CssClass="alert-danger">
    </asp:RequiredFieldValidator><br />
            </div>
         <div class="row">
            <div class="col-xs-3">Provincia<br />
            <span class="glyphicon glyphicon-road"></span>&nbsp<asp:TextBox ID="txtProv" runat="server" ValidationGroup="text" CssClass="form-control" Width="40%"></asp:TextBox>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator14"
         runat="server"
         Text="Compila questo campo"
             ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtProv" CssClass="alert-danger">
    </asp:RequiredFieldValidator>
            </div>
             <div class="col-xs-3">
             Regione<br />
            <span class="glyphicon glyphicon-road"></span>&nbsp<asp:TextBox ID="txtReg" runat="server" ValidationGroup="text" CssClass="form-control" Width="40%"></asp:TextBox>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
         runat="server"
         Text="Compila questo campo"
             ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtReg" CssClass="alert-danger">
    </asp:RequiredFieldValidator>
             </div>
            <div class="col-xs-3">Nazione<br />
            <span class="glyphicon glyphicon-road"></span>&nbsp<asp:TextBox ID="txtNaz" runat="server" ValidationGroup="text" CssClass="form-control" Width="40%"></asp:TextBox>    
              <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
         runat="server"
             ValidationGroup="control"
            Text="Compila questo campo"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtNaz" CssClass="alert-danger">
    </asp:RequiredFieldValidator>
            </div>
            </div>
            </div>
        <div class="row">
            <div class="col-xs-3">
                Telefono<br />
            <span class="glyphicon glyphicon-phone-alt"></span>&nbsp<asp:TextBox ID="txtTel" runat="server" ValidationGroup="text" CssClass="form-control" Width="40%"></asp:TextBox>
                
   <asp:RequiredFieldValidator ID="RequiredFieldValidator10"
         runat="server"
             Text="Compila questo campo"
              ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtTel" CssClass="alert-danger">
    </asp:RequiredFieldValidator>
                <br />
            </div>
        </div>
        <div class="row">
            <div class="col-xs-3">
                Numero Cellulare<br />
            <span class="glyphicon glyphicon-phone"></span>&nbsp<asp:TextBox ID="txtNUmCell" runat="server" ValidationGroup="text" CssClass="form-control" Width="40%"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator12"
         runat="server"
         Text="Compila questo campo"
         ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtNUmCell" CssClass="alert-danger">
    </asp:RequiredFieldValidator><br />
            </div>
            <div class="col-xs-3">
                Email<br />
            <span class="glyphicon glyphicon-envelope"></span>&nbsp<asp:TextBox ID="txtEmail" runat="server" ValidationGroup="text" CssClass="form-control" Width="40%"></asp:TextBox>
                
         <asp:RequiredFieldValidator ID="RequiredFieldValidator13"
         runat="server"
         Text="Compila questo campo"
         ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtEmail" CssClass="alert-danger">
        </asp:RequiredFieldValidator><br />
            </div>
        </div>
         <br />
        <div class="col-xs-6" style="margin-bottom:1%">
            <span class="glyphicon glyphicon-ok"></span>&nbsp<asp:LinkButton ID="Button1" runat="server" Text="Inserisci" OnClick="Button1_Click" CssClass="btn btn-primary">Inserisci</asp:LinkButton>
    &nbsp;&nbsp;
            <span class="glyphicon glyphicon-remove"></span>&nbsp<asp:LinkButton ID="btnChiudi" runat="server" OnClick="btnChiudi_Click" Text="Chiudi" CssClass="btn btn-primary">Chiudi</asp:LinkButton>
        </div>
    </div>  
</asp:Content>