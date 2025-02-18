document.addEventListener('keydown', function (event) {
    if (event.key === 'Delete') {
        const focusedElement = document.activeElement;
        focusNext();
        if (focusedElement &&
            focusedElement.dataset.importance === "deletable")
            focusedElement.remove();
    }
});

function createValueInput(name) {
    const newField = document.createElement('div');
    newField.classList.add('output-field');
    newField.innerHTML = `<input type="text" name="${String(name)}" placeholder="Enter value" required data-importance="deletable">`;
    return newField;
}
async function fetchTrainData(data, url) {
    if (typeof url !== 'string') throw new Error("url must be string");

    try {
        console.log(`Fetching:`, data);

        const response = await fetch(`${BaseUrl}${url}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });
        if (!response.ok) {
            throw new Error(`Server responded with error: ${response.status}`);
        }

    } catch (error) {
        console.error("Error occured while fetch process: ", error);
    }

}