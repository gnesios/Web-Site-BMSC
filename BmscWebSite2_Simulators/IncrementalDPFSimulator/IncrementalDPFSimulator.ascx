<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IncrementalDPFSimulator.ascx.cs" Inherits="BmscWebSite2_Simulators.IncrementalDPFSimulator.IncrementalDPFSimulator" %>


<div class="simulator">
    <p>simula tu inter&eacute;s ganado</p>

    <p>
        <asp:TextBox runat="server" ID="txbMonto" TextMode="Number" CssClass="form" placeholder="(Monto)" MaxLength="10" ToolTip="Monto"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="rfvMonto" ControlToValidate="txbMonto"
            Display="Dynamic" ErrorMessage="Debe elegir un valor para este campo."
            SetFocusOnError="true" ForeColor="#95c11f" ValidationGroup="DPFI"></asp:RequiredFieldValidator>
        <asp:RangeValidator runat="server" ID="rgvMonto" ControlToValidate="txbMonto"
            Display="Dynamic" ErrorMessage="El monto ingresado no es válido." SetFocusOnError="true"
            ForeColor="#95c11f" Type="Integer" MinimumValue="0" MaximumValue="9999999" ValidationGroup="DPFI"></asp:RangeValidator>
    </p>

    <p>
        <asp:DropDownList runat="server" ID="ddlMoneda" CssClass="form" AppendDataBoundItems="true" ToolTip="Moneda">
            <asp:ListItem Selected="True" Text="Bolivianos" Value="0"></asp:ListItem>
        </asp:DropDownList>
    </p>

    <p class="buttonarea"><asp:LinkButton runat="server" ID="lnkConfirm" Text="simula tu interés" OnClick="lnkConfirm_Click" ValidationGroup="DPFI"></asp:LinkButton></p>
    <asp:Literal runat="server" ID="ltrFormLink" Text=""></asp:Literal>
    
    <img src="/_catalogs/masterpage/bmsc/images/form_icon.png" alt="" />

    <asp:Literal runat="server" ID="ltrScriptLoader" Text=""></asp:Literal>
    <asp:Literal runat="server" ID="ltrMessage" Text=""></asp:Literal>
</div>