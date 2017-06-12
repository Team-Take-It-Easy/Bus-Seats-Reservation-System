<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BusSeatsReservation.WebClient._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
    <div>
        <a class="btn btn-default" href="#">Create user</a>
        <a class="btn btn-default" href="#">Learn reservation</a>
        <a class="btn btn-default" href="#">Learn bus</a>
    </div>

</asp:Content>
