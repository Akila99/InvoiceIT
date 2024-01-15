<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateWorkItem.aspx.cs" Inherits="InvoiceIT.UpdateWorkItem" %>

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
    <title>Update work item</title>
</head>
<body>
    <h2 class="standardheader">Update Work Item</h2>
    <div id="frmcont" runat="server">
     <div id="updateworkitemheader" runat="server"></div>
    <form id="Updateworkitem" runat="server">
        <asp:HiddenField ID="CtrlworkitemID" runat="server" Value=""></asp:HiddenField>
         <div class="frm_row_cont">
            <asp:Literal ID="taskListPh" runat="server"  ></asp:Literal>
        </div><br/>
        <div class="frm_row_cont">
            <asp:Literal ID= "ClientListPH" runat="server"  ></asp:Literal>
        </div><br/>
        <div class="frm_row_cont">
            <asp:Literal ID="StaffListPh" runat="server" ></asp:Literal>
        </div><br/>
        <div class="frm_row_cont">
            <asp:Label ID="LblDate" class="frmlabel" runat="server" Text="Work Item Date"></asp:Label>
            <br />
            <asp:TextBox ID="cntrldate" runat="server" TextMode="Date" Class="tbinput" ></asp:TextBox>
        </div><br/>
        <div class="frm_row_cont">
            <asp:Label ID="LblwrkitmStartTime" class="frmlabel" runat="server" Text="Work Item Start Time"></asp:Label>
            <br />
            <asp:DropDownList ID="upwrkitmStartTime" class="dllist" runat="server">
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
            <asp:DropDownList ID="upwrkitmEndTime" class="dllist" runat="server">
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
            <asp:Literal ID="wrkitmStatusPH" runat="server"></asp:Literal>
        </div><br/>
        <div class="frm_row_cont"> 
            <asp:Label ID="lblcmnt" runat="server" Text="Comment" Class="frmlabel" ></asp:Label>
            <br/>
            <asp:TextBox ID="txtcmnt" runat="server" TextMode="MultiLine" Height="100px" Class="tbinput" ></asp:TextBox>
        </div><br/>
        <div class="frm_row_cont">
            <asp:Button ID="btnwrkitm" class="button" runat="server" Text="Update Work Item" OnClick="btnsubmit_Click" />
        </div>         
    </form>
        </div>
   
</body>
</html>

        
