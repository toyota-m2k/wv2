using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wv2 {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        protected string callerName([CallerMemberName] string memberName = "") {
            return memberName;
        }

        private void WV2NavigationStarting(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            Debug.WriteLine($"{callerName()}:{e.Uri} ({e.NavigationId})");
        }

        private void WV2ContentLoaded(object sender, Microsoft.Web.WebView2.Core.CoreWebView2ContentLoadingEventArgs e)
        {
            Debug.WriteLine($"{callerName()}: ({e.NavigationId})");
        }

        private void WV2NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            Debug.WriteLine($"{callerName()}: {e.IsSuccess} ({e.NavigationId})");
        }

        private void WV2WebMessageChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
            Debug.WriteLine(callerName());
        }

        private void WV2SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e)
        {
            Debug.WriteLine($"{callerName()}: is new document = {e.IsNewDocument}");
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {

        }

        private void WV2CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            webView.CoreWebView2.NavigationStarting += CWV2NavigationStarting;
            webView.CoreWebView2.ContentLoading += CWV2ContentLoading;
            webView.CoreWebView2.DOMContentLoaded += CWV2DomContentLoaded;
            webView.CoreWebView2.WebResourceRequested += CWV2WebResourceRequested;
            webView.CoreWebView2.SourceChanged += CWV2SourceChanged;
            webView.CoreWebView2.NavigationCompleted += CWV2NavigationCompleted;
            webView.CoreWebView2.FrameNavigationStarting += CWV2FrameNavigationStarting;
            webView.CoreWebView2.FrameNavigationCompleted += CWV2FrameNavigationCompleted;
            webView.CoreWebView2.DownloadStarting += CWV2DownloadStarting;
            webView.CoreWebView2.HistoryChanged += CWV2HistoryChanged;
            webView.CoreWebView2.NewWindowRequested += CWV2NewWindowRequested;

        }

        private void CWV2NewWindowRequested(object sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            Debug.WriteLine($"{callerName()}:{e.Uri}");
            e.Handled = true;
        }

        private void CWV2HistoryChanged(object sender, object e)
        {
            Debug.WriteLine($"{callerName()}: {e}");
        }

        private void CWV2DownloadStarting(object sender, CoreWebView2DownloadStartingEventArgs e)
        {
            Debug.WriteLine($"{callerName()}: {e.DownloadOperation.Uri}");
        }

        private void CWV2FrameNavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            Debug.WriteLine($"{callerName()}: {e.IsSuccess} ({e.NavigationId})");
        }

        private void CWV2FrameNavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            Debug.WriteLine($"{callerName()}:{e.Uri} ({e.NavigationId})");
        }

        private void CWV2NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            Debug.WriteLine($"{callerName()}: {e.IsSuccess} ({e.NavigationId})");
        }

        private void CWV2SourceChanged(object sender, CoreWebView2SourceChangedEventArgs e)
        {
            Debug.WriteLine($"{callerName()}: {webView.Source} : new document = ({e.IsNewDocument})");
        }

        private void CWV2WebResourceRequested(object sender, CoreWebView2WebResourceRequestedEventArgs e)
        {
            Debug.WriteLine($"{callerName()}: ({e.Request.Uri})");
        }

        private void CWV2DomContentLoaded(object sender, CoreWebView2DOMContentLoadedEventArgs e)
        {
            Debug.WriteLine($"{callerName()}: ({e.NavigationId})");
        }

        private void CWV2ContentLoading(object sender, CoreWebView2ContentLoadingEventArgs e)
        {
            Debug.WriteLine($"{callerName()}: ({e.NavigationId})");
        }

        private void CWV2NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            Debug.WriteLine($"{callerName()}:{e.Uri} ({e.NavigationId})");
        }

        //private void WebView_ContainsFullScreenElementChanged(object sender, object e) {
        //    Debug.WriteLine(callerName());
        //}

        //private void WebView_ContentLoading(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlContentLoadingEventArgs e) {
        //    Debug.WriteLine(callerName());
        //}

        //private void WebView_DOMContentLoaded(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlDOMContentLoadedEventArgs e) {
        //    Debug.WriteLine(callerName());
        //}

        //private void WebView_FrameContentLoading(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlContentLoadingEventArgs e) {
        //    Debug.WriteLine(callerName());
        //}

        //private void WebView_FrameDOMContentLoaded(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlDOMContentLoadedEventArgs e) {
        //    Debug.WriteLine(callerName());
        //}

        //private void WebView_FrameNavigationCompleted(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlNavigationCompletedEventArgs e) {
        //    Debug.WriteLine(callerName());
        //}

        //private void WebView_FrameNavigationStarting(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlNavigationStartingEventArgs e) {
        //    Debug.WriteLine(callerName());
        //    e.Cancel = true;
        //}

        //private void WebView_LongRunningScriptDetected(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlLongRunningScriptDetectedEventArgs e) {
        //    Debug.WriteLine(callerName());
        //}

        //private void WebView_NavigationCompleted(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlNavigationCompletedEventArgs e) {
        //    Debug.WriteLine(callerName());
        //}

        //private void WebView_NavigationStarting(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlNavigationStartingEventArgs e) {
        //    Debug.WriteLine(callerName());
        //}

        //private void WebView_NewWindowRequested(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlNewWindowRequestedEventArgs e) {
        //    Debug.WriteLine(callerName());
        //}

        //private void WebView_PermissionRequested(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlPermissionRequestedEventArgs e) {
        //    Debug.WriteLine(callerName());
        //}

        //private void WebView_ScriptNotify(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlScriptNotifyEventArgs e) {
        //    Debug.WriteLine(callerName());
        //}

        //private void WebView_UnsafeContentWarningDisplaying(object sender, object e) {
        //    Debug.WriteLine(callerName());
        //}

        //private void WebView_UnsupportedUriSchemeIdentified(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlUnsupportedUriSchemeIdentifiedEventArgs e) {
        //    Debug.WriteLine(callerName());
        //}

        //private void WebView_UnviewableContentIdentified(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlUnviewableContentIdentifiedEventArgs e) {
        //    Debug.WriteLine(callerName());
        //}
    }
}
