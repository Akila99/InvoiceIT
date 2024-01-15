 b<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add a New client.aspx.cs" Inherits="InvoiceIT.Add_a_New_client" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="style.css" />
    <title>Add a New Client</title>
</head>
<body class="body">
    <h2>Add a new Client</h2>
    <form id="frmnewclient" runat="server">
        <div class="frm_row_cont">
            <asp:Label ID="lblclicomname" runat="server" Text="Client Company Name*" Class="frmlabel"></asp:Label>
            <br/>
            <asp:TextBox ID="txtclicompname" runat="server" Class="tbinput"></asp:TextBox>
             <asp:RequiredFieldValidator ID="valclicompnam" runat="server" ErrorMessage="Company Name is required !" ControlToValidate="txtclicompname" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont">
        <asp:Label ID="lblcompadd1" runat="server" Text="Client Company Address 1*" Class ="frmlabel"></asp:Label>
            <br/>
            <asp:TextBox ID="txtclicomadd1" runat="server" Class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valcompadd1" runat="server" ErrorMessage="Company Address 1 is required !" ControlToValidate="txtclicomadd1" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont">
            <asp:Label ID="lblcomadd2" runat="server" Text="Client Company Address 2*" Class="frmlabel"></asp:Label>
            <br/>
            <asp:TextBox ID="txtcopadd2" runat="server" Class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valcompadd2" runat="server" ErrorMessage="Company Name 2 is required !" ControlToValidate="txtcopadd2" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont">
        <asp:Label ID="lblcomploc" runat="server" Text="Client Company Location*" Class="frmlabel"></asp:Label>
        <br/>
            <asp:TextBox ID="txtcomploc" runat="server" Class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valcomploc" runat="server" ErrorMessage="Company Location is required !" ControlToValidate="txtcomploc" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont">
           <asp:Label ID="lblcompcod" runat="server" Text="Client Company code*" Class="frmlabel"></asp:Label>
        <br/>
            <asp:TextBox ID="txtcompcod" runat="server" Class="tbinput" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="valcompcod" runat="server" ErrorMessage="Company Code is required !" ControlToValidate="txtcomploc" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont">
            <asp:Label ID="lblconfnam" runat="server" Text="Contact First Name*" Class="frmlabel"></asp:Label>
            <br/>
            <asp:TextBox ID="txtconfnam" runat="server" Class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valconfnam" runat="server" ErrorMessage="Contact First Name is required !" ControlToValidate="txtconfnam" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont">
          <asp:Label ID="lblconlnam" runat="server" Text="Contact Last Name*" Class="frmlabel"></asp:Label>
            <br/>
            <asp:TextBox ID="txtconlnam" runat="server" Class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valconlnam" runat="server" ErrorMessage="Contact Last Name is required !" ControlToValidate="txtconlnam" Display="Static"></asp:RequiredFieldValidator>
        </div><br />
        <div class="frm_row_cont">
        <asp:Label ID="lblconemail" runat="server" Text="Contact Email*" Class ="frmlabel"></asp:Label>
            <br/>
            <asp:TextBox ID="txtconemail" runat="server" Class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valconemail" runat="server" ErrorMessage="Contact Email is required !" ControlToValidate="txtconemail" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont">
           <asp:Label ID="lblconmob" runat="server" Text="Contact Mobile No*" Class ="frmlabel"></asp:Label>
            <br/>
            <asp:TextBox ID="txtconmob" runat="server" Class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valconmob" runat="server" ErrorMessage="Contact Mobile Number is required !" ControlToValidate="txtconmob" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont">
          <asp:Label ID="lblbill" runat="server" Text="Bill to" Class ="frmlabel"></asp:Label>
        <br/>
            <asp:DropDownList ID="drpbillto" runat="server" Class="tbinput">
                <asp:ListItem>Company</asp:ListItem>
                <asp:ListItem>Client</asp:ListItem>
            </asp:DropDownList>
        </div><br />
        <div class="frm_row_cont">
          <asp:Label ID="lblsta" runat="server" Text="Status" Class ="frmlabel"></asp:Label>
            <br/>
            <asp:DropDownList ID="drpsts" runat="server" Class="tbinput">
                <asp:ListItem>Good</asp:ListItem>
                <asp:ListItem>In Arrears</asp:ListItem>
                <asp:ListItem>Discontinued</asp:ListItem>
            </asp:DropDownList>
        </div><br />
        <div>
            <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick ="btnsubmit_Click" Class ="button" />
        </div>
        
    </form>

</body>
</html>
