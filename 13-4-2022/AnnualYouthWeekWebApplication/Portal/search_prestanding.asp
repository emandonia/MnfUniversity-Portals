<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1256">
</head>
<body>

                         

<!--#include file=common/preconnection.inc-->
   
 <%
Session("id")=""

dim filed,name
    filed=request("filed")
    if filed <>"" then
    session("filed")=filed
    else
    filed=session("filed")
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
    sql="SELECT DISTINCT MainData.ArabicAddress,MainData.Faculty, MainData.PaperId, MainData.MainResName, Mid(MainData.ReashWay,1,300) AS summ  "&_
            " FROM FacultyTable, MainData where MainData.Faculty = FacultyTable.FacultyID "

       
            if session("filed") <> "" then
            
            sql=sql&" and MainData.Faculty= "&session("filed")
            
            end if 
            
            if session("rname") <> "" then
            
            sql=sql&" and MainData.MainResName like '%"&session("rname")&"%'"
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
 'response.Write sql
'response.End 
         newset.open sql,DataBaseConectionprestand,1,3,1
         
	  %>
	  <center><font face=" imes new roman" size=5><b>   قاعدة البيانات للأبحاث المتميزة لأعضاء هيئة التدريس بجامعة المنوفية قبل نشرها     </b></font><br />       </center>
	  
	  <%
			if NOT(newset.EOF) then
			
         newset.MoveFirst 
				newset.PageSize = session("rec")
				if cint(m_nPageIndex) <= newset.PageCount then
				newset.AbsolutePage= m_nPageIndex
				end if
				 
				m_nNumOfRecords = newset.RecordCount
				m_nPageCount    = newset.PageCount
			
				  
		dim i	
		 
        Response.Write "<center><font face=Arial size=3 color=darkblue>"
 			Response.Write " <font size=3><strong> <br><br>"
			%> <%
			 

        Response.Write " <table width=480 border=0 valign=top dir=rtl align=center>"
         
        For i=1 To newset.PageSize		
		'*********************************Drawing search result***********************
		 
			   Response.Write "<tr><td bgcolor=yellow><font face=arial size=2>"
			  href="prepaperDetails.asp?id="& newset(2)
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
								[<A href="search_outstanding.asp?m_nPageIndex=<%=i%>"><%=i%></A>]
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