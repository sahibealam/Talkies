//function showPleaseWait1(obj) {
//    document.getElementById("ScreenDisable").style.display = '';
//    document.getElementById("ScreenDisable").style.width = document.documentElement.scrollWidth + "px";
//    document.getElementById("ScreenDisable").style.height = document.documentElement.scrollHeight + "px";

//    if (document.getElementById("divImg") != null) {
//        document.body.removeChild(document.getElementById("divImg"));
//    }

//    var b = document.createElement("divImg");
//    b.setAttribute("id", "divImg");

//    document.getElementById('ScreenDisable').appendChild(b);
//    //document.body.appendChild(b);

//    document.getElementById("divImg").style.top = ((document.documentElement.clientHeight / 2) - 50) + "px";
//    document.getElementById("divImg").style.left = (document.documentElement.clientWidth / 2) + "px";
//    document.getElementById("divImg").style.position = "absolute";

//    document.getElementById("divImg").style.height = "100px";
//    document.getElementById("divImg").style.width = "100px";
//    document.getElementById("divImg").innerHTML = "<center><img src='assets/images/wait.gif' /></center>";
//}

//function showPleaseWait(obj) {
//    document.getElementById("ScreenDisable").style.display = '';
//    document.getElementById("ScreenDisable").style.width = document.documentElement.scrollWidth + "px";
//    document.getElementById("ScreenDisable").style.height = document.documentElement.scrollHeight + "px";

//    if (document.getElementById("divImg") != null) {
//        document.body.removeChild(document.getElementById("divImg"));
//    }

//    var b = document.createElement("divImg");
//    b.setAttribute("id", "divImg");

//    document.getElementById('ScreenDisable').appendChild(b);
//    //document.body.appendChild(b);

//    document.getElementById("divImg").style.top = ((document.documentElement.clientHeight / 2) - 50) + "px";
//    document.getElementById("divImg").style.left = (document.documentElement.clientWidth / 2) + "px";
//    document.getElementById("divImg").style.position = "absolute";

//    document.getElementById("divImg").style.height = "100px";
//    document.getElementById("divImg").style.width = "100px";
//    document.getElementById("divImg").innerHTML = "<center><img src='assets/images/wait.gif' /></center>";

//    return true;
//}

function isNumericVal(obj) {
    var _value = obj.value;
    if (!$.isNaN(_value)) {
        return true;
    }
    else {
        obj.value = "";
        return false;
    }
}
function checknum(obj) {
    var _value = obj.value;
    if ($.isNumeric(_value)) {
        return true;
    }
    else {
        obj.value = "";
        return false;
    }
}

function validateLogin(obj) {
    if (document.getElementById('ctl00_ContentPlaceHolder1_txtUserName').value == "") {
        alert("Please Provide User Name!!");
        document.getElementById('ctl00_ContentPlaceHolder1_txtUserName').focus();
        return false;
    }
    if (document.getElementById('ctl00_ContentPlaceHolder1_txtPassowrd').value == "") {
        alert("Please Provide Password!!");
        document.getElementById('ctl00_ContentPlaceHolder1_txtPassowrd').focus();
        return false;
    }
    return true;
}

function checkDataFilled(obj) {
    if (obj.value == "") {
        obj.style.cssText = "border-color:#f2a696; color: #D68273; border-width: thick;";
    }
    else {
        obj.style.cssText = "";
    }
}

function checkDataFilledDDL(obj) {
    if (obj.value == "0") {
        obj.style.cssText = "border-color:#f2a696; color: #D68273; border-width: thick;";
    }
    else {
        obj.style.cssText = "";
    }
}