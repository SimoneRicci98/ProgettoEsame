<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AggiungiAnagrafica.aspx.cs" UnobtrusiveValidationMode="None" MasterPageFile="~/MasterPage.master" Inherits="AggiungiAnagrafica" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
     <div class="row" style="text-align:center">
         Inserisci dati
         <asp:Label ID="lblAz" runat="server"></asp:Label>
         <br />
        </div>
        <div class="row">
            <div class="col-md-3">
                Ragione Sociale
                <br />
                <asp:TextBox ID="txtRagSoc" runat="server" ValidationGroup="text"></asp:TextBox>
                
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
         runat="server"
         ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtRagSoc" CssClass="alert-danger"></asp:RequiredFieldValidator><br />
            </div> 
        </div>
        <div class="row">
            <div class="col-md-3">
                Nome e cognome<br />
            <asp:TextBox ID="txtNomCog" runat="server" ValidationGroup="text"></asp:TextBox>
                
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
         runat="server"
            Text="Compila questo campo"
             ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtNomCog" CssClass="alert-danger">
    </asp:RequiredFieldValidator><br />
            </div> 
            <div class="col-md-3">
                P.IVA<br />
                <asp:TextBox ID="txtPIva" runat="server" ValidationGroup="text"></asp:TextBox>
                
      <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
         runat="server"
            Text="Compila questo campo"
             ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtPIva" CssClass="alert-danger">
    </asp:RequiredFieldValidator><br />
            </div> 
        </div>
        <div class="row">
            <div class="col-md-3">
                COD Fiscale<br />
                <asp:TextBox ID="txtCodF" runat="server" ValidationGroup="text"></asp:TextBox>    
     <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
         runat="server"
            Text="Compila questo campo"
             ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtCodF" CssClass="alert-danger"></asp:RequiredFieldValidator><br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-5">
                Indirizzo<br />
            <asp:TextBox ID="txtIndirizzo" runat="server" Width="70%" ValidationGroup="text"></asp:TextBox>
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
            <div class="col-md-3">Nazione<br />
            <asp:TextBox ID="txtNaz" runat="server" ValidationGroup="text"></asp:TextBox>
                
              <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
         runat="server"
             ValidationGroup="control"
            Text="Compila questo campo"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtNaz" CssClass="alert-danger">
    </asp:RequiredFieldValidator><br />
            </div>
            <div class="col-md-3">Regione<br />
            <asp:TextBox ID="txtReg" runat="server" ValidationGroup="text"></asp:TextBox>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
         runat="server"
         Text="Compila questo campo"
             ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtReg" CssClass="alert-danger">
    </asp:RequiredFieldValidator>
            </div>
            <div class="row">
            <div class="col-md-3">Provincia<br />
            <asp:TextBox ID="txtProv" runat="server" ValidationGroup="text"></asp:TextBox>
                
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8"
         runat="server"
            Text="Compila questo campo"
             ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtProv" CssClass="alert-danger">
    </asp:RequiredFieldValidator><br />
            </div>
            <div class="col-md-3">Cap<br />
            <asp:TextBox ID="txtCap" runat="server" ValidationGroup="text"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator9"
         runat="server"
            Text="Compila questo campo"
             ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtCap" CssClass="alert-danger">
    </asp:RequiredFieldValidator><br />
            </div>
            </div>
            </div>
        <div class="row">
            <div class="col-md-3">
                Telefono<br />
            <asp:TextBox ID="txtTel" runat="server" ValidationGroup="text"></asp:TextBox>
                
   <asp:RequiredFieldValidator ID="RequiredFieldValidator10"
         runat="server"
             Text="Compila questo campo"
              ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtTel" CssClass="alert-danger">
    </asp:RequiredFieldValidator>
                <br />
            </div>
            <div class="col-md-3">
                Fax<br />
            <asp:TextBox ID="txtFax" runat="server" ValidationGroup="text"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator11"
         runat="server"
         Text="Compila questo campo"
         ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtFax" CssClass="alert-danger">
    </asp:RequiredFieldValidator>
                <br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                Numero Cellulare<br />
            <asp:TextBox ID="txtNUmCell" runat="server" ValidationGroup="text"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator12"
         runat="server"
         Text="Compila questo campo"
         ValidationGroup="control"
         ErrorMessage="Compila questo campo"
         ControlToValidate="txtNUmCell" CssClass="alert-danger">
    </asp:RequiredFieldValidator><br />
            </div>
            <div class="col-md-3">
                Email<br />
            <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="text"></asp:TextBox>
                
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
        <asp:Button ID="Button1" runat="server" Text="Inserisci" OnClick="Button1_Click" ValidationGroup="control" CssClass="btn-default" />
    </div>  
</asp:Content>