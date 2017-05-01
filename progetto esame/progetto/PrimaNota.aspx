<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrimaNota.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="PrimaNota" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
            <div class="row">
                <div class="col-md-3">
                     Data operazione
                </div>
               <div class="col-md-3">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
               </div>
                <div class="col-md-3">
                    <asp:RadioButton ID="radioEmessa" runat="server" GroupName="Fattura" Text="Fattura Emessa" />
                </div>
                <div class="col-md-3">
                    <asp:RadioButton ID="radioRicevuta" runat="server" GroupName="Fattura" Text="Fattura ricevuta" />
                </div>
                <br />
                <br />
            </div>
            <div class="row">
                <div class="col-md-3">
                    Data Fattura 
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </div>
               <div class="col-md-3">
                    <asp:RadioButton ID="radioCliente" runat="server" GroupName="ClienteFornitore" Text="Cliente" />
               </div>
                <div class="col-md-3">
                    <asp:RadioButton ID="radioFornitore" runat="server" GroupName="ClienteFornitore" Text="Fornitore" />
                </div>
                <br />
            </div>
    </div>
</asp:Content>