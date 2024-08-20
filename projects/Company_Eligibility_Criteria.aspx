<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Company_Eligibility_Criteria.aspx.cs" Inherits="Project.Company_Eligibility_Criteria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Panel ID="Panel1" runat="server">
<table cellpadding="0" cellspacing="0" width="100%">
<tr>
    <td align="right">
                <asp:Button ID="Button4" runat="server" Text="LogOut" onclick="Button4_Click1"/>
            <asp:TextBox ID="Txt_updby" runat="server" CssClass="commonTxtbox" 
                    BorderStyle="None" ReadOnly="True" ></asp:TextBox>            
            </td>        
</tr>
</table>
<table cellpadding="3px" cellspacing="3px">
    <tr>
        <td align="right">
            <asp:Label ID="Label12" runat="server"  Text="Edit :"></asp:Label></td>
           <td> <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
    </tr>

    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" CssClass="lablewidth" Text="ELIGIBILITY CRITERIA" ></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label2" CssClass="lablewidth" runat="server" Text="Company Name :"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"  Width="202px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label3" CssClass="lablewidth" runat="server"  Text="SSLC,10th:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label4" CssClass="lablewidth" runat="server" Text="PUC,12th:"></asp:Label>
        </td>
        <td>
           <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label5" CssClass="lablewidth" runat="server" Text="Diploma: "></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label6" CssClass="lablewidth" runat="server" Text="Under Graduation: "></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox5" runat="server" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label7" CssClass="lablewidth" runat="server"  Text="Post Graduation:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox6" runat="server" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label8" CssClass="lablewidth" runat="server" Text="Gap In Studies:" ></asp:Label>
        </td>
        <td>
               <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label9" CssClass="lablewidth" runat="server" Text="Number Of Backlogs:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox8" runat="server" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>    
            <asp:Label ID="Label10" CssClass="lablewidth" runat="server" Text="Course Offring:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox9" CssClass="lablewidth" runat="server" ></asp:TextBox>
        </td>
    </tr>
    <tr>
         <td>
            <asp:Label ID="Label11" CssClass="lablewidth" runat="server"  Text="Description:  "></asp:Label>
         </td>
         <td>
             <asp:TextBox ID="TextBox10" runat="server" ></asp:TextBox>
        </td> 
    </tr>
    
    <tr>
         <td>
             <asp:Label ID="Label15" CssClass="lablewidth" runat="server" Text="Is_Active:"  Visible="False"></asp:Label>
         </td>
         <td>
             <asp:TextBox ID="TextBox13" runat="server"  Visible="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
         <td>
            <asp:Label ID="Label17" CssClass="lablewidth" runat="server" CssClass="style27" 
            Text="CompanyCollegeId:  " Visible="False"></asp:Label>
         </td>
         <td>
              <asp:TextBox ID="TextBox14" runat="server"
              Visible="False"></asp:TextBox>
        </td> 
    </tr>
    <tr> 
        <td>
            <asp:Label ID="Label18" CssClass="lablewidth" runat="server"  Text="CutOffType:"  Visible="False"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox15" runat="server" Visible="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="Button1" runat="server"  Text="Save"  onclick="Button1_Click" />
            <asp:Button ID="Button2" runat="server"  Text="Previous"  onclick="Button2_Click" />
            <asp:Button ID="Button3" runat="server"  Text="Next"  onclick="Button3_Click" />
            <asp:Label ID="lblErrMsg" runat="server"  CssClass="lablewidth" Text="Label" Visible="False"></asp:Label>
        </td>
   </tr>   
   </table>
   <hr />
   <asp:Label ID="Label16" CssClass="lablewidth" runat="server"  Text="NEW HORIZON COLLEGE OF ENGINEERING"></asp:Label>
    
</asp:Panel>
</asp:Content>
