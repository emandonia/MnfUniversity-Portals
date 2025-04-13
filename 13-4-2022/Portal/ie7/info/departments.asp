<%@ Language=VBScript %>
<!--#include file="temp/top.asp" -->
<!--#include file=common/connection.inc-->

<%
id=Request.QueryString("dept")
%> 

 <body bgcolor="#2E6586">
 <table border=0 width=100% cellpadding=0 cellspacing=0 align=center>
    <tr>
        <td  align=center>
            <b> <FONT color=#FFFFff size=5  face=tarnsparntarabic><u> 
<%
set dbrsname=server.CreateObject("adodb.recordset")
dbrsname.Open " select * from Departments where dept_id='"&id&"'",DataBaseConection,1,3,1
Response.Write(dbrsname("dept_name"))
%> 
 </u></FONT>   
        </td>
    </tr>
    <tr> 
        <td valign=top align=center>
        <%
set dbdeptrs5=server.CreateObject("adodb.recordset")
dbdeptrs5.Open "select * from deptmessage where dept_id ='"&id&"' and m_id<3  order by m_id",DataBaseConection,1,3,1
fcont=dbdeptrs5.Fields.count-1 %>
<TABLE   cellSpacing=1  cellPadding=0   align=center  style="WIDTH: 380; HEIGHT: 78px" border="0">

<tr>
<td  align=center valign="top" >
<img border="0" src="images/mes1.jpg" width="165" height="76"></td>
</tr>
 <%
do while not dbdeptrs5.EOF
 %>
 <tr>
  <% for i=fcont to 2 step-1 %> 
  
   <td  bordercolor=cornsilk align=right height="23" >
      <P align=right style="line-height: 150%">
       <font color=#FFFFff> <b><FONT size=3 face=tarnsparntarabic>-&nbsp;<%=dbdeptrs5(i)%> </FONT> </b></font>
      </P></td>
        <% next %> 
  </tr>
 <tr>
      <td>
       
      </td>
      </tr>
<% dbdeptrs5.MoveNext
loop
%>
 
<% 
dbdeptrs5.Close

%>
<tr><td align=left colspan=2><A href="deptmessage.asp?dept=<%=id%>" target=_top style="color:yellow">ссу╥э╧...</A></td></tr>

</TABLE>
        </td>
    </tr>
    <tr>    
        <td valign=top align=center>
        <%
set dbdeptrs4=server.CreateObject("adodb.recordset")
dbdeptrs4.Open "select * from deptfutureplane where dept_id ='"&id&"' and future_id<3  order by future_id",DataBaseConection,1,3,1
fcont=dbdeptrs4.Fields.count-1 %>
<TABLE   cellSpacing=1  cellPadding=0   align=center  style="WIDTH: 380px; HEIGHT: 111px" border="0">
<tr >
<td  align=center  >
<img border="0" src="images/fut1.jpg" width="165" height="76"></td>
</tr>
 <%
do while not dbdeptrs4.EOF
 %>
 <tr>
  <% for i=fcont to 2 step-1 %> 
  
   <td  bordercolor=cornsilk align=right >
      <P align=right style="line-height: 150%">
       <font color=#FFFFff> <b><FONT size=3 face=tarnsparntarabic>-&nbsp;<%=dbdeptrs4(i)%> </FONT> </b></font>
      </P></td>
        <% next %> 
  </tr>
 
<% dbdeptrs4.MoveNext
loop
%>
 
<% 
dbdeptrs4.Close

%>

<tr><td align=left colspan=2><A href="deptfutureplane.asp?dept=<%=id%>" target=_top style="color:yellow">
	ссу╥э╧...</A></td></tr>

</TABLE>
        </td>
    </tr>
    <tr>
        <td valign=top align=center>
        <%
set dbdeptrs6=server.CreateObject("adodb.recordset")
dbdeptrs6.Open "select * from deptgoals where dept_id ='"&id&"' and g_id<3  order by g_id",DataBaseConection,1,3,1
fcont=dbdeptrs6.Fields.count-1 %>
<TABLE  bordercolor=silver  cellSpacing=2  cellPadding=1   align=center  border=0   style="WIDTH: 380; HEIGHT: 106px">
<tr>
<td  align=center valign="top" >
<img border="0" src="images/gol1.jpg" width="165" height="76"></td>
</tr>
 <%
do while not dbdeptrs6.EOF
 %>
 <tr>
  <% for i=fcont to 2 step-1 %> 
  
   <td  bordercolor=cornsilk align=right >
      <P align=right style="line-height: 150%">
       <font color=#FFFFff> <b><FONT size=3 face=tarnsparntarabic>-&nbsp;<%=dbdeptrs6(i)%> </FONT> </b></font>
      </P></td>
        <% next %> 
  </tr>
 <tr>
      <td>
       
      </td>
      </tr>
