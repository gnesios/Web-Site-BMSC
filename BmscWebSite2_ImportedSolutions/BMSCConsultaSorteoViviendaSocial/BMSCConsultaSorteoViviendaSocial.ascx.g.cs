﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BmscWebSite2_ImportedSolutions.BMSCConsultaSorteoViviendaSocial {
    using System.Web.UI.WebControls.Expressions;
    using System.Web.UI.HtmlControls;
    using System.Collections;
    using System.Text;
    using System.Web.UI;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Microsoft.SharePoint.WebPartPages;
    using System.Web.SessionState;
    using System.Configuration;
    using Microsoft.SharePoint;
    using System.Web;
    using System.Web.DynamicData;
    using System.Web.Caching;
    using System.Web.Profile;
    using System.ComponentModel.DataAnnotations;
    using System.Web.UI.WebControls;
    using System.Web.Security;
    using System;
    using Microsoft.SharePoint.Utilities;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    using System.Web.UI.WebControls.WebParts;
    using Microsoft.SharePoint.WebControls;
    using System.CodeDom.Compiler;
    
    
    public partial class BMSCConsultaSorteoViviendaSocial {
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected global::System.Web.UI.WebControls.DropDownList ddlTipoDocumento;
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected global::System.Web.UI.WebControls.RequiredFieldValidator rfvTipoDocumento;
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected global::System.Web.UI.WebControls.TextBox txbDocumento;
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected global::System.Web.UI.WebControls.RequiredFieldValidator rfvDocumento;
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected global::System.Web.UI.WebControls.DropDownList ddlDepartamento;
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected global::System.Web.UI.WebControls.RequiredFieldValidator rfvDepartamento;
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected global::System.Web.UI.WebControls.LinkButton lnkConfirm;
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected global::System.Web.UI.WebControls.Literal ltrScriptLoader;
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected global::System.Web.UI.WebControls.Literal ltrMessage;
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebPartCodeGenerator", "12.0.0.0")]
        public static implicit operator global::System.Web.UI.TemplateControl(BMSCConsultaSorteoViviendaSocial target) 
        {
            return target == null ? null : target.TemplateControl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control3() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Selected = true;
            @__ctrl.Text = "CARNET DE IDENTIDAD";
            @__ctrl.Value = "1";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control4() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Text = "OTRO DOCUMENTO";
            @__ctrl.Value = "2";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private void @__BuildControl__control2(System.Web.UI.WebControls.ListItemCollection @__ctrl) {
            global::System.Web.UI.WebControls.ListItem @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control3();
            @__ctrl.Add(@__ctrl1);
            global::System.Web.UI.WebControls.ListItem @__ctrl2;
            @__ctrl2 = this.@__BuildControl__control4();
            @__ctrl.Add(@__ctrl2);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.DropDownList @__BuildControlddlTipoDocumento() {
            global::System.Web.UI.WebControls.DropDownList @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.DropDownList();
            this.ddlTipoDocumento = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "ddlTipoDocumento";
            @__ctrl.CssClass = "form";
            @__ctrl.AutoPostBack = true;
            @__ctrl.ToolTip = "Tipo de documento";
            this.@__BuildControl__control2(@__ctrl.Items);
            @__ctrl.SelectedIndexChanged -= new System.EventHandler(this.ddlTipoDocumento_SelectedIndexChanged);
            @__ctrl.SelectedIndexChanged += new System.EventHandler(this.ddlTipoDocumento_SelectedIndexChanged);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.RequiredFieldValidator @__BuildControlrfvTipoDocumento() {
            global::System.Web.UI.WebControls.RequiredFieldValidator @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.RequiredFieldValidator();
            this.rfvTipoDocumento = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "rfvTipoDocumento";
            @__ctrl.ControlToValidate = "ddlTipoDocumento";
            @__ctrl.ValidationGroup = "SorteoVivienda";
            @__ctrl.Display = global::System.Web.UI.WebControls.ValidatorDisplay.Dynamic;
            @__ctrl.ErrorMessage = "Debe elegir un valor para este campo.";
            @__ctrl.InitialValue = "0";
            @__ctrl.SetFocusOnError = true;
            @__ctrl.ForeColor = ((System.Drawing.Color)(global::System.Drawing.Color.FromArgb(149, 193, 31)));
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.TextBox @__BuildControltxbDocumento() {
            global::System.Web.UI.WebControls.TextBox @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.TextBox();
            this.txbDocumento = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "txbDocumento";
            @__ctrl.CssClass = "form";
            ((System.Web.UI.IAttributeAccessor)(@__ctrl)).SetAttribute("placeholder", "(Documento de identidad)");
            @__ctrl.MaxLength = 20;
            @__ctrl.ToolTip = "Documento de identidad";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.RequiredFieldValidator @__BuildControlrfvDocumento() {
            global::System.Web.UI.WebControls.RequiredFieldValidator @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.RequiredFieldValidator();
            this.rfvDocumento = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "rfvDocumento";
            @__ctrl.ControlToValidate = "txbDocumento";
            @__ctrl.ValidationGroup = "SorteoVivienda";
            @__ctrl.Display = global::System.Web.UI.WebControls.ValidatorDisplay.Dynamic;
            @__ctrl.ErrorMessage = "Debe ingresar un valor para este campo.";
            @__ctrl.SetFocusOnError = true;
            @__ctrl.ForeColor = ((System.Drawing.Color)(global::System.Drawing.Color.FromArgb(149, 193, 31)));
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control6() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Selected = true;
            @__ctrl.Text = "(Departamento expedido)";
            @__ctrl.Value = "0";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control7() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Text = "BENI";
            @__ctrl.Value = "BE";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control8() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Text = "COCHABAMBA";
            @__ctrl.Value = "CB";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control9() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Text = "CHUQUISACA";
            @__ctrl.Value = "CH";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control10() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Text = "LA PAZ";
            @__ctrl.Value = "LP";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control11() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Text = "ORURO";
            @__ctrl.Value = "OR";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control12() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Text = "PANDO";
            @__ctrl.Value = "PA";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control13() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Text = "POTOSÍ";
            @__ctrl.Value = "PO";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control14() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Text = "SANTA CRUZ";
            @__ctrl.Value = "SC";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.ListItem @__BuildControl__control15() {
            global::System.Web.UI.WebControls.ListItem @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.ListItem();
            @__ctrl.Text = "TARIJA";
            @__ctrl.Value = "TJ";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private void @__BuildControl__control5(System.Web.UI.WebControls.ListItemCollection @__ctrl) {
            global::System.Web.UI.WebControls.ListItem @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control6();
            @__ctrl.Add(@__ctrl1);
            global::System.Web.UI.WebControls.ListItem @__ctrl2;
            @__ctrl2 = this.@__BuildControl__control7();
            @__ctrl.Add(@__ctrl2);
            global::System.Web.UI.WebControls.ListItem @__ctrl3;
            @__ctrl3 = this.@__BuildControl__control8();
            @__ctrl.Add(@__ctrl3);
            global::System.Web.UI.WebControls.ListItem @__ctrl4;
            @__ctrl4 = this.@__BuildControl__control9();
            @__ctrl.Add(@__ctrl4);
            global::System.Web.UI.WebControls.ListItem @__ctrl5;
            @__ctrl5 = this.@__BuildControl__control10();
            @__ctrl.Add(@__ctrl5);
            global::System.Web.UI.WebControls.ListItem @__ctrl6;
            @__ctrl6 = this.@__BuildControl__control11();
            @__ctrl.Add(@__ctrl6);
            global::System.Web.UI.WebControls.ListItem @__ctrl7;
            @__ctrl7 = this.@__BuildControl__control12();
            @__ctrl.Add(@__ctrl7);
            global::System.Web.UI.WebControls.ListItem @__ctrl8;
            @__ctrl8 = this.@__BuildControl__control13();
            @__ctrl.Add(@__ctrl8);
            global::System.Web.UI.WebControls.ListItem @__ctrl9;
            @__ctrl9 = this.@__BuildControl__control14();
            @__ctrl.Add(@__ctrl9);
            global::System.Web.UI.WebControls.ListItem @__ctrl10;
            @__ctrl10 = this.@__BuildControl__control15();
            @__ctrl.Add(@__ctrl10);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.DropDownList @__BuildControlddlDepartamento() {
            global::System.Web.UI.WebControls.DropDownList @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.DropDownList();
            this.ddlDepartamento = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "ddlDepartamento";
            @__ctrl.CssClass = "form";
            @__ctrl.ToolTip = "Departamento expedido";
            this.@__BuildControl__control5(@__ctrl.Items);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.RequiredFieldValidator @__BuildControlrfvDepartamento() {
            global::System.Web.UI.WebControls.RequiredFieldValidator @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.RequiredFieldValidator();
            this.rfvDepartamento = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "rfvDepartamento";
            @__ctrl.ControlToValidate = "ddlDepartamento";
            @__ctrl.ValidationGroup = "SorteoVivienda";
            @__ctrl.Display = global::System.Web.UI.WebControls.ValidatorDisplay.Dynamic;
            @__ctrl.ErrorMessage = "Debe elegir un valor para este campo.";
            @__ctrl.InitialValue = "0";
            @__ctrl.SetFocusOnError = true;
            @__ctrl.ForeColor = ((System.Drawing.Color)(global::System.Drawing.Color.FromArgb(149, 193, 31)));
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.LinkButton @__BuildControllnkConfirm() {
            global::System.Web.UI.WebControls.LinkButton @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.LinkButton();
            this.lnkConfirm = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "lnkConfirm";
            @__ctrl.Text = "consultar";
            @__ctrl.ValidationGroup = "SorteoVivienda";
            @__ctrl.Click -= new System.EventHandler(this.lnkConfirm_Click);
            @__ctrl.Click += new System.EventHandler(this.lnkConfirm_Click);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.Literal @__BuildControlltrScriptLoader() {
            global::System.Web.UI.WebControls.Literal @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Literal();
            this.ltrScriptLoader = @__ctrl;
            @__ctrl.ID = "ltrScriptLoader";
            @__ctrl.Text = "";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.Literal @__BuildControlltrMessage() {
            global::System.Web.UI.WebControls.Literal @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Literal();
            this.ltrMessage = @__ctrl;
            @__ctrl.ID = "ltrMessage";
            @__ctrl.Text = "";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private void @__BuildControlTree(global::BmscWebSite2_ImportedSolutions.BMSCConsultaSorteoViviendaSocial.BMSCConsultaSorteoViviendaSocial @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n<div class=\"simulator\">\r\n    <p>Consulta tu participaci&oacute;n en el sorteo" +
                        "</p>\r\n    <p>\r\n        "));
            global::System.Web.UI.WebControls.DropDownList @__ctrl1;
            @__ctrl1 = this.@__BuildControlddlTipoDocumento();
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n        "));
            global::System.Web.UI.WebControls.RequiredFieldValidator @__ctrl2;
            @__ctrl2 = this.@__BuildControlrfvTipoDocumento();
            @__parser.AddParsedSubObject(@__ctrl2);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n    </p>\r\n    <p>\r\n        "));
            global::System.Web.UI.WebControls.TextBox @__ctrl3;
            @__ctrl3 = this.@__BuildControltxbDocumento();
            @__parser.AddParsedSubObject(@__ctrl3);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n        "));
            global::System.Web.UI.WebControls.RequiredFieldValidator @__ctrl4;
            @__ctrl4 = this.@__BuildControlrfvDocumento();
            @__parser.AddParsedSubObject(@__ctrl4);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n    </p>\r\n    <p>\r\n        "));
            global::System.Web.UI.WebControls.DropDownList @__ctrl5;
            @__ctrl5 = this.@__BuildControlddlDepartamento();
            @__parser.AddParsedSubObject(@__ctrl5);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n        "));
            global::System.Web.UI.WebControls.RequiredFieldValidator @__ctrl6;
            @__ctrl6 = this.@__BuildControlrfvDepartamento();
            @__parser.AddParsedSubObject(@__ctrl6);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n    </p>\r\n    <p class=\"buttonarea\">"));
            global::System.Web.UI.WebControls.LinkButton @__ctrl7;
            @__ctrl7 = this.@__BuildControllnkConfirm();
            @__parser.AddParsedSubObject(@__ctrl7);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("</p>\r\n    <img src=\"/_catalogs/masterpage/bmsc/images/form_icon.png\" alt=\"\">\r\n   " +
                        " "));
            global::System.Web.UI.WebControls.Literal @__ctrl8;
            @__ctrl8 = this.@__BuildControlltrScriptLoader();
            @__parser.AddParsedSubObject(@__ctrl8);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n    "));
            global::System.Web.UI.WebControls.Literal @__ctrl9;
            @__ctrl9 = this.@__BuildControlltrMessage();
            @__parser.AddParsedSubObject(@__ctrl9);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n</div>"));
        }
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private void InitializeControl() {
            this.@__BuildControlTree(this);
            this.Load += new global::System.EventHandler(this.Page_Load);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected virtual object Eval(string expression) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected virtual string Eval(string expression, string format) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression, format);
        }
    }
}