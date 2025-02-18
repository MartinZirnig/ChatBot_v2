const EmotionsContainer = document.getElementById('emotionsFields');
const InformationsContainer = document.getElementById('informationsFields');
const Form = document.getElementById('mainForm');


document.getElementById('appendEmotion').addEventListener('click', x => {
    addEmotion();
});
document.getElementById('appendInformations').addEventListener('click', x => {
    addInformation();
});
Form.addEventListener('submit', function (event) {
    event.preventDefault();

    const formData = new FormData(this);

    const outputs = new Output(
        formData.get('Format'), formData.getAll('Emotions[]'),
        formData.getAll('Informations[]'), formData.get('Output'));
    outputs.Emotions = clearEmptyFromArray(outputs.Emotions);
    outputs.Informations = clearEmptyFromArray(outputs.Informations);


    if (testOutputs(outputs)) {
        fetchTrainData(outputs, '/Training/TrainOutputs')
        Form.reset();
    }
    else {
        console.info("information format is not correct");
    }
});

function addEmotion() {
    EmotionsContainer.appendChild(createValueInput('Emotions[]'));
}
function addInformation() {
    InformationsContainer.appendChild(createValueInput('Informations[]'));
}

function testOutputs(outputs) {
    if (!Output.isOutput(outputs)) return false;
    if (isWhiteOrEmpty(outputs.Format)) return false;
    if (outputs.Emotions.length === 0) return false;
    if (outputs.Informations.length === 0) return false;
    if (isWhiteOrEmpty(outputs.Output)) return false;


    return true;
}
