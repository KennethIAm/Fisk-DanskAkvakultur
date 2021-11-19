////function UnityProgress(unityInstance, progress) {
////  if (!unityInstance.Module)
////    return;
////  if (!unityInstance.logo) {
////    unityInstance.logo = document.createElement("div");
////    unityInstance.logo.className = "logo " + unityInstance.Module.splashScreenStyle;
////    unityInstance.container.appendChild(unityInstance.logo);
////  }
////  if (!unityInstance.progress) {    
////    unityInstance.progress = document.createElement("div");
////    unityInstance.progress.className = "progress " + unityInstance.Module.splashScreenStyle;
////    unityInstance.progress.empty = document.createElement("div");
////    unityInstance.progress.empty.className = "empty";
////    unityInstance.progress.appendChild(unityInstance.progress.empty);
////    unityInstance.progress.full = document.createElement("div");
////    unityInstance.progress.full.className = "full";
////    unityInstance.progress.appendChild(unityInstance.progress.full);
////    unityInstance.container.appendChild(unityInstance.progress);
////  }
////  unityInstance.progress.full.style.width = (100 * progress) + "%";
////  unityInstance.progress.empty.style.width = (100 * (1 - progress)) + "%";
////  if (progress == 1)
////    unityInstance.logo.style.display = unityInstance.progress.style.display = "none";
////}

function UnityProgress(dom) {
    this.progress = 0.0;
    this.message = "";
    this.dom = dom;
    var parent = dom.parentNode;
    this.SetProgress = function (progress) {
        if (this.progress < progress)
            this.progress = progress;

        if (progress == 1) {
            this.SetMessage("Preparing...");
            document.getElementById("bgBar").style.display = "none";
            document.getElementById("progressBar").style.display = "none";
        }
        this.Update();
    }
    this.SetMessage = function (message) {
        this.message = message;
        this.Update();
    }
    this.Clear = function () {
        document.getElementById("loadingBox").style.display = "none";
    }
    this.Update = function () {
        var length = 200 * Math.min(this.progress, 1);
        bar = document.getElementById("progressBar")
        bar.style.width = length + "px";
        document.getElementById("loadingInfo").innerHTML = this.message;
    }
    this.Update();
}