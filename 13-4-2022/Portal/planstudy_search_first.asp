 
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1256">
</head>
<body>
<!--#include file=common/palnstudyconnection.inc-->
<!--#include file="global/SyncSearch_planstudy.asp" -->	


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
session("sname")=""
session("rname")=""
session("pname")=""
session("rec")=""
         
            sql=sql&" and name like '%"&session("name")&"%'"
             

    set facultyset=Server.CreateObject("ADODB.Recordset")
    set deptset=Server.CreateObject("ADODB.Recordset")
    set degreeset=Server.CreateObject("ADODB.Recordset")
 facultyset.open " Select * from FacultyTable order by FacultyID   ",DataBaseConectionplan,1,3,1
deptset.open " Select * from Department      ",DataBaseConectionplan,1,3,1
 

%>
<center><br />
<p class=phead><u>������ ����� ��������� ���������� ������� ��� �������</u></p>
<br />
</center>
 
<table     height="276" width="360" cellpadding=0 cellspacing=0  border=0 dir=rtl align=center>
 <FORM action="search_planstudy.asp" method=POST id=send_to_friend name=send_to_friend onsubmit="return valid(this);">

<tr ><td ><b>��������</b></TD>
<TD>
	<select name="filed" onchange="SyncJoin22();">
		<option value="">�� �������
		<% Do while Not facultyset.EOF%>
		
			 
			<option value="<%=facultyset("FacultyID")%>" > <%=facultyset("FacultyName")%> <%
       
		
			facultyset.Movenext
		Loop

		%>
		</select>
		</TD></TR> 

 <tr ><td ><b>�������</b></td>
 <td><select name=skill style="width=170;">
 
            <option value="">�� �������
                
				 <% 
              if false then 
             
             Do while Not deptset.EOF%>
		
			 
			<option value="<%=deptset("DeptID")%>" > <%=deptset("DeptName")%> <%
       
		
			deptset.Movenext
		Loop
		end if
		%>
  	
</select> 
</td>
</tr>
<tr >
	<td>
		<b>��� �������</b>
	</td>
	<td>
		<select name="deg" >
		<option value="">����
			<option value="2" >�������
			<option value="1" >�������
		</select>
	</td>
</tr>
 
<tr >
	<td>
		<b>����� ���������</b>
	</td>
	<td>
		<input type=text name=rname size=35>
	</td>
</tr>
<tr >
	<td>
		<b>����� ���������</b>
	</td>
	<td>
		<input type=text name=pname size=35>
	</td>
</tr>
<tr >
	<td>
		 <b>��� ��������� �� ������</b>
	</td>
	<td>
		<select name=rec >
		<option value="10">10
		<option value="20">20
		<option value="30">30
		<option value="40">40
		</select>
	</td>
</tr>
<tr  >

	<td colspan=2><center>
	<input type="submit" value="������"    alt="SUBMIT" > 
		&nbsp;&nbsp;&nbsp;
	<input type="reset" value="������"   alt="clear" > 
		
	</td>
	
</tr>
<tr>
<td colspan=2><br /><br /><font color=firebrick>** ���� ����� �������� �� ��� �� ���� �����</font>
</td>
</tr>
</table>
</FORM>
 
</body>
</html>