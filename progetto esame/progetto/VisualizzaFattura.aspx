﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VisualizzaFattura.aspx.cs" Inherits="VisualizzaFattura" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div class="col-xs-4">
        <div class="row">nome/azienda <asp:Label ID="lblRagSoc" runat="server"></asp:Label></div>
        <div class="row">indirizzo <asp:Label ID="lblIndirizzoMio" runat="server"></asp:Label> </div>
        <div class="row">Codice fiscale <asp:Label ID="lblCodFisc" runat="server"></asp:Label> </div>
        <div class="row">partita iva <asp:Label ID="lblPartIva" runat="server"></asp:Label> </div>
        <div class="row">n° telefono <asp:Label ID="lblNumTel" runat="server"></asp:Label> </div>
        <div class="row">email <asp:Label ID="lblEmail" runat="server"></asp:Label> </div>
    </div>
    <div class="col-xs-offset-7 col-xs-4">
        <div class="row">spettabile <asp:Label ID="lblRagSocCliFor" runat="server"></asp:Label> </div>
        <div class="row">indirizzo <asp:Label ID="lblIndirizzoCliFor" runat="server"></asp:Label> </div>
        <div class="row">Codice fiscale <asp:Label ID="lblCodFiscCliFor" runat="server"></asp:Label> </div>
        <div class="row">partita iva <asp:Label ID="lblPartIvaCliFor" runat="server"></asp:Label> </div>
        <div class="row">n° telefono <asp:Label ID="lblNumTelCliFor" runat="server"></asp:Label> </div>
    </div>
    <div class="col-xs-12">
        <div class="col-xs-6">Oggetto <asp:Label ID="lblOggetto" runat="server"></asp:Label></div>
    </div>
    <div class="col-xs-12">
        <div class="col-xs-8">Fattura numero <asp:Label ID="lblNumFatt" runat="server"></asp:Label>&nbsp;del <asp:Label ID="lblDataFatt" runat="server"></asp:Label></div>
    </div>
    <div class="col-xs-12">
        <div class="col-xs-5">
            pagamento <asp:Label ID="lblTipoPagamento" runat="server"></asp:Label>
        </div>
    </div>
    <div class="col-xs-12">
        <div class="col-xs-1">cod articolo</div>
        <div class="col-xs-5">descrizione</div>
        <div class="col-xs-1">quantità</div>
        <div class="col-xs-2">prezzo unitario</div>
        <div class="col-xs-1">sconto</div>
        <div class="col-xs-1">importo</div>
        <div class="col-xs-1">iva</div>
    </div>
        <%=caricatabella_imponibili()%> 
    <div class="col-xs-12" style="text-align:right">
        imponibile <asp:Label ID="lblImponibile" runat="server"></asp:Label><br />
        imposta iva <asp:Label ID="lblImpostaIva" runat="server"></asp:Label><br />
        tot fatt <asp:Label ID="lblTotFatt" runat="server"></asp:Label></div>
        <div class="col-xs-12">
            <asp:Button ID="btnStampa" runat="server" Text="Scarica in pdf" CssClass="btn btn-primary" OnClick="btnStampa_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSalva" runat="server" Text="Salva" CssClass="btn btn-primary" OnClick="btnSalva_Click" />
        </div>
    </form>
</body>
</html>