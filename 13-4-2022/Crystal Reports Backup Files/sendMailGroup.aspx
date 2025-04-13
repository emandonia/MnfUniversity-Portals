<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/UniversityMaster.Master" AutoEventWireup="true" CodeBehind="sendMailGroup.aspx.cs" Inherits="MnfUniversity_Portals.sendMailGroup" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

  <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <table style="width: 100%;">   <tr>
                                                                    <td> <asp:Label ID="Label5" runat="server" Text ="Subject" meta:resourcekey="subject"></asp:Label></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtSubj" runat="server" CssClass="textboxservice"></asp:TextBox>
                                                                    </td>
                                                                </tr>


                 </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label1" runat="server" Text ="Complain" meta:resourcekey="complain"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtComp" CssClass="textboxservice" runat="server" TextMode="MultiLine" Height="199px" Width="396px"></asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                             <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label4" runat="server" Text ="Message" meta:resourcekey="complain"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                              <ajaxtk:AsyncFileUpload ID="InsertAsyncFileUpload1" runat="server" PersistFile ="true" PersistedStoreType="Session"/>
                                                                 
                                                                         
                                                                    </td>
                                                                </tr>
                                                                    <tr>
                        <td>
                            <asp:Label ID="Label6"  runat="server" Text="Choose Faculty:" meta:resourcekey="facLabelResource1"></asp:Label>
                        </td>
                        <td>

                             <asp:DropDownList AppendDataBoundItems="true"  DataSourceID="ObjectDataSource1"  DataTextField="Faculty_Name" DataValueField="ID" AutoPostBack="true" 
                                 ID="FacDropDownList" runat="server">
                                <asp:ListItem Value="-1" meta:resourcekey="choose">اختر  الكلية</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource runat="server" ID="ObjectDataSource1" SelectMethod="GetFacultiesandIDs" TypeName="BLL.Prtl_OwnersUtility">
                                <SelectParameters>
                                    <asp:RouteParameter RouteKey="lang" Name="currentLang" Type="String"></asp:RouteParameter>
                                </SelectParameters>
                            </asp:ObjectDataSource>
                     

                         
                        
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="Choose Department:" meta:resourcekey="depLabelResource1"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList AppendDataBoundItems="true" DataSourceID="ObjectDataSource2" DataTextField="Department_Name"  
                                DataValueField="ID" AutoPostBack="true" ID="DepDropDownList" runat="server">
                                <asp:ListItem Value="-1" meta:resourcekey="choose">اختر  القسم</asp:ListItem>
                            </asp:DropDownList>
   <asp:ObjectDataSource runat="server" ID="ObjectDataSource2" SelectMethod="GetDepartmentsandIDs" TypeName="BLL.Prtl_OwnersUtility">
                                <SelectParameters>
                                    <asp:RouteParameter RouteKey="lang" Name="currentLang" Type="String"></asp:RouteParameter>
                                    <asp:ControlParameter ControlID="FacDropDownList" PropertyName="SelectedValue" Name="facId" Type="Int32"></asp:ControlParameter>
                                </SelectParameters>
                            </asp:ObjectDataSource>

                       
                         
                        </td>
                    </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Send" meta:resourcekey="Send" />
                                                                    </td>
                                                                </tr>
                                                           
                                                     <tr><td>
                    <asp:Label ID="sentlabel" runat="server" Visible="false" ForeColor="red
                        " Text="Message Sent"></asp:Label>
                    </td></tr>
            </table>
               </ContentTemplate>
      <Triggers>
              <asp:PostBackTrigger ControlID="InsertAsyncFileUpload1" /> 
   <asp:PostBackTrigger ControlID="Button1" /> 
            </Triggers>
    </asp:UpdatePanel>
</asp:Content>
