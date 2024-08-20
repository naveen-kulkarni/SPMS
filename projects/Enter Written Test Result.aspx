<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Enter Written Test Result.aspx.cs" Inherits="Project.Wrt_Test_Result" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table cellpadding="1px" cellspacing="1px" width="100%" >
        <tr>
            
            <td align="right">
                <asp:Button ID="Button2" runat="server" Text="LogOut" onclick="Button2_Click"/>
            <asp:TextBox ID="Txt_updby" runat="server" CssClass="commonTxtbox" 
                    BorderStyle="None" ontextchanged="Txt_updby_TextChanged" ReadOnly="True" ></asp:TextBox>            
            </td> 
        </tr>
     </table>


<asp:Panel ID="Panel1" runat="server">
<fieldset><legend>Enter USN</legend>
<table  cellpadding="0px" cellspacing="0px">
    <tr>
        <td > 
             <asp:TextBox ID="Text_USN" runat="server" CssClass="commonTxtbox colmwidth"></asp:TextBox>
        </td>    
        <td >
           <asp:ImageButton ID="ImageButton1" runat="server"  
                ImageUrl="/images/buttons/search.gif" AlternateText="Search" 
                onclick="ImageButton1_Click"/>
        </td>
    </tr>
</table>

<fieldset><legend>Entry Written Test Results Manualy</legend>
<table cellpadding="3px" cellspacing="3px">
    <tr>
        <td colspan="5" align="center">
            <asp:Label ID="lblErrMsg" runat="server" CssClass="ReportMsg"></asp:Label>
        </td>
    </tr>
   
     
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_fname" runat="server" Text="First Name :" CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="4">
            <asp:TextBox ID="Txt_fname" runat="server" ReadOnly="true" CssClass="commonTxtbox"></asp:TextBox>&nbsp;
        </td>
    </tr>

    <tr>
        <td align="right">
            <asp:Label ID="Lbl_mname" runat="server" Text="Middle Name :" CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="4">
            <asp:TextBox ID="Txt_mname" runat="server"  ReadOnly="true" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_lname" runat="server" Text="Last Name :" CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="4">
            <asp:TextBox ID="Txt_lname"  ReadOnly="true" runat="server" CssClass="commonTxtbox"></asp:TextBox>&nbsp;
        </td>
    </tr>
   
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_cntc" runat="server" Text="Contact Number :" CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="4">
            <asp:TextBox ID="Txt_cntc"  ReadOnly="true" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_mail" runat="server" Text="E-mail :" CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="4">
            <asp:TextBox ID="Txt_mail"  ReadOnly="true" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_Dept" runat="server" Text="Department :"  CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="4">
            <asp:TextBox ID="Text_Dept" runat="server"  ReadOnly="true" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td  valign="top" align="right">
            <asp:Label ID="Lbl_Company" runat="server" Text="Company Name :"  CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="4">
                        <asp:DropDownList ID="Drp_dwn_Company" CssClass="searchTxtBox" runat="server" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                            AutoPostBack="True">
                        </asp:DropDownList>
        </td>
        
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_Round" runat="server" Text="Round Cleared :"  CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:CheckBox ID="ChecK_apt" runat="server" Text="apptitude" />
        </td>
        <td>
            <asp:CheckBox ID="Check_techRnd1" runat="server" Text="technical_round1" />
        </td>
        <td>
            <asp:CheckBox ID="Check_techRnd2" runat="server" Text="technical_round2" />
        </td>
        <td>
            <asp:CheckBox ID="Check_techRnd3" runat="server" Text="technical_round3" />
        </td>
    </tr>
     <tr>
        <td align="right">
            <asp:Label ID="Lbl_Description" runat="server" Text="Description :" CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="4">
            <asp:TextBox ID="Txt_Desc" runat="server" CssClass="commonTxtbox" ></asp:TextBox>
            
        </td>
    </tr>  
    <tr>
        <td align="center" colspan="5">
            <asp:Button ID="Button1" runat="server" Text="Save" CssClass="buttonsimg" onclick="Button1_Click" />  
            <asp:Button ID="Btn_del" runat="server" CssClass="buttonsimg" Text="Delete" 
                onclick="Btn_del_Click" />
            <asp:Button ID="Btn_clr" runat="server" CssClass="buttonsimg" Text="Clear" />
        </td>
    </tr>

</table>
</fieldset>

</fieldset>
</asp:Panel>



<asp:Panel ID="Panel2" runat="server">
<fieldset><legend>Written Test Result by Attaching Files</legend>
<table>
    <tr>
        <td align="center" colspan="3">
            <asp:Label ID="Lbl_Msg" runat="server" CssClass="ReportMsg" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_companyname" runat="server" Text="Company Name :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DropDown_companyName" CssClass="dropdownbox" 
                runat="server"  onselectedindexchanged="DropDown_companyName_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
    </tr>
    
    <tr>
        <td colspan="2" align="center">
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </td>
        <td>
            <asp:DropDownList ID="DropDownList1" CssClass="dropdownbox" runat="server" 
                AutoPostBack="True" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged1">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="Btn_Upload" runat="server" Text="Upload File" 
                onclick="Btn_Upload_Click" />
            <asp:Button ID="BtnDownload" runat="server" onclick="BtnDownload_Click" 
                Text="Download" />
        </td>
    </tr>
</table>
</fieldset>
</asp:Panel>

</asp:Content>
