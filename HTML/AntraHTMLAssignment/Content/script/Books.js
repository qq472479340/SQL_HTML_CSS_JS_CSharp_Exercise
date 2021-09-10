fetch('https://fakerestapi.azurewebsites.net/api/v1/Books')
    .then(function (response) {
        return response.json()
    }).then(function (jsdata) {
        let length = jsdata.length
        let tbody = document.querySelector("tbody")
        tbody.innerHTML = ""
        for (let i = 0; i < length; i++) {
            let tr = `<tr><td>${jsdata[i].id}</td><td>${jsdata[i].title}</td><td>${jsdata[i].description}</td><td>${jsdata[i].pageCount}</td><td>${jsdata[i].excerpt}</td><td>${jsdata[i].publishDate}</td></tr>`
            tbody.innerHTML = tbody.innerHTML + tr
        }
    })