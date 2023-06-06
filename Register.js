const firstName = document.getElementById('firstName')
const lastName = document.getElementById('lastName')
const id = document.getElementById('id')
const pass = document.getElementById('pass')
const email = document.getElementById('email')
const confirmPass = document.getElementById('confirmPass')
const form = document.getElementById('form')
const error = document.getElementById('error')

form.addEventListener('submit', (e) => {
    let fullName = String(firstName.value).concat(" ", String(lastName.value))
    let messages = []
    if (!/^[a-zA-Z ]+$/.test(fullName) && !/^[א-ת ]+$/.test(fullName)) {
        messages.push("השם חייב להיות באנגלית או בעברית")
    }
    if (!/^[0-9]+$/.test(id.value)) {
        messages.push("תעודת הזהות צריכה להכיל רק מספרים")
    }
    if (id.value.length != 9) {
        messages.push("תעודת הזהות צריכה להכיל 9 מספרים")
    }
    if (pass.value !== confirmPass.value) {
        messages.push("הסיסמאות אינן תואמות")
    }
    if (!/^(?:[a-z0-9!#$%&'*+\=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+\=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])$/.test(email.value)) {
        messages.push("אימייל אינו תקין")
    }
    if (messages.length > 0) {
        e.preventDefault()
        error.innerText = messages.join(', ')
    }
})