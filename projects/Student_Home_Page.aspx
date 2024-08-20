<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student_Home_Page.aspx.cs" Inherits="Project.Student_Home_Page" %>
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
<div class="clear hideSkiplink">
        <asp:Menu ID="NavigationMenu" CssClass="submenutype" runat="server" EnableViewState="false" IncludeStyleBlock="false" Orientation="Horizontal" >
            <Items>
            <asp:MenuItem Text="Master Data">
                <asp:MenuItem NavigateUrl="~/AddBlog.aspx" Text="Add Blog"/>
                <asp:MenuItem NavigateUrl="~/HolidayList.aspx" Text="Holiday List"/>
                </asp:MenuItem>
                <asp:MenuItem Text="Student Profile">
                 <asp:MenuItem NavigateUrl="~/StudentEdit.aspx" Text="Edit Student Profile"/> 
                 <asp:MenuItem NavigateUrl="~/View_Student_Profile.aspx" Text="view Student Profile"/>                                                               
                 
                </asp:MenuItem>
                <asp:MenuItem Text="Company Profile">
                <asp:MenuItem NavigateUrl="~/CompanyChart.aspx" Text="History"/>                
                </asp:MenuItem>               
                <asp:MenuItem Text="Placement Department">
                <asp:MenuItem NavigateUrl="~/View_Test_Plan_Student.aspx" Text="View Test Plan"/>
                </asp:MenuItem>                
            </Items>
        </asp:Menu>
 </div>
</asp:Content>
