

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1256">
</head>
<body>
<!--#include file=common/poststudyconnection.inc-->
   
 <%
Session("id")=""

dim filed,skill,deg,name
    filed=request("filed")
    if filed <>"" then
    session("filed")=filed
    else
    filed=session("filed")
    end if
    skill=request("skill")
    if skill <>"" then
    session("skill")=skill
    else
    skill=session("skill")
    end if
    deg=request("deg")
    if deg <>"" then
    session("deg")=deg
    else
    deg=session("deg")
    end if
    name=request("sname")
    if name <>"" then
    session("sname")=name
    else
    name=session("sname")
    end if
    rname=request("rname")
    if rname <>"" then
    session("rname")=rname
    else
    rname=session("rname")
    end if
    pname=request("pname")
    if pname <>"" then
    session("pname")=pname
    else
    pname=session("pname")
    end if
    rec=request("rec")
    if rec <>"" then
    session("rec")=rec
    else
    rec=session("rec")
    end if
    
     
   
  

    set newset=Server.CreateObject("ADODB.Recordset")
    
 
dim sql 
    sql="SELECT DISTINCT MainData.ArabicAddress,MainData.Faculty, MainData.PaperId, MainData.StudentName, Mid(MainData.Summary,1,300) AS summ , Studytype.StudyId "&_
         " FROM  Studytype ,FacultyTable,Department, MainData where Department.DeptID = MainData.Department and FacultyTable.FacultyID = Department.FacultyID   and Studytype.StudyId = MainData.StudyType "

   
 
 
            if session("filed") <> "" then
            
            sql=sql&" and MainData.Faculty= "&session("filed")
            
            end if 
            if session("skill") <> "" then
            
            sql=sql&" and MainData.Department= "&session("skill")
            
            end if
            if session("deg") <> "" then
            
            sql=sql&" and MainData.StudyType = '"&session("deg")& "'"
            
            end if
            if session("sname") <> "" then
            
            sql=sql&" and SUPERVISORS.SuperName like '%"&session("sname")&"%'"
             
            end if
            if session("rname") <> "" then
            
            sql=sql&" and MainData.StudentName like '%"&session("rname")&"%'"
            end if
            if session("pname") <> "" then
            
            sql=sql&" and  MainData.ArabicAddress like '%"&session("pname")&"%'"
            end if
         
         if request("m_nPageIndex") ="" then
         m_nPageIndex=1
         else
         m_nPageIndex=request("m_nPageIndex")
         end if
       
newset.MaxRecords = 5000
sql=sql&";" 
'  response.Write sql
'response.End 
         newset.open sql,DataBaseConectionpost,1,3,1
         
	  %>
	  <center><font face=" imes new roman" size=6><b>   رسائل الماجستير و الدكتوراة     </b></font><br />       </center>
	  
	  <%
			if NOT(newset.EOF) then
			dim a,b
         a=0
         b=0
         do while not newset.EOF
         if newset(5)="1" then
         a=a+1
         else
         b=b+1     
         end if
      
         newset.MoveNext 
         loop
         newset.MoveFirst 
				newset.PageSize = session("rec")
				if cint(m_nPageIndex) <= newset.PageCount then
				newset.AbsolutePage= m_nPageIndex
				end if
				 
				m_nNumOfRecords = newset.RecordCount
				m_nPageCount    = newset.PageCount
			
				  
		dim i	
		 
        Response.Write "<center><font face=Arial size=3 color=darkred>"
 			Response.Write " <font size=3><strong> <br><br>"
			%> <%
			  response.Write "<div  align=right><u> "
        response.Write "عدد الرسائل المطابقة"
         response.Write "</u>"
			  response.Write "&nbsp;&nbsp;&nbsp;&nbsp; <font color=firebrick>"
response.Write a
response.Write "&nbsp;"
response.Write "  رسالة دكتوراة"
 response.Write "&nbsp;/&nbsp;"
response.Write b
response.Write "&nbsp;"
response.Write " رسالة ماجسيتر "
response.Write "</font>"

        Response.Write " <br><br><table width=480 border=0 valign=top dir=rtl align=center>"
         
        
        For i=1 To newset.PageSize		
		'*********************************Drawing search result***********************
		 
			   Response.Write "<tr><td bgcolor=wheat><font face=arial size=2>"
			  href="paperDetails.asp?id="& newset(2)
			    %><a href="javascript:openwindow('<%=href%>')"><B><% Response.Write  newset(0)
			    Response.Write "</a></td></tr><tr><td>"
		        Response.Write newset("summ")
		        Response.Write "....&nbsp;&nbsp;&nbsp;&nbsp;"%><a href="javascript:openwindow('<%=href%>')"><font color=darkred><b>المزيــد </font></td></tr><tr><td><b><font color=red>
		        <%response.Write "  اســم البـاحــث"
		        %>&nbsp;:&nbsp;&nbsp;<%
		        Response.Write newset(3)
		        
		        Response.Write "</td></tr>" 
		       
		        Response.Write "<tr><td><hr width=300</td></tr>" 
		        
		 	'*****************************************************************************
			newset.MoveNext
			if newset.EOF then EXIT FOR
		Next 
		Response.Write "</table>"
		%>
			
		<%
 
  
          	  
          
 
			
			Dim  strTempFilter
			
			 
			Response.Write("<TABLE width='80%' align='CENTER' border=0>")
				Response.Write("<TR>")
					Response.Write("<TD align='LEFT'>")
						 
						For i=1 To m_nPageCount
							if NOT(i=m_nPageIndex) then
%>
								[<A href="search_poststudy.asp?m_nPageIndex=<%=i%>"><%=i%></A>]
	 <%		 		    else
			 					Response.Write("[<FONT color='#ff0000' size=-1 face='TAHOMA'>"&i&"</FONT>]")
							end if
						Next
					Response.Write("</TD>")
				Response.Write("</TR>")
			Response.Write("</TABLE>")
				
		  		 

		
		else
				m_nNumOfRecords = 0
				m_nPageCount    = 0
				
				Response.Write("<BR><BR><BR>")
				Response.Write("<center><FONT color='#ff0000' face='TAHOMA' size=-1>")
				Response.Write("لا يوجد سجلات متاحه")
				Response.Write("</FONT>")
			end if
		%>

</body>
</html>