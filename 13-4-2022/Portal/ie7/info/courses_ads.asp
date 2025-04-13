<%@ Language=VBScript %>
<!--#include file="temp/top.asp" -->
<!--#include file=common/connection.inc-->

<%
id=Request.QueryString("dept")
pub=Request.QueryString("pub")
%> 
<!--Response.Write(id)-->

 <DIV align=center>

 <b><FONT color="#ffff00" size=5  face="tarnsparnt arabic">
<%
set dbrsname=server.CreateObject("adodb.recordset")
dbrsname.Open "select * from Departments where dept_id='"&id&"'",DataBaseConection,1,3,1
Response.Write(dbrsname("dept_name"))
%> 
 </FONT>  </b>
 <BR>
<FONT color="#FFFFFF" size=4 face="tarnsparnt arabic">
 ==================</FONT><FONT color="#00ffff" size=4 face="tarnsparnt arabic"><BR>
</FONT>
<FONT color="#000080" size=4 face="tarnsparnt arabic">
 <span style="background-color: #FFFF00">—”Ê„ «‘ —«ﬂ œÊ—«  «·Õ«”» «·«·Ï </span> 
</FONT>
<br>
 &nbsp;</DIV>
 
 <DIV align=left>
<br>
<%
set dbdeptrs1=server.CreateObject("adodb.recordset")

dbdeptrs1.Open "SELECT distinct course_types.course_type_id,course_types.course_type  from course_types,courses where course_types.course_type_id=courses.course_type_id ",DataBaseConection,1,3,1

fcont=dbdeptrs1.Fields.count-1 %>
<TABLE  bordercolor=yellow  cellSpacing=2  cellPadding=1   align=center  border=1  width=500 style="WIDTH: 500px;" dir=rtl>
<tr>
<td width="888" height="41" bgcolor="#FBFBF4" align="center" bordercolor="#F0F8FF">

<form method="get"  name="selectpub" >
<p align="center">&nbsp; 
<b> »—Ã«¡  ÕœÌœ ‰Ê⁄ «·œÊ—… «· œ—Ì»Ì…</b>

<input type="hidden" name="dept" size="11"  value=<%=id%> >
<select name="pub" size="1" onclick="JavaScript:ChangeAction()"  onchange="JavaScript:ChangeAction()" onselect="JavaScript:ChangeAction() return false;" >
 <%do while not dbdeptrs1.EOF
   %>
 <option value=<%= dbdeptrs1("course_type_id")%>  > <%= dbdeptrs1("course_type")%> </option>
<% dbdeptrs1.MoveNext
loop
%>
<option value=0    > ﬂ· «·œÊ—«  «· œ—Ì»Ì… </option>
<option value=null selected  >&nbsp;&nbsp;&nbsp; </option>
</select></b>
&nbsp;&nbsp; <b><input type="submit" value="»ÕÀ" id=submit2 name=submit2></b>

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
dbdeptrs.Open "select * from q_courses where dept_id ='"&id&"'  order by course_id" ,DataBaseConection,1,3,1
else
dbdeptrs.Open "select * from q_courses where dept_id ='"&id&"'and course_type_id="&pub&"  order by course_id" ,DataBaseConection,1,3,1
end if
fcont=dbdeptrs.Fields.count-1 %>
<TABLE  bordercolor=yellow  cellSpacing=2  cellPadding=1   align=center  border=1  width=500 style="WIDTH: 500px; HEIGHT: 84px" dir=ltr>
<tr  bgcolor=white >
 <td bordercolor=cornsilk colspan=3>
<font color="#2D6586" size=5 face=Arial > <b>
<p align=center>
<%if pub=0 then %>
ﬂ· «·œÊ—«  «· œ—Ì»Ì…
<%else%>
<%= dbdeptrs("course_type")%> 
<%end if%>
</p>
</b>
</font>
</td>
</tr>
<tr>
  <% for i=fcont-5 to 3 step-1%> 
  
<td bordercolor=cornsilk align=center valign=middle >
<font color=yellow size=4 face=Arial> <b>
<%=dbdeptrs(i).Name %>
</b></font>
 </td>
<%next%>
</tr>
 <%do while not dbdeptrs.EOF   %>
 <tr>
  <% for i=fcont-5 to 3 step-1%> 
  
   <td  bordercolor=cornsilk align=right >
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