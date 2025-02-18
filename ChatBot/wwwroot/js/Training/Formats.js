const FormatsContainer = document.getElementById('outputFields');
const Form = document.getElementById('mainForm');


document.getElementById('appendOutput').addEventListener('click', x => {
    addIntend();
    jumpDown();
});

Form.addEventListener('submit', function (event) {
    event.preventDefault();

    const formData = new FormData(this);

    const formats = new Format(
        formData.get('input'), formData.getAll('Emotions[]'), formData.get('format'));
    formats.Emotions = clearEmptyFromArray(formats.Emotions);


    if (testFormats(formats)) {
        fetchTrainData(formats, '/Training/TrainFormats')
        Form.reset();
    }
    else {
        console.info("emotion format is not correct");
    }
});

function addIntend() {
    PurposeContainer.appendChild(createValueInput('Emotions[]'));
}
function testFormats(formats) {
    if (!Format.isFormat(formats)) return false;
    if (isWhiteOrEmpty(formats.Input)) return false;
    if (isWhiteOrEmpty(formats.Format)) return;
    if (formats.Emotions.length === 0) return false;

    return true;
}
