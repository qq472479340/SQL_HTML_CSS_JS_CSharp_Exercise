fetch('https://fakerestapi.azurewebsites.net/api/v1/Authors')
    .then(function (response) {
        return response.json()
    }).then(function (jsdata) {
        let length = jsdata.length
        let tbody = document.querySelector("tbody")
        tbody.innerHTML = ""
        for (let i = 0; i < length; i++) {
            let tr = `<tr><td>${jsdata[i].id}</td><td>${jsdata[i].idBook}</td><td>${jsdata[i].firstName}</td><td>${jsdata[i].lastName}</td></tr>`
            tbody.innerHTML = tbody.innerHTML + tr
        }
    })