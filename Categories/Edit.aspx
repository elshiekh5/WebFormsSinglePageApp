<%@ Page Title="" Language="C#" MasterPageFile="~/Clear.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="SinglePageAppWebForms.Categories.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add new Category</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal" id="divFormContainer" runat="server">
        <h4>Create a new account</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtTitle" CssClass="col-md-2 control-label">txtTitle</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtTitle" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTitle"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtDescription" CssClass="col-md-2 control-label">Description</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDescription"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="btnSave_Click" Text="Save" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
    <div class="form-horizontal" id="alertBox" runat="server" visible="false">
       
                        <div class="alert alert-success text-center" role="alert">
                              <asp:literal runat="server" id="ltrMessage"></asp:literal>
                        </div>
        </div>
</asp:Content>
