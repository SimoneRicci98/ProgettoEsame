<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrimaNota.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="PrimaNota" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript">

function openWindow() {
window.open('AggiungiAnagrafica.aspx','PopUp','width=500,height=500,menubar=yes,toolbar=yes,resizable=yes');
        }
        </script>

    <div class="col-md-12">
            <div class="row">
                <div class="col-md-2">
                     Data operazione
                </div>
               <div class="col-md-3">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> dd/mm/yyyy
               </div>
                <div class="col-md-4">
                    <div class="col-md-6">
                        <asp:RadioButton ID="radioEmessa" runat="server" GroupName="Fattura" Text="Fattura Emessa" />
                    </div>
                    <div class="col-md-6">
                        <asp:RadioButton ID="radioRicevuta" runat="server" GroupName="Fattura" Text="Fattura ricevuta" />
                    </div>
                    <dialog class="modal-dialog">
                        
                    </dialog>
                </div>
                <br />
                <br />
            </div>
            <div class="row">
                <div class="col-md-2">
                    Data Fattura 
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox> dd/mm/yyyy
                </div>
               <div class="col-md-4">
                   <div class="col-md-6">
                    <asp:RadioButton ID="radioCliente" runat="server" GroupName="ClienteFornitore" Text="Cliente" />
                       <br />
                       <asp:DropDownList ID="DropDownList1" runat="server">
                       </asp:DropDownList>
                   <br />
                   <input id="Button1" type="button" language="javascript" onclick="return openWindow()" value="Aggiungi cliente" />
                   </div>
                   <div class="col-md-6">
                    <asp:RadioButton ID="radioFornitore" runat="server" GroupName="ClienteFornitore" Text="Fornitore" />
                       <br />
                       <asp:DropDownList ID="DropDownList2" runat="server">
                       </asp:DropDownList>
                       <br />
                   <input id="Button2" type="button" language="javascript" onclick="return openWindow()" value="Aggiungi  fornitore" /></div>

                </div>
                <br />
            </div>
    </div>
</asp:Content>