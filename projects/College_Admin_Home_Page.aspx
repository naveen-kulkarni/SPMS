<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="College_Admin_Home_Page.aspx.cs" Inherits="Project.For_Student_Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table cellpadding="0" cellspacing="0" width="100%">
<tr>
    <td align="right">
                <asp:Button ID="Button1" runat="server" Text="LogOut" onclick="Button1_Click1"/>
            <asp:TextBox ID="Txt_updby" runat="server" CssClass="commonTxtbox" 
                    BorderStyle="None" ReadOnly="True" ></asp:TextBox>            
            </td>        
</tr>
</table>

<div class="clear hideSkiplink">
        <asp:Menu ID="NavigationMenu" CssClass="submenutype" runat="server" EnableViewState="false" IncludeStyleBlock="false" Orientation="Horizontal" >
            <Items>
                <asp:MenuItem Text="Master Data">
                <asp:MenuItem NavigateUrl="~/AddDepartment.aspx" Text="Add Department"/>
                <asp:MenuItem NavigateUrl="~/HolidayConfigure.aspx" Text="Add Holiday"/>
                    <asp:MenuItem NavigateUrl="~/AddCourse.aspx" Text="Add Course"/>
                    <asp:MenuItem NavigateUrl="~/Subject.aspx" Text="Add Subject"/>


                </asp:MenuItem>
                <asp:MenuItem Text="Student Profile">               
                <asp:MenuItem NavigateUrl="~/Student_Registration_Form.aspx" Text="Add Student"/>
                </asp:MenuItem>

                <asp:MenuItem Text="Company Profile">
                <asp:MenuItem NavigateUrl="~/companyprofile.aspx" Text="Company Details"/>
                <asp:MenuItem NavigateUrl="~/Company_Eligibility_Criteria.aspx" Text="Selection Criteria"/>
                <asp:MenuItem NavigateUrl="~/company_Recruitment_Process.aspx" Text="Recruitment Plan Details"/>
                <asp:MenuItem NavigateUrl="~/CompanyChart.aspx" Text="History"/>                
                </asp:MenuItem>               

                <asp:MenuItem Text="Placement Department">
                <asp:MenuItem NavigateUrl="~/Test_Schedule.aspx" Text="Shedule Written Test"/>
                <asp:MenuItem NavigateUrl="~/Enter Written Test Result.aspx" Text="Entry For Written Test"/>
                <asp:MenuItem NavigateUrl="~/Nxt_Round_Intimation.aspx" Text="Next Round Intimation"/>
                <asp:MenuItem NavigateUrl="~/Scd_gd_round.aspx" Text="Schedule GD Round"/>
                <asp:MenuItem NavigateUrl="~/Ent_gd_rnd_Result.aspx" Text="Enter GD Round Result"/>
                <asp:MenuItem NavigateUrl="~/Schd_Fnl_HR_rnd.aspx" Text="Schedule Final HR Round"/>
                <asp:MenuItem NavigateUrl="~/Ent_Fnl_Seltd_Std.aspx" Text="Enter Final Selected Students"/>
                </asp:MenuItem>


                 
                <asp:MenuItem Text="Pool Campus"> 
                <asp:MenuItem NavigateUrl="~/Pool_Campus_College_Master.aspx" Text="Pool Campus College Master"/>               
                
                <asp:MenuItem NavigateUrl="~/Pool_Campus_Company_Config.aspx" Text="Pool Campus College Configuration"/>               
                <asp:MenuItem NavigateUrl="~/Pool_Campus_Company_Placement_Criteria.aspx" Text="Pool Campus Company Placement Criteria"/>               
                <asp:MenuItem NavigateUrl="~/Pool_Campus_Eligible_Student.aspx" Text="Pool Campus Eligible Student"/>               
                <asp:MenuItem NavigateUrl="~/Pool_Campus_Recruitment_Plan_Master.aspx" Text="Pool Campus Recruitment Plan Master"/>
                <asp:MenuItem NavigateUrl="~/Pool_Campus_Recruitment_Schedular.aspx" Text="Pool Campus Recruitment Schedular"/>
                <asp:MenuItem NavigateUrl="~/Pool_Campus_Recruitment_Test_Result.aspx" Text="Pool Campus Recruitment Test Result"/>               
                </asp:MenuItem>
                
            </Items>
        </asp:Menu>
 </div>
    <table cellpadding="3px" cellspacing="3px" width="100%">
    <tr>
        <td>
            <asp:Button ID="Btn_Add" runat="server" Text="Add Student"  CssClass ="buttonsimg" onclick="Button1_Click"  />
        
            <asp:Button ID="Btn_Delete" runat="server" Text="Delete Student"   CssClass ="buttonsimg" 
            onclick="Btn_Delete_Click"/>
       
            <asp:Button ID="Btn_Search" runat="server" Text="Search Student"   CssClass ="buttonsimg" 
            onclick="Btn_Search_Click" />
        
            <asp:Button ID="Btn_View" runat="server" Text="View All Student"   CssClass ="buttonsimg" 
             onclick="Btn_View_Click"  />
            
        </td>
    </tr>
</table>
<asp:Panel ID="Panel_delete" runat="server" Visible="False">
<fieldset ><legend >Delete Record </legend>
<table>
    <tr>
        <td align ="right" >
            <asp:Label ID="Lbl_USN" runat="server" Text="USN :"></asp:Label>
        </td>
        <td align ="right ">
            <asp:TextBox ID="Txt_USN" runat="server" CssClass ="commonTxtbox "></asp:TextBox>
        </td>
    </tr>
    <tr>
        
        <td align ="center"  colspan="2">
            <asp:Button ID="Btn_Del" runat="server" Text="Delete" cssclass="buttonsimg " onclick="Btn_Del_Click" />
            <asp:Button ID="Btn_Cancel" runat="server"  cssclass="buttonsimg" Text="Cancel" />
        </td>
    </tr>
</table>
</fieldset>
</asp:Panel>
<asp:Panel ID="Panel_Search" runat="server" Visible="False">
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
            <asp:DropDownList ID="DropDownList1" runat="server" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
        <td>
            <asp:ImageButton ID="ImageButton2" runat="server" 
            ImageUrl="/images/buttons/search.gif" AlternateText="Search" 
                onclick="ImageButton2_Click"/>
        </td>
        
        <td>
        Not Varified Student
            <asp:GridView ID="grd_varify" runat="server">
            </asp:GridView>
        </td>
   </tr>
</table>
</fieldset>
</asp:Panel>


<asp:Panel ID="PNL_EDIT_AND_SEARCH" runat="server" Visible="False">

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
        <td rowspan="3" colspan="8">
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
            
    
   
    
</table>
<asp:Button ID="Btn_not_Verify" runat="server" Text="VERIFIED" 
        CssClass ="buttonsimg" onclick="Btn_not_Verify_Click" />

    <asp:Label ID="Label3" runat="server" Text="Label" CssClass="ReportMsg" 
        Visible="False"></asp:Label>
</fieldset >
    </asp:Panel>
<asp:Panel ID="Panel_view" runat="server" Visible="False">
<fieldset><legend > All Records</legend> 
    <asp:GridView ID="Grid_All_Student" runat="server">
    </asp:GridView>
</fieldset>
</asp:Panel>
</asp:Content>
