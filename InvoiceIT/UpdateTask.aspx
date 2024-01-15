<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateTask.aspx.cs" Inherits="InvoiceIT.UpdateTask" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="style.css" />
    <title>Update Task</title>
</head>
<body>
    <div id="frmcont" runat="server">
     <div id="updatetaskheader" runat="server"></div>
    <form id="updateTask" runat="server">
        <asp:HiddenField ID="CtrlTaskID" runat="server" Value=""></asp:HiddenField>
        <div class="frm_row_cont">
          <asp:Label ID="lbltasktitle" runat="server" Text="Task Title*" Class="frmlabel"></asp:Label>
            <br />
            <asp:TextBox ID="cntrltasktitle" runat="server" Class="tbinput" ReadOnly="true"></asp:TextBox>
             
        </div><br/>
        <div class="frm_row_cont">
          <asp:Label ID="Lbltskdes" runat="server" Text="Task Description" Class="frmlabel"></asp:Label>
            <br />
            <asp:TextBox ID="cntrltskdes" runat="server" TextMode="MultiLine" Height="100px" Class="tbinput"></asp:TextBox>

        </div><br/>
        <div class="frm_row_cont">
          <asp:Label ID="lbltskrate" runat="server" Text="Task Rate*" Class="frmlabel"></asp:Label>
            <br />
            <asp:TextBox ID="cntrltskrate" runat="server" Class="tbinput" ></asp:TextBox>
              <asp:RequiredFieldValidator ID="valtskrate" runat="server" ErrorMessage="Task rate is required !" ControlToValidate="cntrltskrate" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont">
            <asp:Button ID="btnsubmit" runat="server" Text="Update Task" OnClick="btnupdatetaskdetails_click"  Class ="button" />
        </div>
    </form>
        </div>
</body>
</html>
