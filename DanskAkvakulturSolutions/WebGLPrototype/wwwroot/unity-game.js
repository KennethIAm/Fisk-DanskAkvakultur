var unityInstance;

window.initializeUnityInstance = function (container, webglBuildUrl) {
    console.log(`Container: ${container} WebGL URL: ${webglBuildUrl}`);

    unityInstance = UnityLoader.instantiate(container, webglBuildUrl, {
        onProgress: UnityProgress,
        Module: {
            onQuit: function () {
                //console.warn("Unity is disposed.");
                disposeUnityInstance;
            }
        }
    });
};

window.disposeUnityInstance = function () {
    if (unityInstance) {
        unityInstance.Quit(function () {
            console.log("Unity has quit.");
        });

        unityInstance = null;
    }
};