const PurposeContainer = document.getElementById('outputFields');
const Form = document.getElementById('mainForm');

document.getElementById('appendOutput').addEventListener('click', x => {
    addPurpose();
    jumpDown();
});

Form.addEventListener('submit', function (event) {
    event.preventDefault();

    const formData = new FormData(this);

    const purpose = new Purpose(
        formData.get('input'), formData.getAll('Purposes[]'));
    purpose.Purposes = clearEmptyFromArray(purpose.Purposes);


    if (testPurpose(purpose)) {
        fetchTrainData(purpose, '/Training/TrainPurposes')
        Form.reset();
    }
    else {
        console.info("purpose format is not correct");
    }
});




function addPurpose() {
    PurposeContainer.appendChild(createValueInput('Purposes[]'));
}
function testPurpose(purposes) {
    if (!Purpose.isPurpose(purposes)) return false;
    if (isWhiteOrEmpty(purposes.Input)) return false;
    if (purposes.Purposes.length === 0) return false;

    return true;
}
