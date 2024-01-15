<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTask.aspx.cs" Inherits="InvoiceIT.AddTask" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="style.css" />
    <title>Add a New Task</title>
</head>
<body class="body">
    <h2>Add a new task</h2>
    <form id="frmnewtask" runat="server">
        <div class="frm_row_cont">
          <asp:Label ID="lbltasktitle" runat="server" Text="Task Title*" Class="frmlabel"></asp:Label>
            <br />
            <asp:TextBox ID="txttasktitle" runat="server" Class="tbinput"></asp:TextBox>
              <asp:RequiredFieldValidator ID="valtsktitle" runat="server" ErrorMessage="Task Title is required !" ControlToValidate="txttasktitle" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont">
          <asp:Label ID="Lbltskdes" runat="server" Text="Task Description" Class="frmlabel"></asp:Label>
            <br />
            <asp:TextBox ID="txttskdes" runat="server" TextMode="MultiLine" Height="100px" Class="tbinput"></asp:TextBox>
        </div><br/>
        <div class="frm_row_cont">
          <asp:Label ID="lbltskrate" runat="server" Text="Task Rate*" Class="frmlabel"></asp:Label>
            <br />
            <asp:TextBox ID="txttskrate" runat="server" Class="tbinput"></asp:TextBox>
              <asp:RequiredFieldValidator ID="valtskrate" runat="server" ErrorMessage="Task rate is required !" ControlToValidate="txttskrate" Display="Static"></asp:RequiredFieldValidator>
        </div><br/>
        <div class="frm_row_cont">
            <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" Class ="button" />
        </div>

    </form>
</body>
</html>
