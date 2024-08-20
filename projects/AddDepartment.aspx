<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddDepartment.aspx.cs" Inherits="Project.AddDepartment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
<tr>
    <td align="right">
                <asp:Button ID="Button1" runat="server" Text="LogOut" onclick="Button1_Click"/>
            <asp:TextBox ID="Txt_updby" runat="server" CssClass="commonTxtbox" 
                    BorderStyle="None" ReadOnly="True" ></asp:TextBox>            
            </td>        
</tr>
</table>

    <asp:Panel ID="PanelDepartment" runat="server" Width="700">
    
<table  width="100%">
	<tr>
	<td align="center">
		<table width="100%">
			<tr>
				<td align="right">
                    <asp:Label ID="Label" runat="server" Text="Department Name" CssClass="lablewidth"></asp:Label>
				</td>
				<td align="left">
					<asp:TextBox ID="txtDeptName" runat="server" CssClass="commonTxtbox"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td align="right">
                    <asp:Label ID="Label1" runat="server" Text="Description" CssClass ="lablewidth"></asp:Label>
				</td>
				<td align="left">
					<asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="tablewidth"></asp:TextBox>
				</td>
			</tr>
            <tr>
            <td align="right">
                <asp:RadioButton ID="RdUG" runat="server" Text="Under Graduation" 
                    GroupName="degreeType" CssClass="lablewidth"/>
            </td>
            <td align="left">
                <asp:RadioButton ID="RdPG" runat="server" Text="Post Graduation" 
                    GroupName="degreeType" CssClass="lablewidth" /></td>                
            </tr>
			<tr>
				<td colspan="2" align="left">
					<asp:HiddenField ID="hdnDeptId" runat="server" />
					<asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" CssClass="buttonsimg"/>
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
					<asp:GridView ID="gvDept" runat="server" AutoGenerateColumns="false" Width="100%">
						<Columns>
							<asp:TemplateField HeaderText="Department Name">
								<ItemTemplate>
									<asp:Label ID="lblDeptName" runat="server" Text='<%#Eval("Dept_Name")%>'></asp:Label>
									<asp:HiddenField ID="hdnDeptID" runat="server" Value='<%#Eval("DepartmentId")%>' />
								</ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Description">
								<ItemTemplate>
									<asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
								</ItemTemplate>
							</asp:TemplateField>
                            <asp:TemplateField HeaderText="Degree">
								<ItemTemplate>
									<asp:Label ID="lblDegree" runat="server" Text='<%#Eval("Degree")%>'></asp:Label>
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
