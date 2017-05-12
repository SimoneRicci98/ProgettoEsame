<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProvaGridViewFolle.aspx.cs" UnobtrusiveValidationMode="None" Inherits="ProvaGridViewFolle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
               <asp:GridView ID="grvStudentDetails" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="grvStudentDetails_RowDeleting" ShowFooter="True" Style="text-align: left" Width="97%">
                   <Columns>
                       <asp:BoundField DataField="RowNumber" HeaderText="Nr." />
                       <asp:TemplateField HeaderText="Conto di mastro">
                           <ItemTemplate>
                               <asp:DropDownList ID="drpConto" runat="server">
                                   <asp:ListItem>Seleziona conto</asp:ListItem>
                                   <asp:ListItem Value="conto1">conto1</asp:ListItem>
                                   <asp:ListItem Value="conto2">conto2</asp:ListItem>
                                   <asp:ListItem Value="conto3">conto3</asp:ListItem>
                               </asp:DropDownList>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="drpIva" ErrorMessage="*" InitialValue="Select"></asp:RequiredFieldValidator>
                           </ItemTemplate>
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="Avere">
                           <ItemTemplate>
                               <asp:TextBox ID="txtAvere" runat="server" MaxLength="50"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAvere" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Dare">
                           <ItemTemplate>
                               <asp:TextBox ID="txtDare" runat="server" MaxLength="3" Width="66px"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDare" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Iva">
                           <ItemTemplate>
                               <asp:DropDownList ID="drpIva" runat="server">
                                   <asp:ListItem Value="4">4</asp:ListItem>
                                   <asp:ListItem Value="10">10</asp:ListItem>
                                   <asp:ListItem Value="22">22</asp:ListItem>
                               </asp:DropDownList>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="drpIva" ErrorMessage="*" InitialValue="Select"></asp:RequiredFieldValidator>
                           </ItemTemplate>
                           <FooterStyle HorizontalAlign="Right" />
                           <FooterTemplate>
                               <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="Add New Row" />
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
        
    </div>
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save Data" />
    </form>
</body>
</html>
