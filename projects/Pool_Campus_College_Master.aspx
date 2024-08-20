<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pool_Campus_College_Master.aspx.cs" Inherits="Final_Report_SMPS.Other_College_Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 160px;
        }
    </style>
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
    <asp:Label ID="Label1" runat="server" Text="OTHER COLLEGE DETAIL" 
        Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="Black"></asp:Label>
     <table> 
           
   
     <tr>
     <td>
        <asp:Label ID="LblCollegeName" runat="server" Text="College Name" CssClass="lablewidth"></asp:Label>  
        </td>
        <td>
            <asp:TextBox ID="TxtCollName" runat="server" CssClass="Textwidth"></asp:TextBox>
              <asp:RequiredFieldValidator ID="CollNameValidator" runat="server" Text="**" 
                ErrorMessage="plz enter a College Address" ControlToValidate="TxtCollName" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
               
       
        </td>
        
          </tr>

          <tr>
     <td>
        <asp:Label ID="LblCollegeAddress" runat="server" Text="College Address" CssClass="lablewidth"></asp:Label>  
        </td>
        <td>
            <asp:TextBox ID="TxtCollAddress" runat="server" CssClass="Textwidth"></asp:TextBox>
              <asp:RequiredFieldValidator ID="CollAddressValidator" runat="server" Text="**" 
                ErrorMessage="plz enter a College Address" ControlToValidate="TxtCollAddress" 
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
            <asp:RequiredFieldValidator ID="HrPhoneValidator" runat="server" Text="**" 
                ErrorMessage="plz enter a HR Ph_No" ControlToValidate="TxtDescription" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>

        
        
    </tr>
      </table>

      
       

       
                 
         
    

    <table>
<tr>
<td>
    <asp:Button ID="BtnAdd" runat="server" Text="Add" onclick="BtnAdd_Click"  CssClass="buttonsimg"/>
    </td>
    <td>
    <asp:Button ID="BtnEdit" runat="server" Text="Update" onclick="BtnEdit_Click" 
            ValidationGroup="plz" CssClass="buttonsimg" />
    </td>
<td>
    <asp:Button ID="BtnDelete" runat="server" Text="Delete" onclick="BtnDelete_Click" 
        ValidationGroup="please1" CssClass="buttonsimg" />
    </td>
    <td>
    <asp:Button ID="BtnShowAll" runat="server" onclick="BtnShowAll_Click" 
        Text="ShowAll" ValidationGroup="please2"  CssClass="buttonsimg"/>
        </td>
        <td>
    <asp:Button ID="BtnBack" runat="server" onclick="BtnBack_Click" Text="Back" 
                ValidationGroup="please3" CssClass="buttonsimg" />
    
    </td><td>
    <asp:Button ID="BtnHome" runat="server" onclick="BtnHome_Click" Text="Home" 
            ValidationGroup="please4" CssClass="buttonsimg" />
    </td>
    
   <td>
    <asp:GridView ID="GrdStudent_Det" runat="server" CssClass="grdvew">
    </asp:GridView>
    </td>
    
</tr>
</table>
<asp:ValidationSummary ID="vscontrol" runat="server" ShowMessageBox="true" 
        DisplayMode="BulletList" HeaderText="Plz Correct These Errors" 
        ForeColor="Red"/>
     
        </asp:Content>
