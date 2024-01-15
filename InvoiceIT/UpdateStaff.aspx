<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateStaff.aspx.cs" Inherits="InvoiceIT.UpdateStaff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="stylesheet" href="style.css" />
    <title>Update Staff Member</title>
</head>
<body>
     <div id="frmcont" runat="server">
     <div id="updatestaffheader" runat="server"></div>
     <form id="Updatestaff" runat="server">
         <asp:HiddenField ID="CtrlStaffID" runat="server" Value=""></asp:HiddenField>
        <div class="frm_row_cont"> 
            <asp:Label ID="lblstafffnm" runat="server" Text="Staff Name*" Class="frmlabel" ></asp:Label>
            <br/>
            <asp:TextBox ID="cntrlstafnm" runat="server" Class="tbinput" ReadOnly="true" ></asp:TextBox>
           
        </div><br/>
        <div class="frm_row_cont"> 
            <asp:Label ID="lblstaffsurnm" runat="server" Text="Staff Surname*" Class="frmlabel" ></asp:Label>
            <br/>
            <asp:TextBox ID="cntrlsurnm" runat="server" Class="tbinput" ReadOnly="true" ></asp:TextBox>
            
        </div><br/>
        <div class="frm_row_cont"> 
            <asp:Label ID="lblstffemail" runat="server" Text="Staff Email*" Class="frmlabel" ></asp:Label>
            <br/>
            <asp:TextBox ID="cntrlstffemail" runat="server" Class="tbinput" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="valstaffemail" runat="server" ErrorMessage="Staff Email is required !" ControlToValidate="cntrlstffemail" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont"> 
            <asp:Label ID="lblstfmob" runat="server" Text="Staff Mobile No.*" Class="frmlabel" ></asp:Label>
            <br/>
            <asp:TextBox ID="cntrlstfmob" runat="server" Class="tbinput" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="valstfmob" runat="server" ErrorMessage="Staff Mobile Number is required !" ControlToValidate="cntrlstfmob" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont"> 
            <asp:Label ID="lblacclvl" runat="server" Text="Staff Access Level" Class ="frmlabel"></asp:Label>
        <br />
            <asp:Literal ID="acclevlPH" runat="server"></asp:Literal>
            
        </div><br />
        <div class="frm_row_cont"> 
            <asp:Label ID="lblstaffsts" runat="server" Text="Staff status" Class ="frmlabel"></asp:Label>
        <br />
            <asp:Literal ID="stffstsPH" runat="server"></asp:Literal>
            
        </div><br />
        <div class="frm_row_cont">
            <asp:Button ID="btnsubmit" runat="server" Text="Submit" Onclick="btnsubmit_Click" Class ="button" />
        </div>
         
    </form>
    </div>
</body>
</html>
