<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student_Academic_Details.aspx.cs" Inherits="Project.Student_Academic_Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table cellpadding="1px" cellspacing="1px" width="100%" >
        <tr>
            
           <td align="right">
                <asp:Button ID="Button1" runat="server" Text="LogOut" onclick="Button1_Click1"/>
            <asp:TextBox ID="Txt_updby" runat="server" ReadOnly="true" CssClass="commonTxtbox" BorderStyle="None" ></asp:TextBox>            
            </td>     
        </tr>
     </table>
    <fieldset><legend >Academic Details</legend>
    <table cellpadding="3px" cellspacing="3px">
     <tr>
            <td colspan="2">
                <asp:Label ID="Lbl_msg" runat="server" Text="Label" CssClass="ReportMsg" 
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
            <asp:Label ID="Lbl_class" runat="server" Text="Class :" CssClass="lablewidth"></asp:Label></td><td>
            <asp:DropDownList ID="DropDown_Academic" runat="server" >
            <asp:ListItem>-----------Select----------</asp:ListItem>
            <asp:ListItem>SSLC</asp:ListItem>
            <asp:ListItem>PUC</asp:ListItem>
            <asp:ListItem>Diploma</asp:ListItem>
            <asp:ListItem>UG</asp:ListItem>
            <asp:ListItem>PG</asp:ListItem>
            
            
            </asp:DropDownList>
        </td>
    </tr>
     <tr>
            <td align ="right" >
                <asp:Label ID="Lbl_Branch" runat="server" Text="Branch :" CssClass="lablewidth"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Txt_Branch" runat="server" CssClass="commonTxtbox"></asp:TextBox>
            </td>
        </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_yr_Psng" runat="server" Text="Year of Passing :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_yr_Psng" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_Pertge" runat="server" Text="Percentage :"  CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_pertge" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td align="right">
            <asp:Label ID="Lbl_clg" runat="server" Text="School/COllege Name :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_clg" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>
    
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_brd" runat="server" Text="Board/University :"  CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_brd" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>

<tr>
<td colspan ="2">
    <asp:Button ID="Button2" runat="server" Text="Add" CssClass="buttonsimg" onclick="Button2_Click" />
    <asp:Button ID="btn_10th" runat="server" Text="10th/SSLC Details" cssclass="buttonsimg " onclick="Button1_Click" />
    <asp:Button ID="btn_diploma" runat="server" Text="Diploma Details" 
        cssclass="buttonsimg " onclick="btn_diploma_Click"  />
    <asp:Button ID="btn_puc" runat="server" Text="PUC Details" 
        cssclass="buttonsimg " onclick="btn_puc_Click"  />
    <asp:Button ID="btn_ug" runat="server" Text="UG Details" cssclass="buttonsimg " 
        onclick="btn_ug_Click"  />
    <asp:Button ID="btn_pg" runat="server" Text="PG Details" cssclass="buttonsimg " 
        onclick="btn_pg_Click"  />
    
</td>
</tr>
</table>
<br />

    <asp:Panel ID="Pnl10th" runat="server">
    
<table>
    <tr>
        <td>    
            <asp:Label ID="Lbl_10school" runat="server" Text="SSLC/10 :"  CssClass="lablewidth"></asp:Label>
        </td>
    </tr>
      <tr>
        <td align="right">
            <asp:Label ID="Lbl_10yer" runat="server" Text="Year of Passing :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_10yer" runat="server" ReadOnly="true" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    
        <td align="right">
            <asp:Label ID="Lbl_10perc" runat="server" Text="Percentage :"  CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txt_10perc" runat="server" CssClass="commonTxtbox" 
                ReadOnly="True"></asp:TextBox>
        </td>
   
        <td align="right">
            <asp:Label ID="lbl_10schl" runat="server" Text="School Name :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txt_10school" runat="server" CssClass="commonTxtbox" 
                ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="lbl_10brd" runat="server" Text="Board/University :"  CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txt_10brd" runat="server" CssClass="commonTxtbox" 
                ReadOnly="True"></asp:TextBox>
        </td>
    </tr>

                
            
       
</table>
</asp:Panel>
   
<asp:Panel ID="pnlpuc" runat="server">
  

<table>
    <tr>
        <td>    
            <asp:Label ID="Lbl_pucor12" runat="server" Text="PUC/10+2"  CssClass="lablewidth"></asp:Label>
        </td>
    </tr>
    <tr>
            <td align="right">
                <asp:Label ID="lbl_12brnch" runat="server" Text="Branch :" CssClass="lablewidth"></asp:Label>
            </td>
            <td align="right">
                <asp:TextBox ID="txt_12brnch" runat="server" CssClass="commonTxtbox" 
                    ReadOnly="True"></asp:TextBox>
            </td>
        
        <td align="right">
            <asp:Label ID="lbl_12yr" runat="server" Text="Year of Passing :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txt_12yr" runat="server" CssClass="commonTxtbox" 
                ReadOnly="True"></asp:TextBox>
        </td>
    
        <td align="right">
            <asp:Label ID="lbl_12per" runat="server" Text="Percentage :"  CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txt_12per" runat="server" CssClass="commonTxtbox" 
                ReadOnly="True"></asp:TextBox>
        </td>
        </tr>
        <tr>
   
        <td align="right">
            <asp:Label ID="lbl_12coll" runat="server" Text="COllege Name :" CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="5">
            <asp:TextBox ID="txt_12coll" runat="server" CssClass="commonTxtbox" 
                ReadOnly="True"></asp:TextBox>
        </td>
    
        <td align="right">
            <asp:Label ID="lbl_12uni" runat="server" Text="Board/University :"  CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txt_12uni" runat="server" CssClass="commonTxtbox" 
                ReadOnly="True"></asp:TextBox>
        </td>
    </tr>

                
            
       
