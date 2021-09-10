//1.
let salaries = {
    John: 100,
    Ann: 160,
    Pete: 130
}

let sum = 0//salaries.Ann + salaries.John + salaries.Pete

for (let key in salaries) {
    sum += salaries[key]
}
console.log(sum)

//2.
function multiplyNumeric(obj) {
    for (let key in obj) {
        if (typeof (obj[key]) == 'number')
            obj[key] = 2 * obj[key]
    }
}

let menu = {
    width: 200,
    height: 300,
    title: "My menu"
};

multiplyNumeric(menu)

console.log(menu)

//3.
function checkEmailId(str) {
    str = str.toLowerCase()
    let flag = 0, index = -1
    for (let i = 0; i < str.length; i++) {
        if (flag == 0 && str[i] == '@') {
            flag = 1
            index = i
        }
        else if (flag == 1 && str[i] == '.' && i - 1 != index) {
            return true
        }
    }
    return false
}

let email = '2@q.com'

console.log(checkEmailId(email))

//4.
function truncate(str, maxlength) {
    let length = str.length
    if (length <= maxlength)
        return str
    let new_str = ''
    for (let i = 0; i < maxlength - 1; i++) {
        new_str += str[i]
    }
    new_str += '…'
    return new_str
}

console.log(truncate("What I'd like to tell on this topic is:", 20))
console.log(truncate("Hi everyone!", 20))

//5.
let arr = ["James", "Brennie"]
console.log(arr)

arr.push("Robert")
console.log(arr)

let length = arr.length
arr[(length - 1) / 2] = "Calvin"
console.log(arr)

console.log(arr.shift())
console.log(arr)

arr.unshift("Rose", "Regal")
console.log(arr)

//6.
function validateCards(cardsToValidate, bannedPrefixes) {
    let res = []
    for (let i = 0; i < cardsToValidate.length; i++) {
        let card = cardsToValidate[i], isValid = true, isAllowed = true
        let sum = 0
        for (let j = 0; j < card.length - 1; j++) {
            sum += Number(card[j])*2
        }
        sum = sum % 10
        if (sum == card[card.length - 1]) {
            isValid = true
            for (let k = 0; k < bannedPrefixes.length; k++) {
                let str = bannedPrefixes[k]
                let length = str.length
                let checkstr = ""
                for (let l = 0; l < length; l++) {
                    checkstr += card[l]
                }
                if (checkstr == str) {
                    isAllowed = false
                    break
                }
            }
        }
        else {
            isValid = false
            isAllowed = false
        }
        res.push({ 'card': card, 'isValid': isValid, 'isAllowed': isAllowed })
    }
    return res
}

console.log(validateCards(['6724843711060148'], ['11', '3434', '67453', '9']))

//7.
function validateEmails(email) {
    let index = -1
    let step1 = false, step2 = false, step3 = false
    let step1count = 0, step3count = 0
    for (let i = 0; i < email.length; i++) {
        if (email[i] == '@' && i != 0) {
            index = i + 1
            break
        }
        else if (email[i] == '@' && i == 0) {
            return false
        }
        else {
            if (step1 == false) {
                if (email[i] < 'a' || email[i] > 'z') {
                    if (i == 0)
                        return false
                    step1 = true
                }
                else {
                    step1count += 1
                    if (step1count > 6)
                        return false
                }
            }
            if (step1 == true && step2 == false) {
                if (email[i] == '_') {
                    step2 = true
                    continue
                }
                else {
                    step2 = true
                }
            }
            if (step1 == true && step2 == true && step3 == false) {
                if (email[i] >= '0' && email[i] <= '9' ) {
                    step3count += 1
                    if (step3count > 4)
                        return false
                } else {
                    return false
                }
            }
        }
    }
    let domain = ""
    for (let j = index; j < email.length; j++) {
        domain += email[j]
    }
    if (domain == "hackerrank.com")
        return true
    return false
}

console.log(validateEmails('julia@hackerrank.com'))
console.log(validateEmails('julia_@hackerrank.com'))
console.log(validateEmails('julia_0@hackerrank.com'))
console.log(validateEmails('julia0_@hackerrank.com'))
console.log(validateEmails('julia@gmail.com'))