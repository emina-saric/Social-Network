'use strict';
app.factory('chartService', ['$http', '$q', 'localStorageService', 'ngAuthSettings', function ($http, $q, localStorageService, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    var authServiceFactory = {};

    
    var _GetUserConfirmedStats = function () {
        return $http.get(serviceBase + 'api/Profile/GetUserConfirmedStats/').then(function (response) {
            return response;
        });
    };

    var _GetUserProfileImageStats = function () {
        return $http.get(serviceBase + 'api/Profile/GetUserProfileImageStats/').then(function (response) {
            return response;
        });
    };

    var _GetBannedUsersStats= function () {
        return $http.get(serviceBase + 'api/Profile/GetBannedUsersStats/').then(function (response) {
            return response;
        });
    };
    var _GetPhoneNumbersStats = function () {
        return $http.get(serviceBase + 'api/Profile/GetPhoneNumbersCount/').then(function (response) {
            return response;
        });
    };

    authServiceFactory.GetUserConfirmedStats = _GetUserConfirmedStats;
    authServiceFactory.GetUserProfileImageStats = _GetUserProfileImageStats;
    authServiceFactory.GetBannedUsersStats = _GetBannedUsersStats;
    authServiceFactory.GetPhoneNumbersStats = _GetPhoneNumbersStats;
   /* authServiceFactory.deleteCurrentUser = _deleteCurrentUser;
    authServiceFactory.editCurrentUser = _editCurrentUser;
    authServiceFactory.changePassword = _changePassword;*/

    return authServiceFactory;
}]);