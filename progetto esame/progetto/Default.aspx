<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="_Default" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="content1">
    <div class="col-md-12" style="margin-top:2%">
        <div class="col-md-4">
            
            Inserisci il nome con il quale vuoi essere riconosciuto<br />
            
            <asp:TextBox ID="txtUtente" runat="server" OnTextChanged="txtUtente_TextChanged" CssClass="form-control" Width="90%"></asp:TextBox>
            <asp:Label ID="lblErr2" runat="server" ForeColor="#CC0000"></asp:Label>
            <br />
            Inserisci qui la domanda<br />
            <asp:TextBox ID="txtDomanda" runat="server" OnTextChanged="TextBox2_TextChanged" TextMode="MultiLine" Width="90%" CssClass="form-control" Rows="5" ></asp:TextBox>
            
            <asp:Label ID="lblErr1" runat="server" ForeColor="#CC0000"></asp:Label>
            
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click"  Text="Invia" CssClass="btn btn-primary" />
            <br />
            <br />
            <asp:ListBox ID="lstDomande" runat="server" Rows="10" Width="80%" CssClass="list-group-item"></asp:ListBox>
            
        </div>
        <div class="col-md-4">
            qui le possibilità di acquisti con le relative caratteristiche 
            <div class="row">
                Versione di prova <br />
                Qui potrai provare le potenzialità di questo software web ma con qualche restrizione,
                come il limite di 10 fatture e avere al massimo 5 clienti e 3 fornitori
                <br />
                <asp:Button ID="btnProva" runat="server" Text="Prosegui" OnClick="btnProva_Click" CssClass="btn btn-primary" />
            </div>
            <div class="row" style="margin-top:1%">
                Versione completa <br />
                Qui potrai utilizzare questo software web con tutte le sue caratterestiche,
                nessuna restrizione e supporto immediato tramite mail
                <br />
                <asp:Button ID="btnCompleta" runat="server" Text="Prosegui" OnClick="btnCompleta_Click" CssClass="btn btn-primary" />
            </div>
        </div>
        <div class="col-md-4">
            
            Qui rispondo alle vostre domande settimanalmente<br />
            <asp:ListBox ID="lstRisposte" runat="server" Rows="10" Width="80%" CssClass="list-group-item"></asp:ListBox>
            
            </div>
    </div>

</asp:Content>