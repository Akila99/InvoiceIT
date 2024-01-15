<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateInvoice.aspx.cs" Inherits="InvoiceIT.UpdateInvoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="style.css" />
    
    <title>UpdateInvoice</title>
</head>
<body>
    <div id="frmcont" runat="server">
    <div id="updateinvoheader" runat="server"></div>
    <form id="UpdateInvoice" runat="server">
        <asp:HiddenField ID="CtrlinvoID" runat="server" Value="" ></asp:HiddenField>
        <div class="frm_row_cont">
            <asp:Literal ID= "ClientListPH" runat="server"  ></asp:Literal>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="Lblinvostrdate" runat="server" class="frmlabel" Text="Invoice Start Date* Eg-:mm/dd/yyyy"></asp:Label><br />
            <asp:TextBox ID="Ctrlinvodate" runat="server" class="tbinput"   ></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="revCrsDesc"
                ControlToValidate="Ctrlinvodate"
                Display="Static"
                runat="server"
                ErrorMessage="Start Date is required"></asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="Lblenddate" runat="server" class="frmlabel" Text="Invoice End Date* Eg-:mm/dd/yyyy"></asp:Label><br />
            <asp:TextBox ID="txtenddate" runat="server" class="tbinput"  ></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator1"
                ControlToValidate="txtenddate"
                Display="Static"
                runat="server"
                ErrorMessage="Start Date is required"></asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="lblgendate" runat="server" class="frmlabel" Text="Invoice generated Date* Eg-:mm/dd/yyyy"></asp:Label><br />
            <asp:TextBox ID="txtgendate" runat="server" class="tbinput"   ></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator2"
                ControlToValidate="txtgendate"
                Display="Static"
                runat="server"
                ErrorMessage="Generated Date is required"></asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="lblsendate" runat="server" class="frmlabel" Text="Invoice Sent Date* Eg-:mm/dd/yyyy"></asp:Label><br />
            <asp:TextBox ID="txtsendate" runat="server" class="tbinput"  ></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator3"
                ControlToValidate="txtsendate"
                Display="Static"
                runat="server"
                ErrorMessage="Generated Date is required"></asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="lblpaydue" runat="server" class="frmlabel" Text="Invoice payment Due Date* Eg-:mm/dd/yyyy"></asp:Label><br />
            <asp:TextBox ID="txtpaydue" runat="server" class="tbinput" ></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator4"
                ControlToValidate="txtpaydue"
                Display="Static"
                runat="server"
                ErrorMessage="Payment Due Date is required"></asp:RequiredFieldValidator>
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblStatus" runat="server" class="frmlabel" Text="Invoice Status"></asp:Label><br />
            <asp:Literal ID="invoStatusPH" runat="server"></asp:Literal>
        </div>
        <div class="frm_row_cont">
            <asp:Button ID="btnupinvo" runat="server" class="button" Text="Update Invoice Details" OnClick="btnupinvo_Click" />
        </div>
        
    </form>
        </div>
</body>
</html>
