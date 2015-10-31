<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Poll.aspx.cs" Inherits="pollsNew.Users.Poll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="DDValidator" />
    <div class="DDFloatLeft">
        <asp:Label ID="object1Name" runat="server"></asp:Label>
        <br />
        <asp:PlaceHolder ID="Object1Radio" runat="server"></asp:PlaceHolder>
    </div>
    <div class="DDFloatLeft attributesBlock">
        <asp:PlaceHolder ID="attributes" runat="server"></asp:PlaceHolder>
    </div>
    <div class="DDFloatLeft">
        <asp:Label ID="object2Name" runat="server"></asp:Label>
        <br />
        <asp:PlaceHolder ID="Object2Radio" runat="server"></asp:PlaceHolder>
    </div>
    <div class="clear"></div>
    <asp:Button ID="PollButton" runat="server" Text="Vote"  />

</asp:Content>
