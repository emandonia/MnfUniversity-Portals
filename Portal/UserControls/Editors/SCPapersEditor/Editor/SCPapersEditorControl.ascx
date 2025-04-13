<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SCPapersEditorControl.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Editors.SCPapersEditor.Editor.SCPapersEditorControl" %>
<%@ Import Namespace="Common" %>
<%@ Register Src="~/UserControls/Editors/SCPapersEditor/Details/SCPapersDetailsViewControl.ascx" TagPrefix="uc" TagName="SCPapersDetailsViewControl" %>


<div style ="overflow: scroll; width: 100%;">
   
    <asp:DropDownList ID="SearchDropDown" runat="server" AutoPostBack ="True" OnSelectedIndexChanged="SearchTypeDropDownList_IndexChanged" >
                             
                         <%--<asp:ListItem Value="-1">اختر نوع الرسالة</asp:ListItem>--%>
                        <asp:ListItem Value="True" >رسائل تم مناقشتها</asp:ListItem>
                        <asp:ListItem Value="False">رسائل لم يتم مناقشتها</asp:ListItem>
                   </asp:DropDownList>
   <br/><br/><br/>
    <asp:ListView ID="EditorListView"  runat="server" DataSourceID="SPapersLinqDataSource2"
        DataKeyNames="PaperId" InsertItemPosition="FirstItem">
        <InsertItemTemplate>
            <td colspan="6">
                <asp:LinkButton ValidationGroup="InsertValidation" OnClick="SPapersEditorControl_insertClicked" ID="InsertLinkButton" ToolTip="Insert"
                    runat="server" AlternateText="Insert">
                    <asp:Image ID="InsertImage" ImageUrl='<%# InsertImageURL %>' CssClass="NoMargin" runat="server"></asp:Image>
                    <asp:Label ID="Label1" runat="server" Text="Insert New Thesis"></asp:Label>
                </asp:LinkButton>
               
            </td>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr runat="server" id="ListViewDataRow">
                <td class="ActionDiv">
                    <asp:LinkButton CommandArgument='<%# Bind("PaperId") %>' ID="Editor_LinkButton" OnClick="Editor_ImageButton_Click"
                        runat="server">
                        <asp:Image ID="EditorImage" ImageUrl='<%# EditImageURL %>' CssClass="NoMargin" runat="server"></asp:Image>
                    </asp:LinkButton>
                    <asp:LinkButton ToolTip="Delete" ID="LinkButton42" runat="server" CausesValidation="False"
                        CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this entry?");'>
                        <asp:Image ID="DeleteImage" ImageUrl='<%# DeleteImageURL %>' CssClass="NoMargin" runat="server"></asp:Image>
                    </asp:LinkButton>
                </td>
                <td>
                    <asp:Label Text='<%# Bind("ArabicAddress") %>' runat="server" ID="AddressLabel" />
                </td>
                <td>
                    <asp:Label Text='<%# Bind("StudentName") %>' runat="server" ID="EngMainResNameLabel" />

                </td>
               
              
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table id="Table1" runat="server">
                <tr id="Tr1" runat="server">
                    <td id="Td1" runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="1" class="ListViewLayoutTable">
                            <tr id="Tr2" runat="server" class="ListViewLayoutTableHeader">
                                <th id="Th2" runat="server">
                                    <asp:Label ID="Label1" runat="server" Text="Actions"></asp:Label>
                                </th>
                                <th id="Th5" runat="server">
                                    <asp:Label ID="Label8" runat="server" Text="Thesis Title"></asp:Label>
                                </th>
                                <th id="Th1" runat="server">
                                    <asp:Label ID="Label3" runat="server" Text="Researcher Name"></asp:Label>
                                </th>
                                
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="Tr3" runat="server">
                    <td id="Td2" runat="server" style="text-align: center; font-family: Verdana, Arial, Helvetica, sans-serif; color: #333333;">
                        <asp:DataPager ID="DataPagerProducts" runat="server" PageSize="15">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False"
                                    ShowLastPageButton="False" ShowPreviousPageButton="False" ButtonType="Button"
                                    ButtonCssClass="Pager_PreviousButton" />
                                <asp:NumericPagerField ButtonCount="5" ButtonType="Button" NumericButtonCssClass="Pager_Button"
                                    CurrentPageLabelCssClass="Pager_SelectButton" />
                                <asp:NextPreviousPagerField ShowLastPageButton="True" ShowNextPageButton="False"
                                    ShowFirstPageButton="False" ShowPreviousPageButton="False" ButtonType="Button"
                                    ButtonCssClass="Pager_NextButton" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>
    
  
    <asp:LinqDataSource ID="SPapersLinqDataSource2" runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
        EntityTypeName="" TableName="ResearchPlan_MainDatas" EnableDelete="True" EnableInsert="True"
        OrderBy="StudentName" EnableUpdate="True" Where="FacultyTable.Prtl_FacOwnerID == Guid?(@ID) && ResearchType == @ResearchType"  >
         <WhereParameters>
        <asp:SessionParameter SessionField="SPapersOwner_ID" Name="ID" DbType="Guid" />
             
               <asp:ControlParameter ControlID="SearchDropDown" Name="ResearchType" PropertyName="SelectedValue" Type="Boolean" />
    </WhereParameters>
    </asp:LinqDataSource>


   
    <uc:SCPapersDetailsViewControl runat="server" ID="SCPapersDetailsViewControl" />
  
</div>