<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pool_Campus_Eligible_Student_Delete.aspx.cs" Inherits="Final_Report_SMPS.Pool_Campus_Eligible_Student_Delete" %>
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
 <table>
 <tr>
        <td>
            <asp:Label ID="LblStudentId" runat="server" Text="Student Id" CssClass="lablewidth"></asp:Label>  
        </td>
        <td class="style1">
             
            <asp:DropDownList ID="DDLStudentId" runat="server" CssClass="dropdownbox">
            </asp:DropDownList>
                  </td>
        
             
        
    
    
 
    <td>
    <asp:Button ID="BtnDelete" runat="server" Text="Delete" 
            onclick="BtnDelete_Click"   CssClass="buttonsimg" />
    </td>
 
    
        <td>
    <asp:Button ID="BtnBack" runat="server"   Text="Back" onclick="BtnBack_Click"  CssClass="buttonsimg"  />
    </td>
     
      </tr>
      
      <tr><td>
          <asp:GridView ID="GrdStudent_Det" runat="server" CssClass="grdvew">
          </asp:GridView>
    </td>  </tr>
      
     </table>
</asp:Content>
