<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/StaffMaster.Master" AutoEventWireup="true" CodeBehind="StaffSenRes.aspx.cs" Inherits="MnfUniversity_Portals.UI.StaffSenRes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
<ContentTemplate>
    

    <asp:ListView ID="ListView1" runat="server" DataKeyNames="ID"     >
        <AlternatingItemTemplate>
            <li style="background-color: #FFFFFF; color: #284775;"><%--ID:
                <asp:Label Text='<%# Eval("ID") %>' runat="server" ID="IDLabel" /><br />--%>
                 <asp:LinkButton ID="Details" runat="server" CommandName="Select" CommandArgument ='<%#Eval("Files")%>' OnClick ="Details_OnClick" >تعديل</asp:LinkButton>
                           
             <%--<asp:HyperLink ID="HyperLink2" runat="server"  ForeColor="blue"   Text='<%#Eval("Title")%>'  NavigateUrl='<%#GetUrl(Eval("Files"))%>'   > </asp:HyperLink>--%>
                          
             <asp:Label Text='<%# Eval("Title") %>' runat="server" ID="Label1"   Font-Bold="True"   /><br />
                <asp:Label Text='<%# Eval("AuthorName") %>' runat="server" ID="AuthorNameLabel"  Font-Bold="True"  />,<asp:Label Text='<%# Eval("Co_Authors") %>' runat="server" ID="Co_AuthorsLabel" Font-Bold="True"  /><br />
                <asp:Label Text='<%# Eval("Journal") %>' runat="server" ID="JournalLabel"  Font-Bold="True" Font-Italic="True" />,  Vol. <asp:Label Text='<%# Eval("Volume") %>' runat="server" ID="VolumeLabel" Font-Bold="True" Font-Italic="True" />,  No. <asp:Label Text='<%# Eval("Number") %>' Font-Bold="True" Font-Italic="True" runat="server" ID="NumberLabel" />,  pp. <asp:Label Text='<%# Eval("pageNum") %>' runat="server" ID="pageNumLabel" Font-Bold="True" Font-Italic="True" />, <asp:Label Text='<%# Eval("Year") %>' runat="server" ID="YearLabel" Font-Bold="True" Font-Italic="True"/><br />
                 ــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــ  
            
                     <%-- الملف: <asp:Label Text='<%# Eval("Files") %>' runat="server" ID="FilesLabel" /><br />
                Staff_ID:
                <asp:Label Text='<%# Eval("Staff_ID") %>' runat="server" ID="Staff_IDLabel" /><br />
                Fac_ID:
                <asp:Label Text='<%# Eval("Fac_ID") %>' runat="server" ID="Fac_IDLabel" /><br />
                Dep_ID:
                <asp:Label Text='<%# Eval("Dep_ID") %>' runat="server" ID="Dep_IDLabel" /><br />
                prtl_Owner:
                <asp:Label Text='<%# Eval("prtl_Owner") %>' runat="server" ID="prtl_OwnerLabel" /><br />--%>
            </li>
        </AlternatingItemTemplate>   
        <EditItemTemplate>
            <li style="background-color: #999999;"><%--ID:
                <asp:Label Text='<%# Eval("ID") %>' runat="server" ID="IDLabel1" /><br />--%>
                AuthorName:
                <asp:TextBox Text='<%# Bind("AuthorName") %>' runat="server" ID="AuthorNameTextBox" /><br />
                Co_Authors:
                <asp:TextBox Text='<%# Bind("Co_Authors") %>' runat="server" ID="Co_AuthorsTextBox" /><br />
                Title:
                <asp:TextBox Text='<%# Bind("Title") %>' runat="server" ID="TitleTextBox" /><br />
                Journal:
                <asp:TextBox Text='<%# Bind("Journal") %>' runat="server" ID="JournalTextBox" /><br />
                Volume:
                <asp:TextBox Text='<%# Bind("Volume") %>' runat="server" ID="VolumeTextBox" /><br />
                Number:
                <asp:TextBox Text='<%# Bind("Number") %>' runat="server" ID="NumberTextBox" /><br />
                pageNum:
                <asp:TextBox Text='<%# Bind("pageNum") %>' runat="server" ID="pageNumTextBox" /><br />
                Year:
                <asp:TextBox Text='<%# Bind("Year") %>' runat="server" ID="YearTextBox" /><br />
                Files:
                <asp:TextBox Text='<%# Bind("Files") %>' runat="server" ID="FilesTextBox" /><br />
               <%-- Staff_ID:
                <asp:TextBox Text='<%# Bind("Staff_ID") %>' runat="server" ID="Staff_IDTextBox" /><br />
                Fac_ID:
                <asp:TextBox Text='<%# Bind("Fac_ID") %>' runat="server" ID="Fac_IDTextBox" /><br />
                Dep_ID:
                <asp:TextBox Text='<%# Bind("Dep_ID") %>' runat="server" ID="Dep_IDTextBox" /><br />
                prtl_Owner:
                <asp:TextBox Text='<%# Bind("prtl_Owner") %>' runat="server" ID="prtl_OwnerTextBox" /><br />--%>
                <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" /><asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" /></li>
        </EditItemTemplate>
        <EmptyDataTemplate>
            No data was returned.
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <li style="">
                    <%--<asp:HyperLink ID="HyperLink2" runat="server"  ForeColor="blue"   Text='<%#Eval("Title")%>' NavigateUrl='<%#GetUrl(Eval("Files"))%>'   > </asp:HyperLink>--%>
                 
 <asp:LinkButton ID="Details" runat="server" CommandName="Select" CommandArgument ='<%#Eval("Files")%>' OnClick ="Details_OnClick" >تعديل</asp:LinkButton>
       
               <asp:Label Text='<%# Eval("Title") %>' runat="server" ID="Label1"   Font-Bold="True"   /><br />
                <asp:Label Text='<%# Eval("AuthorName") %>' runat="server" ID="AuthorNameLabel"  Font-Bold="True"  />,<asp:Label Text='<%# Eval("Co_Authors") %>' runat="server" ID="Co_AuthorsLabel" Font-Bold="True"  /><br />
                <asp:Label Text='<%# Eval("Journal") %>' runat="server" ID="JournalLabel"  Font-Bold="True" Font-Italic="True" />,  Vol. <asp:Label Text='<%# Eval("Volume") %>' runat="server" ID="VolumeLabel" Font-Bold="True" Font-Italic="True" />,  No. <asp:Label Text='<%# Eval("Number") %>' Font-Bold="True" Font-Italic="True" runat="server" ID="NumberLabel" />,  pp. <asp:Label Text='<%# Eval("pageNum") %>' runat="server" ID="pageNumLabel" Font-Bold="True" Font-Italic="True" />, <asp:Label Text='<%# Eval("Year") %>' runat="server" ID="YearLabel" Font-Bold="True" Font-Italic="True"/><br />
              ــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــ  
            
               <%--   اسم المؤلف: <asp:Label Text='<%# Eval("AuthorName") %>' runat="server" ID="AuthorNameLabel" /><br />
                اسماء المشاركين : <asp:Label Text='<%# Eval("Co_Authors") %>' runat="server" ID="Co_AuthorsLabel" /><br />
                عنوان البحث:<asp:Label Text='<%# Eval("Title") %>' runat="server" ID="TitleLabel" /><br />
                الجريدة: <asp:Label Text='<%# Eval("Journal") %>' runat="server" ID="JournalLabel" /><br />
                المجلد:  <asp:Label Text='<%# Eval("Volume") %>' runat="server" ID="VolumeLabel" /><br />
                العدد:  <asp:Label Text='<%# Eval("Number") %>' runat="server" ID="NumberLabel" /><br />
                رقم الصفحات: <asp:Label Text='<%# Eval("pageNum") %>' runat="server" ID="pageNumLabel" /><br />
                السنة: <asp:Label Text='<%# Eval("Year") %>' runat="server" ID="YearLabel" /><br />
                الملف: <asp:Label Text='<%# Eval("Files") %>' runat="server" ID="FilesLabel" /><br />--%>
               <%-- AuthorName:
                <asp:TextBox Text='<%# Bind("AuthorName") %>' runat="server" ID="AuthorNameTextBox" /><br />
                Co_Authors:
                <asp:TextBox Text='<%# Bind("Co_Authors") %>' runat="server" ID="Co_AuthorsTextBox" /><br />
                Title:
                <asp:TextBox Text='<%# Bind("Title") %>' runat="server" ID="TitleTextBox" /><br />
                Journal:
                <asp:TextBox Text='<%# Bind("Journal") %>' runat="server" ID="JournalTextBox" /><br />
                Volume:
                <asp:TextBox Text='<%# Bind("Volume") %>' runat="server" ID="VolumeTextBox" /><br />
                Number:
                <asp:TextBox Text='<%# Bind("Number") %>' runat="server" ID="NumberTextBox" /><br />
                pageNum:
                <asp:TextBox Text='<%# Bind("pageNum") %>' runat="server" ID="pageNumTextBox" /><br />
                Year:
                <asp:TextBox Text='<%# Bind("Year") %>' runat="server" ID="YearTextBox" /><br />
                Files:
                <asp:TextBox Text='<%# Bind("Files") %>' runat="server" ID="FilesTextBox" /><br />--%>
               <%-- Staff_ID:
                <asp:TextBox Text='<%# Bind("Staff_ID") %>' runat="server" ID="Staff_IDTextBox" /><br />
                Fac_ID:
                <asp:TextBox Text='<%# Bind("Fac_ID") %>' runat="server" ID="Fac_IDTextBox" /><br />
                Dep_ID:
                <asp:TextBox Text='<%# Bind("Dep_ID") %>' runat="server" ID="Dep_IDTextBox" /><br />
                prtl_Owner:
                <asp:TextBox Text='<%# Bind("prtl_Owner") %>' runat="server" ID="prtl_OwnerTextBox" /><br />--%>
                <asp:Button runat="server" CommandName="Insert" Text="Insert" ID="InsertButton" /><asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" />
            </li>
        </InsertItemTemplate>
        <ItemSeparatorTemplate>
            <br />
        </ItemSeparatorTemplate>
        <ItemTemplate>
            <li style="background-color: #E0FFFF; color: #333333;">
              
                    <%--<asp:HyperLink ID="HyperLink2" runat="server"  ForeColor="blue"   Text='<%#Eval("Title")%>' NavigateUrl='<%#GetUrl(Eval("Files"))%>'   > </asp:HyperLink>--%>
               <asp:LinkButton ID="Details" runat="server" CommandName="Select" CommandArgument ='<%#Eval("Files")%>' OnClick ="Details_OnClick" >تعديل</asp:LinkButton>
          
                   <asp:Label Text='<%# Eval("Title") %>' runat="server" ID="Label1"   Font-Bold="True"  /><br />
                <asp:Label Text='<%# Eval("AuthorName") %>' runat="server" ID="AuthorNameLabel"  Font-Bold="True" />,<asp:Label Text='<%# Eval("Co_Authors") %>' runat="server" ID="Co_AuthorsLabel" Font-Bold="True"  /><br />
                <asp:Label Text='<%# Eval("Journal") %>' runat="server" ID="JournalLabel"  Font-Bold="True" Font-Italic="True" />,  Vol. <asp:Label Text='<%# Eval("Volume") %>' runat="server" ID="VolumeLabel" Font-Bold="True" Font-Italic="True" />,  No. <asp:Label Text='<%# Eval("Number") %>' Font-Bold="True" Font-Italic="True" runat="server" ID="NumberLabel" />,  pp. <asp:Label Text='<%# Eval("pageNum") %>' runat="server" ID="pageNumLabel" Font-Bold="True" Font-Italic="True" />, <asp:Label Text='<%# Eval("Year") %>' runat="server" ID="YearLabel" Font-Bold="True" Font-Italic="True"/><br />
              ــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــ  
            
              <%--    اسم المؤلف: <asp:Label Text='<%# Eval("AuthorName") %>' runat="server" ID="AuthorNameLabel" /><br />
                اسماء المشاركين : <asp:Label Text='<%# Eval("Co_Authors") %>' runat="server" ID="Co_AuthorsLabel" /><br />
                عنوان البحث:<asp:Label Text='<%# Eval("Title") %>' runat="server" ID="TitleLabel" /><br />
                الجريدة: <asp:Label Text='<%# Eval("Journal") %>' runat="server" ID="JournalLabel" /><br />
                المجلد:  <asp:Label Text='<%# Eval("Volume") %>' runat="server" ID="VolumeLabel" /><br />
                العدد:  <asp:Label Text='<%# Eval("Number") %>' runat="server" ID="NumberLabel" /><br />
                رقم الصفحات: <asp:Label Text='<%# Eval("pageNum") %>' runat="server" ID="pageNumLabel" /><br />
                السنة: <asp:Label Text='<%# Eval("Year") %>' runat="server" ID="YearLabel" /><br />
                الملف: <asp:Label Text='<%# Eval("Files") %>' runat="server" ID="FilesLabel" /><br />--%>
                <%--ID:
                <asp:Label Text='<%# Eval("ID") %>' runat="server" ID="IDLabel" /><br />--%>
               <%-- AuthorName:
                <asp:Label Text='<%# Eval("AuthorName") %>' runat="server" ID="AuthorNameLabel" /><br />
                Co_Authors:
                <asp:Label Text='<%# Eval("Co_Authors") %>' runat="server" ID="Co_AuthorsLabel" /><br />
                عنوان البحث : <asp:Label Text='<%# Eval("Title") %>' runat="server" ID="TitleLabel" /><br />
                الجريدة :  <asp:Label Text='<%# Eval("Journal") %>' runat="server" ID="JournalLabel" /><br />
                Volume:
                <asp:Label Text='<%# Eval("Volume") %>' runat="server" ID="VolumeLabel" /><br />
                Number:
                <asp:Label Text='<%# Eval("Number") %>' runat="server" ID="NumberLabel" /><br />
                pageNum:
                <asp:Label Text='<%# Eval("pageNum") %>' runat="server" ID="pageNumLabel" /><br />
                Year:
                <asp:Label Text='<%# Eval("Year") %>' runat="server" ID="YearLabel" /><br />
                Files:
                <asp:Label Text='<%# Eval("Files") %>' runat="server" ID="FilesLabel" /><br />--%>
              <%--  Staff_ID:
                <asp:Label Text='<%# Eval("Staff_ID") %>' runat="server" ID="Staff_IDLabel" /><br />
                Fac_ID:
                <asp:Label Text='<%# Eval("Fac_ID") %>' runat="server" ID="Fac_IDLabel" /><br />
                Dep_ID:
                <asp:Label Text='<%# Eval("Dep_ID") %>' runat="server" ID="Dep_IDLabel" /><br />--%>
            <%--    prtl_Owner:
                <asp:Label Text='<%# Eval("prtl_Owner") %>' runat="server" ID="prtl_OwnerLabel" /><br />--%>
            </li>
        </ItemTemplate>
        <LayoutTemplate>
            <ul runat="server" id="itemPlaceholderContainer" style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                <li runat="server" id="itemPlaceholder" />
            </ul>
            <div style="text-align: center; background-color: #5D7B9D; font-family: Verdana, Arial, Helvetica, sans-serif; color: #FFFFFF;">
                <asp:DataPager runat="server" ID="DataPager1">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True"></asp:NextPreviousPagerField>
                    </Fields>
                </asp:DataPager>

            </div>

        </LayoutTemplate>
        <SelectedItemTemplate>
            <li style="background-color: #E2DED6; font-weight: bold; color: #333333;">
             
                            <%--<asp:HyperLink ID="HyperLink2" runat="server"  ForeColor="blue"   Text='<%#Eval("Title")%>' NavigateUrl='<%#GetUrl(Eval("Files"))%>'   > </asp:HyperLink>--%>
                 
                  <asp:Label Text='<%# Eval("Title") %>' runat="server" ID="Label1"   Font-Bold="True"   /><br />
                <asp:Label Text='<%# Eval("AuthorName") %>' runat="server" ID="AuthorNameLabel"  Font-Bold="True"  />,<asp:Label Text='<%# Eval("Co_Authors") %>' runat="server" ID="Co_AuthorsLabel" Font-Bold="True"  /><br />
                <asp:Label Text='<%# Eval("Journal") %>' runat="server" ID="JournalLabel"  Font-Bold="True" Font-Italic="True" />,  Vol. <asp:Label Text='<%# Eval("Volume") %>' runat="server" ID="VolumeLabel" Font-Bold="True" Font-Italic="True" />,  No. <asp:Label Text='<%# Eval("Number") %>' Font-Bold="True" Font-Italic="True" runat="server" ID="NumberLabel" />,  pp. <asp:Label Text='<%# Eval("pageNum") %>' runat="server" ID="pageNumLabel" Font-Bold="True" Font-Italic="True" />, <asp:Label Text='<%# Eval("Year") %>' runat="server" ID="YearLabel" Font-Bold="True" Font-Italic="True"/><br />
                 ــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــــ  
                         <%--    اسم المؤلف: <asp:Label Text='<%# Eval("AuthorName") %>' runat="server" ID="AuthorNameLabel" /><br />
                اسماء المشاركين : <asp:Label Text='<%# Eval("Co_Authors") %>' runat="server" ID="Co_AuthorsLabel" /><br />
                عنوان البحث:<asp:Label Text='<%# Eval("Title") %>' runat="server" ID="TitleLabel" /><br />
                الجريدة: <asp:Label Text='<%# Eval("Journal") %>' runat="server" ID="JournalLabel" /><br />
                المجلد:  <asp:Label Text='<%# Eval("Volume") %>' runat="server" ID="VolumeLabel" /><br />
                العدد:  <asp:Label Text='<%# Eval("Number") %>' runat="server" ID="NumberLabel" /><br />
                رقم الصفحات: <asp:Label Text='<%# Eval("pageNum") %>' runat="server" ID="pageNumLabel" /><br />
                السنة: <asp:Label Text='<%# Eval("Year") %>' runat="server" ID="YearLabel" /><br />
                الملف: <asp:Label Text='<%# Eval("Files") %>' runat="server" ID="FilesLabel" /><br />--%>
                <%--ID:
                <asp:Label Text='<%# Eval("ID") %>' runat="server" ID="IDLabel" /><br />--%>
               <%-- AuthorName:
                <asp:Label Text='<%# Eval("AuthorName") %>' runat="server" ID="AuthorNameLabel" /><br />
                Co_Authors:
                <asp:Label Text='<%# Eval("Co_Authors") %>' runat="server" ID="Co_AuthorsLabel" /><br />
                Title:
                <asp:Label Text='<%# Eval("Title") %>' runat="server" ID="TitleLabel" /><br />
                Journal:
                <asp:Label Text='<%# Eval("Journal") %>' runat="server" ID="JournalLabel" /><br />
                Volume:
                <asp:Label Text='<%# Eval("Volume") %>' runat="server" ID="VolumeLabel" /><br />
                Number:
                <asp:Label Text='<%# Eval("Number") %>' runat="server" ID="NumberLabel" /><br />
                pageNum:
                <asp:Label Text='<%# Eval("pageNum") %>' runat="server" ID="pageNumLabel" /><br />
                Year:
                <asp:Label Text='<%# Eval("Year") %>' runat="server" ID="YearLabel" /><br />
                Files:
                <asp:Label Text='<%# Eval("Files") %>' runat="server" ID="FilesLabel" /><br />--%>
             <%--   Staff_ID:
                <asp:Label Text='<%# Eval("Staff_ID") %>' runat="server" ID="Staff_IDLabel" /><br />
                Fac_ID:
                <asp:Label Text='<%# Eval("Fac_ID") %>' runat="server" ID="Fac_IDLabel" /><br />
                Dep_ID:
                <asp:Label Text='<%# Eval("Dep_ID") %>' runat="server" ID="Dep_IDLabel" /><br />--%>
              
            </li>
        </SelectedItemTemplate>
      
    </asp:ListView>


    <asp:LinqDataSource runat="server" EntityTypeName="" ID="LinqDataSource1" ContextTypeName="Portal_DAL.PortalDataContextDataContext" 
        TableName="Prtl_SecntificResearches" OrderBy="ID desc"></asp:LinqDataSource>
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
