<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Select.aspx.cs" Inherits="pollsNew.Users.Select" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <asp:validationsummary runat="server" CssClass="DDValidator"></asp:validationsummary >
    <asp:PlaceHolder ID="tablesView" runat="server">
        <asp:GridView ID="tablesList" runat="server" AutoGenerateColumns="false"
            CssClass="DDGridView" RowStyle-CssClass="td" HeaderStyle-CssClass="th" CellPadding="6" HeaderText="Выберите таблицу">
            <Columns>
                 <asp:HyperLinkField DataNavigateUrlFormatString="/Users/Select.aspx?tableId={0}" DataNavigateUrlFields="tableId" runat="server" DataTextField="tableName" />
            </Columns>
        </asp:GridView>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="objectsView" runat="server" Visible="false">
        <%--<asp:GridView ID="objectsList" runat="server" AutoGenerateColumns="false"
            CssClass="DDGridView" RowStyle-CssClass="td" HeaderStyle-CssClass="th" CellPadding="6" HeaderText="Выберите таблицу">
            <Columns>
<%--                <asp:TemplateField HeaderText="Table Name" SortExpression="TableName">
                    <ItemTemplate>
                         <asp:DynamicHyperLink NavigateUrl=""  runat="server"><%# Eval("DisplayName") %></asp:DynamicHyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Table Name" SortExpression="TableName">
                    <ItemTemplate>                        
                         <asp:Label runat="server"><%# Eval("objectName") %></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                
            </Columns>
        </asp:GridView>--%>
        <asp:CheckBoxList ID="objectsList" runat="server" ></asp:CheckBoxList>
        <asp:Button ID="selectObjects" OnClick="selectObjects_Click" runat="server"  Text="Выбрать" />
    </asp:PlaceHolder>    
</asp:Content>
