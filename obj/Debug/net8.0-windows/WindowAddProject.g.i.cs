﻿#pragma checksum "..\..\..\WindowAddProject.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E3BF7F87846658114D4C8584EC5F9D25FAC6D2EF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjectManagmentSystemWPF;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace ProjectManagmentSystemWPF {
    
    
    /// <summary>
    /// WindowAddProject
    /// </summary>
    public partial class WindowAddProject : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\WindowAddProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxProjectName;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\WindowAddProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxProjectEmployees;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\WindowAddProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxProjectDescription;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\WindowAddProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonAddProject;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\WindowAddProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonConstructor;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ProjectManagmentSystemWPF;V1.0.0.0;component/windowaddproject.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WindowAddProject.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.textBoxProjectName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.textBoxProjectEmployees = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.textBoxProjectDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.buttonAddProject = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\WindowAddProject.xaml"
            this.buttonAddProject.Click += new System.Windows.RoutedEventHandler(this.buttonAddProject_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.buttonConstructor = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\WindowAddProject.xaml"
            this.buttonConstructor.Click += new System.Windows.RoutedEventHandler(this.buttonConstructor_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

