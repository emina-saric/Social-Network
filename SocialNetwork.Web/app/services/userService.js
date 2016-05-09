'use strict';
app.factory('userService', ['$http', '$q', 'localStorageService', 'ngAuthSettings', function ($http, $q, localStorageService, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    var authServiceFactory = {};

    var currentUser = {
        userName: "",
        userId: ""
    };

    var _getCurrentUser = function(user) {
        currentUser.userName = user;
        return $http.get(serviceBase + 'api/Profile/GetUserByUserName/' + currentUser.userName).then(function (response) {
            currentUser.userId = response.data['id'];
            return response;
        });

    };
    var serviceBaseX = 'http://localhost:57409/';
    var _deleteCurrentUser = function () {
        return $http.delete(serviceBaseX + 'api/Profile/DeleteCurrentUser/' + currentUser.userId).then(function (response) {
            alert(response.data['id'])
            return response;
        });
    }

    authServiceFactory.getCurrentUser = _getCurrentUser;
    authServiceFactory.deleteCurrentUser = _deleteCurrentUser;
    return authServiceFactory;
}]);