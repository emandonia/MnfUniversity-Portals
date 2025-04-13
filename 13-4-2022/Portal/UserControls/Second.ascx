<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Second.ascx.cs" Inherits="Second" %>
<style type="text/css">

    .auto-style1 {
        width: 100%;
    }
    .auto-style3 {
        direction: ltr;
    }
    .auto-style2 {
        direction: ltr;
        font-weight: 700;
    }
    .auto-style4 {
        direction: ltr;
        font-weight: 700;
        height: 32px;
    }
    .auto-style5 {
        direction: ltr;
        height: 32px;
    }
    .auto-style6 {
        direction: ltr;
        font-weight: 700;
        height: 45px;
    }
</style>
<p>
    <asp:FormView ID="FormView3" runat="server" DataSourceID="SqlDataSource3" Height="629px" Width="578px">
        <EditItemTemplate>
            AcdNumber:
            <asp:TextBox ID="AcdNumberTextBox" runat="server" Text='<%# Bind("AcdNumber") %>' />
            <br />
            Name:
            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
            <br />
            Case:
            <asp:TextBox ID="CaseTextBox" runat="server" Text='<%# Bind("Case") %>' />
            <br />
            P1:
            <asp:TextBox ID="P1TextBox" runat="server" Text='<%# Bind("P1") %>' />
            <br />
            Code2:
            <asp:TextBox ID="Code2TextBox" runat="server" Text='<%# Bind("Code2") %>' />
            <br />
            G:
            <asp:TextBox ID="GTextBox" runat="server" Text='<%# Bind("G") %>' />
            <br />
            PE:
            <asp:TextBox ID="PETextBox" runat="server" Text='<%# Bind("PE") %>' />
            <br />
            CountOfAcdNumber:
            <asp:TextBox ID="CountOfAcdNumberTextBox" runat="server" Text='<%# Bind("CountOfAcdNumber") %>' />
            <br />
            GGA1:
            <asp:TextBox ID="GGA1TextBox" runat="server" Text='<%# Bind("GGA1") %>' />
            <br />
            GGA2:
            <asp:TextBox ID="GGA2TextBox" runat="server" Text='<%# Bind("GGA2") %>' />
            <br />
            GGA3:
            <asp:TextBox ID="GGA3TextBox" runat="server" Text='<%# Bind("GGA3") %>' />
            <br />
            GGA4:
            <asp:TextBox ID="GGA4TextBox" runat="server" Text='<%# Bind("GGA4") %>' />
            <br />
            GGA5:
            <asp:TextBox ID="GGA5TextBox" runat="server" Text='<%# Bind("GGA5") %>' />
            <br />
            GGA6:
            <asp:TextBox ID="GGA6TextBox" runat="server" Text='<%# Bind("GGA6") %>' />
            <br />
            GGA7:
            <asp:TextBox ID="GGA7TextBox" runat="server" Text='<%# Bind("GGA7") %>' />
            <br />
            GGA8:
            <asp:TextBox ID="GGA8TextBox" runat="server" Text='<%# Bind("GGA8") %>' />
            <br />
            GGA9:
            <asp:TextBox ID="GGA9TextBox" runat="server" Text='<%# Bind("GGA9") %>' />
            <br />
            GGA10:
            <asp:TextBox ID="GGA10TextBox" runat="server" Text='<%# Bind("GGA10") %>' />
            <br />
            GGA11:
            <asp:TextBox ID="GGA11TextBox" runat="server" Text='<%# Bind("GGA11") %>' />
            <br />
            GGA12:
            <asp:TextBox ID="GGA12TextBox" runat="server" Text='<%# Bind("GGA12") %>' />
            <br />
            GGA13:
            <asp:TextBox ID="GGA13TextBox" runat="server" Text='<%# Bind("GGA13") %>' />
            <br />
            GGA14:
            <asp:TextBox ID="GGA14TextBox" runat="server" Text='<%# Bind("GGA14") %>' />
            <br />
            GGA15:
            <asp:TextBox ID="GGA15TextBox" runat="server" Text='<%# Bind("GGA15") %>' />
            <br />
            GGA16:
            <asp:TextBox ID="GGA16TextBox" runat="server" Text='<%# Bind("GGA16") %>' />
            <br />
            GGA17:
            <asp:TextBox ID="GGA17TextBox" runat="server" Text='<%# Bind("GGA17") %>' />
            <br />
            GGA18:
            <asp:TextBox ID="GGA18TextBox" runat="server" Text='<%# Bind("GGA18") %>' />
            <br />
            GGA19:
            <asp:TextBox ID="GGA19TextBox" runat="server" Text='<%# Bind("GGA19") %>' />
            <br />
            GGA20:
            <asp:TextBox ID="GGA20TextBox" runat="server" Text='<%# Bind("GGA20") %>' />
            <br />
            GGB1:
            <asp:TextBox ID="GGB1TextBox" runat="server" Text='<%# Bind("GGB1") %>' />
            <br />
            GGB2:
            <asp:TextBox ID="GGB2TextBox" runat="server" Text='<%# Bind("GGB2") %>' />
            <br />
            B1N:
            <asp:TextBox ID="B1NTextBox" runat="server" Text='<%# Bind("B1N") %>' />
            <br />
            B2N:
            <asp:TextBox ID="B2NTextBox" runat="server" Text='<%# Bind("B2N") %>' />
            <br />
            GGC1:
            <asp:TextBox ID="GGC1TextBox" runat="server" Text='<%# Bind("GGC1") %>' />
            <br />
            GGC2:
            <asp:TextBox ID="GGC2TextBox" runat="server" Text='<%# Bind("GGC2") %>' />
            <br />
            GGC3:
            <asp:TextBox ID="GGC3TextBox" runat="server" Text='<%# Bind("GGC3") %>' />
            <br />
            GGD1:
            <asp:TextBox ID="GGD1TextBox" runat="server" Text='<%# Bind("GGD1") %>' />
            <br />
            GGD2:
            <asp:TextBox ID="GGD2TextBox" runat="server" Text='<%# Bind("GGD2") %>' />
            <br />
            GGD3:
            <asp:TextBox ID="GGD3TextBox" runat="server" Text='<%# Bind("GGD3") %>' />
            <br />
            GGD4:
            <asp:TextBox ID="GGD4TextBox" runat="server" Text='<%# Bind("GGD4") %>' />
            <br />
            GGD5:
            <asp:TextBox ID="GGD5TextBox" runat="server" Text='<%# Bind("GGD5") %>' />
            <br />
            GGD6:
            <asp:TextBox ID="GGD6TextBox" runat="server" Text='<%# Bind("GGD6") %>' />
            <br />
            D1N:
            <asp:TextBox ID="D1NTextBox" runat="server" Text='<%# Bind("D1N") %>' />
            <br />
            D2N:
            <asp:TextBox ID="D2NTextBox" runat="server" Text='<%# Bind("D2N") %>' />
            <br />
            D3N:
            <asp:TextBox ID="D3NTextBox" runat="server" Text='<%# Bind("D3N") %>' />
            <br />
            D4N:
            <asp:TextBox ID="D4NTextBox" runat="server" Text='<%# Bind("D4N") %>' />
            <br />
            D5N:
            <asp:TextBox ID="D5NTextBox" runat="server" Text='<%# Bind("D5N") %>' />
            <br />
            D6N:
            <asp:TextBox ID="D6NTextBox" runat="server" Text='<%# Bind("D6N") %>' />
            <br />
            memo:
            <asp:TextBox ID="memoTextBox" runat="server" Text='<%# Bind("memo") %>' />
            <br />
            University:
            <asp:TextBox ID="UniversityTextBox" runat="server" Text='<%# Bind("University") %>' />
            <br />
            Faculty:
            <asp:TextBox ID="FacultyTextBox" runat="server" Text='<%# Bind("Faculty") %>' />
            <br />
            Presedent:
            <asp:TextBox ID="PresedentTextBox" runat="server" Text='<%# Bind("Presedent") %>' />
            <br />
            Dean:
            <asp:TextBox ID="DeanTextBox" runat="server" Text='<%# Bind("Dean") %>' />
            <br />
            Head:
            <asp:TextBox ID="HeadTextBox" runat="server" Text='<%# Bind("Head") %>' />
            <br />
            Dept:
            <asp:TextBox ID="DeptTextBox" runat="server" Text='<%# Bind("Dept") %>' />
            <br />
            Date:
            <asp:TextBox ID="DateTextBox" runat="server" Text='<%# Bind("Date") %>' />
            <br />
            Year:
            <asp:TextBox ID="YearTextBox" runat="server" Text='<%# Bind("Year") %>' />
            <br />
            AcdYear:
            <asp:TextBox ID="AcdYearTextBox" runat="server" Text='<%# Bind("AcdYear") %>' />
            <br />
            A1N:
            <asp:TextBox ID="A1NTextBox" runat="server" Text='<%# Bind("A1N") %>' />
            <br />
            A2N:
            <asp:TextBox ID="A2NTextBox" runat="server" Text='<%# Bind("A2N") %>' />
            <br />
            A3N:
            <asp:TextBox ID="A3NTextBox" runat="server" Text='<%# Bind("A3N") %>' />
            <br />
            A4N:
            <asp:TextBox ID="A4NTextBox" runat="server" Text='<%# Bind("A4N") %>' />
            <br />
            A5N:
            <asp:TextBox ID="A5NTextBox" runat="server" Text='<%# Bind("A5N") %>' />
            <br />
            A6N:
            <asp:TextBox ID="A6NTextBox" runat="server" Text='<%# Bind("A6N") %>' />
            <br />
            A7N:
            <asp:TextBox ID="A7NTextBox" runat="server" Text='<%# Bind("A7N") %>' />
            <br />
            A8N:
            <asp:TextBox ID="A8NTextBox" runat="server" Text='<%# Bind("A8N") %>' />
            <br />
            A9N:
            <asp:TextBox ID="A9NTextBox" runat="server" Text='<%# Bind("A9N") %>' />
            <br />
            A10N:
            <asp:TextBox ID="A10NTextBox" runat="server" Text='<%# Bind("A10N") %>' />
            <br />
            A11N:
            <asp:TextBox ID="A11NTextBox" runat="server" Text='<%# Bind("A11N") %>' />
            <br />
            A12N:
            <asp:TextBox ID="A12NTextBox" runat="server" Text='<%# Bind("A12N") %>' />
            <br />
            A13N:
            <asp:TextBox ID="A13NTextBox" runat="server" Text='<%# Bind("A13N") %>' />
            <br />
            A14N:
            <asp:TextBox ID="A14NTextBox" runat="server" Text='<%# Bind("A14N") %>' />
            <br />
            A15N:
            <asp:TextBox ID="A15NTextBox" runat="server" Text='<%# Bind("A15N") %>' />
            <br />
            A16N:
            <asp:TextBox ID="A16NTextBox" runat="server" Text='<%# Bind("A16N") %>' />
            <br />
            A17N:
            <asp:TextBox ID="A17NTextBox" runat="server" Text='<%# Bind("A17N") %>' />
            <br />
            A18N:
            <asp:TextBox ID="A18NTextBox" runat="server" Text='<%# Bind("A18N") %>' />
            <br />
            A19N:
            <asp:TextBox ID="A19NTextBox" runat="server" Text='<%# Bind("A19N") %>' />
            <br />
            A20N:
            <asp:TextBox ID="A20NTextBox" runat="server" Text='<%# Bind("A20N") %>' />
            <br />
            C1N:
            <asp:TextBox ID="C1NTextBox" runat="server" Text='<%# Bind("C1N") %>' />
            <br />
            C2N:
            <asp:TextBox ID="C2NTextBox" runat="server" Text='<%# Bind("C2N") %>' />
            <br />
            C3N:
            <asp:TextBox ID="C3NTextBox" runat="server" Text='<%# Bind("C3N") %>' />
            <br />
            CATEGORY:
            <asp:TextBox ID="CATEGORYTextBox" runat="server" Text='<%# Bind("CATEGORY") %>' />
            <br />
            R:
            <asp:TextBox ID="RTextBox" runat="server" Text='<%# Bind("R") %>' />
            <br />
            GEE1:
            <asp:TextBox ID="GEE1TextBox" runat="server" Text='<%# Bind("GEE1") %>' />
            <br />
            EE1N:
            <asp:TextBox ID="EE1NTextBox" runat="server" Text='<%# Bind("EE1N") %>' />
            <br />
            EE1M:
            <asp:TextBox ID="EE1MTextBox" runat="server" Text='<%# Bind("EE1M") %>' />
            <br />
            Expr1:
            <asp:TextBox ID="Expr1TextBox" runat="server" Text='<%# Bind("Expr1") %>' />
            <br />
            Vice Dean:
            <asp:TextBox ID="Vice_DeanTextBox" runat="server" Text='<%# Bind("[Vice Dean]") %>' />
            <br />
            Name1:
            <asp:TextBox ID="Name1TextBox" runat="server" Text='<%# Bind("Name1") %>' />
            <br />
            Name2:
            <asp:TextBox ID="Name2TextBox" runat="server" Text='<%# Bind("Name2") %>' />
            <br />
            Name3:
            <asp:TextBox ID="Name3TextBox" runat="server" Text='<%# Bind("Name3") %>' />
            <br />
            Name4:
            <asp:TextBox ID="Name4TextBox" runat="server" Text='<%# Bind("Name4") %>' />
            <br />
            Name5:
            <asp:TextBox ID="Name5TextBox" runat="server" Text='<%# Bind("Name5") %>' />
            <br />
            Name6:
            <asp:TextBox ID="Name6TextBox" runat="server" Text='<%# Bind("Name6") %>' />
            <br />
            Name7:
            <asp:TextBox ID="Name7TextBox" runat="server" Text='<%# Bind("Name7") %>' />
            <br />
            Name8:
            <asp:TextBox ID="Name8TextBox" runat="server" Text='<%# Bind("Name8") %>' />
            <br />
            Name9:
            <asp:TextBox ID="Name9TextBox" runat="server" Text='<%# Bind("Name9") %>' />
            <br />
            Name10:
            <asp:TextBox ID="Name10TextBox" runat="server" Text='<%# Bind("Name10") %>' />
            <br />
            Name11:
            <asp:TextBox ID="Name11TextBox" runat="server" Text='<%# Bind("Name11") %>' />
            <br />
            Name12:
            <asp:TextBox ID="Name12TextBox" runat="server" Text='<%# Bind("Name12") %>' />
            <br />
            SUM:
            <asp:TextBox ID="SUMTextBox" runat="server" Text='<%# Bind("SUM") %>' />
            <br />
            P:
            <asp:TextBox ID="PTextBox" runat="server" Text='<%# Bind("P") %>' />
            <br />
            point:
            <asp:TextBox ID="pointTextBox" runat="server" Text='<%# Bind("point") %>' />
            <br />
            B1L:
            <asp:TextBox ID="B1LTextBox" runat="server" Text='<%# Bind("B1L") %>' />
            <br />
            depart:
            <asp:TextBox ID="departTextBox" runat="server" Text='<%# Bind("depart") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <InsertItemTemplate>
            AcdNumber:
            <asp:TextBox ID="AcdNumberTextBox" runat="server" Text='<%# Bind("AcdNumber") %>' />
            <br />
            Name:
            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
            <br />
            Case:
            <asp:TextBox ID="CaseTextBox" runat="server" Text='<%# Bind("Case") %>' />
            <br />
            P1:
            <asp:TextBox ID="P1TextBox" runat="server" Text='<%# Bind("P1") %>' />
            <br />
            Code2:
            <asp:TextBox ID="Code2TextBox" runat="server" Text='<%# Bind("Code2") %>' />
            <br />
            G:
            <asp:TextBox ID="GTextBox" runat="server" Text='<%# Bind("G") %>' />
            <br />
            PE:
            <asp:TextBox ID="PETextBox" runat="server" Text='<%# Bind("PE") %>' />
            <br />
            CountOfAcdNumber:
            <asp:TextBox ID="CountOfAcdNumberTextBox" runat="server" Text='<%# Bind("CountOfAcdNumber") %>' />
            <br />
            GGA1:
            <asp:TextBox ID="GGA1TextBox" runat="server" Text='<%# Bind("GGA1") %>' />
            <br />
            GGA2:
            <asp:TextBox ID="GGA2TextBox" runat="server" Text='<%# Bind("GGA2") %>' />
            <br />
            GGA3:
            <asp:TextBox ID="GGA3TextBox" runat="server" Text='<%# Bind("GGA3") %>' />
            <br />
            GGA4:
            <asp:TextBox ID="GGA4TextBox" runat="server" Text='<%# Bind("GGA4") %>' />
            <br />
            GGA5:
            <asp:TextBox ID="GGA5TextBox" runat="server" Text='<%# Bind("GGA5") %>' />
            <br />
            GGA6:
            <asp:TextBox ID="GGA6TextBox" runat="server" Text='<%# Bind("GGA6") %>' />
            <br />
            GGA7:
            <asp:TextBox ID="GGA7TextBox" runat="server" Text='<%# Bind("GGA7") %>' />
            <br />
            GGA8:
            <asp:TextBox ID="GGA8TextBox" runat="server" Text='<%# Bind("GGA8") %>' />
            <br />
            GGA9:
            <asp:TextBox ID="GGA9TextBox" runat="server" Text='<%# Bind("GGA9") %>' />
            <br />
            GGA10:
            <asp:TextBox ID="GGA10TextBox" runat="server" Text='<%# Bind("GGA10") %>' />
            <br />
            GGA11:
            <asp:TextBox ID="GGA11TextBox" runat="server" Text='<%# Bind("GGA11") %>' />
            <br />
            GGA12:
            <asp:TextBox ID="GGA12TextBox" runat="server" Text='<%# Bind("GGA12") %>' />
            <br />
            GGA13:
            <asp:TextBox ID="GGA13TextBox" runat="server" Text='<%# Bind("GGA13") %>' />
            <br />
            GGA14:
            <asp:TextBox ID="GGA14TextBox" runat="server" Text='<%# Bind("GGA14") %>' />
            <br />
            GGA15:
            <asp:TextBox ID="GGA15TextBox" runat="server" Text='<%# Bind("GGA15") %>' />
            <br />
            GGA16:
            <asp:TextBox ID="GGA16TextBox" runat="server" Text='<%# Bind("GGA16") %>' />
            <br />
            GGA17:
            <asp:TextBox ID="GGA17TextBox" runat="server" Text='<%# Bind("GGA17") %>' />
            <br />
            GGA18:
            <asp:TextBox ID="GGA18TextBox" runat="server" Text='<%# Bind("GGA18") %>' />
            <br />
            GGA19:
            <asp:TextBox ID="GGA19TextBox" runat="server" Text='<%# Bind("GGA19") %>' />
            <br />
            GGA20:
            <asp:TextBox ID="GGA20TextBox" runat="server" Text='<%# Bind("GGA20") %>' />
            <br />
            GGB1:
            <asp:TextBox ID="GGB1TextBox" runat="server" Text='<%# Bind("GGB1") %>' />
            <br />
            GGB2:
            <asp:TextBox ID="GGB2TextBox" runat="server" Text='<%# Bind("GGB2") %>' />
            <br />
            B1N:
            <asp:TextBox ID="B1NTextBox" runat="server" Text='<%# Bind("B1N") %>' />
            <br />
            B2N:
            <asp:TextBox ID="B2NTextBox" runat="server" Text='<%# Bind("B2N") %>' />
            <br />
            GGC1:
            <asp:TextBox ID="GGC1TextBox" runat="server" Text='<%# Bind("GGC1") %>' />
            <br />
            GGC2:
            <asp:TextBox ID="GGC2TextBox" runat="server" Text='<%# Bind("GGC2") %>' />
            <br />
            GGC3:
            <asp:TextBox ID="GGC3TextBox" runat="server" Text='<%# Bind("GGC3") %>' />
            <br />
            GGD1:
            <asp:TextBox ID="GGD1TextBox" runat="server" Text='<%# Bind("GGD1") %>' />
            <br />
            GGD2:
            <asp:TextBox ID="GGD2TextBox" runat="server" Text='<%# Bind("GGD2") %>' />
            <br />
            GGD3:
            <asp:TextBox ID="GGD3TextBox" runat="server" Text='<%# Bind("GGD3") %>' />
            <br />
            GGD4:
            <asp:TextBox ID="GGD4TextBox" runat="server" Text='<%# Bind("GGD4") %>' />
            <br />
            GGD5:
            <asp:TextBox ID="GGD5TextBox" runat="server" Text='<%# Bind("GGD5") %>' />
            <br />
            GGD6:
            <asp:TextBox ID="GGD6TextBox" runat="server" Text='<%# Bind("GGD6") %>' />
            <br />
            D1N:
            <asp:TextBox ID="D1NTextBox" runat="server" Text='<%# Bind("D1N") %>' />
            <br />
            D2N:
            <asp:TextBox ID="D2NTextBox" runat="server" Text='<%# Bind("D2N") %>' />
            <br />
            D3N:
            <asp:TextBox ID="D3NTextBox" runat="server" Text='<%# Bind("D3N") %>' />
            <br />
            D4N:
            <asp:TextBox ID="D4NTextBox" runat="server" Text='<%# Bind("D4N") %>' />
            <br />
            D5N:
            <asp:TextBox ID="D5NTextBox" runat="server" Text='<%# Bind("D5N") %>' />
            <br />
            D6N:
            <asp:TextBox ID="D6NTextBox" runat="server" Text='<%# Bind("D6N") %>' />
            <br />
            memo:
            <asp:TextBox ID="memoTextBox" runat="server" Text='<%# Bind("memo") %>' />
            <br />
            University:
            <asp:TextBox ID="UniversityTextBox" runat="server" Text='<%# Bind("University") %>' />
            <br />
            Faculty:
            <asp:TextBox ID="FacultyTextBox" runat="server" Text='<%# Bind("Faculty") %>' />
            <br />
            Presedent:
            <asp:TextBox ID="PresedentTextBox" runat="server" Text='<%# Bind("Presedent") %>' />
            <br />
            Dean:
            <asp:TextBox ID="DeanTextBox" runat="server" Text='<%# Bind("Dean") %>' />
            <br />
            Head:
            <asp:TextBox ID="HeadTextBox" runat="server" Text='<%# Bind("Head") %>' />
            <br />
            Dept:
            <asp:TextBox ID="DeptTextBox" runat="server" Text='<%# Bind("Dept") %>' />
            <br />
            Date:
            <asp:TextBox ID="DateTextBox" runat="server" Text='<%# Bind("Date") %>' />
            <br />
            Year:
            <asp:TextBox ID="YearTextBox" runat="server" Text='<%# Bind("Year") %>' />
            <br />
            AcdYear:
            <asp:TextBox ID="AcdYearTextBox" runat="server" Text='<%# Bind("AcdYear") %>' />
            <br />
            A1N:
            <asp:TextBox ID="A1NTextBox" runat="server" Text='<%# Bind("A1N") %>' />
            <br />
            A2N:
            <asp:TextBox ID="A2NTextBox" runat="server" Text='<%# Bind("A2N") %>' />
            <br />
            A3N:
            <asp:TextBox ID="A3NTextBox" runat="server" Text='<%# Bind("A3N") %>' />
            <br />
            A4N:
            <asp:TextBox ID="A4NTextBox" runat="server" Text='<%# Bind("A4N") %>' />
            <br />
            A5N:
            <asp:TextBox ID="A5NTextBox" runat="server" Text='<%# Bind("A5N") %>' />
            <br />
            A6N:
            <asp:TextBox ID="A6NTextBox" runat="server" Text='<%# Bind("A6N") %>' />
            <br />
            A7N:
            <asp:TextBox ID="A7NTextBox" runat="server" Text='<%# Bind("A7N") %>' />
            <br />
            A8N:
            <asp:TextBox ID="A8NTextBox" runat="server" Text='<%# Bind("A8N") %>' />
            <br />
            A9N:
            <asp:TextBox ID="A9NTextBox" runat="server" Text='<%# Bind("A9N") %>' />
            <br />
            A10N:
            <asp:TextBox ID="A10NTextBox" runat="server" Text='<%# Bind("A10N") %>' />
            <br />
            A11N:
            <asp:TextBox ID="A11NTextBox" runat="server" Text='<%# Bind("A11N") %>' />
            <br />
            A12N:
            <asp:TextBox ID="A12NTextBox" runat="server" Text='<%# Bind("A12N") %>' />
            <br />
            A13N:
            <asp:TextBox ID="A13NTextBox" runat="server" Text='<%# Bind("A13N") %>' />
            <br />
            A14N:
            <asp:TextBox ID="A14NTextBox" runat="server" Text='<%# Bind("A14N") %>' />
            <br />
            A15N:
            <asp:TextBox ID="A15NTextBox" runat="server" Text='<%# Bind("A15N") %>' />
            <br />
            A16N:
            <asp:TextBox ID="A16NTextBox" runat="server" Text='<%# Bind("A16N") %>' />
            <br />
            A17N:
            <asp:TextBox ID="A17NTextBox" runat="server" Text='<%# Bind("A17N") %>' />
            <br />
            A18N:
            <asp:TextBox ID="A18NTextBox" runat="server" Text='<%# Bind("A18N") %>' />
            <br />
            A19N:
            <asp:TextBox ID="A19NTextBox" runat="server" Text='<%# Bind("A19N") %>' />
            <br />
            A20N:
            <asp:TextBox ID="A20NTextBox" runat="server" Text='<%# Bind("A20N") %>' />
            <br />
            C1N:
            <asp:TextBox ID="C1NTextBox" runat="server" Text='<%# Bind("C1N") %>' />
            <br />
            C2N:
            <asp:TextBox ID="C2NTextBox" runat="server" Text='<%# Bind("C2N") %>' />
            <br />
            C3N:
            <asp:TextBox ID="C3NTextBox" runat="server" Text='<%# Bind("C3N") %>' />
            <br />
            CATEGORY:
            <asp:TextBox ID="CATEGORYTextBox" runat="server" Text='<%# Bind("CATEGORY") %>' />
            <br />
            R:
            <asp:TextBox ID="RTextBox" runat="server" Text='<%# Bind("R") %>' />
            <br />
            GEE1:
            <asp:TextBox ID="GEE1TextBox" runat="server" Text='<%# Bind("GEE1") %>' />
            <br />
            EE1N:
            <asp:TextBox ID="EE1NTextBox" runat="server" Text='<%# Bind("EE1N") %>' />
            <br />
            EE1M:
            <asp:TextBox ID="EE1MTextBox" runat="server" Text='<%# Bind("EE1M") %>' />
            <br />
            Expr1:
            <asp:TextBox ID="Expr1TextBox" runat="server" Text='<%# Bind("Expr1") %>' />
            <br />
            Vice Dean:
            <asp:TextBox ID="Vice_DeanTextBox" runat="server" Text='<%# Bind("[Vice Dean]") %>' />
            <br />
            Name1:
            <asp:TextBox ID="Name1TextBox" runat="server" Text='<%# Bind("Name1") %>' />
            <br />
            Name2:
            <asp:TextBox ID="Name2TextBox" runat="server" Text='<%# Bind("Name2") %>' />
            <br />
            Name3:
            <asp:TextBox ID="Name3TextBox" runat="server" Text='<%# Bind("Name3") %>' />
            <br />
            Name4:
            <asp:TextBox ID="Name4TextBox" runat="server" Text='<%# Bind("Name4") %>' />
            <br />
            Name5:
            <asp:TextBox ID="Name5TextBox" runat="server" Text='<%# Bind("Name5") %>' />
            <br />
            Name6:
            <asp:TextBox ID="Name6TextBox" runat="server" Text='<%# Bind("Name6") %>' />
            <br />
            Name7:
            <asp:TextBox ID="Name7TextBox" runat="server" Text='<%# Bind("Name7") %>' />
            <br />
            Name8:
            <asp:TextBox ID="Name8TextBox" runat="server" Text='<%# Bind("Name8") %>' />
            <br />
            Name9:
            <asp:TextBox ID="Name9TextBox" runat="server" Text='<%# Bind("Name9") %>' />
            <br />
            Name10:
            <asp:TextBox ID="Name10TextBox" runat="server" Text='<%# Bind("Name10") %>' />
            <br />
            Name11:
            <asp:TextBox ID="Name11TextBox" runat="server" Text='<%# Bind("Name11") %>' />
            <br />
            Name12:
            <asp:TextBox ID="Name12TextBox" runat="server" Text='<%# Bind("Name12") %>' />
            <br />
            SUM:
            <asp:TextBox ID="SUMTextBox" runat="server" Text='<%# Bind("SUM") %>' />
            <br />
            P:
            <asp:TextBox ID="PTextBox" runat="server" Text='<%# Bind("P") %>' />
            <br />
            point:
            <asp:TextBox ID="pointTextBox" runat="server" Text='<%# Bind("point") %>' />
            <br />
            B1L:
            <asp:TextBox ID="B1LTextBox" runat="server" Text='<%# Bind("B1L") %>' />
            <br />
            depart:
            <asp:TextBox ID="departTextBox" runat="server" Text='<%# Bind("depart") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            <table class="auto-style1">
                <tr>
                    <td align="center" class="auto-style3" colspan="2">
                        <asp:Label ID="Label1" runat="server" Font-Names="Times New Roman" Font-Size="XX-Large" ForeColor="Red" Text="إشعار نتيجة"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Font-Names="Times New Roman" Font-Size="XX-Large" ForeColor="Red" Text="كلية التربية"></asp:Label>
                    </td>
                    <td align="center" class="auto-style3">
                        <asp:Image ID="Image1" runat="server" Height="72px" ImageUrl="~/images/1.jpg" Width="93px" />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="auto-style2">
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("AcdYear") %>'></asp:Label>
                    </td>
                    <td align="center" class="auto-style3">
                        <asp:Label ID="Label5" runat="server" Text="العام الاكاديمي"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="auto-style2">
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>' />
                    </td>
                    <td align="center" class="auto-style3">
                        <asp:Label ID="Label7" runat="server" Text="الاسم"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="auto-style2">
                        <asp:Label ID="AcdNumberLabel" runat="server" Text='<%# Bind("AcdNumber") %>' />
                    </td>
                    <td align="center" class="auto-style3">
                        <asp:Label ID="Label8" runat="server" Text="الرقم الاكاديمي"></asp:Label>
                    </td>
                </tr>
                <tr align="center" style="border: thick">
                    <td class="auto-style2">
                        <asp:Label ID="RLabel" runat="server" Text='<%# Bind("R") %>' />
                    </td>
                    <td align="center" class="auto-style3">
                        <asp:Label ID="Label9" runat="server" Text="النتيجة"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="auto-style2">
                        <asp:Label ID="P1Label" runat="server" Text='<%# Bind("P1") %>' />
                    </td>
                    <td align="center" class="auto-style3">
                        <asp:Label ID="Label10" runat="server" Text="التقدير العام"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="auto-style4">
                        <asp:Label ID="PLabel" runat="server" Text='<%# Bind("P") %>' />
                    </td>
                    <td align="center" class="auto-style5">
                        <asp:Label ID="Label11" runat="server" Text="النسبة المئوية"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="auto-style2" colspan="2">
                        <asp:Label ID="Label12" runat="server" Font-Size="X-Large" Text="أولا المواد الأساسية"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="auto-style2">
                        <asp:Label ID="GGA1Label" runat="server" Text='<%# Bind("GGA1") %>' />
                    </td>
                    <td align="center" class="auto-style3">
                        <asp:Label ID="A1NLabel" runat="server" Text='<%# Bind("A1N") %>' />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="auto-style2">
                        <asp:Label ID="GGA2Label" runat="server" Text='<%# Bind("GGA2") %>' />
                    </td>
                    <td align="center" class="auto-style3">
                        <asp:Label ID="A2NLabel" runat="server" Text='<%# Bind("A2N") %>' />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="auto-style2">
                        <asp:Label ID="GGA3Label" runat="server" Text='<%# Bind("GGA3") %>' />
                    </td>
                    <td align="center" class="auto-style3">
                        <asp:Label ID="A3NLabel" runat="server" Text='<%# Bind("A3N") %>' />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="auto-style2">
                        <asp:Label ID="GGA4Label" runat="server" Text='<%# Bind("GGA4") %>' />
                    </td>
                    <td align="center" class="auto-style3">
                        <asp:Label ID="A4NLabel" runat="server" Text='<%# Bind("A4N") %>' />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="auto-style2">
                        <asp:Label ID="GGA5Label" runat="server" Text='<%# Bind("GGA5") %>' />
                    </td>
                    <td align="center" class="auto-style3">
                        <asp:Label ID="A5NLabel" runat="server" Text='<%# Bind("A5N") %>' />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="auto-style6" colspan="2">
                        <asp:Label ID="Label13" runat="server" Font-Size="X-Large" Text="ثانيا المواد الاختيارية"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="auto-style2">
                        <asp:Label ID="GGA11Label" runat="server" Text='<%# Bind("GGA11") %>' />
                    </td>
                    <td align="center" class="auto-style3">
                        <asp:Label ID="A11NLabel" runat="server" Text='<%# Bind("A11N") %>' />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="auto-style2">
                        <asp:Label ID="GGA12Label" runat="server" Text='<%# Bind("GGA12") %>' />
                    </td>
                    <td align="center" class="auto-style3">
                        <asp:Label ID="A12NLabel" runat="server" Text='<%# Bind("A12N") %>' />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="auto-style2">
                        <asp:Label ID="GGA14Label" runat="server" Text='<%# Bind("GGA14") %>' />
                    </td>
                    <td align="center" class="auto-style3">
                        <asp:Label ID="A14NLabel" runat="server" Text='<%# Bind("A14N") %>' />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label15" runat="server" Text="يعتمد، عميد الكلية"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="Label14" runat="server" Font-Size="Small" Text="ادارة الدراسات العليا"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label16" runat="server" Font-Italic="True" Font-Names="Gulim" Font-Size="Small" Text='<%# Eval("Dean") %>'></asp:Label>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
            </table>
            <br />
        </ItemTemplate>
    </asp:FormView>
</p>
<p>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Second_goup_general_diploma %>" ProviderName="<%$ ConnectionStrings:Second_goup_general_diploma.ProviderName %>" SelectCommand="SELECT * FROM [TFinal Results] WHERE (([AcdNumber] = ?) AND ([depart] = ?))">
        <SelectParameters>
            <asp:QueryStringParameter Name="AcdNumber" QueryStringField="id" Type="String" />
            <asp:QueryStringParameter Name="depart" QueryStringField="dept" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</p>


