window.AceEditorInit = function () {
    if (!window.ace) {
        setTimeout(AceEditorInit, 30);
        return;
    }

    var editor = ace.edit("editor");
    editor.setTheme("ace/theme/monokai");
    editor.session.setMode("ace/mode/javascript");
    editor.setOptions({
        fontSize: "14px",
        showPrintMargin: false,
        wrap: true,
        tabSize: 2,
        useSoftTabs: true,
        showGutter: true,
        highlightActiveLine: true,
        highlightSelectedWord: true,
        enableBasicAutocompletion: true,
        enableLiveAutocompletion: true,
        enableSnippets: true
    });
};

