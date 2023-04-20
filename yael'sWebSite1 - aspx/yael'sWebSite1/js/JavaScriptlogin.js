function checkUserName2(idUsername2, idError) {
    var un = document.getElementById(idUsername2).value;
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


function checkPassword2(idPassword2, idError) {
    var pass = document.getElementById(idPassword2).value;
    var errorPass = document.getElementById(idError);
    errorPass.innerHTML = "";
    if (pass.length < 6) {
        errorPass.innerHTML = "Password must contains at least 6  charecters! ";
        return false;
    }
    if (pass.length < 'A' || pass.length > 'Z') {
       errorPass.innerHTML = "Password must contains at least 1 capital letter!";
        return false;
    }
    return true;
}

/*function validateForm() {
    //window.alert("You pressed the Send button");
    var result = true;
    */
    result = checkUserName2("username2", "errorUsername2") && result;
    result = checkPassword2("password2", "errorPass2") && result;

    return result;
}


