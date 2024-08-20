<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddHolidayPopup.aspx.cs" Inherits="Project.AddHolidayPopup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<title>Add Holiday</title>
	 
	<script>
	    function cancel() {
	        window.close();
	    }
		
	</script>
    <table cellpadding="0" cellspacing="0" width="100%">
<tr>
    <td align="right">
                <asp:Button ID="Button1" runat="server" Text="LogOut" onclick="Button1_Click"/>
            <asp:TextBox ID="Txt_updby" runat="server" CssClass="commonTxtbox" 
                    BorderStyle="None" ReadOnly="True" ></asp:TextBox>            
            </td>        
</tr>
</table>
    
    <asp:Panel ID="pnladdholiday" runat="server">
    <table width="100%">
	<tr>
	<td align="right">
        <asp:Label ID="Label1" runat="server" Text=" Selected Date" CssClass="lablewidth"></asp:Label></td>
	<td> <asp:Label ID="lblDate" runat="server" CssClass="lablewidth"></asp:Label></td>
	</tr>
	<tr>
	<td align="right">
        <asp:Label ID="Label2" runat="server" Text="Holiday Name " CssClass="lablewidth"></asp:Label></td>
	<td>
	 <asp:TextBox ID="txtHolidayName" runat="server" CssClass="commonTxtbox"></asp:TextBox>
	</td>
	</tr>
	<tr>
	<td align="right">
        <asp:Label ID="Label3" runat="server" Text="Holiday Description" CssClass="lablewidth"></asp:Label></td>
	<td>
	<asp:TextBox ID="txtDescription" runat="server" CssClass="commonTxtbox"></asp:TextBox>
	</td>
	</tr>
	<tr>
	<td colspan="2" align="center">
	<asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" CssClass="buttonsimg" />
	<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="cancel()"  CssClass="buttonsimg"/>
	</td>
	</tr>
	</table>
    </asp:Panel>
</asp:Content>

