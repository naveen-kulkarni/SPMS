<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HolidayList.aspx.cs" Inherits="Project.HolidayList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <table cellpadding="1px" cellspacing="1px" width="100%" >
        <tr>
            
            <td align="right">
                <asp:Button ID="Button2" runat="server" Text="LogOut" onclick="Button2_Click"/>
            <asp:TextBox ID="Txt_updby" runat="server" CssClass="commonTxtbox" 
                    BorderStyle="None" ReadOnly="True" ></asp:TextBox>            
            </td> 
        </tr>
     </table>
<asp:Panel ID="Panel1" runat="server">
    <table width="100%">
	<tr>
	<td colspan="2">
        <asp:Label ID="Label1" runat="server" Text="Year" CssClass="lablewidth"></asp:Label>
     <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" 
			onselectedindexchanged="ddlYear_SelectedIndexChanged" CssClass="dropdownbox">	
	       </asp:DropDownList>
	</td>
	</tr>
	<tr>
	<td align="center" colspan="2">
		<asp:GridView ID="grdHolidayCalendar" runat="server" OnRowDataBound="grdHolidayCalendar_RowDataBound">
		</asp:GridView>
	</td>
	</tr>
	<tr>
	<td>&nbsp;</td>
	</tr>
	<tr>
	<td align="left" colspan="2">
	<asp:Label ID="lblHolidayListHeading" runat="server" Text="Holiday List" Visible="false"></asp:Label>    
	</td>
	</tr>
	<tr>
	<td style="width: 60%">
	<asp:GridView ID="grdHolidayList" runat="server" AutoGenerateColumns="False" 
			onrowdatabound="grdHolidayList_RowDataBound" Width="100%">
	<Columns>
	<asp:BoundField HeaderText="Holiday Name" DataField="Holiday_Name" />
		<asp:TemplateField HeaderText="Holiday Date">
			<ItemTemplate>
				<asp:Label ID="lblHolidayDate" runat="server" Text='<%# Bind("HolidayDate") %>'></asp:Label>
			</ItemTemplate>
		</asp:TemplateField>
	<asp:BoundField HeaderText="Description" DataField="Description" />
 	</Columns>
	</asp:GridView>
	</td>
	<td align="right" style="width: 40%">
	<table width="40%" style=" text-align:right;" id="tblColors" visible="false" runat="server">
	    <tr>
	       <td style="background-color: #FFE67E; width:20%"></td>
	       <td> Sunday</td>
	    </tr>
		<tr>
			<td style="background-color: #6CE26C ; width:20%"></td>
			<td> Holiday</td>
		</tr>
	</table>
	</td>

	</tr>
	
	</table>
    </asp:Panel>
</asp:Content>

