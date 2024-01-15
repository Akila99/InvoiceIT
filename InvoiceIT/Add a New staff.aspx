<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add a New staff.aspx.cs" Inherits="InvoiceIT.Add_a_New_staff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="style.css" />
    <title>Add A New Staff Member</title>
</head>
<body class="body">
    <h2>Add a New Staff Member</h2>
    <form id="frmaddanwstaff" runat="server">
        <div class="frm_row_cont"> 
            <asp:Label ID="lblstafffnm" runat="server" Text="Staff Name*" Class="frmlabel" ></asp:Label>
            <br/>
            <asp:TextBox ID="txtstafnm" runat="server" Class="tbinput" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="valstafnm" runat="server" ErrorMessage="Staff Name is required !" ControlToValidate="txtstafnm" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont"> 
            <asp:Label ID="lblstaffsurnm" runat="server" Text="Staff Surname*" Class="frmlabel" ></asp:Label>
            <br/>
            <asp:TextBox ID="txtsurnm" runat="server" Class="tbinput" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="valsurnm" runat="server" ErrorMessage="Staff Surname is required !" ControlToValidate="txtsurnm" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont"> 
            <asp:Label ID="lblstffemail" runat="server" Text="Staff Email*" Class="frmlabel" ></asp:Label>
            <br/>
            <asp:TextBox ID="txtstffemail" runat="server" Class="tbinput" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="valstaffemail" runat="server" ErrorMessage="Staff Email is required !" ControlToValidate="txtstffemail" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont"> 
            <asp:Label ID="lblstfmob" runat="server" Text="Staff Mobile No.*" Class="frmlabel" ></asp:Label>
            <br/>
            <asp:TextBox ID="txtstfmob" runat="server" Class="tbinput" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="valstfmob" runat="server" ErrorMessage="Staff Mobile Number is required !" ControlToValidate="txtstfmob" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont"> 
            <asp:Label ID="lblacclvl" runat="server" Text="Staff Access Level" Class ="frmlabel"></asp:Label>
        <br />
            <asp:DropDownList ID="dpdwnacclvl" runat="server" Class="tbinput">
                <asp:ListItem>Administrator</asp:ListItem>
                <asp:ListItem>Staff</asp:ListItem>
            </asp:DropDownList>
        </div><br />
        <div class="frm_row_cont"> 
            <asp:Label ID="lblstaffsts" runat="server" Text="Staff status" Class ="frmlabel"></asp:Label>
        <br />
            <asp:DropDownList ID="dodwnsts" runat="server" Class="tbinput">
                <asp:ListItem>Active</asp:ListItem>
                <asp:ListItem>inactive</asp:ListItem>
            </asp:DropDownList>
        </div><br />
        <div class="frm_row_cont">
            <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" Class ="button" />
        </div>
    </form>
</body>
</html>
