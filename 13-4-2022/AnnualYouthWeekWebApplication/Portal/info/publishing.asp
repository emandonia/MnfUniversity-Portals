<%@ Language=VBScript %>
<!--#include file="temp/top.asp" -->
<!--#include file=common/connection.inc-->

<HEAD>
<META NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<script>
/*
Highlight Link script
By JavaScript Kit (http://javascriptkit.com)
Over 400+ free scripts here!
Above notice MUST stay entact for use
*/
function highlight(which,color){
if (document.all||document.getElementById)
which.style.backgroundColor=color
}

var next=1
var last=8
img1=new Image()
img2=new Image()
img3=new Image()
img4=new Image()
img5=new Image()
img6=new Image()
img7=new Image()
img8=new Image()
img9=new Image()
img10=new Image()


function Gofindit(){
var searchfor = document.selectpub.pub.value;
{
document.selectpub.setfolder.value ="publishes/publish"+searchfor+"/";

img1.src=document.selectpub.setfolder.value+"1.jpg"

img2.src=document.selectpub.setfolder.value+"2.jpg"

img3.src=document.selectpub.setfolder.value+"3.jpg"

img4.src=document.selectpub.setfolder.value+"4.jpg"

img5.src=document.selectpub.setfolder.value+"5.jpg"

img6.src=document.selectpub.setfolder.value+"6.jpg"

img7.src=document.selectpub.setfolder.value+"7.jpg"

img8.src=document.selectpub.setfolder.value+"8.jpg"

img9.src=document.selectpub.setfolder.value+"9.jpg"

img10.src=document.selectpub.setfolder.value+"10.jpg"

}
}


function slideshownext()
{
Gofindit();
next=next+1

if (next>=9)
(next=1)
document.IMG1.src=eval("img"+next+".src")
last=next

}

function slideshowprior(count)
{
Gofindit();
last=last-1
if (last<=0)
(last=count)
document.IMG1.src=eval("img"+last+".src")
next=last
}

function slideshowfirst()
{
Gofindit();
next=1
document.IMG1.src=eval("img"+next+".src")
last=next
}
function slideshowlast(count)
{
Gofindit();
last=count
document.IMG1.src=eval("img"+last+".src")
next=last
}

</script>
</HEAD>
<BODY  bgcolor=white onload="javascript:Gofindit()" onchange="javascript:Gofindit()">

<DIV align=right >

<%
id=Request.QueryString("dept")
%> 

<DIV align=center style="width: 540; height: 900">
<%
set dbdeptrs3=server.CreateObject("adodb.recordset")
dbdeptrs3.Open "select * from publishings where dept_id ='"&id&"' order by publish_year ",DataBaseConection,1,3,1
fcont=dbdeptrs3.Fields.count-1 %>
<div align="center">
<TABLE  bordercolor=#DCDCDC  cellSpacing=1  border=1  width="521" height="900" bgcolor="#E7E6DC"  >
<tr>
<td width="500" height="41" bgcolor="#FBFBF4" align="center" bordercolor="#F0F8FF">
<form method="post" action="main_page.asp" name="selectpub">
<p align="center">&nbsp; 
<b>
<input type="hidden" name="setfolder" size="11">
<b> »—Ã«¡  ÕœÌœ «·‰‘—… «·œÊ—Ì…</b><span lang="ar-sa"> :</span>&nbsp;
<select name="pub" size="1" onclick="JavaScript:slideshowfirst()"  onchange="JavaScript:slideshowfirst()" onselect="JavaScript:slideshowfirst()">
 <%do while not dbdeptrs3.EOF %>
 
 <option value=<%= dbdeptrs3("publish_no")%>  > <%= dbdeptrs3("publish_desc")%> </option>
  
<% dbdeptrs3.MoveNext
loop
%>
<option value="48" selected   > «·‰‘—… «·«ŒÌ—… </option>
</select></b>
<% dbdeptrs3.Close %></p>
</td>
<!-- <b><input type="submit" value="»ÕÀ"></b>-->
</tr>
</form>
 <tr>
     <td  width="500" height="800">
 <IMG  height=900  alt="«·’›Õ… «·«Ê·Ï"   src="JavaScript:slideshowfirst()"   width=490 border=2 name=IMG1 >
 </td>
 <td   width=125 height="900" valign=top style=" text-justify: kashida" bgcolor="#E7E6DC" bordercolor="#F0F8FF">
   <b>
   <A href="JavaScript:slideshowfirst()"   target=_top> 
      <font color=darkblue size=2 face="Arial"> «·’›Õ… «·«Ê·Ï </FONT>
       </A></B>
 <br>
 <br>
 <br>
   <b>
  <A href="JavaScript:slideshowprior(8)"   target=_top> 
      <font color=darkblue size=2 face="Arial">  «·’›Õ… «·”«»ﬁ… </FONT>
       </A></B>
  <br>
 <br>
 <br>
   <b>
  <A  href="JavaScript:slideshownext()" > 
      <font color=darkblue size=2 face="Arial">  «·’›Õ… «· «·Ì… </FONT>
       </A></B>
  <br>
 <br>
 <br>
   <b>
   <A href="JavaScript:Gofindit(),slideshowlast(8)"   target=_top> 
      <font color=darkblue size=2 face="Arial">   «·’›Õ… «·«ŒÌ—… </FONT>
       </A></B>
     <br>
 <br>
 <br>
     </td>
 
 </tr>
</TABLE>
</div>
</DIV>
</DIV>
<!--#include file="temp/bottom.inc" -->