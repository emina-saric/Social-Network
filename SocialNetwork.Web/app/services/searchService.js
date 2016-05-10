'use strict';
app.factory('searchService', ['$http', '$q', 'localStorageService', 'ngAuthSettings', function ($http, $q, localStorageService, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    var authServiceFactory = {};

     var _getAllUsers = function () {
            return $http.get(serviceBase + 'api/Profile/GetUsers/').then(function (response) {
            return response;
        });

    };

    

    authServiceFactory.getAllUsers = _getAllUsers
    

    return authServiceFactory;
}]);