<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JavascriptPlayground.aspx.cs" Inherits="Lab_25_ASP_First_Website.JavascriptPlayground" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        var x = 0;
        
        function runSomeTestData() {
            x++;
            alert("X value:" + x);
            var geek = confirm("Computer geek");

            var name = prompt("Name?");
            alert("Thanks " + name);

            if (geek) {
                alert("Yo");
            }

            else {
                alert("No");
            }
            console.log(geek);
            console.log(name);
        }
    </script>

    <button onclick="runSomeTestData()">Run test data</button>
    <div id="test-data">Data</div>

</asp:Content>
