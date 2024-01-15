<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="InvoiceIT.AdminPanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="style.css" />
    <title></title>
</head>
<body class="body">
   
    <h1 class="h1">This is the Admin Panel</h1>
    <div class="frm_row_cont">
    <p><a href="Add a New client.aspx" class ="button" >Add a New Client</a></p> 
     </div>
    
    <p><a href="Add a New staff.aspx" class ="button" >Add a New Staff</a></p>
        
    <p><a href="AddTask.aspx" class ="button">Add a New Task</a></p>
       
    
    <p><a href="AddWorkItem.aspx"  class ="button">Add a New WorkItem</a></p>
       
    
    <p><a href="GenerateInvoice.aspx" class ="button" >Generate an Invoice</a></p>
        
    <b />
    <div class="frm_row_cont">
    <asp:Label ID="Lbale" runat="server" Text="Get Details : View Details : Delete Details : Update Details"></asp:Label>
    </div>
    <div class="frm_row_cont">
    <p><a href="GetClient.aspx" class ="button" >Get Client List</a></p> 
     </div>
    <p><a href="GetStaff.aspx" class ="button" >Get Staff List</a></p>
    <p><a href="GetTask" class ="button">Get Task List</a></p>
    <p><a href="GetworkItem.aspx"  class ="button">Get Work Item List</a></p>
    <p><a href="GetInvoice.aspx" class ="button" >Get Invoice List</a></p>

    <form id="form1" runat="server">


       
    </form>
</body>
</html>
