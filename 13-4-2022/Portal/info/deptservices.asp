<%@ Language=VBScript %>
<!--#include file="temp/top.asp" -->
<!--#include file=common/connection.inc-->

<%
id=Request.QueryString("dept")
%> 

 <div align=center>
 <b><font color="#ffff00" size=5  face="tarnsparnt arabic">
<%
set dbrsname=server.CreateObject("adodb.recordset")
dbrsname.Open "select * from Departments where dept_id='"&id&"'",DataBaseConection,1,3,1
Response.Write(dbrsname("dept_name"))
%> 
<br>
 </font>  </b> 
<font color="#ffffff" size=4 face="tarnsparnt arabic">
 ==================<br> 
</font>
</div>
 
<div  align=left>
<%
set dbdeptrs=server.CreateObject("adodb.recordset")
dbdeptrs.Open "select * from Deptservices where dept_id ='"&id&"' order by ser_id",DataBaseConection,1,3,1
fcont=dbdeptrs.Fields.count-1 %>
<table  bordercolor=sienna  cellspacing=2  cellpadding=1  dir=rtl  align=center  border=0  width=440 style="WIDTH: 440px; HEIGHT: 84px">
<tr>
<td     align=right >
<p align=center>
<b><font color="#000080"  size=4  face="tarnsparnt arabic">
<span style="background-color: #FFFF99">«Œ ’«’«  «·«œ«—…</span>
</font>  </b><br /><br /> </p>
</td>
</tr>
 
 <%do while not dbdeptrs.EOF   %>
 <tr>
  <% for i=1 to fcont-2 %> 
  
   <td  bordercolor=cornsilk align=right >
      <p style="text-align: justify; text-justify: kashida; line-height: 150%">
       <font color=#FFFFFF size=3 face=tarnsparntarabic> <b><font size=3 face=tarnsparntarabic>-&nbsp;<%=dbdeptrs(i)%> </font> </b></font>
      </p></td>
   <% next %> 
 </tr>
<% dbdeptrs.MoveNext
loop
%>
 <% dbdeptrs.Close%>
</table>
</div>
<!--#include file="temp/bottom.inc" -->