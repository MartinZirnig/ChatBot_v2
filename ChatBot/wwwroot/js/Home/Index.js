const Submit = document.getElementById("send");
const Prompt = document.getElementById("input");
const HistoryContainer = document.getElementById("history");
let ResponsesCount = 0;
let ChannelOccupied = false;


Submit.addEventListener("click", button => {
    SendPrompt();
});
document.addEventListener("keypress", event => {
    if (event.key == "Enter")
        SendPrompt();
});
Prompt.focus();

function SendPrompt() {
    if (ChannelOccupied)
        return;

    const value = Prompt.value;
    Prompt.value = "";

    if (isWhiteOrEmpty(value)) return;

    const container = CreateTextContainer(
        "prompt-box", value, "prompt_" + String(ResponsesCount)
    );
    HistoryContainer.appendChild(container);

    FetchPrompt(value);
}
async function FetchPrompt(text) {
    ChannelOccupied = true;

    let recived;

    try {
        const response = await fetch(`${BaseUrl}/Home/ChatbotApi`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                content: text  
            })
        });

        if (!response.ok) {
            throw new Error(`Server responded with error: ${response.status}`);
        }

        const data = await response.json();
        console.log("Response:", data);

        ReciveResponse(data.content);
    } catch (error) {
        console.error("Errer occured while fetch process: ", error);
    }

    ChannelOccupied = false;
}
function ReciveResponse(response) {
    const container = CreateTextContainer(
        "responese-box", response, "response_" + String(ResponsesCount)
    );
    HistoryContainer.appendChild(container);
}

function CreateTextContainer(classname, text, name) {
    const container = document.createElement("div");
    container.classList.add(classname)
    container.id = name;
    container.name = name;

    const content = document.createElement("code");
    content.textContent = text;
    content.id = name + "_text";
    content.name = name + "_text";

    container.appendChild(content);
    return container;
}