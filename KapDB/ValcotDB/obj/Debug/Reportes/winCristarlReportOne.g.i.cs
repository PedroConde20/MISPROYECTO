﻿#pragma checksum "..\..\..\Reportes\winCristarlReportOne.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5E9D5FAF81B9F612316141913502EE7507E33F3BFE788752C03AC69F81009F5C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using KapDB.Reportes;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using RootLibrary.WPF.Localization;
using SAPBusinessObjects.WPF.Viewer;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace KapDB.Reportes {
    
    
    /// <summary>
    /// winCristarlReportOne
    /// </summary>
    public partial class winCristarlReportOne : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\Reportes\winCristarlReportOne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Reportes\winCristarlReportOne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtTitle;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Reportes\winCristarlReportOne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpInicio;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Reportes\winCristarlReportOne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpFin;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Reportes\winCristarlReportOne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIngresoPorVenta;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Reportes\winCristarlReportOne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SAPBusinessObjects.WPF.Viewer.CrystalReportsViewer viewerReceiptOne;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ValcotDB;component/reportes/wincristarlreportone.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Reportes\winCristarlReportOne.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 16 "..\..\..\Reportes\winCristarlReportOne.xaml"
            ((KapDB.Reportes.winCristarlReportOne)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Reportes\winCristarlReportOne.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.dpInicio = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.dpFin = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.btnIngresoPorVenta = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Reportes\winCristarlReportOne.xaml"
            this.btnIngresoPorVenta.Click += new System.Windows.RoutedEventHandler(this.btnIngresoPorVenta_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.viewerReceiptOne = ((SAPBusinessObjects.WPF.Viewer.CrystalReportsViewer)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

