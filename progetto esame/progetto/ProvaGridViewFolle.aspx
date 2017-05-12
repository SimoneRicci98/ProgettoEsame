<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProvaGridViewFolle.aspx.cs" Inherits="ProvaGridViewFolle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

table {
  background-color: transparent;
}
table {
  border-spacing: 0;
  border-collapse: collapse;
}
* {
  -webkit-box-sizing: border-box;
     -moz-box-sizing: border-box;
          box-sizing: border-box;
}
  *,
  *:before,
  *:after {
    color: #000 !important;
    text-shadow: none !important;
    background: transparent !important;
    -webkit-box-shadow: none !important;
            box-shadow: none !important;
  }
  th {
  text-align: left;
}
td,
th {
  padding: 0;
}
input,
button,
select,
textarea {
  font-family: inherit;
  font-size: inherit;
  line-height: inherit;
}
button,
select {
  text-transform: none;
}
button,
input,
optgroup,
select,
textarea {
  margin: 0;
  font: inherit;
  color: inherit;
}
input {
  line-height: normal;
}
button,
html input[type="button"],
input[type="reset"],
input[type="submit"] {
  -webkit-appearance: button;
  cursor: pointer;
}
.btn-primary {
  color: #fff;
  background-color: #337ab7;
  border-color: #2e6da4;
}
.btn {
  display: inline-block;
  padding: 6px 12px;
  margin-bottom: 0;
  font-size: 14px;
  font-weight: normal;
  line-height: 1.42857143;
  text-align: center;
  white-space: nowrap;
  vertical-align: middle;
  -ms-touch-action: manipulation;
      touch-action: manipulation;
  cursor: pointer;
  -webkit-user-select: none;
     -moz-user-select: none;
      -ms-user-select: none;
          user-select: none;
  background-image: none;
  border: 1px solid transparent;
  border-radius: 4px;
}
        .auto-style1 {
            color: White;
            font-weight: bold;
            background-color: #507CD1;
        }
        .auto-style2 {
            background-color: #EFF3FB;
        }
        .auto-style3 {
            background-color: White;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
               <asp:gridview ID="Gridview1" runat="server" ShowFooter="True" AutoGenerateColumns="False" OnRowCommand="ButtonAdd_Click" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">       
                   <AlternatingRowStyle BackColor="White" />
                   <Columns>
       <asp:TemplateField HeaderText="Tipo">
            <ItemTemplate>
                <asp:DropDownList ID="comboTipo" runat="server" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:DropDownList>
            </ItemTemplate>
       <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="IVA">
            <ItemTemplate>
                <asp:DropDownList ID="comboIVA" runat="server" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:DropDownList>
            </ItemTemplate>
       <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Imponibile">
            <ItemTemplate>
                 <asp:TextBox ID="TextBox3" Text="0" runat="server" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:TextBox>
            </ItemTemplate>
            <FooterStyle HorizontalAlign="Right" />
            <FooterTemplate>
             <asp:Button ID="ButtonAdd" runat="server" Text="Aggiungi una riga" cssClass="btn btn-primary"/>
            </FooterTemplate>
       <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Importo iva" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                       <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                       <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                       <ItemTemplate>
                        <asp:Label ID="lblImpoIva" runat="server" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:Label>
                       </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Conto di mastro">
                           <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                        <asp:DropDownList ID="comboConto" runat="server" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:DropDownList>
                       </ItemTemplate>
                       </asp:TemplateField>
                   </Columns>
                   <EditRowStyle BackColor="#2461BF" />
                   <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                   <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                   <RowStyle BackColor="#EFF3FB" />
                   <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                   <SortedAscendingCellStyle BackColor="#F5F7FB" />
                   <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                   <SortedDescendingCellStyle BackColor="#E9EBEF" />
                   <SortedDescendingHeaderStyle BackColor="#4870BE" />
</asp:gridview>
        
    </div>
    </form>
</body>
</html>
