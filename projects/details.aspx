<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="details.aspx.cs" Inherits="Project.details" %>
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

<table width="95%">
    <tr>
        <td align="right">
<a href="Company_FeedBack.aspx"><asp:Label ID="Label31" runat="server" Text="Feed Back" CssClass="lablewidth"></asp:Label></a>
        </td>
    </tr>
</table>

<table>
<tr>
<td align="right" valign="middle">
        <asp:Label ID="Label34" runat="server" Text="Company Name :" CssClass="lableheader"></asp:Label>
        </td>
        <td>
         <asp:TextBox ID="TextBox21" runat="server" CssClass="commonTxtbox"></asp:TextBox>
         </td>
         <td>
         <asp:Button ID="Button3" runat="server" Text="Search" onclick="Button3_Click" />


</td></tr></table>

<br /><br />
<table border="0">
    <tr>
        <td>
            <h3>
            <asp:Label ID="Label1" runat="server" Text="COMPANY PROFILE" CssClass="lableheader"></asp:Label>
            </h3>
        </td>
    </tr>
</table>
<br />


<table>
<tr>
    
   <td align="right">
        <asp:Label ID="Label2" runat="server" Text="Company Name :" CssClass="lablewidth"></asp:Label>
    </td>
    <td>
         <asp:TextBox ID="TextBox1" runat="server" CssClass="commonTxtbox"></asp:TextBox>  
    
</tr>

<tr>
    <td align="right">
       <asp:Label ID="Label3" runat="server" Text="Managing_Director :" CssClass="lablewidth"></asp:Label>
    </td>
    <td>
       <asp:TextBox ID="TextBox2" runat="server" CssClass="commonTxtbox"></asp:TextBox>
    </td>
</tr>
    
<tr>
    <td align="right">
       <asp:Label ID="Label4" runat="server" Text="Company_CEO :" CssClass="lablewidth"></asp:Label>
    </td>
    <td>
       <asp:TextBox ID="TextBox3" runat="server" CssClass="commonTxtbox" ></asp:TextBox>
    </td>
</tr>
    
 <tr>
   <td align="right">
       <asp:Label ID="Label5" runat="server" Text="Company_Services :" CssClass="lablewidth"></asp:Label>
    </td>
    <td>
       <asp:TextBox ID="TextBox4" runat="server" CssClass="commonTxtbox"></asp:TextBox>
    </td>
</tr>

<tr>
    <td align="right">
       <asp:Label ID="Label6" runat="server" Text="Isocertification_No:" CssClass="lablewidth"></asp:Label>
    </td>
    <td>
       <asp:TextBox ID="TextBox5" runat="server" CssClass="commonTxtbox"></asp:TextBox>
    </td>
</tr>

<tr>
    <td align="right">
      <asp:Label ID="Label7" runat="server" Text="Address:" CssClass="lablewidth"></asp:Label>
    </td>
    <td>
       <asp:TextBox ID="TextBox6" runat="server" TextMode="MultiLine" Width="201px" Height="64px"></asp:TextBox>
    </td>
</tr>
  
<tr>
     <td align="right">
         <asp:Label ID="Label8" runat="server" Text="Company Websites:" CssClass="lablewidth"></asp:Label>
     </td>
     <td>
         <asp:TextBox ID="TextBox7" runat="server" CssClass="commonTxtbox"></asp:TextBox>
     </td>
</tr>

<tr>
    <td align="right">
        <asp:Label ID="Label9" runat="server" Text="Skills:" CssClass="lablewidth"></asp:Label>
    </td>
    <td>    
         <asp:TextBox ID="TextBox8" runat="server" CssClass="commonTxtbox"></asp:TextBox>
    </td>
</tr>
 <tr>
    <td align="right">
        <asp:Label ID="Label10" runat="server" Text="Cost To Company:" CssClass="lablewidth"></asp:Label>
    </td>
     <td>
         <asp:TextBox ID="TextBox9" runat="server" CssClass="commonTxtbox"></asp:TextBox>
    </td>
</tr>
<tr>
     <td align="right">
         <asp:Label ID="Label11" runat="server" Text="Bond :" CssClass="lablewidth"></asp:Label>
      </td>
       <td>
          <asp:TextBox ID="TextBox10" runat="server" CssClass="commonTxtbox"></asp:TextBox>
       </td>
</tr>
<tr>
    <td align="right">
        <asp:Label ID="Label12" runat="server" Text="Description :" 
            CssClass="lablewidth"></asp:Label>
    </td>
        <td>
            <asp:TextBox ID="TextBox11" runat="server" CssClass="commonTxtbox" Height="53px" TextMode="MultiLine" Width="202px"></asp:TextBox>
        </td>
</tr>
  
    
<tr>
<td>
    <h3>
