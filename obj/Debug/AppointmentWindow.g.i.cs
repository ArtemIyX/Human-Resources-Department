﻿#pragma checksum "..\..\AppointmentWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1172369EB058445038BE317CBDFCE58BB061D04502DE705066AA39FFD73EC3EB"
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
    /// AppointmentWindow
    /// </summary>
    public partial class AppointmentWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 48 "..\..\AppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid AppointmentGrid;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\AppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePicker_date;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\AppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox text_department;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\AppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox text_position;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\AppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox text_code;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\AppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox text_salary;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\AppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox text_reason;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\AppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_add;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\AppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_edit;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\AppointmentWindow.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Human Resources Department;component/appointmentwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AppointmentWindow.xaml"
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
            
            #line 9 "..\..\AppointmentWindow.xaml"
            ((Human_Resources_Department.AppointmentWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AppointmentGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 48 "..\..\AppointmentWindow.xaml"
            this.AppointmentGrid.SelectedCellsChanged += new System.Windows.Controls.SelectedCellsChangedEventHandler(this.AppointmentGrid_SelectedCellsChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.datePicker_date = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.text_department = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.text_position = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.text_code = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.text_salary = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.text_reason = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.btn_add = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\AppointmentWindow.xaml"
            this.btn_add.Click += new System.Windows.RoutedEventHandler(this.btn_add_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btn_edit = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\AppointmentWindow.xaml"
            this.btn_edit.Click += new System.Windows.RoutedEventHandler(this.btn_edit_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btn_remove = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\AppointmentWindow.xaml"
            this.btn_remove.Click += new System.Windows.RoutedEventHandler(this.btn_remove_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
