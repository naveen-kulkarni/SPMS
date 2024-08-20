<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="company_Recruitment_Process.aspx.cs" Inherits="Project.compnay_Recruitment_Process" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table cellpadding="0" cellspacing="0" width="100%">
<tr>
    <td align="right">
                <asp:Button ID="Button3" runat="server" Text="LogOut" onclick="Button3_Click"/>
            <asp:TextBox ID="Txt_updby" runat="server" CssClass="commonTxtbox" 
                    BorderStyle="None" ReadOnly="True" ></asp:TextBox>            
            </td>        
</tr>
</table>
<asp:Panel ID="Panel1" runat="server" CssClass="style1" Height="492px" 
        Width="938px">
   <table class="style23">
    <tr>
        <td align="right">
        <asp:Label ID="Label18" runat="server" Text="Edit :"></asp:Label>
        </td>
         <td align="right">
           <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="style20" Height="25px" onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="204px">
        </asp:DropDownList>
    </td>
    </tr>
       
       <tr>
        <td>
    <asp:Label ID="Label1" runat="server" Text="RECRUITMENT PROCESS" ToolTip=" " CssClass="style6"></asp:Label>
    </td>
    </tr>
    <tr>
        <td colspan="2">
             <asp:Label ID="lblErrMsg" runat="server" CssClass="ReportMsg" Text="Label" Visible="False"></asp:Label>
        </td>
    </tr>
   
   <tr>
   <td>
    <asp:Label ID="Label2" runat="server" Text="Tests:" CssClass="style7"></asp:Label>
    </td>
    </tr>
        
        <tr>
        <td>
            <asp:Label ID="Label17" runat="server" CssClass="style18" Text="Company Name :"></asp:Label>
            </td>
            <td>
                
                <asp:DropDownList ID="DropDownList2" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        
        <tr>
            <td>
        <asp:Label ID="Label3" runat="server" CssClass="style8" Text=" Apptitude/Technical test: "></asp:Label>
        </td>
        <td>
            <asp:CheckBox ID="CheckBox1" runat="server" />
            </td>
        </tr>

        <tr>
        <td>
        <asp:Label ID="Label4" runat="server" CssClass="style9" Text=" Group Discussion:"></asp:Label>
        </td>
        <td>
            <asp:CheckBox ID="CheckBox2" runat="server" />
        </td>
        </tr>
        
        <tr>
        <td>
        <asp:Label ID="Label5" runat="server" CssClass="style10" Text="Technical Round 1:"></asp:Label>
        </td>
        <td>
           <asp:CheckBox ID="CheckBox3" runat="server" />
           </td>
           </tr>
      <tr>
        <td>
            <asp:Label ID="Label6" runat="server" CssClass="style11" Text="Technical Round 2:"></asp:Label>
        </td>
            <td>
                <asp:CheckBox ID="CheckBox4" runat="server" />
                </td>
                </tr>
       <tr>
       <td>
        <asp:Label ID="Label7" runat="server" CssClass="style12" Text="Technical Round 3:"></asp:Label>
         </td>
         <td>
        <asp:CheckBox ID="CheckBox5" runat="server" />
        </td>
        </tr>
        <tr>
        <td>
        <asp:Label ID="Label8" runat="server" CssClass="style13" Text="Telephone Interview 1:  "></asp:Label>
        </td>
        <td>
        <asp:CheckBox ID="CheckBox6" runat="server" />
        </td>
        </tr>
        
        <tr>
        <td>
        <asp:Label ID="Label9" runat="server" CssClass="style14" Text="Telephone Interview 2: "></asp:Label>
        </td>
        <td>
           <asp:CheckBox ID="CheckBox7" runat="server" />
           </td>
           </tr>

        <tr>
            <td>
        <asp:Label ID="Label10" runat="server" CssClass="style15" Text="HR Round 1:"></asp:Label>
        </td>
        <td>
        <asp:CheckBox ID="CheckBox8" runat="server" />
        </td>
        </tr>
       <tr>
       <td>
        <asp:Label ID="Label11" runat="server" CssClass="style16" Text="HR Round 2:"></asp:Label>
        </td>
        <td>
           <asp:CheckBox ID="CheckBox9" runat="server" />
           </td>
        </tr>
        
        
        <tr>
            <td>
        <asp:Button ID="Button1" runat="server" CssClass="style2" onclick="Button1_Click" Text="Save" Width="105px" />
        <asp:Button ID="Button2" runat="server" CssClass="style3" onclick="Button2_Click" Text="Previous" Width="105px" />
       
        </td>
        </tr>
        </table>

        <br />
        <hr class="style17" />

        <br />

        <asp:Label ID="Label16" runat="server" CssClass="style7" Text="NEW HORIZON COLLEGE OF ENGINEERING"></asp:Label>
        <br />
        <br />
            <table>
            <tr><td>
            <marquee class="style8">   Department Of Computer Application   </marquee>
                <br />
            </td>
            </tr>
            </table>
    </asp:Panel>

</asp:Content>
