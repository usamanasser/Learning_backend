function changeLang(lang) {
    sessionStorage.setItem("locales", lang);
}
if (sessionStorage.getItem('Dir') == 'ltr' || sessionStorage.getItem('Dir') == null || sessionStorage.getItem('Dir').length == 0 || sessionStorage.getItem('Dir') == "null") {
    removeCSS('~/assets/css/app-rtl.min.css');
}

if (sessionStorage.getItem("Dir") == 'rtl') {
    //loadCSS('~/assets/css/app-rtl.min.css');
    var cssStyles = `
            /* Your CSS styles for RTL */
                    .page-wrapper {
                      margin-left: 0px !important;
        }
                      .navbar-custom{
                                  display: flex;
            justify-content: space-between;
            flex-direction: row-reverse;
                          }
           body{
               font-family: 'Cairo', sans-serif !important;
           }
          a, .btn, button, span, p, input, select, textarea, li, h1, h2, h3, h4, h5, h6 {
                font-family: 'Cairo', sans-serif !important;
           }
           
          `;

    var styleElement = document.createElement('style');
    styleElement.innerHTML = cssStyles;
    document.head.appendChild(styleElement);
}

window.addEventListener('beforeunload', function () {
    var htmlElement = document.documentElement;
    var currentDir = htmlElement.getAttribute('dir');

    if (currentDir) {
        sessionStorage.setItem('Dir', currentDir);
    }
});



function changeDir(x, lang) {
    document.documentElement.setAttribute('dir', x);
    sessionStorage.setItem("Dir", x);
    sessionStorage.setItem("locales", lang);
    var currentUrl = encodeURI(window.location.pathname + window.location.search);
    debugger;
    if (x == 'ltr') {

        var returnUrl = currentUrl;
        var redirectUrl = '/Home/SetLanguage?culture=en-US&returnUrl=' + returnUrl;
        window.location.href = redirectUrl;


           

    }
    else {

        returnUrl = currentUrl;
        redirectUrl = '/Home/SetLanguage?culture=tr-TR&returnUrl=' + returnUrl;
        window.location.href = redirectUrl;
    }

  

}
function removeCSS(cssFilePath) {
    var adjustedPath = cssFilePath;

    if (cssFilePath.startsWith('~/assets')) {
        adjustedPath = cssFilePath.replace('~/assets', '/assets');
    }

    var links = document.getElementsByTagName('link');
    for (var i = 0; i < links.length; i++) {
        var link = links[i];
        if (link.getAttribute('href') === adjustedPath) {
            link.parentNode.removeChild(link);
            break;
        }
    }
}


   


