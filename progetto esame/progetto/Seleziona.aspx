<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Seleziona.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Fatturazione" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <a href="CreaFattura.aspx"><div class="col-md-3"><div class="col-md-12" style="border:solid 1px green">Crea fattura<br />Clicca su questo spazio per creare una fattura</div></div></a>
        <a href="PrimaNota.aspx"><div class="col-md-2"><div class="col-md-12" style="border:solid 1px green">Prima nota<br />Clicca su questo spazio per entrare in prima nota</div></div></a>
        <a href="Giornale.aspx"><div class="col-md-2"><div class="col-md-12" style="border:solid 1px green">Visualizza giornale<br />Clicca su questo spazio per visualizzare il giornale</div></div></a>
        <a href="ContiDiMastro.aspx"><div class="col-md-2"><div class="col-md-12" style="border:solid 1px green">Aggiungi conti di mastro<br />Clicca su questo spazio per aggungere i tuoi conti di mastro</div></div></a>
        <a href="AreaPersonale.aspx"><div class="col-md-3"><div class="col-md-12" style="border:solid 1px green">Area personale<br />Clicca su questo spazio per accedere alla tua area personale</div></div></a>
    </div>    
</asp:Content>