<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="For_Hod_Teacher.aspx.cs" Inherits="Project.For_Hod_Teacher" %>
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

<fieldset ><legend>View Eligible Student</legend>
<table cellpadding="3px" cellspacing="3px" width="100%">
            <tr>
             
                    
                     <td align="right">
                        <asp:Label ID="Label12" runat="server" Text="Department :" CssClass="lablewidth"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="dropdownbox" 
                            onselectedindexchanged="DropDownList2_SelectedIndexChanged" 
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    

                    
                </tr>
                <tr>
                 <td align="center" colspan="3">
                     <asp:GridView ID="Gridload" runat="server">
                     </asp:GridView>
                 </td>
                </tr>
             </table>
            


</fieldset>
</asp:Content>
