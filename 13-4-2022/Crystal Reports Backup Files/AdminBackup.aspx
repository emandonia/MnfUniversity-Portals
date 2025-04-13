<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/SiteMaster.master" AutoEventWireup="true" CodeBehind="AdminBackup.aspx.cs" Inherits="MnfUniversity_Portals.UI.AdminBackup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
<ContentTemplate>
    <div style="align-content: center;">
    <asp:Label ID="Label1" runat="server" Text="Choose Faculty"></asp:Label> &nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="med">كلية الطب</asp:ListItem>
                    <asp:ListItem Value="sci">كلية العلوم</asp:ListItem>
                    <asp:ListItem Value="ho">المستشفيات</asp:ListItem>
                </asp:DropDownList>&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_OnClick" />
                <br /> <br /> <br /></div>
    <table border="1" style="width: 500px;">
       
        <tr>
            <td >
                 <asp:ListView ID="ListView1" runat="server" >
                    <LayoutTemplate>
                        <table id="Table1" runat="server" border="0" width="100%">
                            <tr id="Tr1" runat="server">
                                <td id="Td1" runat="server">
                                    <table class="stafftable" id="itemPlaceholderContainer" border="0" width="100%" runat="server" style=" font-family: Verdana, Arial, Helvetica, sans-serif;">
                                        <tr id="Tr3" runat="server" >

                                                            
                                                            <th id="Th2" runat="server"  ><asp:Label ID="Label10" runat="server" Text="Menu" meta:resourcekey="StaffNameLabelResource1" ></asp:Label></th>
                                            
                                                        </tr>
                                                        <tr id="itemPlaceholder" runat="server" >
                                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>

                    <ItemTemplate>
                       <tr >
                           
                                            <td class="col1">
                                <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="BLUE" NavigateUrl='<%#Eval("url")%>'
                                    Text='<%#Eval("FileName")%>'></asp:HyperLink>
                        </td>
                           
                           </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <table id="Table2" runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                            <tr id="Tr2" runat="server">
                                <td id="Td3" runat="server" meta:resourcekey="NoStaffFound" >No Data Found
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    

                   
                </asp:ListView>

                
            </td>
            <td  >
                <asp:ListView ID="ListView2" runat="server" >
                    <LayoutTemplate>
                        <table id="Table1" runat="server" border="0" width="100%">
                            <tr id="Tr1" runat="server">
                                <td id="Td1" runat="server">
                                    <table class="stafftable" id="itemPlaceholderContainer" border="0" width="100%" runat="server" style=" font-family: Verdana, Arial, Helvetica, sans-serif;">
                                        <tr id="Tr3" runat="server" >

                                                            
                                                            <th id="Th2" runat="server"  ><asp:Label ID="Label10" runat="server" Text="News" meta:resourcekey="StaffNameLabelResource2" ></asp:Label></th>
                                            
                                                        </tr>
                                                        <tr id="itemPlaceholder" runat="server" >
                                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>

                    <ItemTemplate>
                       <tr >
                           
                                            <td class="col1">
                                <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="BLUE" NavigateUrl='<%#Eval("url")%>'
                                    Text='<%#Eval("FileName")%>'></asp:HyperLink>
                        </td>
                           
                           </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <table id="Table2" runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                            <tr id="Tr2" runat="server">
                                <td id="Td3" runat="server" meta:resourcekey="NoStaffFound" >No Data Found
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    

                   
                </asp:ListView>

            </td>

        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="create menu backup" OnClick="LinkButton1_OnClick" Visible="False" meta:resourcekey="createmenubackup"></asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="LinkButton2" runat="server" Text="create news backup" OnClick="LinkButton2_OnClick" Visible="false" meta:resourcekey="createnewsbackup"></asp:LinkButton>
            </td>
        </tr>
        
        

    </table>
    
    
    
    
    


    </ContentTemplate>
</asp:UpdatePanel>
    

</asp:Content>
