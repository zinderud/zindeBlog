"use strict";
var Registration = (function () {
    function Registration(username, password, email) {
        this.Username = username;
        this.Password = password;
        this.Email = email;
    }
    return Registration;
}());
exports.Registration = Registration;
