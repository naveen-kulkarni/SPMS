<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List_Of_Student.aspx.cs" Inherits="Project.List_Of_Student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table cellpadding="1px" cellspacing="1px" width="100%" >
        <tr>
            
            <td align="right">
                <asp:Button ID="Button3" runat="server" Text="LogOut" onclick="Button3_Click"/>
            <asp:TextBox ID="Txt_updby" runat="server" ReadOnly="true" CssClass="commonTxtbox" BorderStyle="None" ></asp:TextBox>            
            </td> 
        </tr>
     </table>

<fieldset><legend>Student Details</legend>
<table cellpadding="3px" cellspacing="3px">
                <tr>
                    <td  align="right">
                        <asp:Label ID="Label1" runat="server" Text="Department :" CssClass="lablewidth"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server"  CssClass="dropdownbox" AutoPostBack="True" > 
                        <asp:ListItem>ALL</asp:ListItem>               
                        </asp:DropDownList>
                    </td>
                    <td  align="right">
                        <asp:Label ID="Label9" runat="server" Text="Students :" CssClass="lablewidth"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList3" runat="server"  CssClass="dropdownbox" 
                            AutoPostBack="True" > </asp:DropDownList>
                    </td>
                    <td align="left">
                        <asp:ImageButton ID="ImageButton5" runat="server" 
                            ImageUrl="/images/buttons/search.gif" AlternateText="Search" 
                            onclick="ImageButton5_Click"/>
                    </td>
                    
                </tr>
              </table></fieldset>
              <center>
                <asp:Label ID="LblMsg" runat="server" Text="Label" Visible="False" CssClass="ReportMsg"></asp:Label>
              <hr />
                  <asp:GridView ID="Grid_Student_Details" runat="server" CellPadding="4" ForeColor="#333333"
                      GridLines="None" AutoGenerateColumns="False" CellSpacing="2">
                      <Columns>
                         <asp:BoundField DataField="USN" HeaderText="USN" />
                         <asp:BoundField DataField="First_Name" HeaderText="First Name" />
                         <asp:BoundField DataField="Middle_Name" HeaderText="Middle Name" />
                         <asp:BoundField DataField="Last_Name" HeaderText="Last Name" />
                         <asp:BoundField DataField="Dept_Name" HeaderText="Department Name" />
                         <asp:BoundField DataField="Gender" HeaderText="Gender" />
                         <asp:BoundField DataField="Phone" HeaderText="Phone" />
                         <asp:BoundField DataField="Email" HeaderText="Email" />
                         <asp:BoundField DataField="Date_Of_Birth" HeaderText="Date of Birth" />
                         <asp:BoundField DataField="Present_Address" HeaderText="Present Address" />
                         <asp:BoundField DataField="Permenant_Address" HeaderText="Permenant Address" />
                      </Columns>
                      <AlternatingRowStyle BackColor="White" />
                      <EditRowStyle BackColor="#2461BF" />
                      <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                      <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                      <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                      <RowStyle BackColor="#EFF3FB" />
                      <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                      <SortedAscendingCellStyle BackColor="#F5F7FB" />
                      <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                      <SortedDescendingCellStyle BackColor="#E9EBEF" />
                      <SortedDescendingHeaderStyle BackColor="#4870BE" />
                  </asp:GridView>
              </center>
              
</asp:Content>
