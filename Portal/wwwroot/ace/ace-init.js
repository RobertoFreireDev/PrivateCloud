window.AceEditorInit = function () {
    if (!window.ace) {
        setTimeout(AceEditorInit, 30);
        return;
    }

    let previousCode = null;
    const editorCopy = new Map();

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

    const debounce = (func, wait) => {
        let timeout;
        return function (...args) {
            clearTimeout(timeout);
            timeout = setTimeout(() => func.apply(this, args), wait);
        };
    };

    function getEditor(element) {
        if (!editorCopy.has(element)) {
            editorCopy.set(element, ace.edit(element));
        }
        return editorCopy.get(element);
    }

    window.ace_destroy = function (element) {
        const editor = getEditor(element);
        editor.destroy();
        editor.container.remove();
        editorCopy.delete(element);
    };

    window.GetCode = debounce(async (dotNetHelper, element) => {
        const editor = getEditor(element);
        const code = editor.getSession().getValue();
        await dotNetHelper.invokeMethodAsync('ReceiveCode', code);
        const selectedCode = editor.getSelectedText();
        if (selectedCode !== previousCode) {
            previousCode = selectedCode;
            await dotNetHelper.invokeMethodAsync('ReceiveSelectedCode', selectedCode);
        }
    }, 20);
};

