const user = {
    appId: "kid_rJQd9Uyv8",
    appSecret: "39bfef437ae34a9b86825315c90e9dfc",
    username: "guest",
    password: "guest"
};

const URL = `https://baas.kinvey.com/appdata/${user.appId}/students`;

const AUTH = {
    "Authorization": 'Basic ' + btoa(user.username + ':' + user.password),
    "Content-type": "application/json",
};

const DOMElements = {
    tableBodyElement: document.getElementsByTagName("tbody")[0],
    theadElements: Array.from(document.getElementsByTagName("tr")[0].children),
};

DOMElements.theadElements.forEach(e => e.addEventListener("click", sortStudent));

function loadStudents(sortWord) {
    DOMElements.tableBodyElement.innerHTML = "";

    if (!sortWord) {
        sortWord = "studentId";
    }

    fetch(URL, {
        headers: AUTH
    })
        .then(response => response.json())
        .then(data => {
            if (Number(data[0][sortWord])) {
                data.sort((a, b) => a[sortWord] - b[sortWord]).forEach(student => createTrElement(student))
            } else {
                data.sort((a, b) => a[sortWord].localeCompare(b[sortWord])).forEach(student => createTrElement(student))
            }

        });


}

loadStudents();

function createTrElement(student) {

    const trElement = document.createElement('tr');

    trElement.innerHTML = `
                <td>${student.studentId}</td>
                <td>${student.firstName}</td>
                <td>${student.lastName}</td>
                <td>${student.facultyNumber}</td>
                <td>${student.grade}</td>`;

    DOMElements.tableBodyElement.appendChild(trElement);
}

function sortStudent(ev) {
    const sortArgument = ev.target.textContent;
    let sortWord = "";
    switch (sortArgument) {
        case "ID":
            sortWord = "studentId";
            break;
        case "First Name":
            sortWord = "firstName";
            break;
        case "Last Name":
            sortWord = "lastName";
            break;
        case "Faculty Number":
            sortWord = "facultyNumber";
            break;
        case "Grade":
            sortWord = "grade";
            break;
    }
    loadStudents(sortWord);
}