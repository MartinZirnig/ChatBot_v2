const IntendsContainer = document.getElementById('intendFields');
const PurposeContainer = document.getElementById('purposeFields');
const EmotionsContainer = document.getElementById('outputFields');
const InformationContainer = document.getElementById('informationFields');
const Form = document.getElementById('mainForm');


document.getElementById('addIntend').addEventListener('click', x => {
    IntendsContainer.appendChild(createInputField('Intends[]'));
    jumpDown();
});
document.getElementById('addPurpose').addEventListener('click', x => {
    PurposeContainer.appendChild(createInputField('Purposes[]'));
    jumpDown();
});
document.getElementById('addEmotion').addEventListener('click', x => {
    EmotionsContainer.appendChild(createInputField('Emotions[]'));
    jumpDown();
});
document.getElementById('addInformations').addEventListener('click', x => {
    InformationContainer.appendChild(createInputField('Intends[]'));
    jumpDown();
});



Form.addEventListener('submit', function (event) {
    event.preventDefault();

    const formData = new FormData(this);

    const conversation = new CompleteConversation(
        formData.get('Input'), formData.get('Output'), formData.get('Format'),
        formData.getAll('Intends[]'), formData.getAll('Purposes[]'),
        formData.getAll('Emotions[]'), formData.getAll('Informations[]'));
    conversation.Intends = clearEmptyFromArray(conversation.Intends);
    conversation.Purposes = clearEmptyFromArray(conversation.Purposes);
    conversation.Emotions = clearEmptyFromArray(conversation.Emotions);
    conversation.Informations = clearEmptyFromArray(conversation.Informations);


    if (testConversations(conversation)) {
        fetchTrainData(conversation, '/Training/TrainConversations')
        Form.reset();
    }
    else {
        console.info("conversation format is not correct");
    }
});


function testConversations(conversation) {
    if (!CompleteConversation.isCompleteConversation(conversation)) return false;
    if (isWhiteOrEmpty(conversation.Input)) return false;
    if (isWhiteOrEmpty(conversation.Output)) return false;
    if (isWhiteOrEmpty(conversation.Format)) return false;
    if (conversation.Intends.length === 0) return false;
    if (conversation.Purposes.length === 0) return false;
    if (conversation.Emotions.length === 0) return false;
    if (conversation.Informations.length === 0) return false;

    return true;
}
