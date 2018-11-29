<%@ Page Title="" Language="C#" MasterPageFile="~/Clear.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SinglePageAppWebForms.Categories._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add new Category</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal" id="divFormContainer" runat="server">
        <h4>Create a new account
        </h4>
        <hr />
        <table class="table table-bordered">
    <thead>
      <tr>
        <th>Firstname</th>
        <th>Edit</th>
        <th>Delete</th>
      </tr>
    </thead>
    <tbody>
        <asp:Repeater ID="drCategories" runat="server">
        <ItemTemplate>
            <tr>
        <td><%# Eval("Title")%></td>
        <td><a href="/Categories/edit?id=<%# Eval("CategoryID")%>" class="btn btn-primary" >Edit</a></td>
        <td><a href="/Categories/default?operation=delete&id=<%# Eval("CategoryID")%>" class="btn btn-primary" >Delete</a>

        </td>
      </tr>
</ItemTemplate>

        </asp:Repeater>
            </tbody>
  </table>
    </div>
    <div class="form-horizontal" id="alertBox" runat="server" visible="false">
       
                        <div class="alert alert-success text-center" role="alert"></div>
        </div>
</asp:Content>
