<%@ Page Title="" Language="C#" MasterPageFile="~/Clear.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SinglePageAppWebForms.Posts._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add new Category</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal" id="divFormContainer" runat="server">
        <h4>Create a new account
        </h4>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlCategories" CssClass="col-md-2 control-label" >Category</asp:Label>
            <div class="col-md-10">
            <asp:DropDownList ID="ddlCategories" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCategories_SelectedIndexChanged"> </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlCategories"
                    CssClass="text-danger" ErrorMessage="The email field is required." InitialValue="-1" />
            </div>
        </div>

        <table class="table table-bordered">
    <thead>
      <tr>
        <th>Firstname</th>
        <th>Edit</th>
        <th>Delete</th>
      </tr>
    </thead>
    <tbody>
        <asp:Repeater ID="drPosts" runat="server">
        <ItemTemplate>
            <tr>
        <td><%# Eval("Title")%></td>
        <td><a href="/Posts/edit?id=<%# Eval("PostID")%>" class="btn btn-primary" >Edit</a></td>
        <td><a href="/Posts/default?operation=delete&id=<%# Eval("PostID")%>" class="btn btn-primary" >Delete</a>

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
