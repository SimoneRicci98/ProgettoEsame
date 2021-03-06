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
        <div class="col-xs-12">
     <div class="col-xs-4" style="border: solid 1px black;margin-top:2%">
        <div class="row">Nome/Azienda: <asp:Label ID="lblRagSoc" runat="server"></asp:Label></div>
        <div class="row">Indirizzo: <asp:Label ID="lblIndirizzoMio" runat="server"></asp:Label> </div>
        <div class="row">Codice fiscale: <asp:Label ID="lblCodFisc" runat="server"></asp:Label> </div>
        <div class="row">Partita iva: <asp:Label ID="lblPartIva" runat="server"></asp:Label> </div>
        <div class="row">N° telefono: <asp:Label ID="lblNumTel" runat="server"></asp:Label> </div>
        <div class="row">Email: <asp:Label ID="lblEmail" runat="server"></asp:Label> </div>
    </div>
        </div>

    <div class="col-xs-offset-7 col-xs-4" style="border: solid 1px black;margin-bottom:2%">
        <div class="row">Spettabile: <asp:Label ID="lblRagSocCliFor" runat="server"></asp:Label> </div>
        <div class="row">Indirizzo: <asp:Label ID="lblIndirizzoCliFor" runat="server"></asp:Label> </div>
        <div class="row">Codice fiscale: <asp:Label ID="lblCodFiscCliFor" runat="server"></asp:Label> </div>
        <div class="row">Partita iva: <asp:Label ID="lblPartIvaCliFor" runat="server"></asp:Label> </div>
        <div class="row">N° telefono: <asp:Label ID="lblNumTelCliFor" runat="server"></asp:Label> </div>
    </div><br />
        <div class="col-xs-12">
    <div class="col-xs-12" style="border: solid 1px black">
        <div class="col-xs-6">Oggetto: <asp:Label ID="lblOggetto" runat="server"></asp:Label></div>
    </div>
    <div class="col-xs-12" style="border: solid 1px black">
        <div class="col-xs-8">Fattura numero <asp:Label ID="lblNumFatt" runat="server"></asp:Label>&nbsp;del <asp:Label ID="lblDataFatt" runat="server"></asp:Label></div>
    </div>
    <div class="col-xs-12"style="border: solid 1px black;margin-bottom:2%">
        <div class="col-xs-5">
            Pagamento: <asp:Label ID="lblTipoPagamento" runat="server"></asp:Label>
        </div>
    </div>
        </div>
    <div class="col-xs-12">
        <div class="col-xs-2" style="border: solid 1px black">Codice articolo</div>
        <div class="col-xs-4" style="border: solid 1px black">Descrizione</div>
        <div class="col-xs-1" style="border: solid 1px black">Quantità</div>
        <div class="col-xs-2" style="border: solid 1px black">Prezzo unitario</div>
        <div class="col-xs-2" style="border: solid 1px black">Iva %</div>
        <div class="col-xs-1" style="border: solid 1px black">Importo</div>
    </div>
        <div class="col-xs-12">
            <%=caricatabella_imponibili()%>
        </div>
             
        <div class="col-xs-12" style="margin-top:2%">
    <div class="col-xs-2 col-xs-offset-10" style="text-align:right;border: solid 1px black">
        <b>Imponibile <asp:Label ID="lblImponibile" Font-Size="15px" runat="server"></asp:Label></b><br />
        <b>Imposta iva <asp:Label ID="lblImpostaIva" Font-Size="15px" runat="server"></asp:Label></b><br />
        <b>Totale fattura <asp:Label ID="lblTotFatt" Font-Size="15px" runat="server"></asp:Label></b></div>
        </div>
    </form>
</body>
</html>
