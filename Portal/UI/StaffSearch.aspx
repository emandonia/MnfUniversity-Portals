<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Masterpages/UniversityMaster.master" CodeBehind="StaffSearch.aspx.cs" Inherits="MnfUniversity_Portals.UI.StaffSearch" %>

<%@ Import Namespace="Common" %>
<%@ Import Namespace="MisBLL" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
<script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-57986194-1', 'auto');
  ga('send', 'pageview');

</script>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            
            <br />
             <br />
             <br />
             <br />
             <br />
             <br />
                  <table style="width:100%;">
                <tr>
                    <td style="height: 29px">
                        <asp:Label ID="Label1" runat="server" Text="Insert National ID" meta:resourcekey="NationalLabelResource1"></asp:Label>
                    </td>
                    <td style="height: 29px">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                      <tr>
                          <td colspan="2"><asp:Label ID="ErrorMsg" runat="server" Visible="False" ForeColor="red"></asp:Label></td>
                      </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" meta:resourcekey="SearchButtonResource1" Text="Search" />
                    </td>
                </tr>
            </table>
           
            
            
            

            <br/> 
      
            <br/>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
            <table  style="width: 100%;">
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="URL"></asp:Label></td>
                    <td>
                        <asp:HyperLink ID="StaffURLHyperLink" runat="server"></asp:HyperLink></td>
                   
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="User Name"></asp:Label></td>
                    <td><asp:Label ID="UserNameLabel" runat="server"></asp:Label></td>
                    
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Password"></asp:Label></td>
                    <td>
                        <asp:Label ID="PasswordLabel" runat="server"></asp:Label></td>
                    
                </tr>
            </table>
            </asp:Panel>
            

            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
 