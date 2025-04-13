<html><head>
<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=windows-1256">
</head>

<%
dim id 
id=request("id")
%>
<!--#include file=common/outconnection.inc-->
 <link rel="stylesheet" type="text/css" href="/templates/sheet.css" />

 <body >
<%
 
set Myset1=Server.CreateObject("ADODB.Recordset")
 
 	sql="SELECT Years.year, FacultyTable.FacultyName, MainData.ArabicAddress, MainData.MainResName, MainData.Summary, MainData.ResName1, MainData.ResName2, MainData.ResName3, MainData.ResName4, MainData.PaperId FROM Years INNER JOIN (FacultyTable INNER JOIN MainData ON FacultyTable.FacultyID = MainData.Faculty) ON Years.year = MainData.Year WHERE (((MainData.PaperId)="&id&"))"

   	Myset1.open sql,DataBaseConectionoutstand,1,3,1
 	 
%>
 <table  bgcolor="#0080C0" cellspacing=4 align=center >
 <tr><td>
<font face=arial size=2>


<table cellpadding=3 cellspacing=6 width=750 border=0  align=center dir=rtl bgcolor="#CAE4FF">
    <tr>
        <td align=right colspan=2><u><b><% Response.Write  Myset1(1) %></b></u></td>
    </tr>
   
    <tr>
        <td colspan=2><br /></td></tr>
    <tr>
        <td align=right width=100><b>اسم الباحث</b></td>
        <td><b>:<% Response.Write  Myset1(3) %></b></td>
    </tr>
    <tr>
        <td align=right><b>بالاشتراك مع</b></td>
        <td><b>
            <table border=0 width=400>
		        <%
		        Myset1.MoveFirst 
		        do while not myset1.eof %>
		        <tr>
		            <td><b>:<%=myset1(5)%></b></td>
		            <td><b><%=myset1(6)%></b></td>
		            <td><b><%=myset1(7)%></b></td>
		             <td><b><%=myset1(8)%></b></td>
		        </tr>
		        <%myset1.MoveNext 
		
		        loop
		        Myset1.MoveFirst
		        %>
	    	</table>
        </b></td>
    </tr>
    <tr>
        <td align=right><b>عام النشر</b></td>
        <td><b>:<% Response.Write  Myset1(0) %></b></td>
    </tr>
    <tr>
        <td align=right valign=top colspan=2><b>ملخص البحث</b></td>
        
     </tr>
     <tr>
        <td></td>
        <td align=justify >
        <table border=1 bordercolor="#0080C0" cellpadding=0 cellspacing=0 >
        <tr>
        <td><P align=justify><b><% Response.Write  Myset1(4) %></b></P>
        
        </td>
        </tr>
        </table>
	 <br /><br />
        </td>
	</tr>
 </table>  
 </font>
 
</td></tr>
</table>
</body>
</html>