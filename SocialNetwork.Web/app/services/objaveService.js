'use strict';
app.factory('objaveService', ['$http', '$q', 'localStorageService', 'ngAuthSettings', function ($http, $q, localStorageService, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    var authServiceFactory = {};

    

   /*authServiceFactory.getCurrentUser = _getCurrentUser;
    authServiceFactory.deleteCurrentUser = _deleteCurrentUser;
    authServiceFactory.editCurrentUser = _editCurrentUser;
    authServiceFactory.changePassword = _changePassword;*/

    return authServiceFactory;
}]);