</table>

  </asp:Panel>
    
    <asp:Panel ID="pnldiploma" runat="server">
    

<table>
    <tr>
        <td>    
            <asp:Label ID="Lbl_dp" runat="server" Text="Diploma"  CssClass="lablewidth"></asp:Label>
        </td>
    </tr>
    <tr>
            <td align="right">
                <asp:Label ID="lbl_dpbrnch" runat="server" Text="Branch :" CssClass="lablewidth"></asp:Label>
            </td>
            <td align="right">
                <asp:TextBox ID="txt_dpbrnch" runat="server" CssClass="commonTxtbox" 
                    ReadOnly="True"></asp:TextBox>
            </td>
        
        <td align="right">
            <asp:Label ID="lbl_dpyr" runat="server" Text="Year of Passing :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txt_dpyr" runat="server" CssClass="commonTxtbox" 
                ReadOnly="True"></asp:TextBox>
        </td>
    
        <td align="right">
            <asp:Label ID="lbl_dpper" runat="server" Text="Percentage :"  CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txt_dpper" runat="server" CssClass="commonTxtbox" 
                ReadOnly="True"></asp:TextBox>
        </td>
        </tr>
    <tr>
   
        <td align="right">
            <asp:Label ID="lbl_dpcollege" runat="server" Text="COllege Name :" CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="5">
            <asp:TextBox ID="txt_dpcollege" runat="server" CssClass="commonTxtbox" 
                ReadOnly="True"></asp:TextBox>
        </td>
    
        <td align="right">
            <asp:Label ID="lbl_dpbrd" runat="server" Text="Board/University :"  CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txt_dpbrd" runat="server" CssClass="commonTxtbox" 
                ReadOnly="True"></asp:TextBox>
        </td>
    </tr>

                
            
       
</table>

</asp:Panel>


    <asp:Panel ID="pnlug" runat="server">
   
    <table>
    <tr>
        <td>    
            <asp:Label ID="lbl_gd" runat="server" Text="Under Graduation"  CssClass="lablewidth"></asp:Label>
        </td>
    </tr>
    <tr>
            <td align="right">
                <asp:Label ID="lbl_gdbrch" runat="server" Text="Branch :" CssClass="lablewidth"></asp:Label>
            </td>
            <td align="right">
                <asp:TextBox ID="txt_gdbrch" runat="server" CssClass="commonTxtbox" 
                    ReadOnly="True"></asp:TextBox>
            </td>
        
        <td align="right">
            <asp:Label ID="lbl_gdyr" runat="server" Text="Year of Passing :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txt_gdyr" runat="server" CssClass="commonTxtbox" 
                ReadOnly="True"></asp:TextBox>
        </td>
    
        <td align="right">
            <asp:Label ID="lbl_gdper" runat="server" Text="Percentage :"  CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txt_gdper" runat="server" CssClass="commonTxtbox" 
                ReadOnly="True"></asp:TextBox>
        </td>
        </tr>
    <tr>
   
        <td align="right">
            <asp:Label ID="lbl_gdclg" runat="server" Text="College Name :" CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="5">
            <asp:TextBox ID="txt_gdclg" runat="server" CssClass="commonTxtbox" 
                ReadOnly="True"></asp:TextBox>
        </td>
    
        <td align="right">
            <asp:Label ID="lbl_gdunst" runat="server" Text="Board/University :"  CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txt_gdunst" runat="server" CssClass="commonTxtbox" 
                ReadOnly="True"></asp:TextBox>
        </td>
    </tr>

                
            
       
</table>

 </asp:Panel>
    <asp:Panel ID="pnlpg" runat="server">
    
<table>
    <tr>
        <td>    
            <asp:Label ID="lbl_pg" runat="server" Text="Post Graduation"  CssClass="lablewidth"></asp:Label>
        </td>
    </tr>
    <tr>
            <td align="right">
                <asp:Label ID="lbl_pgbrch" runat="server" Text="Branch :" CssClass="lablewidth"></asp:Label>
            </td>
            <td align="right">
                <asp:TextBox ID="txt_pgbrch" runat="server" CssClass="commonTxtbox" 
                    ReadOnly="True"></asp:TextBox>
            </td>
        
        <td align="right">
            <asp:Label ID="lbl_pgyr" runat="server" Text="Year of Passing :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txt_pgyr" runat="server" CssClass="commonTxtbox" 
                ReadOnly="True"></asp:TextBox>
        </td>
    
        <td align="right">
            <asp:Label ID="lbl_pgpre" runat="server" Text="Percentage :"  CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txt_pgper" runat="server" CssClass="commonTxtbox" 
                ReadOnly="True"></asp:TextBox>
        </td>
   </tr>
    <tr>
        <td align="right">
            <asp:Label ID="lbl_pgclg" runat="server" Text="College Name :" CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="5">
            <asp:TextBox ID="txt_pgclg" runat="server" CssClass="commonTxtbox" 
                ReadOnly="True"></asp:TextBox>
        </td>
    
        <td align="right">
            <asp:Label ID="lbl_pgunst" runat="server" Text="Board/University :"  CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txt_pgunst" runat="server" CssClass="commonTxtbox" 
                ReadOnly="True"></asp:TextBox>
        </td>
    </tr>

                
            
       
</table>

</asp:Panel>
</fieldset>
</asp:Content>
