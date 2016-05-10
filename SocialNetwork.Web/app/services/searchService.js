'use strict';
app.factory('searchService', ['$http', '$q', 'localStorageService', 'ngAuthSettings', function ($http, $q, localStorageService, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    var authServiceFactory = {};
    var otherUser;

     var _getAllUsers = function () {
            return $http.get(serviceBase + 'api/Profile/GetUsers/').then(function (response) {
            return response;
        });

    };

     var _takeData = function (data) {
         otherUser = data;
         //alert(otherUser.userName)
     }
    



     authServiceFactory.getAllUsers = _getAllUsers;
     authServiceFactory.takeData = _takeData;
    

    return authServiceFactory;
}]);