<script>


function openwindow(href)
{
 
win1= new String()
if (win1)
{
//win1.close

win1=window.open(href,'Node_Data','menubar=0,toolbar=0,scrollbars=1,location=0,status=1,resizable=1 ,width=500 ,height=300'  );
win1.focus()
}
else

win1=window.open(href,'Node_Data','menubar=0,toolbar=0,scrollbars=1,location=0,status=1,resizable=1 ,width=500 ,height=300'  );

}
</script>
		


<%
         myConn_ConnectionString = "DBQ=c:\database\prestandingResearch.mdb;DefaultDir=c:\database\;Driver={Microsoft Access Driver (*.mdb)};DriverId=25;FIL=MS Access;ImplicitCommitSync=Yes;MaxBufferSize=1000;MaxScanRows=20;PageTimeout=50;SafeTransactions=0;Threads=3;UID=admin;UserCommitSync=Yes;"
      
set DataBaseConectionprestand=Server.CreateObject("ADODB.Connection")
        
DataBaseConectionprestand.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""c:\database\prestandingResearch.mdb"" " & ";"
         

DataBaseConectionprestand.Mode=3
DataBaseConectionprestand.Open DataBaseConectionprestand.ConnectionString,"admin",""
 	 
%>
