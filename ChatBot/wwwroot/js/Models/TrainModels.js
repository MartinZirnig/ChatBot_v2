document.getElementById("trainForm").addEventListener("submit", async event => {
    event.preventDefault();
    try {
        const response = await fetch(`${BaseUrl}/Models/Train`, {
            method: "PATCH"
        });
        if (!response.ok) {
            throw new Error(`Server responded with error: ${response.status}`);
        }

    } catch (error) {
        console.error("Error occured while fetch process: ", error);
    }

})
document.getElementById("retrainForm").addEventListener("submit", async event => {
    event.preventDefault();

    try {
        const response = await fetch(`${BaseUrl}/Models/ReTrain`, {
            method: "PATCH"
        });
        if (!response.ok) {
            throw new Error(`Server responded with error: ${response.status}`);
        }

    } catch (error) {
        console.error("Error occured while fetch process: ", error);
    }
})