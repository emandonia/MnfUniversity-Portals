<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchBarViewer.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Viewers.SearchBarViewer" %>

<div id="google" style="float: right;">
    <form action="http://www.google.com/search" method="get" target="_blank">
        <table height="28" cellspacing="0" cellpadding="0">
            <tbody>
                <tr>
                    <td
                        height="24"><a style="COLOR: #00009c; TEXT-DECORATION: none"
                            href="http://www.google.com/">
                            <img alt="Google"
                                src="../../Styles/University_Master/images/google_bg.png" align="absMiddle"
                                border="0" width="120" height="40"></a>
                        <input maxlength="255" size="25" name="q" style=" padding:4px 4px 4px 22px;
	border:1px solid #CCCCCC;
	width:160px;
	height:18px;
     background:#FFFFFF url(../../Styles/University_Master/images/search.png) no-repeat 4px 4px;
     Border-radius:7px;" />
                        <input
                            type="submit" value="ابحث" name="btnG" style=" border-radius:3px;
    font-family:Arial;
    font-weight:bold;
    font-size:14px;
    background-color:#d8d9da;
    color:#334f84 !important;" /></td>
                </tr>
            </tbody>
          
        </table>
    </form>

</div>
