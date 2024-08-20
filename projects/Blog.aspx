<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Blog.aspx.cs" Inherits="Project.Blog" %>
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
<div>
    <table id="Table1" width="80%" runat="server" border="1">
		<tr>
		<td align="right">
            <asp:Label ID="Label1" runat="server" Text="Topic :" CssClass="lablewidth"></asp:Label>
		</td>
		<td>
        <asp:Label ID="lbltopic" runat="server" CssClass="lablewidth"></asp:Label>		
 		</td>
		</tr>
		<tr>
		<td align="right">
            <asp:Label ID="Label2" runat="server" Text="Content :" CssClass="lablewidth"></asp:Label>
		</td>
		<td>
		<asp:Label ID="lblcontent" runat="server" CssClass="lablewidth"></asp:Label>
		</td>
		</tr>
		<tr>
		<td align="right">
            <asp:Label ID="Label3" runat="server" Text="Created By :" CssClass="lablewidth"></asp:Label></td>
		<td>
		<asp:Label ID="lblcreatedBy" runat="server" CssClass="lablewidth"></asp:Label>
		</td>
		</tr>
		<tr>
		<td align="right">
            <asp:Label ID="Label4" runat="server" Text=" Created On :" CssClass="lablewidth"></asp:Label></td>
		<td>
		<asp:Label ID="lblcreatedDate" runat="server" CssClass="lablewidth"></asp:Label>
		</td>
		</tr>
        </table>
        <table>
        <tr>
        <td></td>
        <td align="center">
        <asp:Panel ID="PanelReply" runat="server" Visible="True" Width="500">
        <fieldset>
        <legend class="legfont">Reply</legend>
        <table id="Table2" width="80%" runat="server">
        <tr><td>
        <asp:GridView ID="GVComment" runat="server" AutoGenerateColumns="false"
                AllowPaging="true" CssClass="grdvew">
                <Columns>
                <asp:BoundField HeaderText = "BlogDetailID" DataField = "BlogDetailID" Visible ="false" />
                <asp:BoundField HeaderText = "BlogListID" DataField = "BlogListID" Visible ="false" />
                <asp:BoundField HeaderText = "Reply/Comment" DataField = "Postings" />
                <asp:BoundField HeaderText = "Replied By" DataField = "Postedby" />
                <asp:BoundField HeaderText = "Replied Date" DataField = "Posteddate" />
                <asp:BoundField HeaderText = "Updated_By" DataField = "Updated_By" Visible="false" />
                <asp:BoundField HeaderText = "Updated_Date" DataField = "Updated_Date" Visible="false" />
                </Columns>
            </asp:GridView>
            </td></tr>
            <tr><td></td></tr>
        <tr><td align = "left">
            <asp:Label ID="Label5" runat="server" Text="Reply / Comment" CssClass="lablewidth"></asp:Label></td></tr>
        <tr><td><asp:TextBox ID="txtReply" runat="server" Width="400px" Height="140px" 
            TextMode="MultiLine" CssClass="tablewidth"></asp:TextBox></td> </tr>        
        <tr><td align="left">
            <asp:Label ID="Label6" runat="server" Text="Date" CssClass="lablewidth"></asp:Label></td></tr>
        <tr><td><asp:TextBox ID="txtreplydate" runat="server" Width="400px" CssClass="commonTxtbox"></asp:TextBox></td></tr>
        <tr><td align="left">
            <asp:Label ID="Label7" runat="server" Text="Posted By" CssClass="lablewidth"></asp:Label></td></tr>
        <tr><td><asp:TextBox ID="txtreplyby" runat="server" Width="400px" CssClass="commonTxtbox"></asp:TextBox></td></tr>
        <tr><td></td></tr>
        <tr><td align="right">
        <asp:Button ID="BtnReply" BorderStyle="None" runat="server" Text="Reply" 
        onclick="BtnReply_Click" CssClass="buttonsimg" /></td></tr>
        </table>
        </fieldset>
        </asp:Panel>
        </td>
        </tr>
		</table>
    </div>
</asp:Content>



