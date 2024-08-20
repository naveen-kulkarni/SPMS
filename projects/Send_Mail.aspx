<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Send_Mail.aspx.cs" Inherits="Project.Send_Mail" %>
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
    <fieldset><legend>Company Selection</legend>
            <table cellpadding="3px" cellspacing="3px" width="100%">
            <tr>
             <td align="right">
                        <asp:Label ID="Label1" runat="server" Text="Company Name :" CssClass="lablewidth"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="dropdownbox" 
                            onselectedindexchanged="DropDownList3_SelectedIndexChanged" 
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    
                     <td align="right">
                        <asp:Label ID="Label12" runat="server" Text="Department :" CssClass="lablewidth"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="dropdownbox" 
                            onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            ImageUrl="/images/buttons/search.gif" AlternateText="Search" 
                            onclick="ImageButton1_Click"/>
                    </td>
                </tr>
             </table>
             </fieldset>
<fieldset><legend>Percentages</legend>
<table cellpadding="3px" cellspacing="3px" width="100%">
    <tr>
        <td align="right">
                        <asp:Label ID="Label14" runat="server" Text="SSLC :" CssClass="lablewidth" ></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True" CssClass="Textwidth"></asp:TextBox>
                    </td>
                    <td  align="right">
                        <asp:Label ID="Label15" runat="server" Text="PUC :" CssClass="lablewidth" ></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True" CssClass="Textwidth"></asp:TextBox>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label2" runat="server" Text="Diploma :" CssClass="lablewidth" ></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True" CssClass="Textwidth"></asp:TextBox>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label16" runat="server" Text="Under Graduation :" CssClass="lablewidth"></asp:Label>
                    </td>
                    <td>
                         <asp:TextBox ID="TextBox4" runat="server" ReadOnly="True" CssClass="Textwidth"></asp:TextBox>
                   </td>
             </tr>
       <tr>
            <td align="right">
                        <asp:Label ID="Label17" runat="server" Text="Post Graduation :" CssClass="lablewidth" ></asp:Label>
                    </td>

                    <td>
                         <asp:TextBox ID="TextBox5" runat="server" ReadOnly="True" CssClass="Textwidth"></asp:TextBox>
                    </td>
                    
                    
                    
                    <td align="right">
                        <asp:Label ID="Label3" runat="server" Text="Gap in Studies :" CssClass="lablewidth" ></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox7" runat="server" ReadOnly="True" CssClass="Textwidth"></asp:TextBox>
                   
                    </td>
               </tr>
           </table>
            </fieldset>
            
<fieldset><legend>Send Mail To Students based on Company Criteria</legend>
    <table cellpadding="3px" cellspacing="3px">
    <tr>
                <td colspan="2" align="center">
                    <br />
                     <asp:Label ID="lblStatus" runat="server" Text="Mail Sent Succcessfully" Visible="false"  style="color:Black;"></asp:Label>
                </td>
            </tr>
             <tr>
                <td colspan="2" align="right">
                    <br />
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
                    

</asp:Content>
