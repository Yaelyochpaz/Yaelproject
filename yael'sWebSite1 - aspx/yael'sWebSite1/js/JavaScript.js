function checkFirstname(idfirstname, idError) {
    // 1. at least 6 characters 2. all characters are letters
    var un = document.getElementById(idfirstname).value;
    var error = document.getElementById(idError);
    error.innerHTML = "";
    if (un.length < 2) {
        error.innerHTML = "Firstname must contains at least 2 characters!";
        return false;
    }
    un = un.toLowerCase();
    for (var i = 0; i < un.length; i++) {
        if (un.charAt(i) < 'a' || un.charAt(i) > 'z') {
            error.innerHTML = "Firstname must contains only letters!";
            return false;
        }
    }
    return true;
}

function checkConfirmPass(idPass, idConfirmPass, idError) {
    var pass = document.getElementById(idPass).value;
    var confirmPass = document.getElementById(idConfirmPass).value;
    var error = document.getElementById(idError);
    error.innerHTML = "";
    if (!(pass == confirmPass)) {
        error.innerHTML = "You must enter same password!";
        return false;
    }
    return true;
}


function checkLastname(idlastname, idError) {
    var un = document.getElementById(idlastname).value;
    var error = document.getElementById(idError);
    error.innerHTML = "";
    if (un.length < 2) {
        error.innerHTML = "Lastname must contains at least 2 characters!";
        return false;
    }
    un = un.toLowerCase();
    for (var i = 0; i < un.length; i++) {
        if (un.charAt(i) < 'a' || un.charAt(i) > 'z') {
            error.innerHTML = "Lastname must contains only letters!";
            return false;
        }
    }
    return true;
}


function checkPassword(idPassword, idError) {
    var pass = document.getElementById(idPassword).value;
    var error = document.getElementById(idError);
    if (pass.length < 6) {
        error.innerHTML = "Password must contains at least 6 charecters!";
        return false;
    }
    error.innerHTML = "";
    //<img src='../Images/correct.png' width='20' height='20' />
    return true;
}

function checkMail(idMail, idError) {
    var mail = document.getElementById(idMail).value;
    console.log(mail);
    var errorMail = document.getElementById(idError);
    var regulate = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$/;
    if (!regulate.test(mail)) {
        errorMail.innerHTML = "Invalid email!";
        return false;
    }
    errorMail.innerHTML = "";
    return true;
}

function checkUserName(idUsername, idError) {
    var un = document.getElementById(idUsername).value;
    var error = document.getElementById(idError);
    error.innerHTML = "";
    if (un.length < 8) {
        error.innerHTML = "Username must contains at least 8 characters!";
        return false;
    }
    var spChar = false;
    un = un.toLowerCase();
    for (var i = 0; i < un.length; i++) {
        if (un.charAt(i) >= '0' && un.charAt(i) <= '9') {
            digit = true;
        }
        if (un.charAt(i) > 'a' && un.charAt(i) <= 'z') {
            onlyEnglish = true;
        }
        if (un.charCodeAt(i) >= '31' && un.charCodeAt(i) <= '47') {
            spChar = true;
        }

    }
    console.log("onlyEnglish=" + onlyEnglish);
    console.log("digit=" + digit);
    if (!spChar) {
        error.innerHTML = "Username must contain 2 spaciel charts!";
        return false;
    }
    if (!digit) {
        error.innerHTML = "Username must contain 2 special charts!";
        return false;
    }
    if (!onlyEnglish) {
        error.innerHTML = "Username must contains only english letters and digits!";
        return false;
    }
    return true;
}

function checkGender(id, idError) {
    var gender = document.getElementsByName(id);
    var error = document.getElementById(idError);
    error.innerHTML = "";
    var isChecked = false;
    var selectedIndex = -1;
    for (var i = 0; i < gender.length; i++) {
        if (gender[i].checked) {
            isChecked = true;
            selectedIndex = i;
        }
    }

    if (!isChecked) {
        
        error.innerHTML = "You must choose gender!";
        return false;
    }

    console.log("Checked value = " + gender[selectedIndex].value);
    
    return true;

}

function checkBirth(idBirth, idError) {
    var birth = document.getElementById(idBirth).value;
    var error = document.getElementById(idError);
    error.innerHTML = "";
    console.log("Birth = " + birth);
    if (birth.length == 0) {
        error.innerHTML = "You must enter your birth date";
        return false;
    }
    var year = parseInt(birth.substring(0, 4));
    var today = new Date();
    if (today.getFullYear() - year < 12) {
        error.innerHTML = "You must be at least 12 years old";
        return false;
    }
    console.log("Year = " + year);
    console.log("Today's year = " + today.getFullYear());
    return false;
}

function checkPhone(idphone, idError) {
    var un = document.getElementById(idphone).value;
    var error = document.getElementById(idError);
    error.innerHTML = "";
    if (un.length < 9) {
        error.innerHTML = "Phone number must contains at least 9 characters!";
        return false;
    }
    un = un.toLowerCase();
    for (var i = 0; i < un.length; i++) {
        if (un.charAt(i) < '0' || un.charAt(i) > '9') {
            error.innerHTML = "phone number must contains only numbers!";
            return false;
        }
    }
    return true;
}

function checkHintQuestion(idhintQ, idError) {
    //console.log("Enter to fuction");
    var select = document.getElementById(idhintQ);
    var error = document.getElementById(idError);
    error.innerHTML = "";
    var i = select.selectedIndex;
    var hintQ = select.options[i].value;
    if (i == 0) {   // or hintQ == "empty"
        error.innerHTML = "you must choose one question!";
        return false;
    }
    console.log("Seleceted hint question option " + i);
    console.log("Seleceted hint question value " + hintQ);
    return true;
}
function checkHintAnswer(idhintAns, idError) {
    var ans = document.getElementById(idhintAns).value;
    var error = document.getElementById(idError);
    //console.log(ans.length);
    if (ans == "") {    // ans.length == 0
        error.innerHTML = "you must answer the question!";
        return false;
    }
    return true;
}


function validateForm() {

    //window.alert("You pressed the Send button");
    //var result = true;


    result = checkFirstname("firstname", "errorFN") && result;
    result = checkLastname("lastname", "errorLN") && result;
    result = checkGender("gender", "errorGender") && result;
    result = checkPassword("password", "errorPassword") && result;
    result = checkConfirmPass("password", "ConfirmPass", "errorConfirmPass") && result;
    result = checkPhone("phone", "errorPhone") && result;
    result = checkBirth("birth", "errorBirth") && result;
    result = checkUserName("username", "errorUsername") && result;
    result = checkMail("mail", "errorMail") && result;
    result = checkHintQuestion("hintQ", "errorHintQuestion") && result;
    result = checkHintAnswer("hintAns1", "errorHintQuestion") && result;
    result = checkHintQuestion("hintQ1", "errorHintQuestion1") && result;
    result = checkHintAnswer("hintAns2", "errorHintQuestion1") && result;

    return result;
}

