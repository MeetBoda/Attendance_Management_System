<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher.Master" AutoEventWireup="true" CodeBehind="Update_Teacher.aspx.cs" Inherits="attendance_management_system.Update_Teacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            width: 80%;
            margin: 0 auto;
        }

        .form-container {
            margin-top: 20px;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 10px;
            background-color: #f9f9f9;
        }

        .form-label {
            font-weight: bold;
            margin-bottom: 10px;
        }

        .form-input {
            width: 100%;
            padding: 10px;
            border-radius: 5px;
            border: 1px solid #ccc;
            margin-bottom: 20px;
        }

        .form-button {
            background-color: #007bff;
            color: #fff;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Update Profile</h2>
        <div class="form-container">
            <div class="form-group">
                <label for="txtUpdateEmail" class="form-label">Update Email:</label>
                <asp:TextBox ID="txtUpdateEmail" runat="server" CssClass="form-input"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtUpdateMobile" class="form-label">Update Mobile No:</label>
                <asp:TextBox ID="txtUpdateMobile" runat="server" CssClass="form-input"></asp:TextBox>
            </div>
            <asp:Button ID="btnUpdateProfile" runat="server" Text="Update Profile" CssClass="form-button" OnClick="btnUpdateProfile_Click" />
        </div>
    </div>
</asp:Content>