<% dbdeptrs6.MoveNext
loop
%>
 
<% 
dbdeptrs6.Close

%>
<tr><td align=left colspan=2><A href="deptgoals.asp?dept=<%=id%>" target=_top style="color:yellow">ссу╥э╧...</A></td></tr>

</TABLE>

        </td>
    </tr>   
    <tr> 
        <td align=center>
        <%

set dbdeptrs=server.CreateObject("adodb.recordset")
dbdeptrs.Open "select * from Deptservices where dept_id ='"&id&"' and ser_id<=2 order by ser_id",DataBaseConection,1,3,1
fcont=dbdeptrs.Fields.count-1 %>
<TABLE   cellSpacing=1  cellPadding=0   align=center  style="WIDTH: 380; HEIGHT: 111px" border="0">

<tr >
<td  align=center  >
<img border="0" src="images/sep1.jpg" width="165" height="76"></td>
</tr>
 <%
 do while not dbdeptrs.EOF
  %>
 <tr>
  <% for i=1 to fcont-2 %> 
  
   <td  align=right >
    <p style="line-height: 150%">
    <b><FONT    
      color=#FFFFff size=3 face=tarnsparntarabic>-&nbsp;<%=dbdeptrs(i)%> </FONT> </b>
    </td>
     <% next %> 
        </tr>
       <tr>
      <td>
      <br>
      </td>
      </tr>
<% dbdeptrs.MoveNext
loop 
%>
 
<%
dbdeptrs.Close

%>
<tr><td align=left colspan=2><A href="deptservices.asp?dept=<%=id%>" target=_top style="color:yellow">
	ссу╥э╧...</A></td></tr>
</TABLE>
        </td>
    </tr>
    <tr>
        <td valign=top align=center>
        <%
set dbdeptrs3=server.CreateObject("adodb.recordset")
dbdeptrs3.Open "select * from depthierarchy where dept_id ='"&id&"' and hier_id <3 order by hier_id",DataBaseConection,1,3,1
fcont=dbdeptrs3.Fields.count-1 %>
<TABLE   cellSpacing=0  cellPadding=0 border=0   align=center  style="WIDTH: 380px; HEIGHT: 126px"  >
<tr  >
 <td   colspan=3 valign="top" height="30">
  <p align="center">
	<img border="0" src="images/her1.jpg" width="165" height="76"></td>
  </tr>
 <%
 do while not dbdeptrs3.EOF %>
 <tr>
   <% for i=1 to fcont-3 %> 
     <td  align=right >
      <b><FONT     
      color=#ffffff size=3 face="tarnsparnt arabic"><%=dbdeptrs3(i)%> </FONT> </b>
      </td>
       <% next %>
       </tr>
       <% dbdeptrs3.MoveNext
loop
%>

<% 

dbdeptrs3.Close

%>
<tr><td align=left colspan=2><A href="depthierarchy.asp?dept=<%=id%>" target=_top style="color:yellow">ссу╥э╧...</A></td></tr>
</TABLE>
        </td>
    </tr>    
     
    
     <tr>
        <td valign=top align=center>
        <%
set dbdeptrs2=server.CreateObject("adodb.recordset")
dbdeptrs2.Open "select * from deptachieve where dept_id ='"&id&"' and  achieve_id <=1 order by achieve_id ",DataBaseConection,1,3,1
fcont=dbdeptrs2.Fields.count-1 %>
<TABLE  bordercolor=silver  cellSpacing=2  cellPadding=1   align=center  border=0   style="WIDTH: 380px; HEIGHT: 106px">
<tr>
<td  align=center valign="top" >
<img border="0" src="images/eng1.jpg" width="165" height="76"></td>
</tr>
 <%
do while not dbdeptrs2.EOF 
  %>
 <tr>
  <% for i=1 to fcont-2 %> 
  
   <td  bordercolor=cornsilk align=right >
      <P align=right>
       <font color=#FFFFff> <b><FONT size=3 face=tarnsparntarabic><%=dbdeptrs2(i)%> </FONT> </b></font>
      </P></td>
  <% next %> 
  </tr>
  
<% dbdeptrs2.MoveNext
loop
%>
 <%
  
  dbdeptrs2.Close
 
  %>
<tr><td align=left colspan=2><A href="deptachieve.asp?dept=<%=id%>" target=_top style="color:yellow">ссу╥э╧...</A></td></tr>

 </TABLE>
        </td>
     </tr>    
    
     
 </table>
 
 

<!--#include file="temp/bottom.inc" -->
