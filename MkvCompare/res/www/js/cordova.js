
var cordovaMapS = new Object();
var cordovaMapF = new Object();
var cordovaMapServiceName = new Object();
var cordovaMapActionName = new Object();


var device = {
    platform: "WinDesktop"
};

navigator.notification = new Object();
navigator.globalization = new Object();

function _alert(message, callback, title, button) {
    cordova.exec(callback, null, "Notification", "alert", [message, title]);
}

;

navigator.notification.alert = _alert;

function _info(message, callback, title, button) {
    cordova.exec(callback, null, "Notification", "info", [message, title]);
}




function _getPreferredLanguage(successCB, failCB) {
    var lang = scriptmanager.getlanguage();
    if (lang) {
        var languageObject = new Object();
        languageObject.value = lang;
        successCB(languageObject);
    } else {
        failCB();
    }
}

function sleep(milliseconds) {
    var start = new Date().getTime();
    while(true) {
        if ((new Date().getTime() - start) > milliseconds) {
            break;
        }
    }
}

navigator.globalization.getPreferredLanguage = _getPreferredLanguage;

navigator.notification.info = _info;

var cordova = {
    debug: function(message) {
        scriptmanager.debugjs(message);
    },

    debugCordova: function(message) {
        scriptmanager.debugcordovajs(message);
        console.debug("[CORDOVA.JS] " + message);
    },

    exec: function(success, fail, service, action, args) {
        if (service == "System" && action == "launchLoader") {
            $("#loader_screen").css("visibility", "visible");
        } else if (service == "System" && action == "stopLoader") {
            $("#loader_screen").css("visibility", "hidden");
        } else {
            this.debugCordova("[P1] Exec called " + service + " | " + action);

            var transactionId = Math.floor(Math.random() * 1000001).toString();

            while (cordovaMapServiceName[transactionId] != null) {
                transactionId = Math.floor(Math.random() * 1000001).toString();
            }

            cordovaMapS[transactionId] = success;
            cordovaMapF[transactionId] = fail;
            cordovaMapServiceName[transactionId] = service;
            cordovaMapActionName[transactionId] = action;

            var jsonedString = JSON.stringify(args);

            this.debugCordova("[P1] Infos of call plugin :" + service + " | " + action + " | tId : " + transactionId + " | Success Callback passed : " + cordovaMapS[transactionId] + " | Fail Callback passed : " +
                cordovaMapF[transactionId] + " | args : " + jsonedString);

            scriptmanager.invokefunc(service, action, jsonedString, success, fail, transactionId);
        }
    },

    executeCallbackSuccess: function(id, args) {
        this.debugCordova("[P6] Callback Success JS | args : " + args + " | tId : " + id);
        if (cordovaMapS[id] !== null) {
            this.debugCordova("[P6] Now running success callback of " + cordovaMapServiceName[id] + " | " + cordovaMapActionName[id] + " | tId " + id + " is ok");
            cordovaMapS[id](args);
            this.debugCordova("[P6] Success callback done, now cleaning of " + cordovaMapServiceName[id] + " | " + cordovaMapActionName[id]);
            cordovaMapS[id] = null;
            cordovaMapF[id] = null;
            cordovaMapServiceName[id] = null;
            cordovaMapActionName[id] = null;
        } else {
            this.debugCordova("[P6] tId " + id + " unknown ??");
        }
    },

    executeCallbackSuccessJSON: function(id, args) {
        this.debugCordova("[P6] Callback Success JSON JS | args : " + args + " | tId : " + id);
        var argums = JSON.stringify(args);
        //console.debug(argums);
        if (cordovaMapS[id] !== null) {
            this.debugCordova("[P6] Now running success callback JSON of " + cordovaMapServiceName[id] + " | " + cordovaMapActionName[id] + " | tId " + id + " is ok");
            cordovaMapS[id](argums);
            this.debugCordova("[P6] Success callback JSON done, now cleaning of " + cordovaMapServiceName[id] + " | " + cordovaMapActionName[id]);
            cordovaMapS[id] = null;
            cordovaMapF[id] = null;
            cordovaMapServiceName[id] = null;
            cordovaMapActionName[id] = null;
        } else {
            this.debugCordova("[P6] tId " + id + " unknown ??");
        }
    },

    executeCallbackFail: function(id, args) {
        this.debugCordova("[P6] Callback Fail JS | args : " + args + " | tId : " + id);
        if (cordovaMapF[id] !== null) {
            this.debugCordova("[P6] Now running fail callback of " + cordovaMapServiceName[id] + " | " + cordovaMapActionName[id] + " | tId " + id + " is ok");
            cordovaMapF[id](args);
            this.debugCordova("[P6] Fail callback done, now cleaning of " + cordovaMapServiceName[id] + " | " + cordovaMapActionName[id]);
            cordovaMapS[id] = null;
            cordovaMapF[id] = null;
            cordovaMapServiceName[id] = null;
            cordovaMapActionName[id] = null;
        } else {
            this.debugCordova("[P6] tId " + id + " unknown ??");
        }
    },

    executeCallbackFailJSON: function(id, args) {
        this.debugCordova("[P6] Callback Fail JSON JS | args : " + args + " | tId : " + id);
        var argums = JSON.stringify(args);
        if (cordovaMapF[id] !== null) {
            this.debugCordova("[P6] Now running fail callback JSON of " + cordovaMapServiceName[id] + " | " + cordovaMapActionName[id] + " | tId " + id + " is ok");
            cordovaMapF[id](argums);
            this.debugCordova("[P6] Fail callback JSON done, now cleaning of " + cordovaMapServiceName[id] + " | " + cordovaMapActionName[id]);
            cordovaMapS[id] = null;
            cordovaMapF[id] = null;
            cordovaMapServiceName[id] = null;
            cordovaMapActionName[id] = null;
        } else {
            this.debugCordova("[P6] tId " + id + " unknown ??");
        }
    },

    showNotificationSSLCert: function () {
        this.debugCordova("[P6] Callback Success showNotif JS ");
        if (sessionStorage.SSLCertNotifAlreadyShow === undefined) {
            sessionStorage.SSLCertNotifAlreadyShow = true;
            Utils.nativeAlert("check-ssl-certificate-error-message");

        }
    },

    showLoader: function() {
        $("#loader_screen").css("visibility", "visible");
        //$("#text_loader_screen").text(message);
    },

    hideLoader: function() {
        $("#loader_screen").css("visibility", "hidden");
    }
};