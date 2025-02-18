const BackupInput = document.getElementById("backupName");
const RestoreInput = document.getElementById("restoreModels");


document.getElementById("backupForm")
    .addEventListener("submit", async event => {
        event.preventDefault();

        try {
            const response = await fetch(`${BaseUrl}/Models/BackupModel`, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({ name: BackupInput.value })
            });

            if (!response.ok) {
                throw new Error(`Server responded with error: ${response.status}`);
            }
            
        } catch (error) {
            console.error("Error occured while fetch process: ", error);
        }
    });

document.getElementById("restoreForm")
    .addEventListener("submit", async event => {
        event.preventDefault();
        try {
            const response = await fetch(`${BaseUrl}/Models/RestoreModel`, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({ name: RestoreInput.value })
            });

            if (!response.ok) {
                throw new Error(`Server responded with error: ${response.status}`);
            }

        } catch (error) {
            console.error("Error occured while fetch process: ", error);
        }
    });
document.getElementById("clearForm")
    .addEventListener("submit", async event => {
        event.preventDefault();
        try {
            const response = await fetch(`${BaseUrl}/Models/ClearModel`, {
                method: "POST"
            });

            if (!response.ok) {
                throw new Error(`Server responded with error: ${response.status}`);
            }

        } catch (error) {
            console.error("Error occured while fetch process: ", error);
        }
    });


window.onload = () => {
    reloadModelNames();
}

async function reloadModelNames() {
    try {
        const response = await fetch(`${BaseUrl}/Models/GetModelBackup`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        });
        if (!response.ok) {
            throw new Error(`Server responded with error: ${response.status}`);
        }
        const data = await response.json();
        console.log(data);
        fillModelNames(data);

    } catch (error) {
        console.error("Error occured while fetch process: ", error);
    }
}
function fillModelNames(data) {
    data.forEach(value => {
        const element = document.createElement('option');
        element.value = value;
        element.textContent = value;
        RestoreInput.appendChild(element);
    });
}