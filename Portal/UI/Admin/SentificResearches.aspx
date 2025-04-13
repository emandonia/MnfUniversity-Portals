<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/StaffMaster.Master" AutoEventWireup="true" CodeBehind="SentificResearches.aspx.cs" Inherits="MnfUniversity_Portals.UI.SentificResearches" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="../Styles/University_Master/css/style_1.css" rel="stylesheet" type="text/css">
    <link href="../Styles/University_Master/css/staff_style.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
  
      <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
        <ContentTemplate>

          
            <asp:Panel ID="panelsss" runat="server" Visible ="false"  >
                 <asp:Label ID="Label12" runat="server" BackColor="#6699FF" Text="برجاء ادخال اسم العضو او الكلية او القسم ثم الضغط علي بحث." Font-Bold="True" Font-Size="20" ForeColor="Black"  ></asp:Label>

            <br/><br/>
            <div align="center">
                <table class="staffsearchtable" style="width: 500px;">
                    <tr>
                        <td>
                            <asp:Label ID="Label1300" runat="server"  Text="Enter Staff Name:" meta:resourcekey="NameLabelResource1"></asp:Label>
                        </td>
                        <td>

                            <asp:TextBox  ID="TextBox100" CssClass="textboxservice2" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1400"  runat="server" Text="Choose Faculty:" meta:resourcekey="facLabelResource1"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList AppendDataBoundItems="true"   DataSourceID="ObjectDataSource1" DataTextField="Faculty_Name" DataValueField="ID" ID="FacDropDownList00" CssClass="textboxservice2" OnSelectedIndexChanged="FacDropDownList_SelectedIndexChanged" runat="server">
                                <asp:ListItem Value="-1" meta:resourcekey="choose">اختر</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource runat="server" ID="ObjectDataSource1" SelectMethod="GetFaculties" TypeName="MisBLL.Staff_Utility">
                                <SelectParameters>
                                    <asp:RouteParameter RouteKey="lang" Name="currentLang" Type="String"></asp:RouteParameter>
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1500" runat="server" Text="Choose Department:" meta:resourcekey="depLabelResource1"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DepDropDownList00" CssClass="textboxservice2" Enabled="false" DataTextField="DepName"
                                DataValueField="ID"  runat="server"
                                AppendDataBoundItems="true"
                                 >
                                <asp:ListItem Value="-1" meta:resourcekey="choose">اختر</asp:ListItem>
                            </asp:DropDownList>
                           
                        </td>
                    </tr>
                    

                 

                    <tr>
                        <td colspan="2" style="float: <%=StaticUtilities.FloatLeft%>;">
                            <asp:Button class="btn" ID="Button200" runat="server" Text="Search" meta:resourcekey="seaLabelResource1" OnClick="Button1_Click00" />
                        </td>
                    </tr>
                </table> 
            </asp:Panel>
          

                <asp:ListView ID="ListView100" runat="server"  DataKeyNames ="Abbr" OnSelectedIndexChanging="ListView1_SelectedIndexChanging">
                    <LayoutTemplate>
                        <table id="Table1" runat="server" border="0" width="100%">
                            <tr id="Tr1" runat="server">
                                <td id="Td1" runat="server">
                                    <table class="stafftable" id="itemPlaceholderContainer" border="0" width="100%" runat="server" style=" font-family: Verdana, Arial, Helvetica, sans-serif;">
                                        <tr id="Tr3" runat="server" >

                                                            
                                                            <th id="Th2" runat="server"  ><asp:Label ID="Label10" runat="server" Text="Name" meta:resourcekey="StaffNameLabelResource1" ></asp:Label></th>
                                            <th id="Th1" runat="server" >
                                                                <asp:Label  ID="Label9" runat="server" Text="Job" meta:resourcekey="StaffJobLabelResource1" ></asp:Label></th>
                                            <th id="Th5" runat="server" >
                                                                <asp:Label  ID="Label4" runat="server" Text="Job2" meta:resourcekey="StaffJobLabelResource2" ></asp:Label></th>
                                                            <th id="Th3"  runat="server"><asp:Label  ID="Label11" runat="server" Text="Department" meta:resourcekey="StaffDepLabelResource1" ></asp:Label></th>
                                                            <th id="Th4"  runat="server"><asp:Label  ID="Label12" runat="server" Text="Faculty" meta:resourcekey="StaffFacLabelResource1" ></asp:Label></th>
                                            
                                                        </tr>
                                                        <tr id="itemPlaceholder" runat="server" >
                                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    
                        <asp:DataPager ID="DataPager1" runat="server" OnPreRender="DataPager1_PreRender">
                    <Fields>
                        <asp:NumericPagerField />
                    </Fields>
                </asp:DataPager>


                    </LayoutTemplate>

                    <ItemTemplate>
                       <tr >
                           
                                            <td class="col1">
                              

                                                  <asp:LinkButton ID="LinkButton1" Text='<%#Eval("Name")%>' CommandName="Select" runat="server" />

                                                <%--<asp:LinkButton ID="LinkButton1" Text='<%#Eval("Name")%>' CommandArgument='<%#Eval("ID")%>'  runat="server" OnClick ="LinkButton1_Click"></asp:LinkButton>--%>   
                                                 <%-- <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="BLUE"  NavigateUrl='<%#StaffUrl(Eval("Abbr").ToString())%>'
                                    Text='<%#Eval("Name")%>'></asp:HyperLink>--%>
                        </td>
                           <td class="col2"> 
                               <asp:Label ID="labelID" runat="server" Visible ="false"  Text='<%#Eval("ID")%>'></asp:Label>
                               <asp:Label ID="Label8" runat="server" Text='<%#Eval("Job")%>'></asp:Label></td>
                           <td class="col2"> <asp:Label ID="Label13" runat="server" Text='<%#Eval("Job2")%>'></asp:Label></td>
                           <td class="col3"> <asp:Label ID="Label6" runat="server" Text='<%#Eval("DepName")%>'></asp:Label></td>
                           <td class="col4"> <asp:Label ID="Label7" runat="server" Text='<%#Eval("FacName")%>'></asp:Label></td>
                           
                           </tr>
                    </ItemTemplate>

                    <SelectedItemTemplate>
      <tr style="background-color: #336699; color: White;">
         <td>
            <asp:LinkButton ID="lnkSelect" Text='<%#Eval("Name")%>' CommandName="Select" runat="server"
               ForeColor="White" />
         </td>
         <td><%# Eval("Job")%></td>
         <td><%# Eval("Job2")%></td>
         <td><%# Eval("DepName")%></td
           <td><%# Eval("FacName")%></td>
      </tr>
   </SelectedItemTemplate>

                    <EmptyDataTemplate>
                        <table id="Table2" runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                            <tr id="Tr2" runat="server">
                                <td id="Td3" runat="server" meta:resourcekey="NoStaffFound" >No Staff Data Found
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    

                   
                </asp:ListView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    
    
     <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server"   >
     
         <ContentTemplate> 
            <panel ID ="panelaaaa" runat="server" Visible ="true"  >

            
    <table align="right" dir="rtl" width="100%" >
      <tr>
          <td align="right"></td>
          <td></td>
          <td></td>
          <td></td>
          <td></td>
      </tr>
      <tr>
          <td align="right" dir="rtl">
              <asp:Label ID="Label10" runat="server" Text="اسم المؤلف :" Font-Bold="True" Font-Size="Large"></asp:Label>
          </td>
          <td align="right" dir="rtl">
              <asp:TextBox ID="txtName" runat="server" CssClass="textboxservice2"></asp:TextBox>
          </td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
      </tr>

      <tr>
          <td align="right" dir="rtl" class="auto-style1">
              <asp:Label ID="Label2" runat="server" Text="عنوان البحث :" Font-Bold="True" Font-Size="Large"></asp:Label>
          </td>
          <td align="right" dir="rtl" class="auto-style1">
              <asp:TextBox ID="txtTitle" runat="server" CssClass="textboxservice2"></asp:TextBox>
          </td>
          <td class="auto-style1"></td>
          <td class="auto-style1"></td>
          <td class="auto-style1"></td>
      </tr>

      <tr>
          <td align="right" dir="rtl">
              <asp:Label ID="Label3" runat="server" Text="اسماء المشاركين :" Font-Bold="True" Font-Size="Large"></asp:Label>
          </td>
          <td align="right" dir="rtl">
              <asp:TextBox ID="txtCoOuther" runat="server" CssClass="textboxservice2"></asp:TextBox>
          </td>
          <td></td>
          <td></td>
          <td></td>
      </tr>

      <tr>
          <td align="right" dir="rtl">
              <asp:Label ID="Label4" runat="server" Text="اسم المجلة او المؤتمر :" Font-Bold="True" Font-Size="Large"></asp:Label>
          </td>
          <td align="right" dir="rtl">
              <asp:TextBox ID="txtJour" runat="server" CssClass="textboxservice2"></asp:TextBox>
          </td>
          <td></td>
          <td></td>
          <td></td>
      </tr>

      <tr>
          <td align="right" dir="rtl">
              <asp:Label ID="Label5" runat="server" Text="المجلد :" Font-Bold="True" Font-Size="Large"></asp:Label>
          </td>
          <td align="right" dir="rtl">
              <asp:TextBox ID="txtVloum" runat="server" CssClass="textboxservice2"></asp:TextBox>
          </td>
          <td></td>
          <td></td>
          <td></td>
      </tr>
