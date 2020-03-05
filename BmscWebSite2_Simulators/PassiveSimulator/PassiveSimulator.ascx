<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PassiveSimulator.ascx.cs" Inherits="BmscWebSite2_Simulators.PassiveSimulator.PassiveSimulator" %>

<div class="simulator">
    <p>cual es el inter&eacute;s que recibo?</p>

    <p>
        <asp:TextBox runat="server" ID="txbMonto" CssClass="form" placeholder="(Monto)" MaxLength="10"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="rfvMonto" ControlToValidate="txbMonto" ValidationGroup="SimuladorPasivo"
            Display="Dynamic" ErrorMessage="Debe elegir un valor para este campo."
            SetFocusOnError="true" ForeColor="#95c11f"></asp:RequiredFieldValidator>
        <asp:RangeValidator runat="server" ID="rgvMonto" ControlToValidate="txbMonto" ValidationGroup="SimuladorPasivo"
            Display="Dynamic" ErrorMessage="El monto ingresado no es válido." SetFocusOnError="true"
            ForeColor="#95c11f" Type="Integer" MinimumValue="0" MaximumValue="100000000"></asp:RangeValidator>
    </p>
    <p>
        <asp:DropDownList runat="server" ID="ddlMoneda" CssClass="form"></asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ID="rfvMoneda" ControlToValidate="ddlMoneda" ValidationGroup="SimuladorPasivo"
            Display="Dynamic" ErrorMessage="Debe elegir un valor para este campo." InitialValue="0"
            SetFocusOnError="true" ForeColor="#95c11f"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:DropDownList runat="server" ID="ddlPlazo" CssClass="form">
            <asp:ListItem Selected="True" Text="(Plazo, en días)" Value="0"></asp:ListItem>
            <asp:ListItem Text="360" Value="1"></asp:ListItem>
            <asp:ListItem Text="720" Value="2"></asp:ListItem>
            <asp:ListItem Text="1080" Value="3"></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ID="rfvPlazo" ControlToValidate="ddlPlazo" ValidationGroup="SimuladorPasivo"
            Display="Dynamic" ErrorMessage="Debe elegir un valor para este campo." InitialValue="0"
            SetFocusOnError="true" ForeColor="#95c11f"></asp:RequiredFieldValidator>
    </p>

    <p class="buttonarea"><asp:LinkButton runat="server" ID="lnkConfirm" OnClick="lnkConfirm_Click" Text="ver interés" ValidationGroup="SimuladorPasivo"></asp:LinkButton></p>

    <img src="/_catalogs/masterpage/bmsc/images/form_icon.png" alt="" />

    <asp:Literal runat="server" ID="ltrMessage" Text=""></asp:Literal>
</div>