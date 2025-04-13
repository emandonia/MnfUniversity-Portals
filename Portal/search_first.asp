 
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1256">
</head>
<body>
<!--#include file=common/staffconnection.inc-->
<!--#include file="global/SyncSearch_staff.asp" -->	

<script>
 function valid(formname)
{
temp=false;
 
a=formname.filed.options[formname.filed.selectedIndex].value
b=formname.skill.options[formname.skill.selectedIndex].value
c=formname.deg.options[formname.deg.selectedIndex].value
d=formname.name.value

if(a=="" && b=="" && c=="" && d=="")
{
temp=true;

}

if (temp)
{

alert("Please enter one of search Craiteria  ");
formname.filed.focus();
return false;
}

 
}

</script>
   		




<%
Session("id")=""
session("filed")=""
session("skill")=""
session("deg")=""
session("name")=""
session("rec")=""
            
            sql=sql&" and name like '%"&session("name")&"%'"
             

    set facultyset=Server.CreateObject("ADODB.Recordset")
    set deptset=Server.CreateObject("ADODB.Recordset")
    set degreeset=Server.CreateObject("ADODB.Recordset")

facultyset.open " Select * from FacultyTable order by FacultyID   ",DataBaseConectionstaff,1,3,1
deptset.open " Select * from DepartmentTable where FacultyID='10'    ",DataBaseConectionstaff,1,3,1
degreeset.open " Select * from degrees   ",DataBaseConectionstaff,1,3,1


%>
<FORM action="search.asp" method=POST id=send_to_friend name=send_to_friend onsubmit="return valid(this);"><center><table class=maintable cellpadding=5 cellspacing=3  border=0 dir=rtl>
<tr class=maintr>
	<td colspan=2><center>
		<STRONG> هيئـــة التــدريــــس</strong>
	</td>
</tr>

<tr ><td >الكليــة</TD>
<TD>
	<select name="filed" onchange="SyncJoin1();">
		<option value="">الكل
		<% Do while Not facultyset.EOF%>
		
			 
			<option value="<%=facultyset("FacultyID")%>" > <%=facultyset("FacultyName")%> <%
       
		
			facultyset.Movenext
		Loop

		%>
		</select>		</TD></TR><br><br>

 <tr ><td >القســم</td>
 <td><select name=skill>
 
            <option value="">الكل
                
				<option value="" >   	
</select> </td></tr>
<tr >
	<td>
		الدرجــة
	</td>
	<td>
		<select name="deg" >
		<option value="">الكل
			 <%
			Do while Not degreeset.EOF	
			%>
				<option value="<%= degreeset("degree_name")%>" > <%= degreeset("degree_name")%> <%
	
	         
			degreeset.Movenext
			Loop
	 
		    %>
		</select>
	</td>
</tr><tr >
	<td>		الاســم	</td>	<td>
		<input type=text name=name size=35>	</td></tr>
<tr >
	<td>		عدد السجــلات في الصفحة 	</td>	<td>
		<select name=rec >		<option value="10">10		<option value="20">20		<option value="30">30		<option value="40">40
		</select>	</td></tr>
<tr bgcolor=#b7b3d7>
	<td colspan=2><center>
		<input type=submit value="Search" style="width:120">
		&nbsp;&nbsp;&nbsp;		<input type=reset value="Clear Choices" style="width:120" >
	</td>
</tr></table>
</FORM>
<strong>

في حالة وجود اي خطا في البيانات برجاء ا رسال المعلومات الصحيحة علي</strong>
                                                             <a href="mailto:Ehab_khalil@mailer.eun.eg"> Ehab_khalil@mailer.eun.eg</a>

</body>
</html>