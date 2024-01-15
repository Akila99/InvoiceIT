<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerateInvoice.aspx.cs" Inherits="InvoiceIT.GenerateInvoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="style.css" />
    
    <title>GenerateInvoice</title>
</head>
<body>
    <h2 class="standardheader">Generate Invoices</h2>
    <form id="Frmgeninvo" runat="server">
        <div class="frm_row_cont">
            <asp:Literal ID="clientidPh" runat="server"></asp:Literal>
        </div><br/>
     
        <div class="frm_row_cont">
            <asp:Label ID="LblinvoDate" class="frmlabel" runat="server" Text="Select a Invoice Start Date eg-:mm/dd/yyyy"></asp:Label><br />
            <asp:TextBox ID="CtrlstrDate" runat="server" Class="tbinput" TextMode="Date" ></asp:TextBox>
           </div><br/>
        

        <div class="frm_row_cont">
            <asp:Label ID="lblenddate" class="frmlabel" runat="server" Text="Select a Invoice End Date eg-:mm/dd/yyyy"></asp:Label><br />
            <input type="date" class="dllist" id="CtrlEndDate" name="CtrlEndDate" />
        </div><br/>

        <div class="frm_row_cont">
            <asp:Label ID="lblgendate" class="frmlabel" runat="server" Text="Select a Invoice Generated Date eg-:mm/dd/yyyy"></asp:Label><br />
            <input type="date" class="dllist" id="CtrlgenDate" name="CtrlgenDate" />
            
        </div><br/>

        <div class="frm_row_cont">
            <asp:Label ID="lblsentdate" class="frmlabel" runat="server" Text="Select the Invoice Sent Date  eg-:mm/dd/yyyy"></asp:Label><br />
            <input type="date" class="dllist" id="CtrlsentDate" name="CtrlsentDate" />
            
        </div><br/>
        
        <div class="frm_row_cont">
            <asp:Label ID="lblpaydue" class="frmlabel" runat="server" Text="Select the Invoice Payment Due Date eg-:mm/dd/yyyy"></asp:Label><br />
            <input type="date" class="dllist" id="CtrlpayDate" name="CtrlpayDate" />

        </div><br/>
    
        <div class="frm_row_cont">
            <asp:Label ID="Lblinvosts" class="frmlabel" runat="server" Text="Select an Invoice Status"></asp:Label><br />
            <asp:DropDownList ID="CtrlinvoStatus" class="dllist" runat="server">
			<asp:ListItem value="0">--Please make a selection--</asp:ListItem>
                <asp:ListItem value="Generated">Generated</asp:ListItem>
                <asp:ListItem value="Sent">Sent</asp:ListItem>
                <asp:ListItem value="Overdue">Overdue</asp:ListItem>
				<asp:ListItem value="Paid">Paid</asp:ListItem>
				<asp:ListItem value="Withdrawn">Withdrawn</asp:ListItem>
            </asp:DropDownList>
        </div><br/>
        <div class="frm_row_cont">
            <asp:Button ID="geninvo" class="button" runat="server" Text="Generate" OnClick="geninvo_Click"  />
        </div>
    </form>
</body>
</html>
