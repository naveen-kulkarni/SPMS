<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HolidayConfigure.aspx.cs" Inherits="Project.HolidayConfigure" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script>
    function test(month) {
        alert("test" + month);
    }
    function openPopupForAdd(month, day, year) {
        var HolidayDate = day + "-" + month + "-" + year;
        alert("holidaydate=" + HolidayDate);
        window.open("AddHolidayPopup.aspx?HolidayDate=" + HolidayDate, "AddHoliday", "height=300,width=600,left=100,top=30,resizable=No,scrollbars=No,toolbar=no,menubar=no,location=no,directories=no, status=No");
        return false;

    }

    function openPopupForEdit(HolidayId) {
        window.open("EditHolidayPopup.aspx?HolidayId=" + HolidayId, "AddHoliday", "height=300,width=600,left=100,top=30,resizable=No,scrollbars=No,toolbar=no,menubar=no,location=no,directories=no, status=No");
        return false;

    }

	</script>
    <table cellpadding="1px" cellspacing="1px" width="100%" >
        <tr>
            
            <td align="right">
                <asp:Button ID="Button2" runat="server" Text="LogOut" onclick="Button2_Click"/>
            <asp:TextBox ID="Txt_updby" runat="server" CssClass="commonTxtbox" 
                    BorderStyle="None" ReadOnly="True" ></asp:TextBox>            
            </td> 
        </tr>
     </table>
    <asp:Panel ID="Pnlconfig" runat="server">
    <table width="100%">
			<tr>
				<td colspan="2">
                    <asp:Label ID="Label1" runat="server" Text="Year" CssClass="lablewidth"></asp:Label> 
					<asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" CssClass="dropdownbox" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
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
				<td>
					&nbsp;
				</td>
			</tr>
			<tr>
				<td align="left" colspan="2">
					<asp:Label ID="lblHolidayListHeading" runat="server" Text="Holiday List" Visible="false"></asp:Label>
				</td>
			</tr>
			<tr>
				<td style="width: 60%">
					<asp:GridView ID="grdHolidayList" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdHolidayList_RowDataBound"
						Width="100%">
						<Columns>
							<asp:BoundField HeaderText="Holiday Name" DataField="Holiday_Name" />
							<asp:TemplateField HeaderText="Holiday Date">
								<ItemTemplate>
									<asp:Label ID="lblHolidayDate" runat="server" Text='<%# Bind("HolidayDate") %>'></asp:Label>
								</ItemTemplate>
							</asp:TemplateField>
							<asp:BoundField HeaderText="Description" DataField="Description" />
							<asp:TemplateField HeaderText="Delete Holiday">
							<ItemTemplate>
							<asp:LinkButton ID="lnkbtnDelete" runat="server" OnClick="lnkbtnDelete_Click" Text="Delete Holiday"
								CommandArgument='<%# Eval("HolidayId") %>' OnClientClick="return confirm('Are you sure you want to delete this record?');">
							</asp:LinkButton>
							</ItemTemplate>
							</asp:TemplateField>
						</Columns>
					</asp:GridView>
				</td>
				<td align="right" style="width: 40%">
					<table width="40%" style="text-align: right;" id="tblColors" visible="false" runat="server">
						<tr>
							<td style="background-color: #FFE67E; width: 20%">
							</td>
							<td>
								Sunday
							</td>
						</tr>
						<tr>
							<td style="background-color: #6CE26C; width: 20%">
							</td>
							<td>
								Holiday
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
    </asp:Panel>
</asp:Content>

