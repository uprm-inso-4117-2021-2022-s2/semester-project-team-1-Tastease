export function beforeStart(options, extensions) {
}

export function afterStarted(blazor) {
}

function loadScriptDynamic(src) {
    var customScript = document.createElement('script');
    customScript.setAttribute('src', src);
    document.head.appendChild(customScript);
}
