﻿#pragma checksum "..\..\..\WindowEmployeesConstructor.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FCB8346CB15D94F1421729BAD3F938CE52ABEF84"
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
    /// WindowEmployeesConstructor
    /// </summary>
    public partial class WindowEmployeesConstructor : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\WindowEmployeesConstructor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listBoxAll;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\WindowEmployeesConstructor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listBoxToAdd;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\WindowEmployeesConstructor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonDelete;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\WindowEmployeesConstructor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonDeleteAll;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\WindowEmployeesConstructor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonAdd;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\WindowEmployeesConstructor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonAddAll;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\WindowEmployeesConstructor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonOk;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjectManagmentSystemWPF;V1.0.0.0;component/windowemployeesconstructor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WindowEmployeesConstructor.xaml"
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
            this.listBoxAll = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.listBoxToAdd = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.buttonDelete = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\WindowEmployeesConstructor.xaml"
            this.buttonDelete.Click += new System.Windows.RoutedEventHandler(this.buttonDelete_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.buttonDeleteAll = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\WindowEmployeesConstructor.xaml"
            this.buttonDeleteAll.Click += new System.Windows.RoutedEventHandler(this.buttonDeleteAll_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.buttonAdd = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\WindowEmployeesConstructor.xaml"
            this.buttonAdd.Click += new System.Windows.RoutedEventHandler(this.buttonAdd_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.buttonAddAll = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\WindowEmployeesConstructor.xaml"
            this.buttonAddAll.Click += new System.Windows.RoutedEventHandler(this.buttonAddAll_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.buttonOk = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\WindowEmployeesConstructor.xaml"
            this.buttonOk.Click += new System.Windows.RoutedEventHandler(this.buttonOk_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

