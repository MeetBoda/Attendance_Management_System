<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher.Master" AutoEventWireup="true" CodeBehind="AddSubject.aspx.cs" Inherits="attendance_management_system.AddSubject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
/*.container {
            width: 80%;
            margin: 0 auto;
            padding: 20px;
            background-color: #f9f9f9;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }*/

        label {
            font-weight: bold;
            margin-bottom: 5px;
            display: block;
        }

        select, input[type="hidden"] {
            width: 100%;
            padding: 8px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 16px;
        }

        #btnAddSubject {
            background-color: #007bff; /* Blue background color */
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            transition: background-color 0.3s ease;
        }

        #btnAddSubject:hover {
            background-color: #0056b3; /* Darker blue on hover */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
            <h2>Add Subject</h2>
            <div>
                <label for="ddlSemester">Select Semester:</label>
                <asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="false">
                    <asp:ListItem Text="Select Semester" Value="" />
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
            <div>
                <label for="ddlSubject">Select Subject:</label>
                <asp:DropDownList ID="ddlSubject" runat="server">
                    <asp:ListItem Text="Select Subject" Value="" />
                </asp:DropDownList>
            </div>
            <div>
                <asp:HiddenField ID="sub_name" runat="server"/>
            </div>
            <div>
                <%--<button type="submit" OnClick="btnAddSubject_Click" value="Add Subjet">Add Subject</button>--%>
                <asp:Button ID="btnAddSubject" runat="server" Text="Add Subjet" OnClick="btnAddSubject_Click"  />
            </div>
        </div>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            // Attach a change event handler to the Semester dropdown
            $("#<%= ddlSemester.ClientID %>").change(function () {
                // Get the selected semester value
                var selectedSemester = $(this).val();
                console.log("Hi");
                // Call the web service to fetch subjects based on the selected semester
                $.ajax({
                    type: "POST",
                    url: "SubjectService.asmx/GetSubjectsBySemester",
                    data: JSON.stringify({ semester: selectedSemester }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        // Clear existing items in the Subject dropdown
                        $("#<%= ddlSubject.ClientID %>").empty();

                        // Add a default option
                        var option1 = new Option("Select Subject", "");
                        $("#<%= ddlSubject.ClientID %>").append(option1);

                        // Populate the Subject dropdown with the retrieved subjects
                        $.each(response.d, function (key, value) {
                            var option = new Option(value, value);
                            $("#<%= ddlSubject.ClientID %>").append(option);
                        });
                    },
                    error: function (xhr, textStatus, errorThrown) {
                        console.log(errorThrown);
                    }
                });
            });
            $("#<%= ddlSubject.ClientID %>").change(function () {
                var selectedSubject = $("#<%= ddlSubject.ClientID %>").val();
                var hid = $("#<%= sub_name.ClientID %>");
                hid.val(selectedSubject);
                console.log("Selected Subject: " + selectedSubject);
            });
        });
    </script>
</asp:Content>
