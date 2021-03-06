﻿<%@ Page Language="C#" AutoEventWireup="true" UnobtrusiveValidationMode="none" CodeFile="PrimaNota.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="PrimaNota" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-12">
                 <div class="row" style="text-align:center;margin-bottom:1%">
            <div class="col-xs-12">
               <h4>Tutti i dati sono obbligatori</h4>
            </div>
             </div>
            <div class="row">
                <div class="col-xs-2">
                     Data operazione
                </div>
               <div class="col-xs-3">
                    <asp:TextBox ID="txtDataOperazione" runat="server" TextMode="Date"></asp:TextBox> &nbsp;<asp:Label ID="lblErr1" runat="server" CssClass="alert-danger" Text="Impossibile inserire una data futura" Visible="False"></asp:Label>
                    </div>
                <div class="col-xs-4">
                    <div class="col-xs-6">
                        <asp:RadioButton ID="radioEmessa" runat="server" GroupName="Fattura" Text="Fattura Emessa" />
                    </div>
                    <div class="col-xs-6">
                        <asp:RadioButton ID="radioRicevuta" runat="server" GroupName="Fattura" Text="Fattura ricevuta" />
                    </div>
                </div>
                <br />
                <br />
            </div>
            <div class="row">
                <div class="col-xs-2">
                    Data Fattura 
                </div>
                <div class="col-xs-3">
                    <asp:TextBox ID="txtDataFattura" runat="server" TextMode="Date"></asp:TextBox> &nbsp;<asp:Label ID="lblErr2" runat="server" CssClass="alert-danger" Text="Impossibile inserire una data futura" Visible="False"></asp:Label>
                </div>
               <div class="col-xs-4">
                   <div class="col-xs-6">
                    <asp:RadioButton ID="radioCliente" runat="server" GroupName="ClienteFornitore" Text="Cliente" />
                       <br /><br />
                       <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                       </asp:DropDownList>
                       <br /><br />
                   <asp:Button ID="btnAggCli" runat="server" CssClass="btn btn-primary" OnClick="btnAggCli_Click" Text="Aggiugi cliente" />
                   </div>
                   <div class="col-xs-6">
                    <asp:RadioButton ID="radioFornitore" runat="server" GroupName="ClienteFornitore" Text="Fornitore" />
                       <br /><br />
                       <asp:DropDownList ID="DropDownList2" runat="server">
                       </asp:DropDownList>
                       <br /><br />
                   <asp:Button ID="btnAggFor" runat="server" CssClass="btn btn-primary" Text="Aggiungi fornitore" OnClick="btnAggFor_Click" />
                   </div>
                </div>
                <br />
            </div>
        <div class="row" style="margin-top:2%">
            <div class="col-xs-4">
                N° Documento&nbsp;&nbsp;
                <asp:TextBox ID="txtNumDoc" runat="server" ></asp:TextBox><br />
            </div>
            <div class="col-xs-4">
                Protocollo&nbsp;&nbsp;
                <asp:TextBox ID="txtProt" runat="server"></asp:TextBox><br />
            </div>
            <div class="col-xs-4">
                Totale documento&nbsp;&nbsp;
                <asp:TextBox ID="txtTot" runat="server"></asp:TextBox><br />
            </div> <br />
        </div>                
        <div class="col-xs-6">
             Descrizione &nbsp;&nbsp; <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine"></asp:TextBox>
         </div>
            </div>
        <div class="row" style="margin-top:2%">
            <div class="col-xs-12" style="margin-top:2%">
               <asp:GridView ID="grvPrimaNota" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="grvStudentDetails_RowDeleting" ShowFooter="True" Style="text-align: left" Width="97%">
                   <Columns>
                       <asp:BoundField DataField="RowNumber" HeaderText="Nr." />
                       <asp:TemplateField HeaderText="Conto di mastro">
                           <ItemTemplate>
                               <asp:DropDownList ID="drpConto" runat="server">
                               </asp:DropDownList>
                           </ItemTemplate>
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="Dare">
                           <ItemTemplate>
                               <asp:TextBox ID="txtDare" runat="server"></asp:TextBox>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Avere">
                           <ItemTemplate>
                               <asp:TextBox ID="txtAvere" runat="server" ></asp:TextBox>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Iva">
                           <ItemTemplate>
                               <asp:DropDownList ID="drpIva" runat="server">
                                   <asp:ListItem Value="0">0</asp:ListItem>
                                   <asp:ListItem Value="4">4</asp:ListItem>
                                   <asp:ListItem Value="10">10</asp:ListItem>
                                   <asp:ListItem Value="22">22</asp:ListItem>
                               </asp:DropDownList>
                           </ItemTemplate>
                           <FooterStyle HorizontalAlign="Right" />
                           <FooterTemplate>
                               <asp:Button ID="ButtonAdd" CssClass="btn btn-primary" runat="server" OnClick="ButtonAdd_Click" Text="Aggiungi una riga" />
                           </FooterTemplate>
                       </asp:TemplateField>
                       <asp:CommandField ShowDeleteButton="True" />
                   </Columns>
                   <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                   <RowStyle BackColor="#EFF3FB" />
                   <EditRowStyle BackColor="#2461BF" />
                   <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                   <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                   <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                   <AlternatingRowStyle BackColor="White" />
               </asp:GridView>
        
                <br />
        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click" Text="Salva dati" />
            &nbsp; Salvare solo a fine operazione!&nbsp;
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click" Text="Stampa a video" />
            </div>
        </div>
</asp:Content>