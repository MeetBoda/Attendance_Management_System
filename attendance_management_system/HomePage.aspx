<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="attendance_management_system.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
        background-color: #f4f4f4; /* Light gray background for the whole page */
    }

    .info-container {
        width: 300px;
        margin: 50px auto;
        padding: 20px;
        border: 1px solid #ccc;
        border-radius: 10px;
        background-color: #ffffff; /* White background for the teacher info container */
        transition: transform 0.3s ease;
        animation: fadeIn 1s ease;
    }

    .info-label {
        font-weight: bold;
        margin-bottom: 5px;
    }

    .info-value {
        margin-bottom: 15px;
        color: #333;
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

    .info-container:hover {
        transform: perspective(500px) rotateY(10deg);
    }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="info-container">
        <div class="info-label">Student ID:</div>
        <asp:Label ID="lblSid" CssClass="info-value" runat="server" />

        <div class="info-label">Name:</div>
        <asp:Label ID="lblName" CssClass="info-value" runat="server" />

        <div class="info-label">Email:</div>
        <asp:Label ID="lblEmail" CssClass="info-value" runat="server" />

        <div class="info-label">Mobile:</div>
        <asp:Label ID="lblMobile" CssClass="info-value" runat="server" />

        <div class="info-label">Sem:</div>
        <asp:Label ID="lblSem" CssClass="info-value" runat="server" />

        <div class="info-label">Date of Birth:</div>
        <asp:Label ID="lblDob" CssClass="info-value" runat="server" />

        <div class="info-label">Branch:</div>
        <asp:Label ID="lblbranch" CssClass="info-value" runat="server" />
    </div>
</asp:Content>
