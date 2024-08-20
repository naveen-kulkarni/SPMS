<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Subject.aspx.cs" Inherits="Project.Subject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table cellpadding="1px" cellspacing="1px" width="100%" >
        <tr>
            
           <td align="right">
                <asp:Button ID="Button1" runat="server" Text="LogOut" onclick="Button1_Click"/>
            <asp:TextBox ID="Txt_updby" runat="server" ReadOnly="true" CssClass="commonTxtbox" BorderStyle="None" ></asp:TextBox>            
            </td>     
        </tr>
     </table>
    <asp:Panel ID="PanelSubject" runat="server" Width="800">
    <table  width="100%">
	<tr>
	<td align="center">
		<table width="100%">
			<tr>
				<td align="right">
                    <asp:Label ID="Label1" runat="server" Text="Subject Name" CssClass="lablewidth"></asp:Label>
				</td>
				<td align="left">
					<asp:TextBox ID="txtSubjectName" runat="server" CssClass="commonTxtbox"></asp:TextBox>
				</td>
			</tr>
            <tr>
				<td align="right">
                    <asp:Label ID="Label2" runat="server" Text="Course ID" CssClass="lablewidth"></asp:Label>
				</td>
				<td align="left">
                    <asp:DropDownList ID="DDLCourseId" runat="server" CssClass="dropdownbox">
                    </asp:DropDownList>
				</td>
			</tr>
            <tr>
				<td align="right">
                    <asp:Label ID="Label3" runat="server" Text="Branch Name" CssClass="lablewidth"></asp:Label>
				</td>
				<td align="left">
                    <asp:DropDownList ID="DDLBranchName" runat="server" CssClass="dropdownbox">
                    </asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td align="right">
                    <asp:Label ID="Label4" runat="server" Text="Description"></asp:Label>
				</td>
				<td align="left">
					<asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="tablewidth"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td colspan="2" align="center">
					<asp:HiddenField ID="hdnSubjectId" runat="server" />
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
					<asp:GridView ID="gvSubject" runat="server" AutoGenerateColumns="false" Width="100%">
						<Columns>
							<asp:TemplateField HeaderText="Subject Name">
								<ItemTemplate>
									<asp:Label ID="lblSubjectName" runat="server" Text='<%#Eval("SubjectName")%>'></asp:Label>
									<asp:HiddenField ID="hdnSubjectID" runat="server" Value='<%#Eval("SubjectId")%>' />
								</ItemTemplate>
							</asp:TemplateField>
                            <asp:TemplateField HeaderText="Course ID">
								<ItemTemplate>
									<asp:Label ID="lblCourseID" runat="server" Text='<%#Eval("CourseId")%>'></asp:Label>
								</ItemTemplate>
							</asp:TemplateField>
                            <asp:TemplateField HeaderText="Branch Name">
								<ItemTemplate>
									<asp:Label ID="lblBranchName" runat="server" Text='<%#Eval("BranchName")%>'></asp:Label>
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

