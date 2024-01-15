<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateClient.aspx.cs" Inherits="InvoiceIT.UpdateClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>upadte client details</title>
    <link rel="stylesheet" href="style.css" />
</head>
<body>
     <div id="frmcont" runat="server">
     <div id="updateclientheader" runat="server"></div>
       <form id="updateclient" runat="server">
         <asp:HiddenField ID="CtrlClientID" runat="server" Value=""></asp:HiddenField>
         <div class="frm_row_cont">
            <asp:Label ID="lblclicomname" runat="server" Text="Client Company Name*" Class="frmlabel"></asp:Label>
            <br/>
            <asp:TextBox ID="cntrlcomname" runat="server" ReadOnly="true"></asp:TextBox>
         
         </div><br/>

        <div class="frm_row_cont">
        <asp:Label ID="lblcompadd1" runat="server" Text="Client Company Address 1*" Class ="frmlabel"></asp:Label>
            <br/>
            <asp:TextBox ID="cntrlcompadd1" runat="server" Class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="revcompadd1" 
                runat="server" 
                ErrorMessage="Company Address 1 is required !" 
                ControlToValidate="cntrlcompadd1" 
                Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont">
            <asp:Label ID="lblcomadd2" runat="server" Text="Client Company Address 2*" Class="frmlabel"></asp:Label>
            <br/>
            <asp:TextBox ID="cntrlcompadd2" runat="server" Class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator ID="revcompadd2" runat="server" ErrorMessage="Company Name 2 is required !" ControlToValidate="cntrlcompadd2" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont">
        <asp:Label ID="lblcomploc" runat="server" Text="Client Company Location*" Class="frmlabel"></asp:Label>
        <br/>
            <asp:TextBox ID="cntrlcomploc" runat="server" Class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator ID="revcomploc" runat="server" ErrorMessage="Company Location is required !" ControlToValidate="cntrlcomploc" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont">
           <asp:Label ID="lblcompcod" runat="server" Text="Client Company code*" Class="frmlabel"></asp:Label>
        <br/>
            <asp:TextBox ID="cntrlcompcod" runat="server" Class="tbinput" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="revcompcod" runat="server" ErrorMessage="Company Code is required !" ControlToValidate="cntrlcompcod" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont">
            <asp:Label ID="lblconfnam" runat="server" Text="Contact First Name*" Class="frmlabel"></asp:Label>
            <br/>
            <asp:TextBox ID="cntrlconfnam" runat="server" Class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator ID="revconfnam" runat="server" ErrorMessage="Contact First Name is required !" ControlToValidate="cntrlconfnam" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont">
          <asp:Label ID="lblconlnam" runat="server" Text="Contact Last Name*" Class="frmlabel"></asp:Label>
            <br/>
            <asp:TextBox ID="cntrlconlnam" runat="server" Class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator ID="revconlnam" runat="server" ErrorMessage="Contact Last Name is required !" ControlToValidate="cntrlconlnam" Display="Static"></asp:RequiredFieldValidator>
        </div><br />
        <div class="frm_row_cont">
        <asp:Label ID="lblconemail" runat="server" Text="Contact Email*" Class ="frmlabel"></asp:Label>
            <br/>
            <asp:TextBox ID="cntrlconemail" runat="server" Class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator ID="revconemail" runat="server" ErrorMessage="Contact Email is required !" ControlToValidate="cntrlconemail" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont">
           <asp:Label ID="lblconmob" runat="server" Text="Contact Mobile No*" Class ="frmlabel"></asp:Label>
            <br/>
            <asp:TextBox ID="cntrlconmob" runat="server" Class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator ID="revconmob" runat="server" ErrorMessage="Contact Mobile Number is required !" ControlToValidate="cntrlconmob" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont">
          <asp:Label ID="lblbill" runat="server" Text="Billto" Class ="frmlabel"></asp:Label>
        <br/>
            <asp:Literal ID="Clientbillto" runat="server"></asp:Literal>
            

           </div><br />
        <div class="frm_row_cont">
          <asp:Label ID="lblsta" runat="server" Text="Status" Class ="frmlabel"></asp:Label>
            <br/>
            <asp:Literal ID="ClientStatusPH" runat="server"></asp:Literal>
            

        </div><br />
        <div>
            <asp:Button ID="btnsubmit" runat="server" Text="Update Client Details" Class ="button" OnClick="btnupdateclientDetails_Click" />
        </div>
    </form>
         </div>
</body>
</html>
