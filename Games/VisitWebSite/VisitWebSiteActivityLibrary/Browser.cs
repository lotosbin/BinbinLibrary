using Microsoft.ShDocVw ;
using   mshtml;

public class Browser
{
    public static IWebBrowser2 TheInstance = new InternetExplorerClass() as IWebBrowser2;



}