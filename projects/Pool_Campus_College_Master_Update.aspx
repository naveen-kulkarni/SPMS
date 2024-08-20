<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pool_Campus_College_Master_Update.aspx.cs" Inherits="Final_Report_SMPS.Update_Other_College_Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table cellpadding="1px" cellspacing="1px" width="100%" >
        <tr>
             <td align="right">
                <asp:Button ID="Button2" runat="server" Text="LogOut" onclick="Button2_Click"/>
            <asp:TextBox ID="Txt_updby" runat="server" ReadOnly="true" CssClass="commonTxtbox" BorderStyle="None" ></asp:TextBox>            
            </td> 
        </tr>
     </table>
<table style="height: 181px; width: 307px"> 
     <asp:Label ID="Label1" runat="server" Text="OTHER COLLEGE DETAIL" 
        Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="Black"></asp:Label>
    
    <tr>
        <td>
            <asp:Label ID="LblCollName" runat="server" Text="CollegeName"  CssClass="lablewidth"></asp:Label>  
        </td>
        <td class="style1">
            <asp:DropDownList ID="DDLCollegeName" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DDLCollegeName_SelectedIndexChanged"  CssClass="dropdownbox">
            </asp:DropDownList>
        </td>
    </tr>
 
     <tr>
     <td>
        
            <asp:Label ID="LblCollAddrs" runat="server" Text="College Address" CssClass="lablewidth"></asp:Label>  
        </td>
        <td class="style1">
            <asp:TextBox ID="TxtCollAddrs" runat="server" CssClass="Textwidth"></asp:TextBox>
       
       <asp:RequiredFieldValidator ID="CollAddrsValidator" runat="server" Text="**" 
                ErrorMessage="plz enter a College Address" ControlToValidate="TxtCollAddrs" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
               
       
        </td>
        
          </tr>
    
     <tr>
        <td>
            <asp:Label ID="LblContactNo" runat="server" Text="Contact Number" CssClass="lablewidth"></asp:Label>  
        </td>
        <td class="style1">
            <asp:TextBox ID="TxtContactNo" runat="server" CssClass="Textwidth"></asp:TextBox>
         
        
        <asp:RequiredFieldValidator ID="HrValidator" runat="server" Text="**" 
                ErrorMessage="plz enter a HR Name" ControlToValidate="TxtContactNo" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                
        </td></tr>
        <tr>
        <td>
            <asp:Label ID="LblWebSite" runat="server" Text="WebSite" CssClass="lablewidth"></asp:Label>  
        </td>
        <td class="style1">
            <asp:TextBox ID="TxtWebSite" runat="server" CssClass="Textwidth"></asp:TextBox>
            <asp:RequiredFieldValidator ID="HrEmailIdValidator" runat="server" Text="**" 
                ErrorMessage="plz enter a HR Email-Id" ControlToValidate="TxtWebSite" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
        
         
    
    </tr>

     <tr>
        <td>
            <asp:Label ID="LblDescription" runat="server" Text="Description" CssClass="lablewidth"></asp:Label>  
        </td>
        <td class="style1">
            <asp:TextBox ID="TxtDescription" runat="server" CssClass="Textwidth"></asp:TextBox>
             
        </td>
        
        
    </tr>
     
     
                 
         
    
</table> 
    <table>
<tr>
 
    <td>
    <asp:Button ID="BtnEdit" runat="server" Text="Update" onclick="BtnEdit_Click" CssClass="buttonsimg" />
    </td>
 
     
        <td>
    <asp:Button ID="BtnBack" runat="server" onclick="BtnBack_Click" Text="Back" 
                ValidationGroup="please3" CssClass="buttonsimg" />
    
    </td><td>
    <asp:Button ID="BtnHome" runat="server" onclick="BtnHome_Click" Text="Home" 
            ValidationGroup="please4" CssClass="buttonsimg" />
    </td>
    
   <td>
    <asp:GridView ID="GrdStudent_Det" runat="server"  CssClass="grdvew">
    </asp:GridView>
    </td>
    
</tr>
</table>
<asp:ValidationSummary ID="vscontrol" runat="server" ShowMessageBox="true" 
        DisplayMode="BulletList" HeaderText="Plz Correct These Errors" 
        ForeColor="Red"/>
</asp:Content>
