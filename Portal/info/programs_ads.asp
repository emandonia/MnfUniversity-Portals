<%@ Language=VBScript %>
<!--#include file="temp/top.asp" -->
<!--#include file=common/connection.inc-->


<%
id=Request.QueryString("dept")
pub=Request.QueryString("pub")
%> 

 <DIV align=center>

 <b><FONT color="#ffff00" size=5  face="tarnsparnt arabic">
<%
set dbrsname=server.CreateObject("adodb.recordset")
dbrsname.Open "select * from Departments where dept_id='"&id&"'",DataBaseConection,1,3,1
Response.Write(dbrsname("dept_name"))
%> 
<br>
 </FONT>  </b>
 <BR>
<FONT color="#ffffff" size=4 face="tarnsparnt arabic">
 ==================<br>
</FONT>
<FONT color="#000080" size=4 face="tarnsparnt arabic">
 <span style="background-color: #FFFF00">»—«„Ã „—ﬂ“ «·„⁄·Ê„«  Ê «·«”⁄«— «·„Õœœ… ·Â«</span></FONT><FONT color="#00ffff" size=4 face="tarnsparnt arabic">
 </FONT>
</DIV>
  
<DIV align=left>
<%
set dbdeptrs1=server.CreateObject("adodb.recordset")

dbdeptrs1.Open "SELECT distinct programs_year from programs ",DataBaseConection,1,3,1

fcont=dbdeptrs1.Fields.count-1 %>
<TABLE  bordercolor=yellow  cellSpacing=2 dir=rtl cellPadding=1   align=center  border=1  width=500 >
<tr>
<td width="888" height="41" bgcolor=white align="center"  >

<form method="get"  name="selectpub" >
<p align="center">&nbsp; 
<b>
<b> »—Ã«¡  ÕœÌœ ”‰… «·»—«„Ã</b>

<input type="hidden" name="dept" size="11"  value=<%=id%> >
<select name="pub" size="1" onclick="JavaScript:ChangeAction()"  onchange="JavaScript:ChangeAction()" onselect="JavaScript:ChangeAction() return false;" >
 <%do while not dbdeptrs1.EOF
   %>
 <option value=<%= dbdeptrs1("programs_year")%>  > <%= dbdeptrs1("programs_year")%> </option>
<% dbdeptrs1.MoveNext
loop
%>
<option value=0    > ﬂ· «·»—«„Ã </option>
<option value=null selected  >&nbsp;&nbsp;&nbsp; </option>
</select></b>
&nbsp;&nbsp; <b><input type="submit" value="»Õ‹‹À" id=submit2 name=submit2></b>

 </p>
</td>
</tr>
<tr>
<td>

</td>
</tr>
</form>
 <tr>
 </table>

<br /><br />
<div  align=left>
<%
set dbdeptrs=server.CreateObject("adodb.recordset")
if pub=0 then
dbdeptrs.Open "select * from Q_PROGRAMS where dept_id ='"&id&"'  order by program_no " ,DataBaseConection,1,3,1
else
dbdeptrs.Open "select * from Q_PROGRAMS where dept_id ='"&id&"'and programs_year="&pub&"  order by program_no" ,DataBaseConection,1,3,1
end if
fcont=dbdeptrs.Fields.count-1 %>
<TABLE  bordercolor=yellow  cellSpacing=2  cellPadding=1 dir=ltr  align=center  border=1  width=500 >
<tr  bgcolor=white >
 <td   colspan=2 >
<font color="#2D6586" size=5 face=Arial > <b>
<p align=center>
<%if pub=0 then %>
ﬂ· «·»—«„Ã
<%else%>
<%= dbdeptrs("programs_year")%> »—«„Ã ”‰…
<%end if%>
</p>
</b>
</font>
</td>
</tr>
<tr>
  <% for i=fcont-1 to 3 step-1 %> 
  
<td  bordercolor=cornsilk align=center>
<font color="#00ffff" size=3 face=Arial> <b>
<%=dbdeptrs(i).Name %>
</b></font>
&nbsp;</td>
<%next%>
</tr>
 <%do while not dbdeptrs.EOF   %>
 <tr>
  <% for i=fcont-1 to 3 step-1 %> 
  
   <td   bordercolor=cornsilk align=right >
      <P align=right>
       <font color=white size=3 face=Arial> <b><FONT size=3 face=Arial><%=dbdeptrs(i)%> </FONT> </b></font>
      </P></td>
        <% next %> 
 </tr>
<% dbdeptrs.MoveNext
loop
%>
 <% dbdeptrs.Close
 dbdeptrs1.Close
 %>
</TABLE>
</div>
<!--#include file="temp/bottom.inc" -->