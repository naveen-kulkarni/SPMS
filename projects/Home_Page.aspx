<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home_Page.aspx.cs" Inherits="Final_Report_SMPS.Home_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <table>
       <tr>
       <td>
           <asp:Button ID="BtnPCCM" runat="server" Text="POOL CAMPUS COLLEGE MASTER"   
             CssClass="buttonsimg"   Width="364px" onclick="BtnPCCM_Click"/> 
           &nbsp;<asp:Button ID="BtnPCCC" runat="server" 
               Text="POOL CAMPUS COMPANY COLLEGE CONFIGURATION" CssClass="buttonsimg" Width="364px" 
               onclick="BtnPCCC_Click" /> 
               </td></tr>
           <tr>
           <td>
           
           
           <asp:Button ID="BtnPCCPC" runat="server" 
                   Text="POOL CAMPUS COMPANY PLACEMENT CRITERIA" CssClass="buttonsimg"  Width="364px" 
                   onclick="BtnPCCPC_Click" />
           &nbsp;<asp:Button ID="BtnPCES" runat="server" Text="POOL CAMPUS ELIGIBLE STUDENT"   
                CssClass="buttonsimg"    Width="364px" onclick="BtnPCES_Click"/>
           </td>
           </tr>
           <tr>
           <td>
           
           <asp:Button ID="BtnPCRMPM" runat="server" 
                   Text="POOL CAMPUS RECRUITMENT PLAN MASTER"  CssClass="buttonsimg" Width="364px" 
                   onclick="BtnPCRMPM_Click" />
           &nbsp;<asp:Button ID="BtnPCRS" runat="server" Text="POOL CAMPUS RECRUITMETN SCHEDULAR"  
               CssClass="buttonsimg"     Width="364px" onclick="BtnPCRS_Click" />
            </td>
           </tr>
          
           <tr>
           <td>
           
           
           <asp:Button ID="BtnPCRTR" runat="server" 
                   Text="POOL CAMPUS RECRUITMENT TEST RESULT"   CssClass="buttonsimg" Width="364px" 
                   onclick="BtnPCRTR_Click"/>
           
           &nbsp;</td>
           </tr>
            
             
        
       </table>
	 
 
</asp:Content>
