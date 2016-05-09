'use strict';
app.factory('userService', ['$http', '$q', 'localStorageService', 'ngAuthSettings', function ($http, $q, localStorageService, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    var authServiceFactory = {};

    var currentUser = {
        userName: "",
        userId: ""
    };

    var _getCurrentUser = function (user) {
        return $http.get('http://localhost:57409/api/Profile/GetUserByUserName/' + currentUser.userName).then(function (response) {
            alert(response);
            return true;
        });

    };

    authServiceFactory.getCurrentUser = _getCurrentUser;
    return authServiceFactory;
}]);