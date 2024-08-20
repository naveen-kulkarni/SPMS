<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pool_Campus_Recruitment_Test_Result.aspx.cs" Inherits="Final_Report_SMPS.Pool_Campus_Recruitment_Test_Result" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table cellpadding="1px" cellspacing="1px" width="100%" >
        <tr>
             <td align="right">
                <asp:Button ID="Button2" runat="server" Text="LogOut" onclick="Button2_Click"/>
            <asp:TextBox ID="Txt_updby" ReadOnly="true" runat="server" CssClass="commonTxtbox" BorderStyle="None" ></asp:TextBox>            
            </td> 
        </tr>
     </table>
 <asp:Label ID="Label2" runat="server" Text="TEST RESULT" 
        Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="Black"></asp:Label>
<table> 
    <tr>
    <td>
            <asp:Label ID="LblCmpName" runat="server" Text="Company Name" CssClass="lablewidth"></asp:Label>  
        </td>
        <td class="style1">
            <asp:DropDownList ID="DDlCmpName" runat="server" CssClass="dropdownbox">
            </asp:DropDownList>
                
           
        </td>
             
    </tr>
    <tr>
        <td>
            <asp:Label ID="LblStudentId" runat="server" Text="Student USN" CssClass="lablewidth"></asp:Label>  
        </td>
        <td class="style1">
            <asp:TextBox ID="TxtStudentId" runat="server" CssClass="Textwidth"></asp:TextBox>
            
           <asp:RequiredFieldValidator ID="TxtStudentIdValidator" runat="server" Text="**" 
                ErrorMessage="plz enter a Student Id" ControlToValidate="TxtStudentId" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
       
            
        </td>
    
         
    </tr>
     <tr>
        <td>
            <asp:Label ID="LblResult" runat="server" Text="Result" CssClass="lablewidth"></asp:Label>  
        </td>
        <td class="style1">
            <asp:TextBox ID="TxtResult" runat="server" CssClass="Textwidth"></asp:TextBox>
             <asp:RequiredFieldValidator ID="TxtResultValidator" runat="server" Text="**" 
                ErrorMessage="plz enter a  Result" ControlToValidate="TxtResult" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
       
        
        
            
        </td>
    
         
    </tr>
     <tr>
     <td>
        
            <asp:Label ID="LblDescription" runat="server" Text="Description" CssClass="lablewidth"></asp:Label>  
        </td>
        <td class="style1">
            <asp:TextBox ID="TxtDescription" runat="server" CssClass="Textwidth"></asp:TextBox>
       <asp:RequiredFieldValidator ID="DescriptionValidator" runat="server" Text="**" 
                ErrorMessage="plz enter a Description" ControlToValidate="TxtDescription" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
       
       
        </td>
        
          </tr>
                  
    
      
</table> 
    <table>
<tr>
<td>
    <asp:Button ID="BtnAdd" runat="server" Text="Add" onclick="BtnAdd_Click"  CssClass="buttonsimg" />
    </td>
    <td>
    <asp:Button ID="BtnEdit" runat="server" Text="Update" onclick="BtnEdit_Click" 
            ValidationGroup="ud" CssClass="buttonsimg"  />
    </td>
<td>
    <asp:Button ID="BtnDelete" runat="server" Text="Delete" 
        onclick="BtnDelete_Click" ValidationGroup="del" CssClass="buttonsimg" />
    </td>
    <td>
    <asp:Button ID="BtnShowAll" runat="server"   Text="ShowAll" ValidationGroup="sa" 
            onclick="BtnShowAll_Click" CssClass="buttonsimg" />
        </td>
        <td>
    <asp:Button ID="BtnBack" runat="server"   Text="Back" onclick="BtnBack_Click" 
                ValidationGroup="bk" CssClass="buttonsimg"/>
    
    </td><td>
    <asp:Button ID="BtnHome" runat="server"   Text="Home" onclick="BtnHome_Click" 
            ValidationGroup="hm" CssClass="buttonsimg" />
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
