function createEmotionsContainer(ignored, loaded, inputStringValue, inputArrayValue, id) {
    const container = document.createElement('div');
    container.classList.add('data-container-item');

    const ignoredLabel = createIgnoreCheckbox(ignored, id);

    const loadedCheckbox = document.createElement('input');
    loadedCheckbox.type = 'checkbox';
    loadedCheckbox.disabled = true;
    loadedCheckbox.checked = loaded;
    loadedCheckbox.id = 'loadedEmotions';
    const loadedLabel = document.createElement('label');
    loadedLabel.textContent = 'Loaded';
    loadedLabel.appendChild(loadedCheckbox);

    const select = document.createElement('select');
    select.disabled = true;
    const option = document.createElement('option');
    option.textContent = 'Emotions';
    select.appendChild(option);

    const inputString = document.createElement('input');
    inputString.placeholder = 'String input';
    inputString.value = inputStringValue;
    inputString.readOnly = true;
    inputString.id = 'emotionInput';

    const inputArray = document.createElement('input');
    inputArray.placeholder = 'Array of emotions (comma separated)';
    inputArray.value = inputArrayValue;
    inputArray.readOnly = true;
    inputArray.id = 'emotionsArray';

    container.append(ignoredLabel, loadedLabel, select, inputString, inputArray);
    return container;
}

function createIntendsContainer(ignored, loaded, inputStringValue, inputArrayValue, id) {
    const container = document.createElement('div');
    container.classList.add('data-container-item');

    const ignoredLabel = createIgnoreCheckbox(ignored, id);


    const loadedCheckbox = document.createElement('input');
    loadedCheckbox.type = 'checkbox';
    loadedCheckbox.checked = loaded;
    loadedCheckbox.disabled = true;
    loadedCheckbox.id = 'loadedIntends';
    const loadedLabel = document.createElement('label');
    loadedLabel.textContent = 'Loaded';
    loadedLabel.appendChild(loadedCheckbox);

    const select = document.createElement('select');
    select.disabled = true;
    const option = document.createElement('option');
    option.textContent = 'Intends';
    select.appendChild(option);

    const inputString = document.createElement('input');
    inputString.placeholder = 'String input';
    inputString.value = inputStringValue;
    inputString.readOnly = true;
    inputString.id = 'intendsInput';

    const inputArray = document.createElement('input');
    inputArray.placeholder = 'Array of intends (comma separated)';
    inputArray.value = inputArrayValue;
    inputArray.readOnly = true;
    inputArray.id = 'intendsArray';

    container.append(ignoredLabel, loadedLabel, select, inputString, inputArray);
    return container;
}

function createPurposesContainer(ignored, loaded, inputStringValue, inputArrayValue, id) {
    const container = document.createElement('div');
    container.classList.add('data-container-item');

    const ignoredLabel = createIgnoreCheckbox(ignored, id);


    const loadedCheckbox = document.createElement('input');
    loadedCheckbox.type = 'checkbox';
    loadedCheckbox.disabled = true;
    loadedCheckbox.checked = loaded;
    loadedCheckbox.id = 'loadedPurposes';
    const loadedLabel = document.createElement('label');
    loadedLabel.textContent = 'Loaded';
    loadedLabel.appendChild(loadedCheckbox);

    const select = document.createElement('select');
    select.disabled = true;
    const option = document.createElement('option');
    option.textContent = 'Purposes';
    select.appendChild(option);

    const inputString = document.createElement('input');
    inputString.placeholder = 'String input';
    inputString.value = inputStringValue;
    inputString.readOnly = true;
    inputString.id = 'purposesInput';

    const inputArray = document.createElement('input');
    inputArray.placeholder = 'Array of purposes (comma separated)';
    inputArray.value = inputArrayValue;
    inputArray.readOnly = true;
    inputArray.id = 'purposesArray';

    container.append(ignoredLabel, loadedLabel, select, inputString, inputArray);
    return container;
}

