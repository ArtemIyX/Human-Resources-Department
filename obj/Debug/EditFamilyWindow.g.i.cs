﻿#pragma checksum "..\..\EditFamilyWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "586AD34F5F1ACB0391A4E2BE3574FD8ABBC7728A115D1773854ED09D3B410FD6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Human_Resources_Department;
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


namespace Human_Resources_Department {
    
    
    /// <summary>
    /// EditFamilyWindow
    /// </summary>
    public partial class EditFamilyWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 42 "..\..\EditFamilyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid FamilyGrid;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\EditFamilyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combo_status;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\EditFamilyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox text_pib;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\EditFamilyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox text_year;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\EditFamilyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_add;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\EditFamilyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_edit;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\EditFamilyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_remove;
        
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
            System.Uri resourceLocater = new System.Uri("/Human Resources Department;component/editfamilywindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EditFamilyWindow.xaml"
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
            
            #line 9 "..\..\EditFamilyWindow.xaml"
            ((Human_Resources_Department.EditFamilyWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.FamilyGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 42 "..\..\EditFamilyWindow.xaml"
            this.FamilyGrid.SelectedCellsChanged += new System.Windows.Controls.SelectedCellsChangedEventHandler(this.FamilyGrid_SelectedCellsChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.combo_status = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.text_pib = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.text_year = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btn_add = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\EditFamilyWindow.xaml"
            this.btn_add.Click += new System.Windows.RoutedEventHandler(this.btn_add_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_edit = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\EditFamilyWindow.xaml"
            this.btn_edit.Click += new System.Windows.RoutedEventHandler(this.btn_edit_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_remove = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\EditFamilyWindow.xaml"
            this.btn_remove.Click += new System.Windows.RoutedEventHandler(this.btn_remove_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

