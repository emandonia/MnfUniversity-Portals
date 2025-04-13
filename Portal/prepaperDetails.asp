<html><head>
<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=windows-1256">
</head>

<%
dim id 
id=request("id")
%>
<!--#include file=common/preconnection.inc-->


 <body >
 <br /><br />
<%
 
set Myset1=Server.CreateObject("ADODB.Recordset")
 
 	sql="SELECT MainData.PaperId, MainData.ArabicAddress, MainData.ReashWay,  FacultyTable.FacultyName, MainData.MainResName, MainData.ResKind, MainData.ResName1, MainData.ResName2, MainData.ResName3, MainData.ResName4, MainData.ResName5, MainData.ResName6, MainData.Date FROM FacultyTable INNER JOIN MainData ON FacultyTable.FacultyID = MainData.Faculty WHERE (((MainData.PaperId)="&id&"))"

   	Myset1.open sql,DataBaseConectionprestand,1,3,1
 	 
%>
 <table  bgcolor="#6e0e0f" cellspacing=4 align=center width=70%>
 <tr><td>
<font face=arial size=2>


<table cellpadding=3 cellspacing=6 width=100% border=0  align=center dir=rtl bgcolor="Cornsilk">
    <tr>
        <td align=right colspan=2><u><b><% Response.Write  Myset1(3) %></b></u></td>
    </tr>
   
    <tr>
        <td colspan=2><br /></td></tr>
    <tr>
        <td align=right width=100><b>اسم الباحث</b></td>
        <td><b>:<% Response.Write  Myset1(4) %></b></td>
    </tr>
    <tr>
        <td align=right><b>بالاشتراك مع</b></td>
        <td><b>
            <table border=0 width=400>
		        <%
		        Myset1.MoveFirst 
		        do while not myset1.eof %>
		        <tr>
		             <td><b>:<%=myset1(6)%></b></td>
		             <td><b><%=myset1(7)%></b></td>
		             <td><b><%=myset1(8)%></b></td>
		             <td><b><%=myset1(9)%></b></td>
		             <td><b><%=myset1(10)%></b></td>
		             <td><b><%=myset1(11)%></b></td>
		        </tr>
		        <%myset1.MoveNext 
		
		        loop
		        Myset1.MoveFirst
		        %>
	    	</table>
        </b></td>
    </tr>
    
    <tr>
        <td align=right><b>تاريخ اعتماد تسجيل البحث</b></td>
        <td><b>:<% Response.Write  Myset1(12) %></b></td>
    </tr>
    <tr>
        <td align=right><b>عنوان البحث</b></td>
        <td><b>:<% Response.Write  Myset1(1) %></b></td>
    </tr>
    <tr>
        <td align=right valign=top colspan=2><b>طريقة البحث</b></td>
        
     </tr>
     <tr>
        <td></td>
        <td align=justify >
        <table border=1 bordercolor="#6e0e0f" cellpadding=0 cellspacing=0 >
        <tr>
        <td><P align=justify><b><% Response.Write  Myset1(2) %></b></P>
        
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