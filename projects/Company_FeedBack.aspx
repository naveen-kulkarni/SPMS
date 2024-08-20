<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Company_FeedBack.aspx.cs" Inherits="Project.Company_FeedBack" %>
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

        <asp:Label ID="Label1" runat="server"
            Text="LEAVE YOUR COMMENTS"></asp:Label>
        
    <div>
        <table border="0" cellspacing="20">
        <tr>
            <td>
                <asp:Label ID="lblStatus" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Mail Id"></asp:Label>
                   </td><td>
                    <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
                    </td></tr>
                    <tr><td>
                    <asp:Label ID="Label3" runat="server" Text="Subject :" ></asp:Label></td><td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td></tr>
                    <tr><td>
                    <asp:Label ID="Label4" runat="server" Text="Comments :" ></asp:Label>
                    </td><td>
                    <asp:TextBox ID="TextBox3" runat="server"
                        TextMode="MultiLine" Width="321px"></asp:TextBox>
                            <br />
                         &nbsp;
                            <asp:Label ID="Label5" runat="server" Text="4000 character(s) "></asp:Label>
                            <br />
                         </td></tr>
                         <tr><td>
                         
                         
                         <center>    <asp:Button ID="Button1" runat="server" 
                                      Text="POST COMMENT" onclick="Button1_Click" /></center></td></tr>
                    
              </table>
              </div>
              

</asp:Content>
