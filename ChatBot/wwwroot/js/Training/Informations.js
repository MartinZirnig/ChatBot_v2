const IntendsContainer = document.getElementById('intendsFields');
const PurposesContainer = document.getElementById('purposeFields');
const InformationsContainer = document.getElementById('informationFields');
const Form = document.getElementById('mainForm');


document.getElementById('appendIntend').addEventListener('click', x => {
    addIntend();
});
document.getElementById('appendPurpose').addEventListener('click', x => {
    addPurpose();
});
document.getElementById('appendInformations').addEventListener('click', x => {
    addInformation();
});
Form.addEventListener('submit', function (event) {
    event.preventDefault();

    const formData = new FormData(this);

    const informations = new Information(
        formData.getAll('Intends[]'), formData.getAll('Purposes[]'), formData.getAll('Informations[]'));
    informations.Intends = clearEmptyFromArray(informations.Intends);
    informations.Purposes = clearEmptyFromArray(informations.Purposes);
    informations.Informations = clearEmptyFromArray(informations.Informations);


    if (testInformations(informations)) {
        fetchTrainData(informations, '/Training/TrainInformations')
        Form.reset();
    }
    else {
        console.info("information format is not correct");
    }
});

function addIntend() {
    IntendsContainer.appendChild(createValueInput('Intends[]'));
}
function addPurpose() {
    PurposesContainer.appendChild(createValueInput('Purposes[]'));
}
function addInformation() {
    InformationsContainer.appendChild(createValueInput('Informations[]'));
}
function testInformations(informations) {
    console.log(informations);
    if (!Information.isInformation(informations)) return false;
    console.log(1);
    if (informations.Intends.length === 0) return false;
    console.log(2);

    if (informations.Purposes.length === 0) return false;
    console.log(3);

    if (informations.Informations.length === 0) return false;
    console.log(4);

    return true;
}
