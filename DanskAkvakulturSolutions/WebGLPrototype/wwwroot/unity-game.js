var unityInstance;

window.initializeUnityInstance = function (path, progress) {
    unityInstance = UnityLoader.instantiate("unityContainer", "libs/MyGame/Build/game proto.json", { onProgress: UnityProgress });

    console.log(`Unity Instance:  ${unityInstance}`);
};

window.setFullscreen = function (isFullscreen) {
    unityInstance.SetFullscreen(1);
};