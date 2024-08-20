<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pool_Campus_Eligible_Student_Update.aspx.cs" Inherits="Final_Report_SMPS.Pool_Campus_Eligible_Student_Update" %>
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
 <asp:Label ID="Label2" runat="server" Text="ELIGIBLE STUDENTS" 
        Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="Black"></asp:Label>
 <table style="height: 181px; width: 307px"> 
    
    
    <tr>
        <td>
            <asp:Label ID="LblStudentId" runat="server" Text="Student Id" CssClass="lablewidth"></asp:Label>  
        </td>
        <td class="style1">
             
            <asp:DropDownList ID="DDLStudentId" runat="server" CssClass="dropdownbox" 
                AutoPostBack="True" 
                onselectedindexchanged="DDLStudentId_SelectedIndexChanged"  >
            </asp:DropDownList>
                  </td>
        
             
        
    </tr>
    
    <tr>
        <td>
            <asp:Label ID="LblFirstName" runat="server" Text="First Name" CssClass="lablewidth"></asp:Label>  
        </td>
        <td class="style1">
            <asp:TextBox ID="TxtFirstName"  runat="server"   CssClass="Textwidth" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="FirstNameValidator" runat="server" Text="**" 
                ErrorMessage="plz enter a First Name" ControlToValidate="TxtFirstName" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>    
        </td>
        
             
        
    </tr>
    
     <tr>
        <td>
            <asp:Label ID="LblMiddleName" runat="server" Text="Middle Nae" CssClass="lablewidth"></asp:Label>  
        </td>
        
        <td class="style1">
            <asp:TextBox ID="TxtMiddleName" runat="server"  CssClass="Textwidth" ></asp:TextBox>
             <asp:RequiredFieldValidator ID="MiddleNameValidator" runat="server" Text="**" 
                ErrorMessage="plz enter a Middle Name" ControlToValidate="TxtMiddleName" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator> 
        </td>
     </tr>
     
     <tr>
     <td>
         <asp:Label ID="LblLastName" runat="server" Text="Last Name" CssClass="lablewidth"></asp:Label>
         </td>
     <td>
         <asp:TextBox ID="TxtLastName" runat="server" CssClass="Textwidth"></asp:TextBox>
               <asp:RequiredFieldValidator ID="LastNameValidator" runat="server" Text="**" 
                ErrorMessage="plz enter a Last Name" ControlToValidate="TxtLastName" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator> 
              
              </td>
     </tr>
     <tr>
     <td>
         <asp:Label ID="LblGender" runat="server" Text="Gender" CssClass="lablewidth"></asp:Label>
     </td>
     <td>
         <asp:TextBox ID="TxtGender" runat="server" CssClass="Textwidth"></asp:TextBox>

     </td>
          </tr>
     

     <tr>
        <td>
            <asp:Label ID="LblPhone" runat="server" Text="Phone" CssClass="lablewidth"></asp:Label>  
        </td>
        <td class="style1">
            <asp:TextBox ID="TxtPhone" runat="server" CssClass="Textwidth"></asp:TextBox>
            <asp:RequiredFieldValidator ID="PhoneValidator" runat="server" Text="**" 
                ErrorMessage="plz enter a Phone Number" ControlToValidate="TxtPhone" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator> 
              
        </td>
    
        
             
        
    </tr>
      
      <tr>
        <td>
            <asp:Label ID="LblEmail" runat="server" Text="Email Id" CssClass="lablewidth"></asp:Label>  
         </td>
         <td>
             <asp:TextBox ID="TxtEmail" runat="server" CssClass="Textwidth"></asp:TextBox>

              <asp:RequiredFieldValidator ID="EmailValidator" runat="server" Text="**" 
                ErrorMessage="plz enter a Email" ControlToValidate="TxtEmail" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator> 
                
             </td>
    </tr>



     <tr>
        <td>
            <asp:Label ID="LblDept" runat="server" Text="Department " CssClass="lablewidth"></asp:Label>  
        </td>
        <td class="style1">
            <asp:TextBox ID="TxtDept" runat="server" CssClass="Textwidth"></asp:TextBox>
        </td>
    </tr>

     <tr>
     <td>
            <asp:Label ID="LblCollege" runat="server" Text="College" CssClass="lablewidth"></asp:Label>  
        </td>
        
         <td>
             <asp:DropDownList ID="DDLCollegeName" runat="server"  Width="127">
             </asp:DropDownList>
         
           
         </td>
        
               
             </tr>
              <tr>
     <td>
            <asp:Label ID="LblCourse" runat="server" Text="Course" CssClass="lablewidth"></asp:Label>  
        </td>
        
         <td>
             <asp:TextBox ID="TxtCourse" runat="server"  CssClass="Textwidth" ></asp:TextBox>
         
           <asp:RequiredFieldValidator ID="CourseValidator" runat="server" Text="**" 
                ErrorMessage="plz enter a  Course" ControlToValidate="TxtCourse" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator> 
         
         </td></tr>
        
              <tr>
     <td>
            <asp:Label ID="LblDOB" runat="server" Text="Date Of Birth" CssClass="lablewidth"></asp:Label>  
        </td>
        
         <td>
             <asp:TextBox ID="TxtDOB" runat="server"  CssClass="Textwidth" ></asp:TextBox>
         
          <asp:RequiredFieldValidator ID="DOBValidator" runat="server" Text="**" 
                ErrorMessage="plz enter a  DOB" ControlToValidate="TxtDOB" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator> 
         

         
         </td>
        
             
        
         
    </tr>

    <tr>
     <td>
            <asp:Label ID="LblPresentAddress" runat="server" Text="Present Address" CssClass="lablewidth"></asp:Label>  
        </td>
        
         <td>
             <asp:TextBox ID="TxtPresentAddress" runat="server"  CssClass="Textwidth" ></asp:TextBox>
         
          <asp:RequiredFieldValidator ID="PresentAddressValidator" runat="server" Text="**" 
                ErrorMessage="plz enter a   Present Address" ControlToValidate="TxtPresentAddress" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator> 
         


         
         </td>
        
             
        
         
    </tr>
        
       
        
    <tr>
     <td>
         <asp:Label ID="LblSameAddress" runat="server" Text="Same AS aAbove" CssClass="lablewidth"></asp:Label>
     </td>
     <td>
     <asp:RadioButton ID="Rdyes" runat="server" Text="Yes" GroupName="sameaddress" 
             oncheckedchanged="Rdyes_CheckedChanged" />
         <asp:RadioButton ID="RdNo" runat="server" Text="No" GroupName="sameaddress" />

     </td>
          </tr>
          <tr>
     <td>
            <asp:Label ID="LblPermanentAddress" runat="server" Text="Permanent Address" CssClass="lablewidth"></asp:Label>  
        </td>
        
         <td>
             <asp:TextBox ID="TxtPermanentAddress" runat="server"  CssClass="Textwidth" ></asp:TextBox>
             <asp:RequiredFieldValidator ID="PermanentAddressValidator" runat="server" Text="**" 
                ErrorMessage="plz enter a   Permanent Address" ControlToValidate="TxtPermanentAddress" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator> 
         
         
          

         
         </td>
        
             
        
         
    </tr>
         
 
        
             
        
         
     
</table>
    <table>
<tr>
 
    <td>
    <asp:Button ID="BtnEdit" runat="server" Text="Update" CssClass="buttonsimg" 
            onclick="BtnEdit_Click"  />
    </td>
 
    
        <td>
    <asp:Button ID="BtnBack" runat="server"   Text="Back" onclick="BtnBack_Click" 
                ValidationGroup="bk"  CssClass="buttonsimg" />
    </td>
    <td><asp:Button ID="BtnHome" runat="server"    Text="Home" 
            onclick="BtnHome_Click" ValidationGroup="hm" CssClass="buttonsimg" />
      </td> 
     
   <td>
    <asp:GridView ID="GrdStudent_det" runat="server" CssClass="grdvew">
    </asp:GridView>
        
    </td>
    
</tr>
</table>
 <asp:ValidationSummary ID="vscontrol" runat="server" ShowMessageBox="true" 
        DisplayMode="BulletList" HeaderText="Plz Correct These Errors" 
        ForeColor="Red"/>
     
</asp:Content>
