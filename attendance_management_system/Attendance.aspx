<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="attendance_management_system.Attendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            width: 80%;
            margin: 0 auto;
        }

        .table-container {
            margin-top: 20px;
        }

        .attendance-table {
            width: 100%;
            border-collapse: collapse;
        }

        .attendance-table th,
        .attendance-table td {
            padding: 10px;
            border: 1px solid #ccc;
            text-align: center;
        }

        .attendance-table th {
            background-color: #f2f2f2;
        }

        .subject-row {
            font-weight: bold;
        }

        .phase-heading {
            background-color: #007bff;
            color: black;
        }

        .attendance-label {
            font-weight: bold;
            color: black; /* Change the color to match your design */
            margin-top: 10px; /* Adjust margin-top as needed */
            display: block; /* Makes the labels display as block elements */
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Attendance</h2>
        <div class="table-container">
            <table class="attendance-table">
                <thead>
                    <tr>
                        <th rowspan="2">Subject</th>
                        <th colspan="4" class="phase-heading">Phase 1</th>
                        <th colspan="4" class="phase-heading">Phase 2</th>
                        <th colspan="4" class="phase-heading">Phase 3</th>
                    </tr>
                    <tr>
                        <th>Lecture Present</th>
                        <th>Lecture Total</th>
                        <th>Lab Present</th>
                        <th>Lab Total</th>
                        <th>Lecture Present</th>
                        <th>Lecture Total</th>
                        <th>Lab Present</th>
                        <th>Lab Total</th>
                        <th>Lecture Present</th>
                        <th>Lecture Total</th>
                        <th>Lab Present</th>
                        <th>Lab Total</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptSubjects" runat="server">
                        <ItemTemplate>
                            <tr class="subject-row">
                                <td><%# Eval("SubjectName") %></td>
                                <td><%# Eval("Phase1LecturePresent") %></td>
                                <td><%# Eval("Phase1LectureTotal") %></td>
                                <td><%# Eval("Phase1LabPresent") %></td>
                                <td><%# Eval("Phase1LabTotal") %></td>
                                <td><%# Eval("Phase2LecturePresent") %></td>
                                <td><%# Eval("Phase2LectureTotal") %></td>
                                <td><%# Eval("Phase2LabPresent") %></td>
                                <td><%# Eval("Phase2LabTotal") %></td>
                                <td><%# Eval("Phase3LecturePresent") %></td>
                                <td><%# Eval("Phase3LectureTotal") %></td>
                                <td><%# Eval("Phase3LabPresent") %></td>
                                <td><%# Eval("Phase3LabTotal") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <asp:Label ID="lec_attend" runat="server" CssClass="attendance-label">
        <!-- Content for lec_attend label -->
        </asp:Label>
        <asp:Label ID="lab_attend" runat="server" CssClass="attendance-label">
            <!-- Content for lab_attend label -->
        </asp:Label>
        <asp:Label ID="total_attend" runat="server" CssClass="attendance-label">
            <!-- Content for total_attend label -->
        </asp:Label>
    </div>
</asp:Content>
