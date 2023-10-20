<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup_Student.aspx.cs" Inherits="attendance_management_system.Signup_Student" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Signup</title>
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
            <h2 class="text-center">Signup</h2>
            <div class="mb-3">
                <asp:TextBox runat="server" ID="nameTextBox" CssClass="form-control" placeholder="Name" Required="true" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="nameTextBox"
                    Display="Dynamic" ErrorMessage="Name cannot be empty." ForeColor="Red" />
            </div>
            <div class="mb-3">
                <asp:TextBox runat="server" ID="idNoTextBox" CssClass="form-control" placeholder="Student_ID" Required="true" />
                <asp:RegularExpressionValidator runat="server" ID="idNoValidator" ControlToValidate="idNoTextBox"
                    ValidationExpression="^[a-zA-Z0-9]{10}$"
                    ErrorMessage="Student ID must be 10 alphanumeric characters."
                    ForeColor="Red"
                    Display="Dynamic" />
            </div>
            <div class="mb-3">
                <asp:TextBox runat="server" ID="dobTextBox" CssClass="form-control" placeholder="Date of Birth" TextMode="Date" Required="true" />
            </div>
            <div class="mb-3">
                <asp:TextBox runat="server" ID="emailTextBox" CssClass="form-control" placeholder="Email ID" TextMode="Email" Required="true" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="emailTextBox"
                    Display="Dynamic" ErrorMessage="Invalid email address." ForeColor="Red"
                    ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" />
            </div>
            <div class="mb-3">
                <asp:TextBox runat="server" ID="mobileTextBox" CssClass="form-control" placeholder="Mobile No" Required="true" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="mobileTextBox"
                    Display="Dynamic" ErrorMessage="Mobile number must be 10 digits long." ForeColor="Red"
                    ValidationExpression="^\d{10}$" />
            </div>
            <div class="mb-3">
                <asp:DropDownList runat="server" ID="semesterDropDown" CssClass="form-select">
                    <asp:ListItem Text="Semester 1" Value="1" />
                    <asp:ListItem Text="Semester 2" Value="2" />
                    <asp:ListItem Text="Semester 3" Value="3" />
                    <asp:ListItem Text="Semester 4" Value="4" />
                    <asp:ListItem Text="Semester 5" Value="5" />
                    <asp:ListItem Text="Semester 6" Value="6" />
                    <asp:ListItem Text="Semester 7" Value="7" />
                    <asp:ListItem Text="Semester 8" Value="8" />
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:DropDownList runat="server" ID="DropDownList2" CssClass="form-select">
                    <asp:ListItem Text="Select Branch" Value="" />
                    <asp:ListItem Text="Chemical Engineering" Value="Chemical Engineering" />
                    <asp:ListItem Text="Civil Engineering" Value="Civil Engineering" />
                    <asp:ListItem Text="Computer Engineering" Value="Computer Engineering" />
                    <asp:ListItem Text="Electronics and Communication Engineering" Value="Electronics and Communication Engineering" />
                    <asp:ListItem Text="Information Technology" Value="Information Technology" />
                    <asp:ListItem Text="Instrumentation and Control Engineering" Value="Instrumentation and Control Engineering" />
                    <asp:ListItem Text="Mechanical Engineering" Value="Mechanical Engineering" />
                </asp:DropDownList>
            </div>
            <asp:Button runat="server" ID="signupButton" CssClass="btn btn-success" Text="Signup" OnClick="SignupButton_Click" />
            <p class="mt-3">Already have an account? <a href="Login_Student.aspx">Login</a></p>
            <p class="mt-3">SignUp as<a href="Signup_Teacher.aspx">Teacher</a></p>
        </div>
    </form>
    <script src="bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
</body>
</html>

