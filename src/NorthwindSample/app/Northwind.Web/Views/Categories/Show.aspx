<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage<Category>" %>
<%@ Import Namespace="Northwind.Core" %>
<%@ Import Namespace="Northwind.Web.Controllers" %>
<%@ Import Namespace="SharpArch.Web.Areas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Category Details</h2>

    <div>
        <p>
            ID:
            <%= Model.Id %></p>
        <p>
            Name:
            <%= Model.CategoryName%></p>
        <p>
        <%= Html.ActionLinkForAreas<CategoriesController>(x => x.Delete(Model.Id), "delete") %>
            </p>
    </div>
</asp:Content>
