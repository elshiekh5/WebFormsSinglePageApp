<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="modal.aspx.cs" Inherits="SinglePageAppWebForms.Test.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal" data-whatever="@mdo">Open modal for @mdo</button>
    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal" data-whatever="@fat">Open modal for @fat</button>
    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal" data-whatever="@getbootstrap">Open modal for @getbootstrap</button>

    

    <button type="button" class="btn btn-primary" id="btnTest">Test</button>

    <script>

        $("#btnTest").click(function () {
            $modal_message.text("hdfgdfgdfgdfgdfgdf");
            $('#exampleModal').modal();

        });
    </script>
</asp:Content>
