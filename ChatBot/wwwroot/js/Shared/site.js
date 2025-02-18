const BaseUrl = `${window.location.protocol}//${window.location.hostname}:${window.location.port}`;

function isWhiteOrEmpty(value) {
    return (value.trim().length === 0)
}
function clearEmptyFromArray(array) {
    if (!Array.isArray(array)) throw new Error("input must be array");
    const result = [];
    array.forEach(x => {
        if (!isWhiteOrEmpty(x))
            result.push(x);
    })
    return result;
}
function jumpDown() {
    window.scrollTo(0, document.body.scrollHeight);
}
function jumpUp() {
    window.scrollTo(0, 0);
}
function focusNext() {
    let focusable = Array.from(document.querySelectorAll("input, button, a, textarea, select, [tabindex]:not([tabindex='-1'])"));
    let index = focusable.indexOf(document.activeElement);

    if (index !== -1) {
        let next = focusable[index + 1] || focusable[0];
        next.focus();
    }
}
function makeUrlParams(...params) {
    let result = "?";
    let counter = 1;

    params.forEach(value => {
        if (counter > 1) result += "&";
        result += `param${counter}=${encodeURIComponent(String(value))}`;
        counter++;
    })
    return result;
}