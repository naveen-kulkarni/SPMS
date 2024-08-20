<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Nxt_Round_Intimation.aspx.cs" Inherits="Project.Nxt_Round_Intimation" %>
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

<fieldset><legend>Next Round Intimation</legend>
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
<fieldset><legend>Entry For Next Round ie., Technical Round</legend>
<table cellpadding="1px" cellspacing="1px">
    <tr>
        <td colspan="3" align="center">
            <asp:Label ID="lblErrMsg" runat="server" CssClass="ReportMsg"></asp:Label>
        </td>
    </tr>
     <tr>
        <td align="right">
                     <asp:Label ID="Lbl_fname" runat="server" CssClass="lablewidth" 
                         Text="First Name :"></asp:Label>
                 </td>
                 <td colspan="4">
                     <asp:TextBox ID="Txt_fname" runat="server" CssClass="commonTxtbox" 
                         ReadOnly="true"></asp:TextBox>
                     &nbsp;
                 </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_mname" runat="server" CssClass="lablewidth" 
                Text="Middle Name :"></asp:Label>
        </td>
        <td colspan="4">
            <asp:TextBox ID="Txt_mname" runat="server" CssClass="commonTxtbox" 
                ReadOnly="true"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_lname" runat="server" CssClass="lablewidth" 
                Text="Last Name :"></asp:Label>
        </td>
        <td colspan="4">
            <asp:TextBox ID="Txt_lname" runat="server" CssClass="commonTxtbox" 
                ReadOnly="true"></asp:TextBox>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_cntc" runat="server" CssClass="lablewidth" 
                Text="Contact Number :"></asp:Label>
        </td>
        <td colspan="4">
            <asp:TextBox ID="Txt_cntc" runat="server" CssClass="commonTxtbox" 
                ReadOnly="true"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_mail" runat="server" CssClass="lablewidth" Text="E-mail :"></asp:Label>
        </td>
        <td colspan="4">
            <asp:TextBox ID="Txt_mail" runat="server" CssClass="commonTxtbox" 
                ReadOnly="true"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_Dept" runat="server" CssClass="lablewidth" 
                Text="Department :"></asp:Label>
        </td>
        <td colspan="4">
            <asp:TextBox ID="Text_Dept" runat="server" CssClass="commonTxtbox" 
                ReadOnly="true"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Label1" runat="server" CssClass="lablewidth" Text="Test Date : "></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextDate" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
        <td>
            <asp:ImageButton ID="calbutton" runat="server" 
                ImageUrl="/images/buttons/cal.gif" OnClick="calbutton_Click" />
        </td>
        <td rowspan="6">
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
        <td align="right">
            <asp:Label ID="Lbl_Tst_Status" runat="server" Text="Test Type :" CssClass="lablewidth"></asp:Label>
        </td>

        <td colspan="2">
            <asp:TextBox ID="Txt_Status" runat="server" CssClass="commonTxtbox"></asp:TextBox>&nbsp;
        </td>
    </tr>
    <tr>
                  <td align="right" valign="top">
                     <asp:Label ID="Label4" runat="server" Text="Company Name : " CssClass="lablewidth"></asp:Label>
                  </td>
                  <td colspan="4" valign="top">
                      <asp:DropDownList ID="Drp_dwn_Company" runat="server" CssClass="dropdownbox" 
                          onselectedindexchanged="Drp_dwn_Company_SelectedIndexChanged">
                      </asp:DropDownList>
                  </td>
              </tr>
    
    
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_Description" runat="server" Text="Description :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_Desc" runat="server" CssClass="commonTxtbox" ></asp:TextBox>
            
        </td>
    </tr>  
    <tr>
        <td align="right" colspan="2">
            <asp:Button ID="Button1" runat="server" CssClass="buttonsimg" Text="Save" onclick="Button1_Click" /> 
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
<fieldset><legend>GD Round Result by Attaching Files</legend>
<table>
    <tr>
        <td align="center" colspan="3">
            <asp:Label ID="Lbl_Msg" runat="server" CssClass="ReportMsg" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Lbl_companyname" runat="server" Text="Company Name"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DropDown_companyName" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    
    <tr>
        <td colspan="2" align="center">
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
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
</fieldset>
</asp:Content>
