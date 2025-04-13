<script>


function openwindow(href)
{
 
win1= new String()
if (win1)
{
//win1.close

win1=window.open(href,'Node_Data','menubar=0,toolbar=0,scrollbars=1,location=0,status=1,resizable=1,width=500 ,height=300 '  );
win1.focus()
}
else

win1=window.open(href,'Node_Data','menubar=0,toolbar=0,scrollbars=1,location=0,status=1,resizable=1 ,width=500 ,height=300'  );

}
</script>
		        
        
   <%   

 
'dim DataBaseConection,strSQL,rst
         
         set DataBaseConection=Server.CreateObject("ADODB.Connection")
         DataBaseConection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= ""c:\Inetpub\wwwroot\info\info_center.mdb"" "  & ";"
         set rst = Server.CreateObject("ADODB.Recordset")

'DataBaseConection.ConnectionTimeout=myConn_ConnectionTimeout
'DataBaseConection.CommandTimeout   =myConn_CommandTimeout
DataBaseConection.Mode=3
DataBaseConection.Open DataBaseConection.ConnectionString,"admin",""
 
%>