using System;
using System.Runtime.InteropServices;
using Gtk;

class Program
{
    [DllImport("libwebkit2gtk-4.0.so.37")]
    static extern IntPtr webkit_web_view_new();

    [DllImport("libwebkit2gtk-4.0.so.37")]
    static extern void webkit_web_view_load_uri(IntPtr webView, string uri);

    [DllImport("libgtk-3.so.0")]
    static extern void gtk_container_add(IntPtr container, IntPtr widget);

    static IntPtr webView;

    static void Main()
    {
        Application.Init();

        var window = new Window("Orbinuity App");
        window.SetDefaultSize(1024, 768);
        window.DeleteEvent += (_, __) => Application.Quit();

        VBox vbox = new VBox(false, 2);
        MenuBar menuBar = new MenuBar();

        MenuItem quitItem = new MenuItem("Quit");
        quitItem.Activated += (sender, args) => Application.Quit();

        // Navigate → Home
        MenuItem navItem = new MenuItem("GoTo");
        Menu navMenu = new Menu();
        MenuItem homeItem = new MenuItem("Home");
        homeItem.Activated += (sender, args) =>
        {
            webkit_web_view_load_uri(webView, "https://orbinuity.github.io");
        };
        navMenu.Append(homeItem);
        MenuItem typItem = new MenuItem("Thank You Page");
        typItem.Activated += (sender, args) =>
        {
            webkit_web_view_load_uri(webView, "https://orbinuity.github.io/thank-you-page");
        };
        navMenu.Append(typItem);
        MenuItem aboutItem = new MenuItem("About");
        aboutItem.Activated += (sender, args) =>
        {
            webkit_web_view_load_uri(webView, "https://orbinuity.github.io/about");
        };
        navMenu.Append(aboutItem);
        MenuItem contactItem = new MenuItem("Contact");
        contactItem.Activated += (sender, args) =>
        {
            webkit_web_view_load_uri(webView, "https://orbinuity.github.io/contact");
        };
        navMenu.Append(contactItem);
        MenuItem projectsItem = new MenuItem("Projects");
        projectsItem.Activated += (sender, args) =>
        {
            webkit_web_view_load_uri(webView, "https://orbinuity.github.io/projects");
        };
        navMenu.Append(projectsItem);
        navItem.Submenu = navMenu;

        menuBar.Append(navItem);
        menuBar.Append(quitItem);

        webView = webkit_web_view_new();
        IntPtr webViewWidget = webView;

        webkit_web_view_load_uri(webView, "https://orbinuity.github.io");

        Widget webViewWrapper = new Widget(webViewWidget);
        webViewWrapper.ShowAll();

        vbox.PackStart(menuBar, false, false, 0);
        vbox.PackStart(webViewWrapper, true, true, 0);

        window.Add(vbox);
        window.ShowAll();

        Application.Run();
    }
}
