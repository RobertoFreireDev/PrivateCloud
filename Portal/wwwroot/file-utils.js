function downloadFileFromBase64(filename, base64, contentType) {
    const link = document.createElement('a');
    link.href = `data:${contentType};base64,${base64}`;
    link.download = filename;
    link.click();
}