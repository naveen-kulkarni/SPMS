<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompanyChart.aspx.cs" Inherits="Project.CompanyChart" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    
    
 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table cellpadding="0" cellspacing="0" width="100%">
<tr>
    <td align="right">
                <asp:Button ID="Button5" runat="server" Text="LogOut" onclick="Button5_Click"/>
            <asp:TextBox ID="Txt_updby" runat="server" CssClass="commonTxtbox" 
                    BorderStyle="None" ReadOnly="True" ></asp:TextBox>            
            </td>        
</tr>
</table>
<asp:Panel ID="Panel1" runat="server">
<table>
<tr>
<td >
<asp:Label ID="Label6" runat="server" Text="COMPANY HIRED IN PREVIOUS YEARS " CssClass="lableheader"></asp:Label>
</td>
</tr>
</table>
<table>
    <tr>
    
       <td align="right">
            <asp:Label ID="Label1" runat="server" Text="Company Name :" CssClass="lablewidth"></asp:Label>
       </td>
     <td align="left">
         <asp:TextBox ID="TextBox1" runat="server" CssClass="commonTxtbox"></asp:TextBox>
     </td>
     
    </tr>
    
     <tr>
     
        <td align="right">
         <asp:Label ID="Label2" runat="server" Text="Branch :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
          <asp:TextBox ID="TextBox2" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>
         <tr>
         
        <td align="right">
       <asp:Label ID="Label3" runat="server" Text="Year :" CssClass="lablewidth"></asp:Label>
       </td>
    <td>
    <asp:TextBox ID="TextBox3" runat="server"  CssClass="commonTxtbox"></asp:TextBox>
    </td>
</tr>

 <tr>
 
        <td align="right">
       <asp:Label ID="Label4" runat="server" Text="No Of Students Hired :" 
                CssClass="lablewidth"></asp:Label>
       </td>
    <td>
    <asp:TextBox ID="TextBox4" runat="server"  CssClass="commonTxtbox"></asp:TextBox>
    </td>
</tr>

 <tr>
 
        <td align="right">
       <asp:Label ID="Label5" runat="server" Text="chartid :" CssClass="lablewidth" 
                Visible="False"></asp:Label>
       </td>
    <td>
    <asp:TextBox ID="TextBox5" runat="server"  CssClass="commonTxtbox" Visible="False"></asp:TextBox>
    </td>
</tr>
</table>

<table>
    <tr>
    
        <td align="center">
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Save"  CssClass="buttonsimg" />
    </td>
    <td>
    <asp:Button ID="Button2" runat="server"  onclick="Button2_Click" Text="Previous" CssClass="buttonsimg" />
    </td>
    <td>
    <asp:Button ID="Button3" runat="server"  onclick="Button3_Click" Text="Chart" CssClass="buttonsimg" />
    </td>
    <td>
    
        <asp:Button ID="Button4" runat="server" Text="Next" CssClass="buttonsimg" onclick="Button4_Click" />
    
    </td>
     </tr>
    </table>

        <br />
    <table>
        <tr>
        <td>
           <asp:Label ID="Label7" runat="server" Text="Graphical Representation" CssClass="lableheader"></asp:Label>
         </td>
         
         <td>
         
             <asp:Label ID="Label8" runat="server" Text="Details" CssClass="lableheader"></asp:Label>
         
         </td>
            </tr>
            <tr>
            <td>
                <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource2" 
                    Visible="False">
                    <Series>
                        <asp:Series Name="Series1" XValueMember="xvalues" YValueMembers="yvalues">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SPMSConnectionString %>" 
                    SelectCommand="SELECT * FROM [chart]"></asp:SqlDataSource>
                
                </td>
                
                 <td valign="top">
                    <asp:GridView ID="Grid" runat="server" AutoGenerateColumns="False" 
                         CellPadding="4" ForeColor="#333333" BorderStyle="Groove">
                        <AlternatingRowStyle BackColor="White" />
                    <Columns>
                    <asp:BoundField HeaderText="Company Name" DataField="CompanyName" />
                    <asp:BoundField HeaderText="Branch" DataField="Branch" />
                    <asp:BoundField HeaderText="Year" DataField="xvalues" />
                    <asp:BoundField HeaderText="No Of Student Recruited" DataField="yvalues" />

                    </Columns>
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
                     
                     </td>
                  </tr>
               </table>
      
</asp:Panel>       
</asp:Content>