<asp:Label ID="Label32" runat="server" Text="ELIGIBILITY CRITERIA" CssClass="lableheader"></asp:Label>
 </h3>
     </td>
  </tr>
  
  <tr>
    <td align="right">
        <asp:Label ID="Label13" runat="server" Text="SSLC,10th:" CssClass="lablewidth"></asp:Label>
       </td>
            <td>
                <asp:TextBox ID="TextBox12" runat="server" CssClass="commonTxtbox" ></asp:TextBox>
                </td>
         </tr>
    <tr>
        <td align="right">
             <asp:Label ID="Label14" runat="server" Text="PUC,12th:" CssClass="lablewidth"></asp:Label>
          </td>
         <td>
             <asp:TextBox ID="TextBox13" runat="server" CssClass="commonTxtbox"></asp:TextBox>
             </td>
        </tr>

   <tr>
    <td align="right">
        <asp:Label ID="Label15" runat="server" Text="Diploma :" CssClass="lablewidth"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="TextBox14" runat="server" CssClass="commonTxtbox"></asp:TextBox>
       </td>
     </tr> 
   <tr>
    <td align="right">
        <asp:Label ID="Label16" runat="server" Text="Under_Graduation :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox15" runat="server" CssClass="commonTxtbox"></asp:TextBox>
         </td>
     </tr>
   <tr>
        <td align="right">
            <asp:Label ID="Label17" runat="server" Text="Post_Graduation :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox16" runat="server" CssClass="commonTxtbox"></asp:TextBox>
            </td>
        </tr>
   
   <tr>
    <td align="right">
        <asp:Label ID="Label18" runat="server" Text="Gap In Studies :" 
            CssClass="lablewidth"></asp:Label>
        </td>
    <td>
         <asp:TextBox ID="TextBox17" runat="server" CssClass="commonTxtbox"></asp:TextBox>
         </td>
        </tr>
   
   <tr>
       <td align="right">
           <asp:Label ID="Label19" runat="server" Text="Number Of Backlogs :" CssClass="lablewidth"></asp:Label>
       </td>
       <td>
             <asp:TextBox ID="TextBox18" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
     </tr>
    
    <tr>
        <td align="right">
            <asp:Label ID="Label20" runat="server" Text="Course_Offring :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox19" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>
   <tr>
    <td align="right">
        <asp:Label ID="Label21" runat="server" Text="Description :" CssClass="lablewidth"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="TextBox20" runat="server" CssClass="commonTxtbox" ></asp:TextBox>
    </td>
</tr>



    <tr>
    <td>
       
    <h3>
<asp:Label ID="Label33" runat="server" Text="RECRUITMENT PROCESS" CssClass="lableheader" ></asp:Label>
    </h3>
    </td>
</tr>
    
    <tr>
        <td align="right">
            <asp:Label ID="Label22" runat="server" Text="Apptitude :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:CheckBox ID="CheckBox1" runat="server" 
                EnableTheming="True"/>
        </td>
    </tr>
    
    <tr>
        <td align="right">
            <asp:Label ID="Label23" runat="server" Text="Group_Discussion:" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:CheckBox ID="CheckBox2" runat="server" />
        </td>
    </tr>
    
    <tr>
        <td align="right">
            <asp:Label ID="Label24" runat="server" Text="Technical_Round1:" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:CheckBox ID="CheckBox3" runat="server" />
        </td>
    </tr>

    <tr>
        <td align="right">
            <asp:Label ID="Label25" runat="server" Text="Technical_Round2:" CssClass="lablewidth"></asp:Label>
            </td>
        <td>
            <asp:CheckBox ID="CheckBox4" runat="server" />
        </td>
    </tr>

   <tr>
        <td align="right">
            <asp:Label ID="Label26" runat="server" Text="Technical_Round3:" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:CheckBox ID="CheckBox5" runat="server" />
        </td>
    </tr>
   <tr>
        <td align="right">
            <asp:Label ID="Label27" runat="server" Text="Telephone_Interview1:" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:CheckBox ID="CheckBox6" runat="server" />
            </td>
        </tr>
   <tr>
     <td align="right">
        <asp:Label ID="Label28" runat="server" Text="Telephone_Interview2 :" CssClass="lablewidth"></asp:Label>
    </td>
       <td>
        <asp:CheckBox ID="CheckBox7" runat="server" />
    </td>
    </tr>
    
    <tr>
        <td align="right">
            <asp:Label ID="Label29" runat="server" Text="Hr_Round1 :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:CheckBox ID="CheckBox8" runat="server" />
        </td>
    </tr>

    <tr>
        <td align="right">
            <asp:Label ID="Label30" runat="server" Text="Hr_Round2 :" CssClass="lablewidth"></asp:Label>
            </td>
        <td>
            <asp:CheckBox ID="CheckBox9" runat="server" />
            </td>
        </tr>
        </table>

<table width="95%">
<tr>
<td align="right">

    <asp:Button ID="Button4" runat="server" Text="Print" CssClass="buttonsimg" OnClientClick="javascript:window.print();"/>

  
   <asp:Button ID="Button1" runat="server" Text="Next" onclick="Button1_Click1" CssClass="buttonsimg" />
   </td>
</tr>
</table>

 </asp:Content>


