var GLOBAL = {};
GLOBAL.DotNetReference = null;
GLOBAL.SetDotnetReference = function (pDotNetReference) {
    GLOBAL.DotNetReference = pDotNetReference;
};

window.setDotNetReference = function (objRef) {
    GLOBAL.SetDotnetReference(objRef);
};