<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCourse.aspx.cs" Inherits="Project.AddCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table cellpadding="0" cellspacing="0" width="100%">
<tr>
    <td align="right">
                <asp:Button ID="Button2" runat="server" Text="LogOut" onclick="Button2_Click"/>
            <asp:TextBox ID="Txt_updby" runat="server" CssClass="commonTxtbox" 
                    BorderStyle="None" ReadOnly="True" ></asp:TextBox>            
            </td>        
</tr>
</table>

    <asp:Panel ID="PanelCourse" runat="server" Width="800">
<table  width="100%">
	<tr>
	<td align="center">
		<table width="100%">
			<tr>
				<td align="right">
                    <asp:Label ID="Label1" runat="server" Text="Course Name" CssClass="lablewidth"></asp:Label>
				</td>
				<td align="left">
					<asp:TextBox ID="txtcourseName" runat="server" CssClass="commonTxtbox"></asp:TextBox>
				</td>
			</tr>
            <tr>
				<td align="right">
                    <asp:Label ID="Label2" runat="server" Text="Branch Name" CssClass="lablewidth"></asp:Label>
				</td>
				<td align="left">
					<asp:TextBox ID="txtBranchName" runat="server" CssClass="commonTxtbox"></asp:TextBox>
				</td>
			</tr>
            <tr>
				<td align="right">
                    <asp:Label ID="Label3" runat="server" Text="Department ID" CssClass="lablewidth"></asp:Label>
				</td>
				<td align="left">
                    <asp:DropDownList ID="DDLdeptid" runat="server" CssClass="dropdownbox">
                    </asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td align="right">
                    <asp:Label ID="Label4" runat="server" Text="Description" CssClass="tablewidth"></asp:Label>
				</td>
				<td align="left">
					<asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="tablewidth"></asp:TextBox>
				</td>
			</tr>
            <tr>
            <td colspan="3" align ="center">
                <asp:CheckBox ID="ChckFullTime" runat="server" Text="Full Time" CssClass="lablewidth" />
            
           
                <asp:CheckBox ID="ChckPartTime" runat="server" Text="Part Time" CssClass="lablewidth" />
              
             
                <asp:CheckBox ID="ChckCorrospondance" runat="server" Text="Corrospondance" CssClass="lablewidth" />
            </td>                
            </tr>
			<tr>
				<td colspan="2" align="center">
					<asp:HiddenField ID="hdnCourseId" runat="server" />
					<asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" CssClass="buttonsimg" />
					<asp:Button ID="btnEdit" runat="server" Text="Update" Visible="false" 
                        onclick="btnEdit_Click" CssClass="buttonsimg" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="buttonsimg" />
                    <asp:Button ID="btnShow" runat="server" Text="Show" onclick="btnShow_Click" CssClass="buttonsimg" />
					<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="buttonsimg" />
				</td>
			</tr>
			</table>
	</td>
	</tr>
			<tr>
				<td align="center">
					<asp:GridView ID="gvCourse" runat="server" AutoGenerateColumns="false" Width="100%">
						<Columns>
							<asp:TemplateField HeaderText="Course Name">
								<ItemTemplate>
									<asp:Label ID="lblCourseName" runat="server" Text='<%#Eval("CourseName")%>'></asp:Label>
									<asp:HiddenField ID="hdnCourseID" runat="server" Value='<%#Eval("CourseId")%>' />
								</ItemTemplate>
							</asp:TemplateField>
                            <asp:TemplateField HeaderText="Branch Name">
								<ItemTemplate>
									<asp:Label ID="lblBranchName" runat="server" Text='<%#Eval("BranchName")%>'></asp:Label>
								</ItemTemplate>
							</asp:TemplateField>
                            <asp:TemplateField HeaderText="DepartmentID">
								<ItemTemplate>
									<asp:Label ID="lblDepartmentID" runat="server" Text='<%#Eval("DeptId")%>'></asp:Label>
								</ItemTemplate>
							</asp:TemplateField>
                            <asp:TemplateField HeaderText="FullTime">
								<ItemTemplate>
									<asp:Label ID="lblFullTime" runat="server" Text='<%#Eval("Full_Time")%>'></asp:Label>
								</ItemTemplate>
							</asp:TemplateField>
                            <asp:TemplateField HeaderText="PartTime">
								<ItemTemplate>
									<asp:Label ID="lblPartTime" runat="server" Text='<%#Eval("Part_Time")%>'></asp:Label>
								</ItemTemplate>
							</asp:TemplateField>
                            <asp:TemplateField HeaderText="Corrospondance">
								<ItemTemplate>
									<asp:Label ID="lblCorrospondance" runat="server" Text='<%#Eval("Correspondance")%>'></asp:Label>
								</ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Description">
								<ItemTemplate>
									<asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
								</ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Added by">
								<ItemTemplate>
									<asp:Label ID="lblUpdatedBy" runat="server" Text='<%#Eval("Updated_By")%>'></asp:Label>
								</ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField>
								<ItemTemplate>
									<asp:LinkButton ID="lnkbtnEdit" runat="server" Text="Edit" OnClick="lnkbtnEdit_Click" ></asp:LinkButton>
									<asp:LinkButton ID="lnkbtnDelete" runat="server" Text="Delete" OnClick="lnkbtnDelete_Click"  
									OnClientClick="return confirm('Are you sure you want to delete this record?');"></asp:LinkButton>
								</ItemTemplate>
							</asp:TemplateField>
						</Columns>
					</asp:GridView>
				</td>
			</tr>
		</table>
         </asp:Panel>
</asp:Content>

