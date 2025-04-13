//function applicationLoadHandler() { }; function applicationUnloadHandler() { mainForm.CleanUp(); mainForm = null; Sys.Application.dispose() }; function beginRequestHandler() { mainForm.StartUpdating() }; function endRequestHandler() { mainForm.EndUpdating() }; var mainForm = { pnlPopup: "pnlPopup", innerPopup: "innerPopup", updating: false }; mainForm.StartUpdating = function () {
//    mainForm.updating = true;
//    mainForm.onUpdating()
//}; mainForm.EndUpdating = function () { mainForm.updating = false; mainForm.onUpdated() };
//mainForm.onUpdating = function () {
//    if (mainForm.updating) {
//        var pnlPopup = $get(this.pnlPopup); var innerPopup = $get(this.innerPopup); pnlPopup.style.display = ''; innerPopup.style.display = '';
//        var docBounds = mainForm.GetClientBounds();
//        var innerPopupBounds =Sys.UI.DomElement.getBounds(innerPopup);
//        var x0 = Math.floor( Math.floor(docBounds.x) + Math.floor(docBounds.width / 2) - Math.floor(innerPopupBounds.width / 2));
//        var y0 = Math.floor(Math.floor(docBounds.y) + Math.floor(docBounds.height / 2) - Math.floor(innerPopupBounds.height / 2));
//        var x = Math.floor(x0);
//        var y = Math.floor(y0);
//        if (Sys.Browser.agent == Sys.Browser.InternetExplorer) {
//            if (!pnlPopup.iFrame)
//            {
//                var iFrame = document.createElement("IFRAME"); iFrame.scrolling = "no"; iFrame.src = ""; iFrame.frameBorder = 0; iFrame.style.display = "none"; iFrame.style.position = "absolute"; iFrame.style.filter = "progid:DXImageTransform.Microsoft.Alpha(style=0,opacity=0)";
//                //iFrame.style.zIndex = 1;
//                pnlPopup.parentNode.insertBefore(iFrame, pnlPopup); pnlPopup.iFrame = iFrame
//            } pnlPopup.iFrame.style.width = Math.floor(docBounds.width) + "px";
//            pnlPopup.iFrame.style.height = Math.floor(docBounds.height) + "px";
//            pnlPopup.iFrame.style.left = Math.floor(docBounds.x) + "px";
//            pnlPopup.iFrame.style.top = docBounds.y + "px"; pnlPopup.iFrame.style.display = "block"

//        }
//    }
//}; mainForm.onUpdated = function () { var pnlPopup = $get(this.pnlPopup); var innerPopup = $get(this.innerPopup); pnlPopup.style.display = 'none'; innerPopup.style.display = 'none'; if (pnlPopup.iFrame) { pnlPopup.iFrame.style.display = "none" } }; mainForm.CleanUp = function () { var pnlPopup = $get(this.pnlPopup); if (pnlPopup && pnlPopup.iFrame) { pnlPopup.parentNode.removeChild(pnlPopup.iFrame); pnlPopup.iFrame = null } this._scrollHandler = null; this._resizeHandler = null; this.pnlPopup = null; this.innerPopup = null; this.updating = null }; mainForm.GetClientBounds = function () {
//    var clientWidth; var clientHeight; switch (Sys.Browser.agent) {
//        case Sys.Browser.InternetExplorer:
//            clientWidth = Math.floor( document.documentElement.clientWidth);
//            clientHeight = Math.floor( document.documentElement.clientHeight);
//            break;
//        case Sys.Browser.Safari:
//            Math.floor(clientWidth = window.innerWidth);
//            clientHeight = Math.floor(window.innerHeight);
//            break;
//        case Sys.Browser.Opera:
//            clientWidth = Math.floor(Math.min(window.innerWidth, document.body.clientWidth));
//            clientHeight = Math.floor(Math.min(window.innerHeight, document.body.clientHeight));
//            break;
//        default:
//            clientWidth = Math.floor(Math.min(window.innerWidth, document.documentElement.clientWidth));
//            clientHeight = Math.floor(Math.min(window.innerHeight, document.documentElement.clientHeight)); break
//    }
//    var scrollLeft = (document.documentElement.scrollLeft ? document.documentElement.scrollLeft : document.body.scrollLeft);
//    var scrollTop = (document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop);
//    return new Sys.UI.Bounds(Math.floor(scrollLeft), Math.floor(scrollTop), Math.floor(clientWidth), Math.floor(clientHeight))
//}; if (typeof (Sys) !== "undefined") Sys.Application.notifyScriptLoaded
function applicationLoadHandler() { };

