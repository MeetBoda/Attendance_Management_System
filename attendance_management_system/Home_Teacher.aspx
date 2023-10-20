<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher.Master" AutoEventWireup="true" CodeBehind="Home_Teacher.aspx.cs" Inherits="attendance_management_system.Home_Teacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    body {
        background-color: #f4f4f4; /* Light gray background for the whole page */
    }

    .teacher-info-container {
        width: 300px;
        margin: 0 auto;
        padding: 20px;
        border: 1px solid #ccc;
        border-radius: 10px;
        background-color: #ffffff; /* White background for the teacher info container */
        transition: transform 0.3s ease;
        animation: fadeIn 1s ease;
    }

    .teacher-info-label {
        font-weight: bold;
        margin-bottom: 5px;
    }

    .teacher-info-value {
        margin-bottom: 15px;
        color: #333;
    }

    .teacher-info-subjects {
        font-style: italic;
        color: #666;
    }

    @keyframes fadeIn {
        from {
            opacity: 0;
            transform: translateX(-10px);
        }
        to {
            opacity: 1;
            transform: translateX(0);
        }
    }

    .teacher-info-container:hover {
        transform: perspective(500px) rotateY(10deg);
    }
</style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="teacher-info-container">
        <div class="teacher-info-label">Teacher ID:</div>
        <asp:Label ID="lblTid" CssClass="teacher-info-value" runat="server" />

        <div class="teacher-info-label">Name:</div>
        <asp:Label ID="lblName" CssClass="teacher-info-value" runat="server" />

        <div class="teacher-info-label">Email:</div>
        <asp:Label ID="lblEmail" CssClass="teacher-info-value" runat="server" />

        <div class="teacher-info-label">Mobile:</div>
        <asp:Label ID="lblMobile" CssClass="teacher-info-value" runat="server" />

        <div class="teacher-info-label">Date of Birth:</div>
        <asp:Label ID="lblDob" CssClass="teacher-info-value" runat="server" />

        <div class="teacher-info-label">Department:</div>
        <asp:Label ID="lbldepartment" CssClass="teacher-info-value" runat="server" />

        <div class="teacher-info-label">Subjects:</div>
        <asp:Label ID="lblsubject" CssClass="teacher-info-subjects" runat="server" />
    </div>
</asp:Content>
