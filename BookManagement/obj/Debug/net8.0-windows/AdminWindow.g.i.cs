﻿#pragma checksum "..\..\..\AdminWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A6D36A56FE33414D03F490311968F0F0F70BFE28"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BookManagement;
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


namespace BookManagement {
    
    
    /// <summary>
    /// AdminWindow
    /// </summary>
    public partial class AdminWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearchCustomer;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCustomerName;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCustomerEmail;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCustomerPhone;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpCustomerBirthday;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pbCustomerPassword;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgCustomers;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearchBook;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBookTitle;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBookAuthor;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBookStock;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBookPrice;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgBooks;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpStart;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpEnd;
        
        #line default
        #line hidden
        
        
        #line 163 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgReport;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BookManagement;V1.0.0.0;component/adminwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AdminWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\AdminWindow.xaml"
            ((BookManagement.AdminWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtSearchCustomer = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\..\AdminWindow.xaml"
            this.txtSearchCustomer.GotFocus += new System.Windows.RoutedEventHandler(this.txtSearch_GotFocus);
            
            #line default
            #line hidden
            
            #line 22 "..\..\..\AdminWindow.xaml"
            this.txtSearchCustomer.LostFocus += new System.Windows.RoutedEventHandler(this.txtSearch_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 24 "..\..\..\AdminWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnSearchCustomer_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 25 "..\..\..\AdminWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnShowAllCustomers_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 26 "..\..\..\AdminWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnAddCustomer_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 27 "..\..\..\AdminWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnUpdateCustomer_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 28 "..\..\..\AdminWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnDeleteCustomer_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 29 "..\..\..\AdminWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnClearCustomerFields_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.txtCustomerName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.txtCustomerEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.txtCustomerPhone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.dpCustomerBirthday = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 13:
            this.pbCustomerPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 14:
            this.dgCustomers = ((System.Windows.Controls.DataGrid)(target));
            
            #line 68 "..\..\..\AdminWindow.xaml"
            this.dgCustomers.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgCustomers_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 15:
            this.txtSearchBook = ((System.Windows.Controls.TextBox)(target));
            
            #line 94 "..\..\..\AdminWindow.xaml"
            this.txtSearchBook.GotFocus += new System.Windows.RoutedEventHandler(this.txtSearch_GotFocus);
            
            #line default
            #line hidden
            
            #line 94 "..\..\..\AdminWindow.xaml"
            this.txtSearchBook.LostFocus += new System.Windows.RoutedEventHandler(this.txtSearch_LostFocus);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 96 "..\..\..\AdminWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnSearchBook_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 97 "..\..\..\AdminWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnShowAllBooks_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 98 "..\..\..\AdminWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnAddBook_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 99 "..\..\..\AdminWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnUpdateBook_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 100 "..\..\..\AdminWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnDeleteBook_Click);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 101 "..\..\..\AdminWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnClearBookFields_Click);
            
            #line default
            #line hidden
            return;
            case 22:
            this.txtBookTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 23:
            this.txtBookAuthor = ((System.Windows.Controls.TextBox)(target));
            return;
            case 24:
            this.txtBookStock = ((System.Windows.Controls.TextBox)(target));
            return;
            case 25:
            this.txtBookPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 26:
            this.dgBooks = ((System.Windows.Controls.DataGrid)(target));
            
            #line 137 "..\..\..\AdminWindow.xaml"
            this.dgBooks.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgBooks_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 27:
            this.dpStart = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 28:
            this.dpEnd = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 29:
            
            #line 161 "..\..\..\AdminWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GenerateReport_Click);
            
            #line default
            #line hidden
            return;
            case 30:
            this.dgReport = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

