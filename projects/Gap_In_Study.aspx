<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gap_In_Study.aspx.cs" Inherits="Project.Gap_In_Study" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table cellpadding="1px" cellspacing="1px" width="100%" >
        <tr>
            
            <td align="right">
                <asp:Button ID="Button2" runat="server" Text="LogOut" onclick="Button2_Click"/>
            <asp:TextBox ID="Txt_updby" runat="server" CssClass="commonTxtbox" 
                    BorderStyle="None" ReadOnly="True" ></asp:TextBox>            
            </td> 
        </tr>
     </table>
<fieldset >
    <legend > Gap In Study  </legend>
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
        
        <td align="right">
            <asp:Label ID="Lbl_Year" runat="server" Text="Year :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_Year" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>        
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_class" runat="server" Text="Class :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_class" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>

     <tr>
        <td align="right">
            <asp:Label ID="Lbl_dscption" runat="server" Text="Description :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_dscption" runat="server" TextMode="MultiLine" CssClass="tablewidth"></asp:TextBox>
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
