function checkUserName3(idUsername3, idError) {
    var un = document.getElementById(idUsername3).value;
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
    var result = true;
    
    result = checkUserName3("username3", "errorUsername3") && result;
    result = checkHintQuestion("hintQ", "errorHintQuestion") && result;
    result = checkHintAnswer("hintAns", "errorHintQuestion") && result;
    result = checkHintQuestion("hintQ1", "errorHintQuestion1") && result;
    result = checkHintAnswer("hintAns1", "errorHintQuestion1") && result;
    return result;

}
