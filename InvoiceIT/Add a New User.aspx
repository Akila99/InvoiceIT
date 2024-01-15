<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add a New User.aspx.cs" Inherits="InvoiceIT.Add_a_New_User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="style.css" />
    <title>Add a New user</title>
</head>
<body class="body">
    <h2>Add a New User</h2>
    <form id="frmnwusr" runat="server">
        <div class="frm_row_cont">
            <asp:Label ID="lblusrfnam" runat="server" Text="User First Name" Class="frmlabel"></asp:Label>
           <br/>
            <asp:TextBox ID="txtusrnam" runat="server" Class="tbinput"></asp:TextBox>
             <asp:RequiredFieldValidator ID="valusernam" runat="server" ErrorMessage="user Name is required !" ControlToValidate="txtusrnam" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont">
          <asp:Label ID="lblsysrol" runat="server" Text="User System Role eg-:0-Client |1-Staff | 2-Admin" Class ="frmlabel"></asp:Label>
            <br/>
            <asp:DropDownList ID="drsysrol" runat="server" Class="tbinput">
                <asp:ListItem>0</asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
            </asp:DropDownList>
            </div>
            <div class="frm_row_cont">
            <asp:Label ID="lblemail" runat="server" Text="User Email" Class="frmlabel"></asp:Label>
            <br/>
            <asp:TextBox ID="txtemail" runat="server" Class="tbinput"></asp:TextBox>
             <asp:RequiredFieldValidator ID="Valusremail" runat="server" ErrorMessage="user Email is required !" ControlToValidate="txtusrnam" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
            <div class="frm_row_cont">
            <asp:Label ID="lblpassword" runat="server" Text="User Password" Class="frmlabel"></asp:Label>
            <br/>
            <asp:TextBox ID="txtpasswrd" runat="server" Class="tbinput" TextMode="Password"></asp:TextBox>
             <asp:RequiredFieldValidator ID="valpasswrd" runat="server" ErrorMessage="user Password is required !" ControlToValidate="txtpasswrd" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
            <div>
            <asp:Button ID="Save" runat="server" Text="Save" OnClick ="Save_Click" Class ="button" />
        </div>
    </form>
</body>
</html>
