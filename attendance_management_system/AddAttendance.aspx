<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher.Master" AutoEventWireup="true" CodeBehind="AddAttendance.aspx.cs" Inherits="attendance_management_system.AddAttendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Add Attendance</h2>
        <div>
            <label for="ddlPhase">Select Phase:</label>
            <asp:DropDownList ID="ddlPhase" runat="server">
                <asp:ListItem Text="Phase 1" Value="Phase 1" />
                <asp:ListItem Text="Phase 2" Value="Phase 2" />
                <asp:ListItem Text="Phase 3" Value="Phase 3" />
            </asp:DropDownList>
        </div>
        <div>
            <label for="txtAttendedLecture">Attended Lecture:</label>
            <asp:TextBox ID="txtAttendedLecture" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="txtTotalLecture">Total Lecture:</label>
            <asp:TextBox ID="txtTotalLecture" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="txtAttendedLab">Attended Lab:</label>
            <asp:TextBox ID="txtAttendedLab" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="txtTotalLab">Total Lab:</label>
            <asp:TextBox ID="txtTotalLab" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:HiddenField ID="stu_id" runat="server"/> 
        </div>
        <div>
            <asp:HiddenField ID="sub_name" runat="server"/> 
        </div>
        <div>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
    </div>
</asp:Content>
