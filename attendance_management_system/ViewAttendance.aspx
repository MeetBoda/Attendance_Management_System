<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewAttendance.aspx.cs" Inherits="attendance_management_system.ViewAttendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            width: 80%;
            margin: 0 auto;
        }

        .table-container {
            margin-top: 20px;
        }

        .semester-table {
            width: 100%;
            border-collapse: collapse;
        }

        .semester-table th,
        .semester-table td {
            padding: 10px;
            border: 1px solid #ccc;
            text-align: center;
        }

        .semester-table th {
            background-color: #f2f2f2;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>View Attendance</h2>
        <div class="table-container">
            <table class="semester-table">
                <thead>
                    <tr>
                        <th>Semester No</th>
                        <th>View</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptSemesters" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.DataItem %></td>
                                <td><a href="Attendance.aspx?semester=<%# Container.DataItem %>">View</a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
