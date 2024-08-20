<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View_Test_Plan_Student.aspx.cs" Inherits="Project.For_Student" %>
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


<fieldset><legend>View Test Plan</legend>

<table cellpadding="3px" cellspacing="3px">
    <tr>
        <td align="right">
           <asp:Label ID="Label2" runat="server" CssClass="lablewidth" Text="Company Name:"></asp:Label>
        </td>
        <td colspan="9">
            <asp:DropDownList ID="DropDownList1" runat="server" BorderStyle="Solid" CssClass="dropdownbox" AutoPostBack="True" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
                 <td align="right">
                    <asp:Label ID="Label1" runat="server" Text="Test Date :" CssClass="lablewidth"></asp:Label>
                 </td>
                 <td colspan="9">
                   <asp:TextBox ID="TextDate" runat="server" ReadOnly="true" BorderStyle="Solid"  CssClass="commonTxtbox"></asp:TextBox>
                 </td>
                 </tr>
                 <tr>
                 
                 <td align="right">
                        <asp:Label ID="Label3" runat="server" Text="Test Time :" CssClass="lablewidth"></asp:Label>
                 </td>
                 <td colspan="9">
                      <asp:TextBox ID="Texttime" runat="server" ReadOnly="true" BorderStyle="Solid" CssClass="commonTxtbox"></asp:TextBox>
                 </td>
                 </tr>
                 <tr>
             
                  <td align="right">
                     <asp:Label ID="Label4" runat="server" Text="Test Place : " CssClass="lablewidth"></asp:Label>
                  </td>
                  <td colspan="9">
                      <asp:TextBox ID="TextBox3" runat="server" ReadOnly="true" BorderStyle="Solid" CssClass="commonTxtbox"></asp:TextBox>
                  </td>
             </tr>
             </table>
             <table cellpadding="3px" cellspacing="3px" border="1px">
             <tr>
            <td align="right">
        <asp:Label ID="Label5" runat="server" CssClass="lablewidth" Text=" Apptitude/Technical test"></asp:Label>
        </td>
        
        
        <td align="right">
        <asp:Label ID="Label6" runat="server" CssClass="lablewidth" Text=" Group Discussion"></asp:Label>
        </td>
        
        
        <td align="right">
        <asp:Label ID="Label7" runat="server" CssClass="lablewidth" Text="Technical Round 1"></asp:Label>
        </td>
        
           
        <td align="right">
            <asp:Label ID="Label8" runat="server" CssClass="lablewidth" Text="Technical Round 2"></asp:Label>
        </td>
           
                
       <td align="right">
        <asp:Label ID="Label9" runat="server" CssClass="lablewidth"  Text="Technical Round 3"></asp:Label>
         </td>
        
        
        <td align="right">
        <asp:Label ID="Label10" runat="server" CssClass="lablewidth" Text="Telephone Interview 1"></asp:Label>
        </td>
       
        
        <td align="right">
        <asp:Label ID="Label11" runat="server" CssClass="lablewidth" Text="Telephone Interview 2"></asp:Label>
        </td>
       
            <td align="right">
        <asp:Label ID="Label12" runat="server" CssClass="lablewidth" Text="HR Round 1"></asp:Label>
        </td>
      
        
       <td align="right">
        <asp:Label ID="Label13" runat="server" CssClass="lablewidth" Text="HR Round 2"></asp:Label>
        </td>
       
        </tr>
        <tr>
            <td align="center">
            <asp:CheckBox ID="CheckBox1"  runat="server" />
            </td>
            <td align="center">
            <asp:CheckBox ID="CheckBox2"  runat="server" />
           </td>
           <td align="center">
           <asp:CheckBox ID="CheckBox3"   runat="server" />
           </td>
            <td align="center">
                <asp:CheckBox ID="CheckBox4" runat="server" />
                </td>
                 <td align="center">
        <asp:CheckBox ID="CheckBox5" runat="server" />
        </td>
         <td align="center">
        <asp:CheckBox ID="CheckBox6"  runat="server" />
        </td>
         <td align="center">
           <asp:CheckBox ID="CheckBox7" runat="server" />
           </td>
             <td align="center">
        <asp:CheckBox ID="CheckBox8"  runat="server" />
        </td>
         <td align="center">
           <asp:CheckBox ID="CheckBox9" runat="server" />
           </td>
          
      </tr>
</table>





 </fieldset>
</asp:Content>
