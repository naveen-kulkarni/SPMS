<%@ Page Title="" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pool_Campus_Recruitment_Schedular.aspx.cs" Inherits="Final_Report_SMPS.Schedule_Pool_Campus_Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <style type="text/css">
        .style1
        {
            width: 264px;
        }
    </style>

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
    <asp:Label ID="Label1" runat="server" Text="Test Schedule For Pool Campus  " CssClass="lablewidth"></asp:Label>   
    <asp:Label ID="Label2" runat="server" Text="COMPANY SCHEDULAR" 
        Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="Black"></asp:Label>
    <table> 
    
       <tr> <td>
            <asp:Label ID="LblCollName" runat="server" Text="Company Name" CssClass="lablewidth"></asp:Label>  
        </td>
        <td class="style1">
            <asp:DropDownList ID="DDLCompanyName" runat="server" CssClass="dropdownbox">
            </asp:DropDownList>
             
         </td>
            

        
    </tr>
     <tr>
        <td>
            <asp:Label ID="LdlDate" runat="server" Text="Date" CssClass="lablewidth"></asp:Label>  
        </td>
        <td class="style1">
            <asp:TextBox ID="TxtDate" runat="server" CssClass="Textwidth"></asp:TextBox>
           
          <asp:RequiredFieldValidator ID="DateValidator" runat="server" Text="**" 
                ErrorMessage="plz enter a Date" ControlToValidate="TxtDate" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
              </td>
        <td>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/cal.gif" 
                onclick="ImageButton1_Click" Height="16px" ValidationGroup="cal1" />
        </td>
        <td>
            <asp:Calendar ID="Calendar1" runat="server" 
                onselectionchanged="Calendar1_SelectionChanged" Visible="False" 
                BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" 
                DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                ForeColor="#663399" Height="200px" Width="220px" SelectedDate="2012-04-26" 
                ShowGridLines="True">
                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                <OtherMonthDayStyle ForeColor="white" />
                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                <SelectorStyle BackColor="#FFCC66" />
                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
                    ForeColor="#FFFFCC" />
                <TodayDayStyle BackColor="#FFCC66" ForeColor="White"   />
            </asp:Calendar>
        
        
        </td>
    </tr>
     <tr>
        <td>
            <asp:Label ID="LblTestStatus" runat="server" Text="Test Status" CssClass="lablewidth"></asp:Label>  
        </td>
         <td class="style1">
            <asp:TextBox ID="TxtTestStatus" runat="server" CssClass="Textwidth" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="TestStatusValidator" runat="server" Text="**" 
                ErrorMessage="plz enter a Test Status" ControlToValidate="TxtTestStatus" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
          
               </td>
        
    </tr>
     
</table>
    <table>
<tr>
<td>
    <br />
    <asp:Button ID="BtnAdd" runat="server" Text="Add" onclick="BtnAdd_Click" CssClass="buttonsimg"/>
    <asp:Button ID="BtnUpdate" runat="server"  Text="Update" 
        ValidationGroup="ud" onclick="BtnUpdate_Click1"   CssClass="buttonsimg"  />
    <asp:Button ID="BtnDelete" runat="server" onclick="BtnDelete_Click" Text="Delete" 
        ValidationGroup="del" CssClass="buttonsimg"/>
    <asp:Button ID="BtnShowAll" runat="server" onclick="BtnShowAll_Click" 
        Text="ShowAll" ValidationGroup="sa" CssClass="buttonsimg"/>
        <asp:Button ID="BtnBack" runat="server" onclick="BtnBack_Click" Text="Back" 
        ValidationGroup="bk" CssClass="buttonsimg"/>
    <asp:Button ID="BtnHome" runat="server" onclick="BtnHome_Click" Text="Home" 
        ValidationGroup="hm" CssClass="buttonsimg" />
    <br />
    <asp:GridView ID="GrdStudent_Det" runat="server" CssClass="grdvew">
    </asp:GridView>
    
    </td>
</tr>
</table>
<asp:ValidationSummary ID="vsControl" runat="server" ShowMessageBox="true" 
        DisplayMode="BulletList" HeaderText="Plz Correct These Errors" 
        ForeColor="Red" />
  
   </asp:Content>
