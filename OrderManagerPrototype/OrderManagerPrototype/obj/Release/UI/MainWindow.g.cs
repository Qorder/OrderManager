﻿#pragma checksum "..\..\..\UI\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FC6215A71779458A5BF8ACC61C027AB6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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


namespace OrderManagerPrototype {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\UI\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal OrderManagerPrototype.MainWindow OrderManager;
        
        #line default
        #line hidden
        
        
        #line 5 "..\..\..\UI\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\UI\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView InboxView;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\UI\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView ServicedView;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\UI\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Viewbox InboxViewbox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\UI\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label InboxLabel;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\UI\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Viewbox ServicedViewbox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\UI\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ServicedLabel;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\UI\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label InboxCounter;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\UI\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ServicedCounter;
        
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
            System.Uri resourceLocater = new System.Uri("/OrderManagerPrototype;component/ui/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UI\MainWindow.xaml"
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
            this.OrderManager = ((OrderManagerPrototype.MainWindow)(target));
            
            #line 4 "..\..\..\UI\MainWindow.xaml"
            this.OrderManager.Closed += new System.EventHandler(this.OrderManager_Closed);
            
            #line default
            #line hidden
            
            #line 4 "..\..\..\UI\MainWindow.xaml"
            this.OrderManager.SizeChanged += new System.Windows.SizeChangedEventHandler(this.OrderManager_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.InboxView = ((System.Windows.Controls.TreeView)(target));
            
            #line 17 "..\..\..\UI\MainWindow.xaml"
            this.InboxView.MouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.InboxView_MouseRightButtonUp);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\UI\MainWindow.xaml"
            this.InboxView.TouchUp += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.InboxView_TouchUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ServicedView = ((System.Windows.Controls.TreeView)(target));
            return;
            case 5:
            this.InboxViewbox = ((System.Windows.Controls.Viewbox)(target));
            return;
            case 6:
            this.InboxLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.ServicedViewbox = ((System.Windows.Controls.Viewbox)(target));
            return;
            case 8:
            this.ServicedLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.InboxCounter = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.ServicedCounter = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

