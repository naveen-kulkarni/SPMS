<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student_Registration_Form.aspx.cs" Inherits="Project.Student_Registration_Form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table cellpadding="1px" cellspacing="1px" width="100%" >
        <tr>
            
           <td align="right">
                
            <asp:TextBox ID="Txt_updby" runat="server" ReadOnly="true" CssClass="commonTxtbox" BorderStyle="None" ></asp:TextBox>            
            </td>     
        </tr>
     </table>

<fieldset> 
    <legend> Student Information Form</legend>      
<table cellpadding="3px" cellspacing="3px">
    <tr>
        <td colspan="2">
             <asp:Label ID="lblErrMsg" runat="server" Text="msg" CssClass="ReportMsg" Visible="False"></asp:Label>
        </td>
    </tr>
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
            <asp:Label ID="Lbl_USN" runat="server" Text="USN :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_USN" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td align="right">
            <asp:Label ID="Lbl_Pwd" runat="server" Text="Password :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_Pwd" TextMode="Password" runat="server" CssClass="commonTxtbox"></asp:TextBox>
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
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_crsid" runat="server" Text="Course Id :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DropDownList3" runat="server">
            </asp:DropDownList>
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
                GroupName="Check_Addr" Text="No" />
            
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
            <asp:RadioButton ID="Rd_gap_no" runat="server" GroupName="gap" Text="No" />
        </td>
    </tr>

       
    
    
</table>
<asp:Button ID="Button1" runat="server" Text="Save" CssClass="buttonsimg" onclick="Button1_Click"/>


   
</fieldset >
</asp:Content>
