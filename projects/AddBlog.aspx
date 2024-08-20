<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBlog.aspx.cs" Inherits="Project.AddBlog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" language="javascript">
        function openDetails(BlogListID) {
            window.open("Blog.aspx?BlogListID=" + BlogListID, "Blog List", "height=300,width=600,left=100,top=30,resizable=No,scrollbars=No,toolbar=no,menubar=no,location=no,directories=no, status=No");
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
    <asp:Button ID="BtnAdd" BorderStyle="None" runat="server" Text="Create Blog" 
        onclick="BtnAdd_Click"/>
    <asp:Button ID="BtnQueries" BorderStyle="None" runat="server" Text="Show Blog" 
        onclick="BtnQueries_Click" />
    <asp:Button ID="btndelete" runat="server" BorderStyle="None" Text="Delete Blog" 
        onclick="btndelete_Click1"/>
    <asp:Button ID="btnedit" runat="server" BorderStyle="None" Text="Edit Blog" 
        onclick="btnedit_Click"/>
    <asp:Panel ID="PanelPost" runat="server" Visible="False" Width="500">
    <fieldset>
    <legend class="legfont">Create Blog</legend>
    <table>
    <tr><td align="left">
        <asp:Label ID="Label2" runat="server" Text="Topic " CssClass="lablewidth"></asp:Label></td></tr>
    <tr><td><asp:TextBox ID="txttopic" runat="server" Width="400px"  CssClass="commonTxtbox" ></asp:TextBox></td> </tr>
    <tr><td  align="left">
        <asp:Label ID="Label3" runat="server" Text="Content " CssClass="lablewidth"></asp:Label></td></tr>
    <tr><td><asp:TextBox ID="txtcontent" runat="server" Width="400px" Height="140px" 
            TextMode="MultiLine"  CssClass="tablewidth"></asp:TextBox></td></tr>
    <tr><td  align="left">
        <asp:Label ID="Label4" runat="server" Text="Created By" CssClass="lablewidth"></asp:Label></td></tr>
    <tr><td><asp:TextBox ID="txtcreatedby" runat="server"  CssClass="commonTxtbox" ></asp:TextBox></td></tr>
    <tr><td align="left">
        <asp:Label ID="Label5" runat="server" Text="Created Date" CssClass="lablewidth"></asp:Label></td></tr>
    <tr><td><asp:TextBox ID="txtcreateddate" runat="server"  CssClass="commonTxtbox" ></asp:TextBox></td></tr>
    <tr><td></td></tr>
    <tr><td align="center" colspan="3"><asp:Button ID="btncreate" runat="server" Text="Post" 
            onclick="btncreate_Click" CssClass="buttonsimg"/>
        <asp:Button ID="btnaddback" runat="server" Text="Back"  CssClass="buttonsimg" 
            onclick="btnaddback_Click"/>
            </td></tr>
    </table>
    </fieldset>
    </asp:Panel>
    <asp:Panel ID="PanelShow" runat="server" Visible="False" Width="500">
    <fieldset>
    <legend class="legfont">List Of Blogs</legend>
    <table>
    <tr><td>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SPMSConnectionString %>" 
            SelectCommand="SELECT * FROM [Blog_List]" 
            ProviderName="<%$ ConnectionStrings:SPMSConnectionString.ProviderName %>">
        </asp:SqlDataSource></td></tr>
    <tr><td>
    <asp:GridView ID="gvBlog" runat="server" AutoGenerateColumns="false" 
			onrowdatabound="gvBlog_RowDataBound" >
    <Columns>
	<asp:TemplateField HeaderText="Blogs">
	<ItemTemplate>
	<asp:LinkButton ID="lnkbtnBlogList" runat="server" Text='<%#Eval("BlogTopic") %>'
		CommandArgument='<%#Eval("BlogListID") %>' ></asp:LinkButton>
	</ItemTemplate>
	</asp:TemplateField>
	</Columns>
	</asp:GridView>
    </td></tr>
    <tr>
    <td>
        <asp:Button ID="btnshowback" runat="server" Text="Back" CssClass="buttonsimg" 
            onclick="btnshowback_Click"/>
    </td>
    </tr>
    </table>
    </fieldset>
    </asp:Panel>
    <asp:Panel ID="DeleteBlog" runat="server" Width="500">
    <fieldset>
    <legend class="legfont">Delete Blog</legend>
    <table>
    <tr>
    <td align="right">
        <asp:Label ID="Label1" runat="server" Text="Topic :" CssClass="lablewidth"></asp:Label>
    </td>
    <td>
        <asp:DropDownList ID="Ddldelete" runat="server" CssClass="dropdownbox"  >
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td align="center" colspan="3">
        <asp:Button ID="btndeletetopic" runat="server" Text="Delete" 
            onclick="btndelete_Click" OnClientClick="return confirm('Are you sure you want to delete this record?');" CssClass="buttonsimg"/>
        <asp:Button ID="btndeletereset" runat="server" Text="Reset" CssClass="buttonsimg"/>
        <asp:Button ID="btndeleteback" runat="server" Text="Back" CssClass="buttonsimg" 
            onclick="btndeleteback_Click"/>
    </td>
    </tr>
    </table>
    </fieldset>
    </asp:Panel>
    <asp:Panel ID="updateblog" runat="server" Width="700">
    <fieldset>
    <legend class="legfont">Edit Blog</legend>
    <table>
    <tr><td align="left">
        <asp:Label ID="Label6" runat="server" Text="Topic " CssClass="lablewidth"></asp:Label></td></tr>
    <tr><td>
        <asp:DropDownList ID="Ddlupdatetopic" runat="server" CssClass="dropdownbox" 
            AutoPostBack="True" 
            onselectedindexchanged="Ddlupdatetopic_SelectedIndexChanged">
        </asp:DropDownList>
        </td> </tr>
    <tr><td  align="left">
        <asp:Label ID="Label7" runat="server" Text="Content " CssClass="lablewidth"></asp:Label></td></tr>
    <tr><td><asp:TextBox ID="txtupdatecontent" runat="server" Width="400px" Height="140px" 
            TextMode="MultiLine"  CssClass="tablewidth"></asp:TextBox></td></tr>
    
    <tr><td></td></tr>
    <tr><td align="left">
        <asp:Label ID="Label10" runat="server" Text="Updated Date" CssClass="lablewidth"></asp:Label></td></tr>
    <tr><td><asp:TextBox ID="txtupdateddate" runat="server"  CssClass="commonTxtbox" ></asp:TextBox></td></tr>
    <tr><td></td></tr>
    <tr><td align="center" colspan="3"><asp:Button ID="btnupdate" runat="server" 
            Text="Update" CssClass="buttonsimg" onclick="btnupdate_Click"/>
        <asp:Button ID="Button2" runat="server" Text="Back"  CssClass="buttonsimg" 
            onclick="Button2_Click"/>
            </td></tr>
    </table>
    
    </fieldset>
    </asp:Panel>
    </asp:Content>