function applicationUnloadHandler() {
    mainForm.CleanUp();
    mainForm = null;
    Sys.Application.dispose();
};

function beginRequestHandler() {
    mainForm.StartUpdating();
};

function endRequestHandler() {
    mainForm.EndUpdating();
};

var mainForm = {
    pnlPopup: "pnlPopup",
    innerPopup: "innerPopup",
    updating: false
};

mainForm.StartUpdating = function () {
    mainForm.updating = true;
    mainForm.onUpdating();
};

mainForm.EndUpdating = function () {
    mainForm.updating = false;
    mainForm.onUpdated();
};

mainForm.onUpdating = function () {
    if (mainForm.updating) {
        var pnlPopup = $get(this.pnlPopup);
        var innerPopup = $get(this.innerPopup);
        pnlPopup.style.display = '';
        innerPopup.style.display = '';
        var docBounds = mainForm.GetClientBounds();
        //5-1-2025 1:27 pm 
        //alert(Sys.UI.DomElement.getBounds(innerPopup));
        //var innerPopupBounds = Sys.UI.DomElement.getBounds(innerPopup);
        
        
        //var x0 = Math.floor(Math.floor(docBounds.x) + Math.floor(docBounds.width / 2) - Math.floor(innerPopupBounds.width / 2));
        //var y0 = Math.floor(Math.floor(docBounds.y) + Math.floor(docBounds.height / 2) - Math.floor(innerPopupBounds.height / 2));
        //var x = Math.floor(x0);
        //var y = Math.floor(y0);
        //alert(y);
        if (Sys.Browser.agent == Sys.Browser.InternetExplorer) {
            if (!pnlPopup.iFrame) {
                var iFrame = document.createElement("IFRAME");
                iFrame.scrolling = "no";
                iFrame.src = "";
                iFrame.frameBorder = 0;
                iFrame.style.display = "none";
                iFrame.style.position = "absolute";
                iFrame.style.filter = "progid:DXImageTransform.Microsoft.Alpha(style=0,opacity=0)";
                pnlPopup.parentNode.insertBefore(iFrame, pnlPopup);
                pnlPopup.iFrame = iFrame;
            }
            pnlPopup.iFrame.style.width = Math.floor(docBounds.width) + "px";
            pnlPopup.iFrame.style.height = Math.floor(docBounds.height) + "px";
            pnlPopup.iFrame.style.left = Math.floor(docBounds.x) + "px";
            pnlPopup.iFrame.style.top = docBounds.y + "px";
            pnlPopup.iFrame.style.display = "block";
        }
    }
};

mainForm.onUpdated = function () {
    var pnlPopup = $get(this.pnlPopup);
    var innerPopup = $get(this.innerPopup);
    pnlPopup.style.display = 'none';
    innerPopup.style.display = 'none';
    if (pnlPopup.iFrame) {
        pnlPopup.iFrame.style.display = "none";
    }
};

mainForm.CleanUp = function () {
    var pnlPopup = $get(this.pnlPopup);
    if (pnlPopup && pnlPopup.iFrame) {
        pnlPopup.parentNode.removeChild(pnlPopup.iFrame);
        pnlPopup.iFrame = null;
    }
    this._scrollHandler = null;
    this._resizeHandler = null;
    this.pnlPopup = null;
    this.innerPopup = null;
    this.updating = null;
};

mainForm.GetClientBounds = function () {
    var clientWidth;
    var clientHeight;
    switch (Sys.Browser.agent) {
        case Sys.Browser.InternetExplorer:
            clientWidth = Math.floor(document.documentElement.clientWidth);
            clientHeight = Math.floor(document.documentElement.clientHeight);
            break;
        case Sys.Browser.Safari:
            Math.floor(clientWidth = window.innerWidth);
            clientHeight = Math.floor(window.innerHeight);
            break;
        case Sys.Browser.Opera:
            clientWidth = Math.floor(Math.min(window.innerWidth, document.body.clientWidth));
            clientHeight = Math.floor(Math.min(window.innerHeight, document.body.clientHeight));
            break;
        default:
            clientWidth = Math.floor(Math.min(window.innerWidth, document.documentElement.clientWidth));
            clientHeight = Math.floor(Math.min(window.innerHeight, document.documentElement.clientHeight));
            break;
    }
    var scrollLeft = (document.documentElement.scrollLeft ? document.documentElement.scrollLeft : document.body.scrollLeft);
    var scrollTop = (document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop);
    return new Sys.UI.Bounds(Math.floor(scrollLeft), Math.floor(scrollTop), Math.floor(clientWidth), Math.floor(clientHeight));
};

if (typeof (Sys) !== "undefined")
    Sys.Application.notifyScriptLoaded();