function createFormatContainer(ignored, loaded, inputStringValue, inputArrayValue, formatValue, id) {
    const container = document.createElement('div');
    container.classList.add('data-container-item');

    const ignoredLabel = createIgnoreCheckbox(ignored, id);


    const loadedCheckbox = document.createElement('input');
    loadedCheckbox.type = 'checkbox';
    loadedCheckbox.disabled = true;
    loadedCheckbox.checked = loaded;
    loadedCheckbox.id = 'loadedFormat';
    const loadedLabel = document.createElement('label');
    loadedLabel.textContent = 'Loaded';
    loadedLabel.appendChild(loadedCheckbox);

    const select = document.createElement('select');
    select.disabled = true;
    const option = document.createElement('option');
    option.textContent = 'Format';
    select.appendChild(option);

    const inputString = document.createElement('input');
    inputString.placeholder = 'String input';
    inputString.value = inputStringValue;
    inputString.readOnly = true;
    inputString.id = 'formatInput';

    const inputArray = document.createElement('input');
    inputArray.placeholder = 'Array of emotions (comma separated)';
    inputArray.value = inputArrayValue;
    inputArray.readOnly = true;
    inputArray.id = 'formatArray';

    const inputFormat = document.createElement('input');
    inputFormat.placeholder = 'Format';
    inputFormat.value = formatValue;
    inputFormat.readOnly = true;
    inputFormat.id = 'formatType';

    container.append(ignoredLabel, loadedLabel, select, inputString, inputArray, inputFormat);
    return container;
}

function createInformationsContainer(ignored, loaded, inputArray1Value,
    inputArray2Value, inputArray3Value, id) {
    const container = document.createElement('div');
    container.classList.add('data-container-item');

    const ignoredLabel = createIgnoreCheckbox(ignored, id);


    const loadedCheckbox = document.createElement('input');
    loadedCheckbox.type = 'checkbox';
    loadedCheckbox.checked = loaded;
    loadedCheckbox.disabled = true;
    loadedCheckbox.id = 'loadedInformations';
    const loadedLabel = document.createElement('label');
    loadedLabel.textContent = 'Loaded';
    loadedLabel.appendChild(loadedCheckbox);

    const select = document.createElement('select');
    select.disabled = true;
    const option = document.createElement('option');
    option.textContent = 'Informations';
    select.appendChild(option);

    const inputArray1 = document.createElement('input');
    inputArray1.placeholder = 'Array of intends (comma separated)';
    inputArray1.value = inputArray1Value;
    inputArray1.readOnly = true;
    inputArray1.id = 'informationsArray1';

    const inputArray2 = document.createElement('input');
    inputArray2.placeholder = 'Array of purposes (comma separated)';
    inputArray2.value = inputArray2Value;
    inputArray2.readOnly = true;
    inputArray2.id = 'informationsArray2';

    const inputArray3 = document.createElement('input');
    inputArray3.placeholder = 'Array of informations (comma separated)';
    inputArray3.value = inputArray3Value;
    inputArray3.readOnly = true;
    inputArray3.id = 'informationsArray3';

    container.append(ignoredLabel, loadedLabel, select, inputArray1, inputArray2, inputArray3);
    return container;
}

function createOutputContainer(ignored, loaded, formatValue,
    inputArrayValue, inputInformationsValue, outputValue, id) {
    const container = document.createElement('div');
    container.classList.add('data-container-item');

    const ignoredLabel = createIgnoreCheckbox(ignored, id);

    const loadedCheckbox = document.createElement('input');
    loadedCheckbox.type = 'checkbox';
    loadedCheckbox.checked = loaded;
    loadedCheckbox.disabled = true;
    loadedCheckbox.id = 'loadedInformations';
    const loadedLabel = document.createElement('label');
    loadedLabel.textContent = 'Loaded';
    loadedLabel.appendChild(loadedCheckbox);

    const select = document.createElement('select');
    select.disabled = true;
    const option = document.createElement('option');
    option.textContent = 'Output';
    select.appendChild(option);

    const inputFormat = document.createElement('input');
    inputFormat.placeholder = 'Format';
    inputFormat.value = formatValue;
    inputFormat.readOnly = true;
    inputFormat.id = 'outputFormat';

    const inputArray = document.createElement('input');
    inputArray.placeholder = 'Array of emotions (comma separated)';
    inputArray.value = inputArrayValue;
    inputArray.readOnly = true;
    inputArray.id = 'outputArray';

    const inputInformations = document.createElement('input');
    inputInformations.placeholder = 'Array of informations (comma separated)';
    inputInformations.value = inputInformationsValue;
    inputInformations.readOnly = true;
    inputInformations.id = 'outputInformations';

    const outputText = document.createElement('input');
    outputText.placeholder = 'Output value';
    outputText.value = outputValue;
    outputText.readOnly = true;
    outputText.id = 'outputText';

    container.append(ignoredLabel, loadedLabel, select, inputFormat, inputArray, inputInformations, outputText);
    return container;
}

