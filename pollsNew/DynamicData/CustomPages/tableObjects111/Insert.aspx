<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="pollsNew.DynamicData.CustomPages.tableObjects.Insert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true"></asp:DynamicDataManager>

    <h2 class="DDSubHeader">Добавить новый объект</h2>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="false" HeaderText="Ошибка при вводе данных" CssClass="DDValidator" />
    
    <asp:FormView runat="server" ID="FormView1" DataSourceID="DetailsDataSource" DefaultMode="Insert"
        OnItemCommand="FormView1_ItemCommand" OnItemInserted="FormView1_ItemInserted"  >
        <InsertItemTemplate>            
            <asp:TextBox ID="objectName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server"  EnableClientScript="false" ControlToValidate="objectName" Display="dynamic" CssClass="DDValidator">Введите название</asp:RequiredFieldValidator>                
            <br />
            <asp:DropDownList DataValueField="tableId" runat="server" DataTextField="tableName" DataSourceID="LinqDataSource1" Id="tableId" />
            <br />
            <asp:LinkButton runat="server" Text="Insert" CommandName="Insert"/>
            <asp:LinkButton runat="server" Text="Отмена" CommandName="Cancel"/>
        </InsertItemTemplate>
    </asp:FormView>
    <ef:EntityDataSource ID="DetailsDataSource" runat="server" EnableInsert="true" />
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="pollsNew.DB.pollsEntities" Select="new (tableId, tableName)" TableName="tables"></asp:LinqDataSource>

</asp:Content>
