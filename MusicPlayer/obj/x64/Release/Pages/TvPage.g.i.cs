﻿#pragma checksum "..\..\..\..\Pages\TvPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9DC5A16914D257851FD5D9A36FD79DC9204B54C2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MusicPlayer.Pages;
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


namespace MusicPlayer.Pages {
    
    
    /// <summary>
    /// TvPage
    /// </summary>
    public partial class TvPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 107 "..\..\..\..\Pages\TvPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement MediaTV;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\Pages\TvPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PlayTV;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\..\Pages\TvPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StopTV;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\..\Pages\TvPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TvGrid;
        
        #line default
        #line hidden
        
        
        #line 174 "..\..\..\..\Pages\TvPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpTvList;
        
        #line default
        #line hidden
        
        
        #line 175 "..\..\..\..\Pages\TvPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DownTvList;
        
        #line default
        #line hidden
        
        
        #line 177 "..\..\..\..\Pages\TvPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView RadioCategoriesList;
        
        #line default
        #line hidden
        
        
        #line 192 "..\..\..\..\Pages\TvPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView RadioListView;
        
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
            System.Uri resourceLocater = new System.Uri("/MusicPlayer;component/pages/tvpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\TvPage.xaml"
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
            this.MediaTV = ((System.Windows.Controls.MediaElement)(target));
            return;
            case 2:
            this.PlayTV = ((System.Windows.Controls.Button)(target));
            
            #line 109 "..\..\..\..\Pages\TvPage.xaml"
            this.PlayTV.Click += new System.Windows.RoutedEventHandler(this.PlayTV_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.StopTV = ((System.Windows.Controls.Button)(target));
            
            #line 110 "..\..\..\..\Pages\TvPage.xaml"
            this.StopTV.Click += new System.Windows.RoutedEventHandler(this.StopTV_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TvGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.UpTvList = ((System.Windows.Controls.Button)(target));
            
            #line 174 "..\..\..\..\Pages\TvPage.xaml"
            this.UpTvList.Click += new System.Windows.RoutedEventHandler(this.UpTvList_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DownTvList = ((System.Windows.Controls.Button)(target));
            
            #line 175 "..\..\..\..\Pages\TvPage.xaml"
            this.DownTvList.Click += new System.Windows.RoutedEventHandler(this.DownTvList_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.RadioCategoriesList = ((System.Windows.Controls.ListView)(target));
            return;
            case 8:
            this.RadioListView = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

