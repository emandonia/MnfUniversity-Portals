<%@ Page Language="C#" AutoEventWireup="true" Inherits="MnfUniversity_Portals._Default" CodeBehind="Default.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html style="height: 100%" xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','https://www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-57986194-1', 'auto');
  ga('send', 'pageview');

</script>
    <title></title>
    <link href="Styles/Main/MasterStyle.css" rel="Stylesheet" type="text/css" />
</head>
<body style="height: 100%; margin: 0px">
    <form id="form1" runat="server" style="height: 100%">
        <div style="width: 100%; height: 100%; text-align: center !important;">
            <asp:Image ID="Image1" runat="server" Height="100%" Style="margin: 0 auto !important;" ImageAlign="Middle" />
            <div style="z-index: 3000; direction: rtl; vertical-align: middle; text-align: center; display: block; top: 0px; position: absolute; width: 100%; height: 100%;">
                <asp:ObjectDataSource ID="LinqDataSource1" runat="server" SelectMethod="OwnerLanguages"
                    TypeName="StaticUtilities"></asp:ObjectDataSource>
                <asp:ListView ID="ListView1" runat="server" DataSourceID="LinqDataSource1" GroupItemCount="3">
                    <LayoutTemplate>
                        <table id="Table1" style="width: 100%; height: 100%;" runat="server">
                            <tr id="Tr1" runat="server">
                                <td id="Td1" runat="server">
                                    <table id="groupPlaceholderContainer" runat="server" style="width: 100%; height: 100%; border-collapse: collapse; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                        <tr id="groupPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <AlternatingItemTemplate>
                        <td id="Td2" runat="server" style="font-size: xx-large; padding-left: 190px; font-weight: bold; font-family: Tahoma; text-shadow: 0.1em 0.1em 0.2em white">
                            <div style="padding: 15px; background-size: contain; background-position: center; background-repeat: no-repeat; background-image: url('/styles/Main/images/intro_button.png');">
                                <asp:HyperLink Style="color: white; text-decoration: none;"
                                    ID="HyperLink2" runat="server" NavigateUrl='<%# HomeURL(Eval("LCID").ToString())%>'
                                    Text='<%#StaticUtilities.LanguageName(Eval("LCID"))%>'>
                                </asp:HyperLink>
                            </div>
                        </td>
                    </AlternatingItemTemplate>
                    <ItemTemplate>
                        <td id="Td1" runat="server" style="font-size: xx-large; padding-right: 190px; font-weight: bold; font-family: Tahoma; text-shadow: 0.1em 0.1em 0.2em white">
                            <div style="padding: 15px; background-size: contain; background-position: center; background-repeat: no-repeat; background-image: url('/styles/Main/images/intro_button.png');">
                                <asp:HyperLink Style="color: white; text-decoration: none;"
                                    ID="HyperLink2" runat="server" NavigateUrl='<%#HomeURL(Eval("LCID").ToString())%>'
                                    Text='<%#StaticUtilities.LanguageName(Eval("LCID"))%>'>
                                </asp:HyperLink>
                            </div>
                        </td>
                    </ItemTemplate>
                    <EmptyItemTemplate>
                        <td id="Td4" runat="server" />
                    </EmptyItemTemplate>
                    <GroupTemplate>
                        <tr id="itemPlaceholderContainer" runat="server">
                            <td id="itemPlaceholder" runat="server"></td>
                        </tr>
                    </GroupTemplate>
                </asp:ListView>
            </div>
        </div>
    </form>
</body>
</html>