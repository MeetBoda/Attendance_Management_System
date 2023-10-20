<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_Teacher.aspx.cs" Inherits="attendance_management_system.Login_Teacher" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login</title>
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f4f4f4; /* Light gray background color */
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh; /* Make the body cover the full viewport height */
        }
        .container {
            width: 500px; /* Set the desired width */
            padding: 20px;
            background-color: #fff; /* White background color */
            border-radius: 10px;
            box-shadow: 0px 0px 10px 0px rgba(0, 0, 0, 0.2); /* Box shadow for a subtle border effect */
        }
        .signup-form {
            display: none;
        }
    </style>
</head>
<body>
    <form runat="server">
        <div class="container">
            <h2 class="text-center">Login</h2>
            <div class="mb-3">
                <asp:TextBox runat="server" ID="loginIdTextBox" CssClass="form-control" placeholder="Teacher_ID" TextMode="SingleLine" Required="true" />
            </div>
            <div class="mb-3">
                <asp:TextBox runat="server" ID="loginDobTextBox" CssClass="form-control" placeholder="Date of Birth" TextMode="Date" Required="true" />
            </div>
            <asp:Button runat="server" ID="loginButton" CssClass="btn btn-primary" Text="Login" OnClick="LoginButton_Click" />
            <p class="mt-3">Don't have an account? <a href="Signup_Teacher.aspx">Signup</a></p>
            <p class="mt-3">Login as<a href="Login_Student.aspx">Student</a></p>
        </div>
    </form>
    <script src="bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
</body>
</html>