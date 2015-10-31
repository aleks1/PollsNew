<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="pollsNew.DynamicData.CustomPages.attribute.Insert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true"></asp:DynamicDataManager>
    <h2 class="DDSubHeader">Добавить новый атрибут</h2>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="false" HeaderText="Ошибка при вводе данных" CssClass="DDValidator" />
    
    <asp:FormView runat="server" ID="FormView1" DataSourceID="DetailsDataSource" DefaultMode="Insert"
        OnItemCommand="FormView1_ItemCommand" OnItemInserted="FormView1_ItemInserted"  >
        <InsertItemTemplate>            
            <asp:TextBox ID="attributeName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server"  EnableClientScript="false" ControlToValidate="attributeName" Display="dynamic" CssClass="DDValidator">Введите название</asp:RequiredFieldValidator>                
            <asp:RegularExpressionValidator runat="server" EnableClientScript="false" ControlToValidate="attributeName" ValidationExpression="[а-яА-Яa-zA-Z]+" ErrorMessage="Неверный формат. Название должно состоять только из букв" Display="dynamic">*
        </asp:RegularExpressionValidator>
            <br />
            <asp:TextBox ID="attributeWeight"  TextMode="Number" runat="server" min="1" max="10"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1"  EnableClientScript="false" ControlToValidate="attributeWeight" Display="dynamic" CssClass="DDValidator">Введите вес атрибута</asp:RequiredFieldValidator>
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
