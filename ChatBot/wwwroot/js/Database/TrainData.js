const FetchButton = document.getElementById('fetchButton');
const ResponseContainer = document.getElementById('dataContainer');

const IgnoredBox = document.getElementById('showIgnored');
const LoadedBox = document.getElementById('showLoaded');
const SkipBox = document.getElementById('topValue');
const TopBox = document.getElementById('skipValue');
const TypeBox = document.getElementById('contentSelect');


FetchButton.addEventListener('click', async () => {
    const model = Models.FromText(TypeBox.value);
    const request = new DatabaseRequest(
        Number(SkipBox.value), Number(TopBox.value), IgnoredBox.checked,
        LoadedBox.checked, model);

    const response = await request.getResponse();
    console.log(response);
    appendToPage(response);
});

Models.Texts.forEach(x => {
    const option = document.createElement('option');
    option.value = x;
    option.innerText = x;
    TypeBox.appendChild(option);
});

function appendToPage(response) {
    ResponseContainer.innerHTML = "";
    response.forEach(x => {
        const component = createComponent(x);
        ResponseContainer.appendChild(component);
    });
}
function createComponent(response)
{
    switch (response.model) {
        case 0:
            return createConversationContainer(
                response.ignored, response.loaded, response.input,
                response.emotions, response.intends, response.purposes,
                response.format, response.informations, response.output,
                response.id);
        case 1:
            return createEmotionsContainer(
                response.ignored, response.loaded,
                response.input, response.emotions,
                response.id);
        case 2:
            return createFormatContainer(
                response.ignored, response.loaded, response.input,
                response.emotions, response.format,
                response.id);
        case 3:
            return createIntendsContainer(
                response.ignored, response.loaded,
                response.input, response.inteds,
                response.id);
        case 4:
            return createPurposesContainer(
                response.ignored, response.loaded,
                response.input, response.purposes,
                response.id);
        case 5: 
            return createInformationsContainer(
                response.ignored, response.loaded, response.intends,
                response.purposes, response.informations,
                response.id);
        case 6:
            return createOutputContainer(
                response.ignored, response.loaded, response.format,
                response.emotions, response.informations, response.output,
                response.id);
        default:
            throw new Error("invalid model");
    }
}

async function updateIgnore(id, ignoreElement) {
    try {

        const response = await fetch(`${BaseUrl}/Database/UpdateIgnore${makeUrlParams(id, ignoreElement.checked)}`, {
            method: 'PATCH'
        });
        if (!response.ok) {
            throw new Error(`Server responded with error: ${response.status}`);
        }

    } catch (error) {
        console.error("Error occured while fetch process: ", error);
    }
}
