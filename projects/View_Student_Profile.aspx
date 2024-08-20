<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View_Student_Profile.aspx.cs" Inherits="Project.View_Student_Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table cellpadding="1px" cellspacing="1px" width="100%" >
        <tr>
            
           <td align="right">
                <asp:Button ID="Button1" runat="server" Text="LogOut" onclick="Button1_Click"/>
            <asp:TextBox ID="Txt_updby" runat="server" ReadOnly="true" CssClass="commonTxtbox" BorderStyle="None" ></asp:TextBox>            
            </td>     
        </tr>
     </table>

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
            <asp:Label ID="Lbl_Srch" runat="server" Text="Search :"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_Srch" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:ImageButton ID="ImageButton2" runat="server" 
            ImageUrl="/images/buttons/search.gif" AlternateText="Search" 
                onclick="ImageButton2_Click"/>
        </td>
   </tr>
</table>
</fieldset>
<fieldset> 
    <legend> Student Information Form</legend>      
<table cellpadding="3px" cellspacing="3px">
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_User" runat="server" Text="Login Type :" CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="3">
            <asp:DropDownList ID="DropDown_Login_Id" runat="server">
            
            <asp:ListItem>Student</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr> 
    <tr>
        <td align="right">
            <asp:Label ID="Label1" runat="server" Text="User Name :" CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="3">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>
    
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_fname" runat="server" Text="First Name :" CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="3">
            <asp:TextBox ID="Txt_fname" runat="server" CssClass="commonTxtbox"></asp:TextBox>&nbsp;
        </td>
    </tr>

    <tr>
        <td align="right">
            <asp:Label ID="Lbl_mname" runat="server" Text="Middle Name :" CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="3">
            <asp:TextBox ID="Txt_mname" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_lname" runat="server" Text="Last Name :" CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="3">
            <asp:TextBox ID="Txt_lname" runat="server" CssClass="commonTxtbox"></asp:TextBox>&nbsp;
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_Gndr" runat="server" Text="Gender :" CssClass="lablewidth"></asp:Label></td>
           <td colspan="3"> 
               <asp:TextBox ID="Txt_Gender" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_cntc" runat="server" Text="Contact Number :" CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="3">
            <asp:TextBox ID="Txt_cntc" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_mail" runat="server" Text="E-mail :" CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="3">
            <asp:TextBox ID="Txt_mail" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_dept" runat="server" Text="Department ID :" CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="3">
            <asp:TextBox ID="Txt_dept" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_clgid" runat="server" Text="College ID :" CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="3">
            <asp:TextBox ID="Txt_clgid" runat="server" CssClass="commonTxtbox"></asp:TextBox>&nbsp;
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_crsid" runat="server" Text="Course Id :" CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="3">
            <asp:TextBox ID="Txt_crsid" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
     </tr>
     <tr>
        <td align="right">
            <asp:Label ID="Lbl_dob" runat="server" Text="Date of Birth :" CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="3">
            <asp:TextBox ID="Txt_dob" runat="server" CssClass="commonTxtbox"></asp:TextBox>&nbsp;
        </td>
     </tr>
     <tr>
        <td align="right">
            <asp:Label ID="Lbl_paddress" runat="server" Text="Present Address :" CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="3">
            <asp:TextBox ID="Txt_paddress" runat="server" TextMode="MultiLine" CssClass="tablewidth"></asp:TextBox>
        </td>
     </tr>
     <tr>
        <td align="right">
            <asp:Label ID="Lbr_pmt_address" runat="server" Text="Permenant Address :" CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="3">
            <asp:TextBox ID="Txt_pmt_address" runat="server" TextMode="MultiLine" CssClass="tablewidth"></asp:TextBox>&nbsp;
        </td>
     </tr>

    <tr>
        <td align="right">
            <asp:Label ID="Lbl_gap_study" runat="server" Text="Is your gap in study :" CssClass="lablewidth"></asp:Label></td>
           <td colspan="3"> 
               <asp:TextBox ID="Txt_gap_Study" runat="server"></asp:TextBox>
        </td>
        <td >
            <asp:Button ID="Btn_View_gap" runat="server" cssclass="buttonsimg" Text="View" 
                onclick="Btn_View_gap_Click" />
        </td>
        <td valign="top" rowspan="1">
            <asp:GridView ID="Grid_gap" runat="server" AutoGenerateColumns="False">
            <Columns>
            <asp:BoundField DataField="Year" HeaderText="Total Year Gap" />
            <asp:BoundField DataField="Class" HeaderText="Class" />
            <asp:BoundField DataField="Description" HeaderText="Reason" />

            </Columns>
            </asp:GridView>
        </td>
    </tr>

    

    
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_sameas" runat="server" Text="Same_As_Cur_Add :" CssClass="lablewidth"></asp:Label>
        </td>
        <td colspan="3">
            <asp:TextBox ID="Txt_sameas" runat="server" CssClass="commonTxtbox" ></asp:TextBox>
            
        </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="lbl_10th" runat="server" Text="10th/SSLC Details"></asp:Label>
        </td>
        <td>
            <asp:Button ID="Btn_Academic" runat="server"  cssclass="buttonsimg" Text="View" 
                onclick="Btn_Academic_Click" />
        </td>
        <td rowspan="1" >
            <asp:GridView ID="grid_Acd" runat="server">
                        </asp:GridView>
        </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="lbl_diploma" runat="server" Text="Diploma Details"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btn_diploma" runat="server" cssclass="buttonsimg" Text="View" 
                    onclick="btn_diploma_Click" />
            </td>
            <td>
                <asp:GridView ID="Grd_diploma" runat="server">
                </asp:GridView>
            </td>
            </tr>
            
            
            <tr>
            <td>
                <asp:Label ID="lbl_PUC" runat="server" Text="PUC Details"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btn_puc" runat="server"  cssclass="buttonsimg" Text="View" 
                    onclick="btn_puc_Click" />
            </td>
            <td>
                <asp:GridView ID="Grd_puc" runat="server">

                </asp:GridView>
            </td>
            </tr>



            
        <tr>
        <td>
            <asp:Label ID="lbl_ug" runat="server" Text="UG Details"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btn_ug" runat="server" cssclass="buttonsimg" Text="View" 
                    onclick="btn_ug_Click" />
            </td>
            <td>
                <asp:GridView ID="Grd_ug" runat="server">
                </asp:GridView>
            </td>
            </tr>
            
            <tr>
            <td>
                <asp:Label ID="lbl_pg" runat="server" Text="PG Details"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btn_pg" runat="server" cssclass="buttonsimg" Text="View" 
                    onclick="btn_pg_Click" />
            </td>
            <td>
                <asp:GridView ID="Grd_pg" runat="server">

                </asp:GridView>
            </td>
            </tr>

            <tr>
            <td>
                <asp:Label ID="lbl_Atdnc" runat="server" Text="Attendance"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btnAtdcView" runat="server" cssclass="buttonsimg " Text="View" 
                    onclick="btnAtdcView_Click" /></td>
            <td>
                <asp:GridView ID="grd_Atdc" runat="server">

                </asp:GridView>
            </td>
            </tr>
            
    
   
    
</table>

    <asp:Label ID="Label3" runat="server" Text="Label" CssClass="ReportMsg" 
        Visible="False"></asp:Label>
</fieldset >
</asp:Content>
