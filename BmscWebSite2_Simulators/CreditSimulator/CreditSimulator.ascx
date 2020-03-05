<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreditSimulator.ascx.cs" Inherits="BmscWebSite2_Simulators.CreditSimulator.CreditSimulator" %>


<div class="simulator">
    <p>simula tu cr&eacute;dito ahora</p>

    <p>
        <asp:DropDownList runat="server" ID="ddlTipoCredito" CssClass="form" AppendDataBoundItems="true"
            AutoPostBack="true" OnSelectedIndexChanged="ddlTipoCredito_SelectedIndexChanged">
            <asp:ListItem Selected="True" Text="(Tipo de préstamo)" Value="-1"></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ID="rfvTipoCredito" ControlToValidate="ddlTipoCredito"
            Display="Dynamic" ErrorMessage="Debe elegir un valor para este campo." InitialValue="-1"
            SetFocusOnError="true" ForeColor="#95c11f" ValidationGroup="Credito"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:DropDownList runat="server" ID="ddlPlazo" CssClass="form" ToolTip="Plazo, en meses"
            AutoPostBack="true" OnSelectedIndexChanged="ddlPlazo_SelectedIndexChanged">
            <asp:ListItem Selected="True" Text="(Plazo, en meses)" Value="-1"></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ID="rfvPlazo" ControlToValidate="ddlPlazo"
            Display="Dynamic" ErrorMessage="Debe elegir un valor para este campo." InitialValue="-1"
            SetFocusOnError="true" ForeColor="#95c11f" ValidationGroup="Credito"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:DropDownList runat="server" ID="ddlCesantia" CssClass="form" ToolTip="Cesuro de cesantía">
            <asp:ListItem Selected="True" Text="(Seguro de cesantía)" Value="-1"></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ID="rfvCesantia" ControlToValidate="ddlCesantia"
            Display="Dynamic" ErrorMessage="Debe elegir un valor para este campo." InitialValue="-1"
            SetFocusOnError="true" ForeColor="#95c11f" ValidationGroup="Credito"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:TextBox runat="server" ID="txbMonto" TextMode="Number" CssClass="form" placeholder="(Monto, en bolivianos)" MaxLength="10" ToolTip="Monto"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="rfvMonto" ControlToValidate="txbMonto"
            Display="Dynamic" ErrorMessage="Debe elegir un valor para este campo."
            SetFocusOnError="true" ForeColor="#95c11f" ValidationGroup="Credito"></asp:RequiredFieldValidator>
        <asp:RangeValidator runat="server" ID="rgvMonto" ControlToValidate="txbMonto"
            Display="Dynamic" ErrorMessage="El monto ingresado no es válido." SetFocusOnError="true"
            ForeColor="#95c11f" Type="Integer" MinimumValue="0" MaximumValue="9999999" ValidationGroup="Credito"></asp:RangeValidator>
    </p>
    <p>
        <asp:TextBox runat="server" ID="txbValor" TextMode="Number" CssClass="form" placeholder="(Valor comercial del inmueble)" MaxLength="10" ToolTip="Valor comercial del inmueble"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="rfvValor" ControlToValidate="txbValor"
            Display="Dynamic" ErrorMessage="Debe elegir un valor para este campo."
            SetFocusOnError="true" ForeColor="#95c11f" ValidationGroup="Credito"></asp:RequiredFieldValidator>
        <asp:RangeValidator runat="server" ID="rgvValor" ControlToValidate="txbValor"
            Display="Dynamic" ErrorMessage="El monto ingresado no es válido." SetFocusOnError="true"
            ForeColor="#95c11f" Type="Integer" MinimumValue="0" MaximumValue="9999999" ValidationGroup="Credito"></asp:RangeValidator>
    </p>
    <p>
        <asp:HiddenField runat="server" ID="hdfTasaFija" Value="" />
        <asp:HiddenField runat="server" ID="hdfSpread" Value="" />
        <asp:HiddenField runat="server" ID="hdfTasaVariable" Value="" />
        <asp:HiddenField runat="server" ID="hdfTre" Value="" />
    </p>

    <p class="buttonarea"><asp:LinkButton runat="server" ID="lnkConfirm" Text="simula tu crédito" OnClick="lnkConfirm_Click" ValidationGroup="Credito"></asp:LinkButton></p>
    <asp:Literal runat="server" ID="ltrFormLink" Text=""></asp:Literal>
    
    <img src="/_catalogs/masterpage/bmsc/images/form_icon.png" alt="" />

    <asp:Literal runat="server" ID="ltrScriptLoader" Text=""></asp:Literal>
    <asp:Literal runat="server" ID="ltrMessage" Text=""></asp:Literal>
</div>