<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Test_Schedule.aspx.cs" Inherits="Project.Test_Schedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table cellpadding="0" cellspacing="0" width="100%" >
        <tr> 
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="dropdownbox"
                          onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                      </asp:DropDownList>
            </td>        
            <td align="right">
                <asp:Button ID="Button2" runat="server" Text="LogOut" onclick="Button2_Click"/>
            <asp:TextBox ID="Txt_updby" runat="server" ReadOnly="true" CssClass="commonTxtbox" BorderStyle="None" ></asp:TextBox>            
            </td>        
        </tr>
     </table>


<fieldset><legend>Test_Schedule Entry</legend>
   
         <table cellspacing="1px" cellpadding="1px">
         <tr>
            <td colspan="4">
                <center><asp:Label ID="lblErrMsg" runat="server" CssClass="ReportMsg" Visible="False"></asp:Label></center>                          
                 
            </td>
         </tr>
          <tr>
                  <td align="right" valign="top">
                     <asp:Label ID="Label4" runat="server" Text="Company Name : " CssClass="lablewidth"></asp:Label>
                  </td>
                  <td colspan="4" valign="top">
                      <asp:DropDownList ID="Drp_dwn_Company" runat="server" CssClass="dropdownbox" 
                          onselectedindexchanged="Drp_dwn_Company_SelectedIndexChanged" >
                          
                      </asp:DropDownList>
                      
                  </td>
              </tr>
             <tr>
                 <td align="right">
                    <asp:Label ID="Label1" runat="server" Text="Test Date : " CssClass="lablewidth"></asp:Label>
                 </td>
                 <td>
                   <asp:TextBox ID="TextDate" runat="server"  CssClass="commonTxtbox"></asp:TextBox>
                 </td>
                 <td colspan="1">
                     <asp:ImageButton ID="calbutton" runat="server" 
                     ImageUrl="/images/buttons/cal.gif" OnClick="calbutton_Click"/>
                 </td>
                 <td rowspan="3">
                    <asp:Calendar ID="Calendar1" runat="server" 
                    OnSelectionChanged="Calendar1_SelectionChanged1" Visible="False"></asp:Calendar>  
                 </td>
                 
                    
             </tr>
             <tr>
                 <td align="right">
                        <asp:Label ID="Label2" runat="server" Text="Test Time :" CssClass="lablewidth"></asp:Label>
                 </td>
                 <td colspan="2">
                      <asp:TextBox ID="Texttime" runat="server" CssClass="commonTxtbox"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                  <td align="right">
                     <asp:Label ID="Label3" runat="server" Text="Test Place : " CssClass="lablewidth"></asp:Label>
                  </td>
                  <td colspan="2">
                      <asp:TextBox ID="TextBox3" runat="server" CssClass="commonTxtbox"></asp:TextBox>
                  </td>
             </tr>
            
            
              <tr>
                 <td  colspan="5" align="center">
                     <asp:Button ID="Button1" runat="server" Text="SAVE" CssClass="buttonsimg" OnClick="Button1_Click" />
                     
                     <asp:Button ID="delbutton" runat="server" Text="DELETE" CssClass="buttonsimg" OnClick="delbutton_Click"/>
                     <asp:Button ID="CLRBUTTON" runat="server" Text="CLEAR" CssClass="buttonsimg" 
                         onclick="CLRBUTTON_Click1"/>
                         
                     <asp:Button ID="Btn_SndMail" runat="server" CssClass="buttonsimg" 
                         Text="Send Mail" onclick="Btn_SndMail_Click"/>
                </td>
            </tr>
         </table>

         </fieldset>

</asp:Content>
