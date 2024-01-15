<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InvoiceIT.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="style.css" />
    <title>login page</title>
</head>
<body class="body">
    <h1 class ="h1">  InvoiceIT Company Login Page </h1>
    
    <form id="form1" runat="server">
        
        <div class="frm_row_cont"> 
            <asp:Label ID="lblusrnm" runat="server" Text="Username" Class="frmlabel" ></asp:Label>
            <br/>
            <asp:TextBox ID="cntrlusrnm" runat="server" Class="tbinput" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="valusrnm" runat="server" ErrorMessage="Username is required !" ControlToValidate="cntrlusrnm" Display="Static"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="reqUserEmail" runat="server" ErrorMessage="Invalid Username!. Please try again" ControlToValidate="cntrlusrnm"
                ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" ></asp:RegularExpressionValidator>
        </div><br/>
        <div class="frm_row_cont"> 
            <asp:Label ID="lblpsswrd" runat="server" Text="Password" Class="frmlabel" ></asp:Label>
            <br/>
            <asp:TextBox ID="cntrlusrpasswrd" runat="server" Class="tbinput" TextMod="Password" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="valpasswrd" runat="server" ErrorMessage="Password is required !" ControlToValidate="cntrlusrpasswrd" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont">
            <asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="btnlogin_Click" Class ="button" />
        </div>

    </form>
</body>
</html>
