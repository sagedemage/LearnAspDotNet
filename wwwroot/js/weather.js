async function deleteWeather(id) {
    const delete_weather = confirm("Do you want to delete this weather entry?")
    if (delete_weather) {
        axios.delete("Weathers/Delete?id=" + id)
            .then(function (response) {
                console.log(response)
                window.location.reload()
            })
            .catch(function (error) {
                console.log(error)
            })
    }
}

async function createWeather() {
    const status = document.getElementById("status").value
    const message = document.getElementById("message").value

    console.log(status)
    console.log(message)

    if (status !== null && message !== null) {
        axios.post("Create", {
            "Status": status,
            "Message": message
        })
            .then(function (response) {
                console.log(response)
                window.location.href = "/Weathers"
            })
            .catch(function (error) {
                console.log(error)
            })
    }
}

async function fetchWeather(id) {
    const response = await axios.get("Weathers/Fetch?id=" + id)

    return response.data
}

async function updateWeather(id) {
    const weather = await fetchWeather(id)
    let status = prompt("What is the status of the Weather?", weather.status)
    let message = prompt("Provide the message of the Weather.", weather.message)
    if (status !== null && message !== null) {
        axios.patch("Weathers/Update", {
            "Id": id,
            "Status": status,
            "Message": message
        })
            .then(function (response) {
                console.log(response)
                window.location.reload()
            })
            .catch(function (error) {
                console.log(error)
            })
    }
}