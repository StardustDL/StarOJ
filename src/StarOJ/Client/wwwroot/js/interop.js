window.starojInteropSetTitle = function (newTitle) {
    document.title = newTitle;
};
window.starojInteropScrollTo = function (id) {
    var scrollToElement = document.getElementById(id);
    if (scrollToElement && scrollToElement.offsetTop) {
        window.scrollTo(0, scrollToElement.offsetTop);
    }
};
window.starojInteropCopyItem = function (ele) {
    ele.select();
    document.execCommand('copy');
};
window.starojInteropLoadingInfoShow = function () {
    var loadingInfo = document.getElementById("loading-info-ui");
    loadingInfo.style = "display: block";
};
window.starojInteropLoadingInfoHide = function () {
    var loadingInfo = document.getElementById("loading-info-ui");
    loadingInfo.style = "display: none";
};