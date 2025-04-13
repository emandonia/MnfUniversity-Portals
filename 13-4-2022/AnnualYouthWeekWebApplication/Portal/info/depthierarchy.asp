<%@ Language=VBScript %>
<!--#include file="temp/top.asp" -->
<!--#include file=common/connection.inc-->

<%
id=Request.QueryString("dept")
%> 
 <DIV align=center>
 <b><FONT color="#ffff00" size=5  face="tarnsparnt arabic"><%
set dbrsname=server.CreateObject("adodb.recordset")
dbrsname.Open "select * from Departments where dept_id='"&id&"'",DataBaseConection,1,3,1
Response.Write(dbrsname("dept_name"))
%> 
<br>
 </FONT>   
<FONT color=#ffffff size=4 face="tarnsparnt arabic">
 </FONT>
 <br>
</DIV>
 
 
<DIV align=left>
<%
set dbdeptrs3=server.CreateObject("adodb.recordset")
dbdeptrs3.Open "select * from depthierarchy where dept_id ='"&id&"' order by hier_id ",DataBaseConection,1,3,1
fcont=dbdeptrs3.Fields.count-1 %>
<TABLE    cellSpacing=2  cellPadding=0 dir=ltr  align=center  border=0  width=540 style="WIDTH: 540px; HEIGHT: 38px">

 <%do while not dbdeptrs3.EOF %>
 <tr>
  <% for i=1 to fcont-2 %> 
  
   <td  align=right >
      <P align=right>
       <font color=#ffffff> <b><FONT size=3 face=tarnsparntarabic><%=dbdeptrs3(i)%> </FONT> </b></font>
      </P></td>
       <% next %>
  </tr>
<% dbdeptrs3.MoveNext
loop
%>
 <% dbdeptrs3.Close%>
</TABLE></DIV>
<!--#include file="temp/bottom.inc" -->
