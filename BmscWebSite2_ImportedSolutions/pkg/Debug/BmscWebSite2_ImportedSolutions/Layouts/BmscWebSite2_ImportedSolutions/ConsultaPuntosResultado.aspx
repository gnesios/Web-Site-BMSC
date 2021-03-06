﻿<%@ Assembly Name="BmscWebSite2_ImportedSolutions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=45c5403f90d48226" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaPuntosResultado.aspx.cs" Inherits="BmscWebSite2_ImportedSolutions.Layouts.BmscWebSite2_ImportedSolutions.ConsultaPuntosResultado" DynamicMasterPageFile="~masterurl/default.master" %>

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
    }
    table td { border-right: 1px solid #e3e3e3; padding: 6px 8px; }
    table td:last-child { border-right: none; }
</style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <asp:Literal runat="server" ID="ltrMessage" Text=""></asp:Literal>
    <asp:DetailsView runat="server" ID="dtvPuntos"></asp:DetailsView>
    <asp:GridView runat="server" ID="grvPuntos"></asp:GridView>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Consulta Puntos
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Consulta Puntos
</asp:Content>
