'use strict';
app.factory('userService', ['$http', '$q', 'localStorageService', 'ngAuthSettings', function ($http, $q, localStorageService, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    var authServiceFactory = {};

    var currentUser = {
        userName: "",
        userId: ""
    };

    var _getCurrentUser = function (user) {
        currentUser.userName = user;
        return $http.get(serviceBase + 'api/Profile/GetUserByUserName/' + currentUser.userName).then(function (response) {
            return response;
        });

    };

    authServiceFactory.getCurrentUser = _getCurrentUser;
    return authServiceFactory;
}]);