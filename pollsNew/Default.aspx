<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeBehind="Default.aspx.cs" Inherits="pollsNew._Default" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server" />
    <h2 class="DDSubHeader">Polls</h2>
    <asp:DropDownList ID="tableChoice" runat="server" OnSelectedIndexChanged="tableChoice_SelectedIndexChanged" AutoPostBack="true" DataSourceID="LinqDataSource1"
        DataTextField="tableName" DataValueField="tableId" CssClass="select"></asp:DropDownList>    
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="pollsNew.DB.pollsEntities" Select="new (tableId, tableName)" TableName="tables"></asp:LinqDataSource>
    <asp:GridView ID="objectsGrid" runat="server" CssClass="DDGridView"
                RowStyle-CssClass="td" HeaderStyle-CssClass="th" CellPadding="6" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Нумер" ItemStyle-Width="20" ItemStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>               
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="objectName" HeaderText="Название маршрута" />
            <asp:BoundField DataField="points" HeaderText="Баллы" />
            <asp:BoundField DataField="count" HeaderText="Количество проголосовавших пользователей" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="info" runat="server" />
</asp:Content>


