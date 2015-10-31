<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="pollsNew.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:validationsummary runat="server" ID="ValSum" CssClass="DDValidator"></asp:validationsummary >
    <div class="loginContainer">
        Авторизация
        <div>
            <label for="name">Имя:</label>
            <asp:TextBox runat="server"  ID="authname" />           
            <asp:RequiredFieldValidator ValidationGroup="auth" ControlToValidate="authname"  runat="server" CssClass="DDValidator">*</asp:RequiredFieldValidator>
        </div>
        <div>
            <label for="password">Пароль:</label>
            <asp:TextBox TextMode="Password" runat="server"  ID="authpassword" />
            <asp:RequiredFieldValidator ValidationGroup="auth" ControlToValidate="authpassword"  runat="server" CssClass="DDValidator" >*</asp:RequiredFieldValidator>
        </div>
        <asp:Button runat="server" Text="Button" OnClick="Button1Click" ValidationGroup="auth"/>
    </div>
    <hr />
    <div class="loginContainer">
        Регистрация
        <div>
            <label>name</label>
            <asp:TextBox runat="server" ID="regname" />
            <asp:RequiredFieldValidator ValidationGroup="reg" ControlToValidate="regname" runat="server" CssClass="DDValidator">*</asp:RequiredFieldValidator>
        </div>
        <div>
            <label>password</label>            
            <asp:TextBox TextMode="Password" runat="server" ID="regpassword" />
            <asp:RequiredFieldValidator ValidationGroup="reg" ControlToValidate="regpassword" runat="server" CssClass="DDValidator">*</asp:RequiredFieldValidator>
        </div>
        <div>
            <label>password Repeat</label> 
            <asp:TextBox TextMode="Password" runat="server" ID="regpasswordRepeat" />
            <asp:RequiredFieldValidator ValidationGroup="reg" ControlToValidate="regpasswordRepeat" runat="server" CssClass="DDValidator">*</asp:RequiredFieldValidator>           
        </div>
        <asp:CompareValidator runat="server" ControlToValidate="regpasswordRepeat" ControlToCompare="regpassword" Type="String"
              Display="dynamic" Name="Comparevalidator1" CssClass="DDValidator"  ValidationGroup="reg" >Пароли не совпадают
        </asp:CompareValidator>
        <div>
            <asp:Button runat="server" Text="Button"  OnClick="Button2Click" ValidationGroup="reg" />
        </div>
    </div>
</asp:Content>
