const IntendsContainer = document.getElementById('outputFields');
const Form = document.getElementById('mainForm');


document.getElementById('appendOutput').addEventListener('click', x => {
    addIntend();
    jumpDown();
});

Form.addEventListener('submit', function (event) {
    event.preventDefault();

    const formData = new FormData(this);

    const intends = new Intend(
        formData.get('input'), formData.getAll('Intends[]'));
    intends.Intends = clearEmptyFromArray(intends.Intends);


    if (testEmotions(intends)) {
        fetchTrainData(intends, '/Training/TrainIntends')
        Form.reset();
    }
    else {
        console.info("intend format is not correct");
    }
});

function addIntend() {
    PurposeContainer.appendChild(createValueInput('Intends[]'));
}
function testEmotions(intends) {
    if (!Intend.isIntend(intends)) return false;
    if (isWhiteOrEmpty(intends.Input)) return false;
    if (intends.Intends.length === 0) return false;

    return true;
}