function createConversationContainer(ignored, loaded, inputStringValue,
    inputArray1Value, inputArray2Value, inputArray3Value, formatValue, inputArray4Value, outputValue, id) {
    const container = document.createElement('div');
    container.classList.add('data-container-item');

    const ignoredLabel = createIgnoreCheckbox(ignored, id);

    const loadedCheckbox = document.createElement('input');
    loadedCheckbox.type = 'checkbox';
    loadedCheckbox.checked = loaded;
    loadedCheckbox.disabled = true;
    loadedCheckbox.id = 'loadedConversation';
    const loadedLabel = document.createElement('label');
    loadedLabel.textContent = 'Loaded';
    loadedLabel.appendChild(loadedCheckbox);

    const select = document.createElement('select');
    select.disabled = true;
    const option = document.createElement('option');
    option.textContent = 'Conversation';
    select.appendChild(option);

    const inputString = document.createElement('input');
    inputString.placeholder = 'Input string';
    inputString.value = inputStringValue;
    inputString.readOnly = true;
    inputString.id = 'conversationInput';

    const inputArray1 = document.createElement('input');
    inputArray1.placeholder = 'Array of emotions (comma separated)';
    inputArray1.value = inputArray1Value;
    inputArray1.readOnly = true;
    inputArray1.id = 'conversationEmotions';

    const inputArray2 = document.createElement('input');
    inputArray2.placeholder = 'Array of intents (comma separated)';
    inputArray2.value = inputArray2Value;
    inputArray2.readOnly = true;
    inputArray2.id = 'conversationIntends';

    const inputArray3 = document.createElement('input');
    inputArray3.placeholder = 'Array of purposes (comma separated)';
    inputArray3.value = inputArray3Value;
    inputArray3.readOnly = true;
    inputArray3.id = 'conversationPurposes';

    const inputFormat = document.createElement('input');
    inputFormat.placeholder = 'Format';
    inputFormat.value = formatValue;
    inputFormat.readOnly = true;
    inputFormat.id = 'conversationFormat';

    const inputArray4 = document.createElement('input');
    inputArray4.placeholder = 'Array of informations (comma separated)';
    inputArray4.value = inputArray4Value;
    inputArray4.readOnly = true;
    inputArray4.id = 'conversationInformations';

    const outputText = document.createElement('input');
    outputText.placeholder = 'Output value';
    outputText.value = outputValue;
    outputText.readOnly = true;
    outputText.id = 'conversationOutput';

    container.append(ignoredLabel, loadedLabel, select, inputString, inputArray1, inputArray2, inputArray3, inputFormat, inputArray4, outputText);
    return container;
}


function createIgnoreCheckbox(ignored, id) {
    const ignoredCheckbox = document.createElement('input');
    ignoredCheckbox.type = 'checkbox';
    ignoredCheckbox.checked = ignored;
    ignoredCheckbox.id = 'ignoredOutput';
    ignoredCheckbox.addEventListener('change', () => updateIgnore(id, ignoredCheckbox));
    const ignoredLabel = document.createElement('label');
    ignoredLabel.textContent = 'Ignored';
    ignoredLabel.appendChild(ignoredCheckbox);
    return ignoredLabel;
}