<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pool_Campus_Company_Placement_Criteria.aspx.cs" Inherits="Final_Report_SMPS.Pool_Campus_Company_Placement_Criteria" %>
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
 <asp:Label ID="Label2" runat="server" Text="COLLEGE COMPANY CRITERIA" 
        Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="Black"></asp:Label>
<table style="height: 181px; width: 307px"> 
    
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
            <asp:Label ID="LblCutOfType" runat="server" Text="Cut Of Type" CssClass="lablewidth"></asp:Label>  
        </td>
        <td class="style1">
            <asp:TextBox ID="TxtCutOfType" runat="server" CssClass="Textwidth"></asp:TextBox>
            <asp:RequiredFieldValidator ID="CutOffTypeValidator" runat="server" Text="**" 
                ErrorMessage="plz enter a Cut Of Type" ControlToValidate="TxtCutOfType" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        
        
            
        </td>
    
         
    </tr>
     <tr>
        <td>
            <asp:Label ID="LblCutOfTenth" runat="server" Text="Cut Of Tenth" CssClass="lablewidth"></asp:Label>  
        </td>
        <td class="style1">
            <asp:TextBox ID="TxtCutOfTenth" runat="server" CssClass="Textwidth"></asp:TextBox>
            <asp:RequiredFieldValidator ID="CutOfTenthValidator1" runat="server" Text="**" 
                ErrorMessage="plz enter a Cut Of Tenth" ControlToValidate="TxtCutOfTenth" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        
        
            
        </td>
    
         
    </tr>
     <tr>
     <td>
        
            <asp:Label ID="LblCutOfTwelth" runat="server" Text="Cut Of Twelth" CssClass="lablewidth"></asp:Label>  
        </td>
        <td class="style1">
            <asp:TextBox ID="TxtCutOfTwelth" runat="server" CssClass="Textwidth"></asp:TextBox>
       <asp:RequiredFieldValidator ID="CutOfTwelthValidator" runat="server" Text="**" 
                ErrorMessage="plz enter a Cut Of Twelth" ControlToValidate="TxtCutOfTwelth" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        
       
       
        </td>
        
          </tr>
    
     <tr>
        <td>
            <asp:Label ID="LblCutOfDegree" runat="server" Text="Cut Of Degree" CssClass="lablewidth"></asp:Label>  
        </td>
        <td class="style1">
            <asp:TextBox ID="TxtCutOfDegree" runat="server" CssClass="Textwidth"></asp:TextBox>
         
        <asp:RequiredFieldValidator ID="CutOfDegreeValidator" runat="server" Text="**" 
                ErrorMessage="plz enter a Cut Of Degree" ControlToValidate="TxtCutOfDegree" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        
         
        </td></tr>
        <tr>
        <td>

        
            <asp:Label ID="LblBackInYears" runat="server" Text="Back In Years" CssClass="lablewidth"></asp:Label>  
        </td>
        <td>
            <asp:RadioButton ID="RDTrue" runat="server" Text="yes" GroupName="backyr" />
            <asp:RadioButton ID="RDFalse"  runat="server" Text="No" GroupName="backyr" />  
        </td>
         
        
         
    
    </tr>

    <tr>
        <td>

        
            <asp:Label ID="LblBackLogAllowed" runat="server" Text="Back Log Allowed" CssClass="lablewidth"></asp:Label>  
        </td>
        <td>
            <asp:RadioButton ID="RdBackLogAllowedYes" runat="server" Text="yes" 
                GroupName="backlog" />
            <asp:RadioButton ID="RdBackLogNotAllowed"  runat="server" Text="No" 
                GroupName="backlog" />  
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
    <asp:Button ID="BtnAdd" runat="server" Text="Add" onclick="BtnAdd_Click"  CssClass="buttonsimg"  />
    </td>
    <td>
    <asp:Button ID="BtnEdit" runat="server" Text="Update"   ValidationGroup="plz" 
            onclick="BtnEdit_Click" CssClass="buttonsimg" />
    </td>
<td>
    <asp:Button ID="BtnDelete" runat="server" Text="Delete"  
        ValidationGroup="please1" onclick="BtnDelete_Click" CssClass="buttonsimg"  />
    </td>
    <td>
    <asp:Button ID="BtnShowAll" runat="server"   Text="ShowAll" 
            ValidationGroup="please2" onclick="BtnShowAll_Click" CssClass="buttonsimg" />
        </td>
        <td>
    <asp:Button ID="BtnBack" runat="server"   Text="Back" ValidationGroup="please3" 
                onclick="BtnBack_Click" CssClass="buttonsimg" />
                  
    
    </td><td>
    <asp:Button ID="BtnHome" runat="server"  Text="Home"  ValidationGroup="please4" 
            onclick="BtnHome_Click1" CssClass="buttonsimg" />
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
