<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentEdit.aspx.cs" Inherits="Project.StudentEdit" %>
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
<asp:Panel ID="Panel_Search" runat="server">
<fieldset><legend> Search Student Information   </legend>
<table>
    <tr>
        <td colspan="2">
            <asp:Label ID="lblErrMsg" runat="server" Text="Label" CssClass="ReportMsg" 
                Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
         <td align ="right" >
            <asp:Label ID="Label2" runat="server" Text="Search :"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:ImageButton ID="ImageButton2" runat="server" 
            ImageUrl="/images/buttons/search.gif" AlternateText="Search" 
                onclick="ImageButton2_Click"/>
        </td>
   </tr>
</table>
</fieldset>
</asp:Panel>
<asp:Panel ID="PNL_EDIT_AND_SEARCH" runat="server">

<fieldset> 
    <legend> Student Information Form</legend>      
<table cellpadding="3px" cellspacing="3px">
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_User" runat="server" Text="Login Type :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DropDown_Login_Id" runat="server">
            
            <asp:ListItem>Student</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr> 
    
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_fname" runat="server" Text="First Name :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_fname" runat="server" CssClass="commonTxtbox"></asp:TextBox>&nbsp;
        </td>
    </tr>

    <tr>
        <td align="right">
            <asp:Label ID="Lbl_mname" runat="server" Text="Middle Name :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_mname" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_lname" runat="server" Text="Last Name :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_lname" runat="server" CssClass="commonTxtbox"></asp:TextBox>&nbsp;
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_Gndr" runat="server" Text="Gender :" CssClass="lablewidth"></asp:Label></td>
           <td> <asp:RadioButton ID="Rd_male" runat="server" GroupName="Gender" Text="Male" />
            <asp:RadioButton ID="Rd_female" runat="server" GroupName="Gender" Text="Female" />
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_cntc" runat="server" Text="Contact Number :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_cntc" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_mail" runat="server" Text="E-mail :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_mail" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_dept" runat="server" Text="Department :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_clgid" runat="server" Text="College :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_crsid" runat="server" Text="Course Id :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_crsid" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
     </tr>
     <tr>
        <td align="right">
            <asp:Label ID="Lbl_dob" runat="server" Text="Date of Birth :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_dob" runat="server" CssClass="commonTxtbox"></asp:TextBox>&nbsp;
        </td>
     </tr>
     <tr>
        <td align="right">
            <asp:Label ID="Lbl_paddress" runat="server" Text="Present Address :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_paddress" runat="server" TextMode="MultiLine" CssClass="tablewidth"></asp:TextBox>
        </td>
     </tr>
     <tr>
        <td align="right">
            <asp:Label ID="Lbl_sameas" runat="server" Text="Same_As_Cur_Add :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:RadioButton ID="Rd_yes_prsnt" runat="server" AutoPostBack="True" 
                GroupName="Check_Addr" oncheckedchanged="Rd_yes_prsnt_CheckedChanged" 
                Text="Yes" />
            <asp:RadioButton ID="Rd_no_prmnt" runat="server" AutoPostBack="True" 
                GroupName="Check_Addr" Text="No" 
                oncheckedchanged="Rd_no_prmnt_CheckedChanged" />
            
        </td>
    </tr>
     <tr>
        <td align="right">
            <asp:Label ID="Lbr_pmt_address" runat="server" Text="Permenant Address :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_pmt_address" runat="server" TextMode="MultiLine" CssClass="tablewidth"></asp:TextBox>&nbsp;
        </td>
     </tr>

    <tr>
        <td align="right">
            <asp:Label ID="Lbl_gap_study" runat="server" Text="Is your gap in study :" CssClass="lablewidth"></asp:Label></td>
           <td> <asp:RadioButton ID="Rd_gap_yes" runat="server" GroupName="gap" Text="Yes" 
                   oncheckedchanged="Rd_gap_yes_CheckedChanged" />
            <asp:RadioButton ID="Rd_gap_no" runat="server" GroupName="gap" Text="No" 
                   oncheckedchanged="Rd_gap_no_CheckedChanged" />
        </td>
    </tr>

   
</table>
<asp:Button ID="Btn_Update" runat="server" Text="Update" CssClass="buttonsimg" onclick="Button1_Click"/>


    <asp:Label ID="Label3" runat="server" Text="Label" CssClass="ReportMsg" 
        Visible="False"></asp:Label>
</fieldset >
    </asp:Panel>


</asp:Content>
