﻿<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreditoResultado.aspx.cs" Inherits="BmscWebSite2_Simulators.Layouts.BmscWebSite2_Simulators.CreditoResultado" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
<style type="text/css">
    body 
    { 
        font-family: Verdana, Arial, Tahoma;
        font-weight: normal;
        font-size: 11pt;
        letter-spacing: -0.02em;
        margin: 0px;
        color: #808080;
    }
    table
    {
        width: 100%;
        background-color: #fff;
        border-collapse: collapse;
	    text-align: left;
	    margin: 20px 0;
    }
    table th
    {
        font-weight: normal;
        text-align: left;
        font-variant: small-caps;
        color: #95c11f;
        padding: 10px 8px;
	    border-bottom: 2px solid #95c11f;
        border-right: 1px solid #fff;
    }
    table td { border-right: 1px solid #e3e3e3; padding: 6px 8px; border-bottom: 1px solid #fff; }
    table td:last-child { border-right: none; }
    table tr:nth-child(odd) { background-color: #fff; }
    table tr:nth-child(even) { background-color: #f7f7f7; }
    p.legal { text-align: center; }
</style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <asp:Literal runat="server" ID="ltrMessage" Text=""></asp:Literal>    
    <asp:GridView runat="server" ID="grvCuotas" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Fecha" HeaderText="fecha" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="NumeroCuota" HeaderText="número de cuota" />
            <asp:BoundField DataField="SaldoCapital" HeaderText="saldo capital" DataFormatString="{0:#,0.00}" />
            <asp:BoundField DataField="AmortizacionCapital" HeaderText="saldo de amortización" DataFormatString="{0:#,0.00}" />
            <asp:BoundField DataField="Intereses" HeaderText="intereses" DataFormatString="{0:#,0.00}" />
            <asp:BoundField DataField="ValorCuota" HeaderText="valor cuota" DataFormatString="{0:#,0.00}" />
            <asp:BoundField DataField="SeguroDesgravamen" HeaderText="seguro desgravamen" DataFormatString="{0:#,0.00}" />
            <asp:BoundField DataField="SeguroCesantia" HeaderText="seguro de cesantía" DataFormatString="{0:#,0.00}" />
            <asp:BoundField DataField="CuotaTotal" HeaderText="total de cuota" DataFormatString="{0:#,0.00}" />
        </Columns>
    </asp:GridView>
    <p class="legal">Estimado Cliente, los resultados obtenidos son de carácter referencial. Las tasas pueden cambiar en función a las características del cliente. Para obtener datos oficiales, puedes acercarte a cualquiera de nuestras agencias.</p>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Credito
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Credito
</asp:Content>
