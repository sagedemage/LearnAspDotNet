// View: Weathers/Edit

window.onload = (event) => {
    const params = new URLSearchParams(window.location.search)
    const id = params.get('id')

    const response = axios.get("Fetch?id=" + id).then(function (response) {
        console.log(response.data)
        document.getElementById("status").value = response.data.status
        document.getElementById("message").value = response.data.message
    }).catch(function (error) {
        console.log(error)
    })
}