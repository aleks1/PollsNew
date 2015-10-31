<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.ascx.cs" Inherits="pollsNew.WebControls.UserInfo" %>
<div class="userInfo">
    <asp:HyperLink ID="AdminLink" runat="server" NavigateUrl="~/Admin/Admin.aspx" Visible="false">Административный панелъ</asp:HyperLink>
    <asp:PlaceHolder runat="server" ID="RegLink">
        <asp:HyperLink  runat="server" NavigateUrl="~/Login.aspx">Регистрация/Авторизация</asp:HyperLink>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="UserArea" runat="server" Visible="false">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Users/Select.aspx">Голосовать</asp:HyperLink>
            <asp:Label  runat="server" Text="<%# UserName %>"></asp:Label>
            <asp:Button OnClick="LogOut_Click"  runat="server" Text="LogOut нах!" />
    </asp:PlaceHolder>

    </div>