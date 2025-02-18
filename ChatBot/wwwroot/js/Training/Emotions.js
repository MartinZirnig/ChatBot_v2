const EmotionsContainer = document.getElementById('outputFields');
const Form = document.getElementById('mainForm');


document.getElementById('appendOutput').addEventListener('click', x => {
    addEmotion();
    jumpDown();
});

Form.addEventListener('submit', function (event) {
    event.preventDefault();

    const formData = new FormData(this);

    const emotions = new Emotion(
        formData.get('input'), formData.getAll('Emotions[]'));
    emotions.Emotions = clearEmptyFromArray(emotions.Emotions);


    if (testEmotions(emotions)) {
        fetchTrainData(emotions, '/Training/TrainEmotions')
        Form.reset();
    }
    else {
        console.info("emotion format is not correct");
    }
});

function addEmotion() {
    EmotionsContainer.appendChild(createValueInput('Emotions[]'));
}
function testEmotions(emotions) {
    if (!Emotion.isEmotion(emotions)) return false;
    if (isWhiteOrEmpty(emotions.Input)) return false;
    if (emotions.Emotions.length === 0) return false;

    return true;
}
