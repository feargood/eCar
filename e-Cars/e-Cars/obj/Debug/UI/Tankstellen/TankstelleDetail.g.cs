﻿#pragma checksum "..\..\..\..\UI\Tankstellen\TankstelleDetail.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C84550CE5AD5356C7FC84F76EB353B13"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.34209
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace e_Cars.UI.Tankstellen {
    
    
    /// <summary>
    /// TankstelleDetail
    /// </summary>
    public partial class TankstelleDetail : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\UI\Tankstellen\TankstelleDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonZurück;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\UI\Tankstellen\TankstelleDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DatepickerWartungstermin;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\UI\Tankstellen\TankstelleDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBStandort;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\UI\Tankstellen\TankstelleDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBState;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\UI\Tankstellen\TankstelleDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBID;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\UI\Tankstellen\TankstelleDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSave;
        
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
            System.Uri resourceLocater = new System.Uri("/e-Cars;component/ui/tankstellen/tankstelledetail.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\Tankstellen\TankstelleDetail.xaml"
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
            this.ButtonZurück = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\UI\Tankstellen\TankstelleDetail.xaml"
            this.ButtonZurück.Click += new System.Windows.RoutedEventHandler(this.ButtonZurück_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DatepickerWartungstermin = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.TBStandort = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TBState = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TBID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.ButtonSave = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\UI\Tankstellen\TankstelleDetail.xaml"
            this.ButtonSave.Click += new System.Windows.RoutedEventHandler(this.ButtonSave_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
