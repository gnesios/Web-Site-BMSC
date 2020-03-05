<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BMSCConsultaPuntos.ascx.cs" Inherits="BmscWebSite2_ImportedSolutions.BMSCConsultaPuntos.BMSCConsultaPuntos" %>

<div class="simulator">
    <p>Consulta tus puntos acumulados</p>

    <p>
        <asp:TextBox runat="server" ID="txbDocumento" CssClass="form" placeholder="(Documento de identidad)" MaxLength="20" ToolTip="Documento de identidad"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="rfvDocumento" ControlToValidate="txbDocumento" ValidationGroup="Puntos"
            Display="Dynamic" ErrorMessage="Debe ingresar un valor para este campo."
            SetFocusOnError="true" ForeColor="#95c11f"></asp:RequiredFieldValidator>
    </p>

    <p class="footnote">Por ejemplo 1234567LP ó 7894561SC ó 4567893CB</p>
    
    <script src='https://www.google.com/recaptcha/api.js'></script>
    <div class="g-recaptcha" style="transform:scale(0.75);transform-origin:40px 0" data-sitekey="<%= ConfigurationManager.AppSettings["SiteKey"] %>"></div>
    <asp:Label runat="server" ID="lblCaptcha" ForeColor="#95c11f"></asp:Label>

    <p class="buttonarea"><asp:LinkButton runat="server" ID="lnkConfirm" OnClick="lnkConfirm_Click" Text="consultar" ValidationGroup="Puntos"></asp:LinkButton></p>

    <img src="/_catalogs/masterpage/bmsc/images/form_icon.png" alt="">

    <asp:Literal runat="server" ID="ltrScriptLoader" Text=""></asp:Literal>
    <asp:Literal runat="server" ID="ltrMessage" Text=""></asp:Literal>
</div>