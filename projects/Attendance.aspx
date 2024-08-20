<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="Project.Attendance" %>
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
    

<fieldset >
    <legend > Attendance  </legend>
    <table cellpadding="3px" cellspacing="3px">
 <tr>
        <td colspan="3" align="center">
            <asp:Label ID="lblErrMsg" runat="server" Text="Label" CssClass="ReportMsg" 
                Visible="False"></asp:Label>
            </td>
        
    </tr>
   <tr>
        <td align="right">
            <asp:Label ID="Lbl_USN" runat="server" Text="USN :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_USN" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>
        
    <tr>
        
        <td align="right" colspan ="2">
            <asp:Label ID="Lbl_Attendance_Percentage" runat="server" 
                Text="Final Semester Individual Subject Attendance Percentage :" 
                CssClass="lablewidth"></asp:Label>
             <br />   
            <asp:TextBox ID="Txt_Attendance_Percentage" TextMode="MultiLine" runat="server" CssClass="tablewidth"></asp:TextBox>
        </td>        
    </tr>
    
    
    <tr>
        
        <td  colspan="2">
            
            <asp:Button ID="Btn_Save" runat="server" Text="Save" CssClass="buttonsimg" onclick="Btn_Save_Click"/>
        
          
             <asp:Button ID="Btn_cancel" runat="server" CssClass="buttonsimg" Text="Cancel"/>
            
        </td>
    </tr>
     
     
</table>
</fieldset>

</asp:Content>
