<script>

 
function SyncJoin22()
{
	
	var cc = window.send_to_friend.filed.value
 
	// fill the Node array
	obj = window.send_to_friend.skill;
	updateJoin1(obj, arrJoinItemList, cc);

}

function updateJoin1(obj, arr, cc)
{
	
	var iCount
	
	// remove the old ones
	for(iCount = 0; iCount < obj.length; iCount++)
	{
		while (obj.hasChildNodes())
		 {
   obj.removeChild(obj.lastChild);
} 
		
	}
	// fill the new ones
	var Join
	var nod
	
	for( iCount = 0; iCount < arr.length; iCount++)
	{
		Join = arr[iCount];
		if (Join.mcc == cc || cc == 0)
		{
			nod = Join.node();
			obj.insertBefore(nod);
		}
	}
}

function Join1(id, name, cc) 
{
	var mid;
	var mname;
	var mcc;
	
	this.mid = id;
	this.mname = name	;
	this.mcc = cc;
	this.node = Join_node1;
}

function Join_node1()
{
	var nod=document.createElement("OPTION");
	nod.innerText = this.mname;
	nod.value = this.mid;
	return nod;
}

<%
	dim strSQLCom
	dim rsJoin
	 set rsJoin=Server.CreateObject("ADODB.Recordset")
	' get all the depts
 	rsJoin.open " Select * from Department ",DataBaseConectionplan,1,3,1
  	'set rsJoin = DataBaseConection.Execute(strSQLCom)
	%>

	var arrJoinItemList = new Array();
	
	<%	
	dim iCount
	iCount = 0
	do until rsJoin.eof
		%>
		arrJoinItemList[<%=iCount%>] = new Join1('<%=rsJoin("DeptID")%>', '<%=trim(rsJoin("DeptName"))%>', '<%=rsJoin("FacultyID")%>');
		<%
		rsJoin.movenext
		iCount = iCount + 1
	loop
	set rsJoin = nothing
	%>
</script>


