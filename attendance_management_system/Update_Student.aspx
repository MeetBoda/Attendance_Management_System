<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Update_Student.aspx.cs" Inherits="attendance_management_system.Update_Student" %>
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

        .form-dropdown {
            width: 100%;
            padding: 10px;
            border-radius: 5px;
            border: 1px solid #ccc;
            margin-bottom: 20px;
        }

        .submit-btn {
            background-color: #007bff;
            color: #ffffff;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .submit-btn:hover {
            background-color: #0056b3;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
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
            <div class="form-group">
                <label for="ddlUpdateSemester" class="form-label">Update Semester:</label>
                <asp:DropDownList ID="ddlUpdateSemester" runat="server" CssClass="form-dropdown">
                    <asp:ListItem Text="Select Semester" Value="" />
                </asp:DropDownList>
            </div>
            <asp:Button ID="btnUpdateProfile" runat="server" Text="Update Profile" CssClass="submit-btn" OnClick="btnUpdateProfile_Click" />
        </div>
    </div>
</asp:Content>
