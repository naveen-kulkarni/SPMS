<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ent_Fnl_Seltd_Std.aspx.cs" Inherits="Project.Ent_Fnl_Seltd_Std" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table cellpadding="1px" cellspacing="1px" width="100%" >
        <tr>
            
            <td align="right">
                <asp:Button ID="Button2" runat="server" Text="LogOut" onclick="Button2_Click1"/>
            <asp:TextBox ID="Txt_updby" runat="server" CssClass="commonTxtbox" 
                    BorderStyle="None" ReadOnly="True" ></asp:TextBox>            
            </td> 
        </tr>
     </table>

<fieldset><legend>Enter Final Selected Students</legend>
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

<fieldset><legend>Entry Final Selected Student</legend>
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
        <td colspan="4" valign="top">
                      <asp:DropDownList ID="Drp_dwn_Company" runat="server" CssClass="dropdownbox" 
                          onselectedindexchanged="Drp_dwn_Company_SelectedIndexChanged">
                      </asp:DropDownList>
                  </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_Round" runat="server" Text="Round Cleared :"  CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:CheckBox ID="Check_hr1" runat="server" Text="hr_round1" />

        </td>
        <td>
            <asp:CheckBox ID="Check_hr2" runat="server" Text="hr_round2" />
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
        <td align="right" colspan="5">
            <asp:Button ID="Button1" runat="server" CssClass="buttonsimg" Text="Save" onclick="Button1_Click" />  
            <asp:Button ID="Btn_del" runat="server" CssClass="buttonsimg" Text="Delete" />
            <asp:Button ID="Btn_clr" runat="server" CssClass="buttonsimg" Text="Clear" />
        </td>
    </tr>
    
</table>
</fieldset>

</fieldset>
</asp:Panel>
 

<fieldset><legend>Enter For Final Selected Student</legend>
<asp:Panel ID="Panel2" runat="server">

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
            <asp:DropDownList ID="DropDownList1" runat="server" 
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

</asp:Panel>

<asp:Panel ID="Panel3" runat="server" Visible="True">
<fieldset><legend>Send Mail To Students based on Company Criteria</legend>   

    <table cellpadding="3px" cellspacing="3px">
    <tr>
                <td colspan="2" align="center">
                    
                     <asp:Label ID="lblStatus" runat="server" Text="Mail Sent Succcessfully" Visible="false"  style="color:Black;"></asp:Label>
                </td>
            </tr>
             <tr>
                <td colspan="2" align="right">
                    
                    <asp:Button ID="btnSendMail" runat="server" CssClass="buttonsimg" Text="Send" Width="100px" 
                        Height="30" onclick="btnSendMail_Click"/>
                </td>
            </tr>
        <tr>
            <td align="right" valign="top">
                <asp:Label ID="Label4" runat="server" Text="To :" CssClass="lablewidth"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtToMail" TextMode="MultiLine" runat="server" CssClass="commonTxtbox" Width="750px" Height="80px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label6" runat="server" Text="Subject :" CssClass="lablewidth"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSubject" runat="server" Width="400" CssClass="commonTxtbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
                <td align="right" valign="top">
                    <asp:Label ID="Label7" runat="server" Text="Mail Content :" CssClass="lablewidth"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMailContent" runat="server" TextMode="MultiLine" Width="750px" Height="300px" CssClass="Textwidth"></asp:TextBox>
                </td>
            </tr>                       
    </table>
   </fieldset>                  
 </asp:Panel>
             

 </fieldset>
 </fieldset>
</asp:Content>
