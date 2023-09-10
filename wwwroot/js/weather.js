async function deleteWeather(id) {
    const delete_weather = confirm("Do you want to delete this weather entry?")
    if (delete_weather) {
        const response = await fetch("/Weathers/Delete?id=" + id, {
            method: "DELETE",
            headers: {
                "Content-Type": "application/json",
            }
        })
        window.location.reload()
    }
}

async function createWeather() {
    let status = prompt("What is the status of the Weather?")
    let message = prompt("Provide the message of the Weather.")
    if (status !== null && message !== null) {
        const data = { "Status": status, "Message": message }
        const response = await fetch("Weathers/Create", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(data)
        })
        window.location.reload()
    }
}

async function fetchWeather(id) {
    const response = await fetch("Weathers/Fetch?id=" + id, {
        method: "GET",
        headers: {
            "Content-Type": "application/json"
        },
    })

    return response.json()
}

async function updateWeather(id) {
    console.log(id)
    const weather = await fetchWeather(id)
    let status = prompt("What is the status of the Weather?", weather.status)
    let message = prompt("Provide the message of the Weather.", weather.message)
    if (status !== null && message !== null) {
        const data = { "Id": id, "Status": status, "Message": message }
        const response = await fetch("Weathers/Update", {
            method: "PATCH",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(data)
        })
        window.location.reload()
    }
}