﻿#pragma checksum "C:\Users\darsh\source\repos\event-details-registration\EventDetails\Finish.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7A37A799C9D241AF14C4F1908AB3BF26"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EventDetails
{
    partial class Finish : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.SuccessMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 2:
                {
                    this.Again = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 36 "..\..\..\Finish.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.Again).Click += this.Again_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.LogOutButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 23 "..\..\..\Finish.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.LogOutButton).Click += this.logoutbutton_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
