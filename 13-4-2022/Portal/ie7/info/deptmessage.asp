<!--#include file="temp/top.asp" -->
<!--#include file=common/connection.inc-->

<%
id=Request.QueryString("dept")
%> 

<DIV align=center>
 <b><FONT color="#FFFF00" size=5  face="tarnsparntarabic">
<%
set dbrsname=server.CreateObject("adodb.recordset")
dbrsname.Open "select * from Departments where dept_id='"&id&"'",DataBaseConection,1,3,1
Response.Write(dbrsname("dept_name"))
%> 
<br>
 </FONT>  </b> 
<FONT color="#FFFFFF" size=4 face=Andalus>
 ==================</FONT><FONT color="#00ffff" size=4 face=Andalus><br>
</FONT>
</DIV>
 
 
<DIV align=center>
<%
set dbdeptrs5=server.CreateObject("adodb.recordset")
dbdeptrs5.Open "select * from deptmessage where dept_id ='"&id&"' order by m_id",DataBaseConection,1,3,1
fcont=dbdeptrs5.Fields.count-1 %>
<TABLE    cellSpacing=2  cellPadding=0  align=center  border=0  width=540 style="WIDTH: 540px; HEIGHT: 23px" dir=rtl>

<tr>
<td     align=right >
<P align=center>
<b><FONT color="#000080"  size=4   face="tarnsparnt arabic">
<span style="background-color: #FFFF99">—”«·… «·≈œ«—…
</span>
</FONT> <font color="#000080"><span style="background-color: #FFFF99"> <br />
</span></font><br /> </b> </P>
</td>
</tr>
 <%do while not dbdeptrs5.EOF %>
 <tr>
  <% for i=fcont to 2  step-1%> 
  
   <td   align=right >
      <P style="text-align: justify; text-justify: kashida; line-height: 150%">
       <font color=#ffffff> <b><FONT size=3 face=tarnsparntarabic>-&nbsp;<%=dbdeptrs5(i)%> </FONT> <br /><br /></b></font>
      </P></td>
  <% next %> 
  </tr>
<% dbdeptrs5.MoveNext
loop
%>

<% dbdeptrs5.Close%>
</TABLE>
</DIV>
<!--#include file="temp/bottom.inc" -->