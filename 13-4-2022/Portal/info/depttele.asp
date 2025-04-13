<!--#include file="temp/top.asp" -->
<!--#include file=common/connection.inc-->

<%
id=Request.QueryString("dept")
%> 

<DIV align=center>
 <b><FONT color=#ffff00 size=5  face=cursive>
<%
set dbrsname=server.CreateObject("adodb.recordset")
dbrsname.Open "select * from Departments where dept_id='"&id&"'",DataBaseConection,1,3,1
Response.Write(dbrsname("dept_name"))
%> 
<br>
 </FONT>  </b> 
<FONT color=#FFFFFF size=4 face=Andalus>
 ==================</FONT><FONT color=brown size=4 face=Andalus><br><br>
</FONT>
</DIV>
 
 
<DIV align=center>
<%
set dbdeptrs4=server.CreateObject("adodb.recordset")
dbdeptrs4.Open "select * from departments  where dept_id ='"&id&"'",DataBaseConection,1,3,1
fcont=dbdeptrs4.Fields.count-1 %>
<TABLE    cellSpacing=2  cellPadding=2 dir=ltr align=center  border=1  width=394 style="WIDTH: 394px; HEIGHT: 54px">

 <%do while not dbdeptrs4.EOF %>
 
  <% for i=2 to fcont   %> 
   <tr>
   <td   align=right >
      <P align=right>
       <font color=#ffffff> <b><FONT size=3 face=tarnsparntarabic><%=dbdeptrs4(i)%> </FONT> </b></font>
      </P></td>
      <td   align=right  width=100>
      <P align=right>
       <font color=#ffff00> <b><FONT size=3 face=tarnsparntarabic ><%=dbdeptrs4(i).Name%> </FONT> </b></font>
      </P></td>
      </tr>
  <% next %> 
  
 <% dbdeptrs4.MoveNext
loop
%>

<% dbdeptrs4.Close%>
</TABLE>
</DIV>
<!--#include file="temp/bottom.inc" -->
