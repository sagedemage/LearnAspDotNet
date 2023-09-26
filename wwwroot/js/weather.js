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

function updateWeather() {
    const params = new URLSearchParams(window.location.search)
    const id = params.get('id')
    console.log(id)

    const status = document.getElementById("status").value
    const message = document.getElementById("message").value

    if (status !== null && message !== null) {
        axios.patch("Update", {
            "Id": id,
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