 

<!--#include file=common/outconnection.inc-->
<html>
<head>
<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
</head>
<body>

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
    set degreeset=Server.CreateObject("ADODB.Recordset")

facultyset.open " Select * from FacultyTable order by FacultyID   ",DataBaseConectionoutstand,1,3,1
 

%>
<table id="Table_01" width="580"  border="0" cellpadding="0" cellspacing="0" align=center>
	<tr>
		<td align=center><font face=" imes new roman" size=5><b>
   قاعدة البيانات للأبحاث المتميزة لأعضاء هيئة التدريس بجامعة المنوفية المنشورة في دوريات عالمية  
   </b></font><br /><br /></td>
			</tr>
			<tr>
		
		<td colspan="2"  height="296"  valign=top align=center>
 
<table     height="276" width=350 cellpadding=0 cellspacing=0  border=0 dir=rtl align=center>
 <FORM action="search_outstanding.asp" method=POST id=send_to_friend name=send_to_friend onsubmit="return valid(this);">

<tr ><td width="100"><b>الكليــة</b></TD>
<TD>
	<select name="filed">
		<option value="">كل الكليات
		<% Do while Not facultyset.EOF%>
		
			 
			<option value="<%=facultyset("FacultyID")%>" > <%=facultyset("FacultyName")%> <%
       
		
			facultyset.Movenext
		Loop

		%>
		</select>
		</TD></TR> 

 


	<td>
		<b>إســم الباحـــث</b>
	</td>
	<td>
		<input type=text name=rname size=35>
	</td>
</tr>
<tr >
	<td>
		<b>عنوان البـــحث</b>
	</td>
	<td>
		<input type=text name=pname size=35>
	</td>
</tr>
<tr >
	<td>
		 <b>عدد السجــلات في الصفحة</b>
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
	<input type="submit" value="بحـــث"    alt="SUBMIT" > 
		&nbsp;&nbsp;&nbsp;
	<input type="reset" value="مســـح"   alt="clear" > 	
		
		
	</td>
</tr>
</form>
</table>
 </td>	
 </tr>
</table>
	
</body>
</html>