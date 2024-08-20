<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="companyprofile.aspx.cs" Inherits="Project.companyprofile" %>
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
<fieldset><legend>Company Profile</legend>

<table>
    <tr>
        <td>
            <asp:Label ID="Label15" runat="server" Text="Edit :" CssClass="lablewidth"></asp:Label></td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="style33"  Width="200px" Height="32px" AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged1">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="COMPANY PROFILE :" CssClass="lablewidth"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
           <asp:Label ID="Label2" runat="server" Text="Company Name:"></asp:Label>
        </td>
        <td>
           <asp:TextBox ID="TextBox1" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label8" runat="server" Text="Company Web Sites:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td> 
            <asp:Label ID="Label3" runat="server"  Text="Managing Director: "></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"  Width="202px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>           
            <asp:Label ID="Label9" runat="server" Text="Skills: "></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>                    
            <asp:Label ID="Label4" runat="server"  Text="Company CEO: "></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </td>
    </tr> 
    <tr>
        <td>
            <asp:Label ID="Label10" runat="server" Text="Cost To Company :"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
        </td>
   </tr> 
   <tr>
        <td>           
            <asp:Label ID="Label5" runat="server" Text="Company Services:  "></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </td>
   </tr>
   <tr>
        <td>
            <asp:Label ID="Label11" runat="server"  Text="Bond:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
        </td>
   </tr>
   <tr>
        <td>
            <asp:Label ID="Label6" runat="server" Text="ISO Certification No:"></asp:Label>
        </td>
        <td>
             <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        </td>
   </tr>
   <tr>
        <td>
            <asp:Label ID="Label12" runat="server" Text="Description:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
        </td>
   </tr>
   <tr>
        <td>
            <asp:Label ID="Label7" runat="server" Text="Company Address :"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox6" runat="server"  TextMode="MultiLine" ></asp:TextBox>
        </td>
   </tr>
   <tr>
        <td>
            <asp:Label ID="Label13" runat="server"  Text="Upload  Presentation:"></asp:Label>
        </td>
        <td>
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </td>
   </tr>
   <tr>
        <td>
            <asp:Label ID="UploadStatusLabel" runat="server" ForeColor="#FF3300" Text="Invalid format! cannot store in database!!" Visible="False"></asp:Label>
       </td>
   </tr>
   
  
  <tr>
        <td>
            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Save"/>
        </td>
        <td>
            <asp:Button ID="Button3" runat="server"  onclick="Button3_Click" 
                Text="Delete" />
        </td>
   </tr>
          <asp:Label ID="lblErrMsg" runat="server" Text="Label" Visible="False"></asp:Label>
</table>
</fieldset>
</asp:Content>