<tr>
          <td align="right" dir="rtl">
              <asp:Label ID="Label6" runat="server" Text="العدد :" Font-Bold="True" Font-Size="Large"></asp:Label>
          </td>
          <td align="right" dir="rtl">
              <asp:TextBox ID="txtNum" runat="server" CssClass="textboxservice2"></asp:TextBox>
          </td>
          <td></td>
          <td></td>
          <td></td>
      </tr>

      <tr>
          <td align="right" dir="rtl">
              <asp:Label ID="Label7" runat="server" Text="رقم الصفحات :" Font-Bold="True" Font-Size="Large"></asp:Label>
          </td>
          <td align="right" dir="rtl">
              <asp:TextBox ID="txtPagen" runat="server" CssClass="textboxservice2"></asp:TextBox>
          </td>
          <td></td>
          <td></td>
          <td></td>
      </tr>
  <tr>
          <td align="right" dir="rtl">
              <asp:Label ID="Label8" runat="server" Text="سنة النشر :" Font-Bold="True" Font-Size="Large"></asp:Label>
          </td>
          <td align="right" dir="rtl">
              <asp:TextBox ID="txtyear" runat="server" CssClass="textboxservice2"></asp:TextBox>
          </td>
          <td></td>
          <td></td>
          <td></td>
      </tr>

        
         <tr>
          <td align="right" dir="rtl">
              <asp:Label ID="Label1" runat="server" Text="مستخلص :" Font-Bold="True" Font-Size="Large"></asp:Label>
          </td>
          <td align="right" dir="rtl">
              <asp:TextBox ID="txtAbstar" runat="server" Rows ="5"  CssClass="textboxservice2" Height="125px" Width="350px"></asp:TextBox>
          </td>
          <td></td>
          <td></td>
          <td></td>
      </tr>
        
         
         <tr>
          <td align="right" dir="rtl">
              <asp:Label ID="Label11" runat="server" Text="Abstract :" Font-Bold="True" Font-Size="Large"></asp:Label>
          </td>
          <td align="right" dir="rtl">
              <asp:TextBox ID="txtAbsten" runat="server"  Rows ="5" CssClass="textboxservice2" Height="125px" Width="350px"></asp:TextBox>
          </td>
          <td></td>
          <td></td>
          <td></td>
      </tr>


        <tr>
          <td align="right" dir="rtl">
              <asp:Label ID="Label9" runat="server" Text="ملف البحث :" Font-Bold="True" Font-Size="Large"></asp:Label>
            </td>
          <td align="right" dir="rtl">
              <ajaxtk:AsyncFileUpload ID="AsyncFileUpload1" runat="server" PersistedStoreType="Session" PersistFile="True" Width="70px"  />
            </td>
          <td></td>
          <td></td>
          <td></td>
      </tr>

        <tr>
          <td></td>
          <td></td>
          <td></td>
          <td></td>
          <td></td>
      </tr>

        <tr>
          <td></td>
          <td>
              <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ادخال" CssClass="login_button" />
            </td>
          <td></td>
          <td></td>
          <td></td>
      </tr>

        <tr>
          <td></td>
          <td></td>
          <td></td>
          <td></td>
          <td></td>
      </tr>

        <tr>
          <td></td>
          <td></td>
          <td></td>
          <td></td>
          <td></td>
      </tr>

        <tr>
          <td colspan="5">
              
              <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4"  Width ="100%" Height ="100%"
                  DataKeyNames="ID"   ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"   
                  OnSelectedIndexChanging  ="GridView1_OnSelectedIndexChanging"  >
                  <AlternatingRowStyle BackColor="White" />
                  <Columns>
                      <asp:BoundField DataField="AuthorName" HeaderText="اسم المؤلف" SortExpression="AuthorName"  />
                      <asp:BoundField DataField="Co_Authors" HeaderText="اسماء المشاركين" SortExpression="Co_Authors" />
                      <asp:BoundField DataField="Title" HeaderText="العنوان" SortExpression="Title" />
                      <asp:BoundField DataField="Journal" HeaderText="الجريدة" SortExpression="Journal" />
                      <asp:BoundField DataField="Volume" HeaderText="المجلد" SortExpression="Volume" />
                      <asp:BoundField DataField="Number" HeaderText="العدد" SortExpression="Number" />
                      <asp:BoundField DataField="pageNum" HeaderText="رقم الصفحة" SortExpression="pageNum" />
                      <asp:BoundField DataField="Year" HeaderText="السنة" SortExpression="Year" />
                      <asp:BoundField DataField="Files" HeaderText="الملف" SortExpression="Files" />
                   
                     <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="تعديل" ItemStyle-HorizontalAlign="left" >
                                    <ItemTemplate>
                                        
                                        <%--<asp:Button ID="Button1" runat="server" Text="Button" CommandArgument='<%#Eval("ID")%>'  OnClick ="Button1_OnClick"  />--%>
                                        <asp:LinkButton ID="Details" runat="server" CommandName="Select" CommandArgument ='<%#Eval("ID")%>' OnClick ="Details_OnClick" >تعديل</asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                  </Columns>
                  <EditRowStyle BackColor="#7C6F57" />
                  <FooterStyle CssClass="btn3" BackColor="#1C5E55" Font-Bold="True" ForeColor="White"/>
                  <HeaderStyle CssClass="col5" BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                  <RowStyle CssClass ="grid" BackColor="#E3EAEB" />
                  <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                  <SortedAscendingCellStyle BackColor="#F8FAFA" />
                  <SortedAscendingHeaderStyle BackColor="#246B61" />
                  <SortedDescendingCellStyle BackColor="#D4DFE1" />
                  <SortedDescendingHeaderStyle BackColor="#15524A" />
              </asp:GridView>
              <asp:LinqDataSource ID="LinqDataSource1" runat="server"
                   ContextTypeName="Portal_DAL.PortalDataContextDataContext" EntityTypeName="" TableName="Prtl_SecntificResearches"
                  >
              </asp:LinqDataSource>
            </td>
      </tr>

        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
      </tr>

        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
      </tr>

        <tr>
          <td colspan="5">      
              <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False"
                  GridLines="None" Height="50px" Visible="False"
                  Width="50%" CellPadding="4" ForeColor="#333333">
                  <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                  <CommandRowStyle BackColor="#FFFFC0" Font-Bold="True"></CommandRowStyle>


                  <Fields>
                      <asp:TemplateField HeaderStyle-HorizontalAlign="Right" HeaderText="اسم المؤلف" ItemStyle-HorizontalAlign="Right"
                          SortExpression="AuthorName">
                          <EditItemTemplate>
                              <asp:Label ID="labelID" runat="server" Text='<%# Bind("ID") %>' Visible="False"></asp:Label>
                              <asp:TextBox ID="txtAuthorName" runat="server" Text='<%# Bind("AuthorName") %>' CssClass="textboxservice2"></asp:TextBox>
                          </EditItemTemplate>

                          <ItemTemplate>
                              <%# Eval("AuthorName")%>
                          </ItemTemplate>
                          <HeaderStyle HorizontalAlign="Left" />
                          <ItemStyle HorizontalAlign="Left" />
                      </asp:TemplateField>

                      <asp:TemplateField HeaderStyle-HorizontalAlign="Right" HeaderText="اسماء المشاركين" ItemStyle-HorizontalAlign="Right"
                          SortExpression="AuthorName">
                          <EditItemTemplate>

                              <asp:TextBox ID="txtCo_Authors" runat="server" Text='<%# Bind("Co_Authors") %>' CssClass="textboxservice2"></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <%# Eval("Co_Authors")%>
                          </ItemTemplate>
                          <HeaderStyle HorizontalAlign="Left" />
                          <ItemStyle HorizontalAlign="Left" />
                      </asp:TemplateField>

                      <asp:TemplateField HeaderStyle-HorizontalAlign="Right" HeaderText="عنوان البحث" ItemStyle-HorizontalAlign="Right"
                          SortExpression="Title">
                          <EditItemTemplate>

                              <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("Title") %>' CssClass="textboxservice2"></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <%# Eval("Title")%>
                          </ItemTemplate>
                          <HeaderStyle HorizontalAlign="Left" />
                          <ItemStyle HorizontalAlign="Left" />
                      </asp:TemplateField>

                      <asp:TemplateField HeaderStyle-HorizontalAlign="Right" HeaderText="الجريدة" ItemStyle-HorizontalAlign="Right"
                          SortExpression="Journal">
                          <EditItemTemplate>

                              <asp:TextBox ID="txtJournal" runat="server" Text='<%# Bind("Journal") %>' CssClass="textboxservice2"></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <%# Eval("Journal")%>
                          </ItemTemplate>
                          <HeaderStyle HorizontalAlign="Left" />
                          <ItemStyle HorizontalAlign="Left" />
                      </asp:TemplateField>

                      <asp:TemplateField HeaderStyle-HorizontalAlign="Right" HeaderText="المجلد" ItemStyle-HorizontalAlign="Right"
                          SortExpression="Volume">
                          <EditItemTemplate>

                              <asp:TextBox ID="txtVolume" runat="server" Text='<%# Bind("Volume") %>' CssClass="textboxservice2"></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <%# Eval("Volume")%>
                          </ItemTemplate>
                          <HeaderStyle HorizontalAlign="Left" />
                          <ItemStyle HorizontalAlign="Left" />
                      </asp:TemplateField>

                      <asp:TemplateField HeaderStyle-HorizontalAlign="Right" HeaderText="العدد" ItemStyle-HorizontalAlign="Right"
                          SortExpression="Number">
                          <EditItemTemplate>

                              <asp:TextBox ID="txtNumber" runat="server" Text='<%# Bind("Number") %>' CssClass="textboxservice2"></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <%# Eval("Number")%>
                          </ItemTemplate>
                          <HeaderStyle HorizontalAlign="Left" />
                          <ItemStyle HorizontalAlign="Left" />
                      </asp:TemplateField>

                      <asp:TemplateField HeaderStyle-HorizontalAlign="Right" HeaderText="رقم الصفحات" ItemStyle-HorizontalAlign="Right"
                          SortExpression="pageNum">
                          <EditItemTemplate>

                              <asp:TextBox ID="txtpageNum" runat="server" Text='<%# Bind("pageNum") %>' CssClass="textboxservice2"></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <%# Eval("pageNum")%>
                          </ItemTemplate>
                          <HeaderStyle HorizontalAlign="Left" />
                          <ItemStyle HorizontalAlign="Left" />
                      </asp:TemplateField>

                      <asp:TemplateField HeaderStyle-HorizontalAlign="Right" HeaderText="سنة النشر" ItemStyle-HorizontalAlign="Right"
                          SortExpression="Year">
                          <EditItemTemplate>

                              <asp:TextBox ID="txtYear" runat="server" Text='<%# Bind("Year") %>' CssClass="textboxservice2"></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <%# Eval("Year")%>
                          </ItemTemplate>
                          <HeaderStyle HorizontalAlign="Left" />
                          <ItemStyle HorizontalAlign="Left" />
                      </asp:TemplateField>
                      
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Right" HeaderText="المستخلص عربى" ItemStyle-HorizontalAlign="Right"
                          SortExpression="Year">
                          <EditItemTemplate>

                              <asp:TextBox ID="txtabstract_ar" runat="server" Text='<%# Bind("abstract_ar") %>' CssClass="textboxservice2"></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <%# Eval("Year")%>
                          </ItemTemplate>
                          <HeaderStyle HorizontalAlign="Left" />
                          <ItemStyle HorizontalAlign="Left" />
                      </asp:TemplateField>
                      
                      
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Right" HeaderText="المستخلص انجليزى" ItemStyle-HorizontalAlign="Right"
                          SortExpression="Year">
                          <EditItemTemplate>

                              <asp:TextBox ID="txtabstract_en" runat="server" Text='<%# Bind("abstract_en") %>' CssClass="textboxservice2"></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <%# Eval("Year")%>
                          </ItemTemplate>
                          <HeaderStyle HorizontalAlign="Left" />
                          <ItemStyle HorizontalAlign="Left" />
                      </asp:TemplateField>

                      <asp:TemplateField HeaderStyle-HorizontalAlign="Right" HeaderText="ملف البحث" ItemStyle-HorizontalAlign="Right"
                          SortExpression="AuthorName">
                          <EditItemTemplate>
                              <ajaxtk:AsyncFileUpload ID="AsyncFileUpload1" runat="server" PersistedStoreType="Session" CssClass="textboxservice2" PersistFile="True" Width="70px" />

                              <%--<asp:TextBox ID="txtFiles" runat="server" Text='<%# Bind("Files") %>' ></asp:TextBox>--%>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <%# Eval("Files")%>
                          </ItemTemplate>
                          <HeaderStyle HorizontalAlign="Left" />
                          <ItemStyle HorizontalAlign="Left" />
                      </asp:TemplateField>

                      <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                          ShowHeader="False">
                          <EditItemTemplate>
                              <asp:LinkButton ID="btnmodfy" runat="server" OnClick="btnmodfy_Click" Text="Update"></asp:LinkButton>
                              &nbsp;&nbsp;&nbsp;
                                        <asp:LinkButton ID="btncancel" runat="server" CausesValidation="False" OnClick="btncancel_Click"
                                            Text="Cancel"></asp:LinkButton>
                          </EditItemTemplate>
                          <%-- <InsertItemTemplate>
                                        <asp:LinkButton ID="btndeadd" runat="server" OnClick="btndeadd_Click" Text="Add" ></asp:LinkButton>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" OnClick="LinkButton4_Click"
                                            Text="Cancel"  ></asp:LinkButton>
                                    </InsertItemTemplate>--%>
                          <HeaderStyle HorizontalAlign="Left" />
                          <ItemStyle HorizontalAlign="Right" />
                      </asp:TemplateField>
                  </Fields>
                  <FooterStyle HorizontalAlign="Left" BackColor="Tan" CssClass="grid_footer" Font-Size="Medium"></FooterStyle>

                  <HeaderStyle BackColor="Tan" Font-Bold="True"></HeaderStyle>

                  <AlternatingRowStyle />
                  <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                  <RowStyle />
                  <FooterStyle CssClass="grid_footer" Font-Size="Medium" HorizontalAlign="left" BackColor="#507CD1"
                      Font-Bold="True" ForeColor="White" />
                  <HeaderStyle />
              </asp:DetailsView>
              <asp:LinqDataSource ID="GetDetails" runat="server" ContextTypeName="Portal_DAL.PortalDataContextDataContext"
                  TableName="Prtl_SecntificResearches" Where="ID == @ID" EntityTypeName="">
                  <WhereParameters>
                      <asp:ControlParameter ControlID="GridView1" Name="ID" PropertyName="SelectedValue" Type="Int32" />
                            </WhereParameters>
                        </asp:LinqDataSource>&nbsp;</td>
      </tr>

        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
      </tr>

        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
      </tr>

        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
      </tr>

        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
      </tr>

        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
      </tr>

        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
      </tr>

        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
      </tr>

        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
      </tr>

        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
      </tr>

        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
      </tr>

        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
      </tr>

        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
      </tr>

        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
      </tr>

        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
      </tr>

        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
      </tr>

        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
      </tr>

  </table>  
                </panel>
     </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="NewsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="EventsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="RightLinksPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="LeftLinksPlaceHolder" runat="server">
</asp:Content>
