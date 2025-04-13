<%@ Language=VBScript %>
<!--#include file="temp/top.asp" -->
<!--#include file=common/connection.inc-->

<DIV align=top >

<%
id=Request.QueryString("dept")
%> 

 <DIV align=center>
 <b><FONT color="#ffff00" size=5  face="tarnsparnt arabic">
<%
set dbrsname=server.CreateObject("adodb.recordset")
dbrsname.Open "select * from Departments where dept_id='"&id&"'",DataBaseConection,1,3,1
Response.Write(dbrsname("dept_name"))
dbrsname.Close%>

<br>
 </FONT>  </b> 
<FONT color="#FFFFFF" size=4 face=Andalus>
 ==================</FONT><FONT color="#00ffff" size=4 face=Andalus><br>
</FONT>
</DIV>
 
 
<DIV align=center>
<%
set dbdeptrs2=server.CreateObject("adodb.recordset")
dbdeptrs2.Open "select * from deptachieve where dept_id ='"&id&"' order by achieve_id ",DataBaseConection,1,3,1
fcont=dbdeptrs2.Fields.count-1 %>
<TABLE    cellSpacing=2  cellPadding=0  align=center  border=0  width=484 style="WIDTH: 484px; HEIGHT: 57px" dir=rtl>
<tr>
<td   bordercolor=white   align=right >
<P align=center>
<b><FONT color="#000080"  size=4   face="tarnsparnt arabic">
<span style="background-color: #FFFF99">≈‰Ã«“«  «·≈œ«—…
<br /></span></FONT>  <FONT color="#00ffff"  size=4   face="tarnsparnt arabic">
<br /></FONT>  </b> </P>
</td>
</tr>
 <%do while not dbdeptrs2.EOF %>
 <tr>
  <% for i=1 to fcont-2 %> 
  
   <td  bordercolor=cornsilk align=right >
      <P style="text-align: justify; text-justify: kashida; line-height: 150%">
       <font color=#ffffff> <b><FONT size=3 face=tarnsparntarabic>-&nbsp;<%=dbdeptrs2(i)%> </FONT> </b></font>
      </P></td>
   <% next %> 
 </tr>
<% dbdeptrs2.MoveNext
loop
%>
 <% dbdeptrs2.Close%>
</TABLE>
</DIV>
<br>


</DIV>

<!--#include file="temp/bottom.inc" -->