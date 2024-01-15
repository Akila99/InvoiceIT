<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddWorkItem.aspx.cs" Inherits="InvoiceIT.AddWorkItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="style.css" />
    <link rel="stylesheet" href="Scripts/jqryui/jquery-ui.min.css" />
    <script src="Scripts/jqryui/external/jquery/jquery.js"></script>
    <script src="Scripts/jqryui/jquery-ui.min.js"></script>
    <script>
        $(function () {
            $("#CtrlwrlitmDate").datepicker({
                dateFormat: "dd/mm/yy",
                inline: true,
                showAnim: 'fadeIn',
                changeMonth: true,
                changeYear: true,
            });
        });
    </script>


      <title>Add a new work item</title>
</head>
<body class="body">
    <h2 class="standardheader">Add New Work Item</h2>
    <form id="FrmAddworkitem" runat="server">
        <div class="frm_row_cont">
            <asp:Literal ID="TaskListPH" runat="server"></asp:Literal>
        </div><br/>
        <div class="frm_row_cont">
            <asp:Literal ID= "ClientListPH" runat="server"></asp:Literal>
        </div><br/>
        <div class="frm_row_cont">
            <asp:Literal ID="staffListPH" runat="server"></asp:Literal>
        </div><br/>
        <div class="frm_row_cont">
            <asp:Label ID="LblwrkitmDate" class="frmlabel" runat="server" Text="Select a Date"></asp:Label><br />
            <input type="date"class="dllist" id="CtrlwrlitmDate" name="CtrlwrlitmDate" />
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblwrkitmStartTime" class="frmlabel" runat="server" Text="Work Item Start Time"></asp:Label>
            <br />
            <asp:DropDownList ID="CtrlwrkitmStartTime" class="dllist" runat="server">
                <asp:ListItem>09:00</asp:ListItem>
                <asp:ListItem>09:30</asp:ListItem>
                <asp:ListItem>10:00</asp:ListItem>
				<asp:ListItem>10:30</asp:ListItem>
				<asp:ListItem>11:00</asp:ListItem>
				<asp:ListItem>11:30</asp:ListItem>
				<asp:ListItem>12:00</asp:ListItem>
				<asp:ListItem>12:30</asp:ListItem>
				<asp:ListItem>13:00</asp:ListItem>
				<asp:ListItem>13:30</asp:ListItem>
				<asp:ListItem>14:00</asp:ListItem>
				<asp:ListItem>14:30</asp:ListItem>
				<asp:ListItem>15:00</asp:ListItem>
				<asp:ListItem>15:30</asp:ListItem>
				<asp:ListItem>16:00</asp:ListItem>
            </asp:DropDownList>
        </div><br/>
		<div class="frm_row_cont">
            <asp:Label ID="LblwrkItemEndTime" class="frmlabel" runat="server" Text="Select an End Time"></asp:Label>
            <br />
            <asp:DropDownList ID="CtrlwrkitmEndTime" class="dllist" runat="server">
                <asp:ListItem>09:00</asp:ListItem>
                <asp:ListItem>09:30</asp:ListItem>
                <asp:ListItem>10:00</asp:ListItem>
				<asp:ListItem>10:30</asp:ListItem>
				<asp:ListItem>11:00</asp:ListItem>
				<asp:ListItem>11:30</asp:ListItem>
				<asp:ListItem>12:00</asp:ListItem>
				<asp:ListItem>12:30</asp:ListItem>
				<asp:ListItem>13:00</asp:ListItem>
				<asp:ListItem>13:30</asp:ListItem>
				<asp:ListItem>14:00</asp:ListItem>
				<asp:ListItem>14:30</asp:ListItem>
				<asp:ListItem>15:00</asp:ListItem>
				<asp:ListItem>15:30</asp:ListItem>
				<asp:ListItem>16:00</asp:ListItem>
            </asp:DropDownList>
        </div><br/>
       
        <div class="frm_row_cont">
            <asp:Label ID="LblwrkitmStatus" class="frmlabel" runat="server" Text="Select an Work Item Status"></asp:Label>
            <br />
            <asp:DropDownList ID="CtrlwrkitmStatus" class="dllist" runat="server">
			<asp:ListItem value="0">--Please make a selection--</asp:ListItem>
                <asp:ListItem value="Paused">Paused</asp:ListItem>
                <asp:ListItem value="Ongoing">Ongoing</asp:ListItem>
                <asp:ListItem value="Completed">Completed</asp:ListItem>
                <asp:ListItem value="Discontinued">Discontinued</asp:ListItem>
                
            </asp:DropDownList>
        </div><br/>
        <div class="frm_row_cont"> 
            <asp:Label ID="lblcmnt" runat="server" Text="Comment" Class="frmlabel" ></asp:Label>
            <br/>
            <asp:TextBox ID="txtcmnt" runat="server" TextMode="MultiLine" Height="100px" Class="tbinput" ></asp:TextBox>
        </div><br/>
        <div class="frm_row_cont">
            <asp:Button ID="btnwrkitm" class="button" runat="server" Text="Add New Work Item" OnClick="btnwrkitm_Click" />
        </div>
    </form>
    </body>
</html>
