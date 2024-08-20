<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Teacher_Hod_Home_Page.aspx.cs" Inherits="Project.Teacher_Hod_Home_Page" %>
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
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Attendance.aspx" Text="Add Student Attendance">                
                </asp:MenuItem>
                <asp:MenuItem Text="Company Profile">
                
                <asp:MenuItem NavigateUrl="~/CompanyChart.aspx" Text="History"/>                
                </asp:MenuItem>               

                <asp:MenuItem Text="Placement Department">
                <asp:MenuItem NavigateUrl="~/For_Hod_Teacher.aspx" Text="View Eligible Students"/>
                <asp:MenuItem NavigateUrl="~/View_Test_Plan_Student.aspx" Text="View Test Plan"/>
                
                </asp:MenuItem>
                
            </Items>
        </asp:Menu>
 </div>
</asp:Content>
