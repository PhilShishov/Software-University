// function solve() {
//     const SELECTORS = {
//         TABLE_ROWS: '#customers tr td:last-child',
//         MESSAGE: 'result',
//         EMAIL: 'email',
//     };

//     const message = document.getElementById(SELECTORS.MESSAGE);
//     deleteByEmail();

//     function getEmail() {
//         return document.getElementsByName(SELECTORS.EMAIL)[0].value;
//     }

//     function deleteByEmail() {
//         const rows = document.querySelectorAll(SELECTORS.TABLE_ROWS);
//         const email = getEmail();
//         const rowToDelete = Array.from(rows).find(row => row.textContent == email);
//         console.log(rowToDelete)

//         if (rowToDelete) {
//             let row = rows[0].parentNode;
//             row.parentNode.removeChild(row);
//             message.textContent = 'Deleted.';
//         } else {
//             message.textContent = "Not found.";
//         }
//     }
// }

function solve() {
    let searchedEmail = document.getElementsByName('email')[0].value;
    let emailTds = document.querySelectorAll("table tr td:nth-child(2)");
    let isFound = false;

    for (let td of emailTds) {
        if (td.textContent === searchedEmail) {
            let trElement = td.parentNode.parentNode;
            trElement.removeChild(td.parentNode);
            isFound = true;
        }
    }

    document.getElementById('result').textContent = isFound ? "Deleted." : "Not found.";
}