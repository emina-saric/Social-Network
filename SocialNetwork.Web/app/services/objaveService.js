'use strict';
app.factory('objaveService', ['$http', '$q', 'localStorageService', 'ngAuthSettings', function ($http, $q, localStorageService, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    var authServiceFactory = {};

    
    var _GetObjave = function () {
        return $http.get(serviceBase + 'api/Objave/GetObjave/').then(function (response) {
            return response;
        });

    };
    var _PostObjava = function (objava) {
        return $http.post(serviceBase+'api/Objave/CreateObjava',objava).then(function (response) {
            
            return response;
        });

    };
    var _DeleteObjava = function (id) {
        return $http.delete(serviceBase + 'api/Objave/DeleteObjava/'+id).then(function (response) {

            return response;
        });

    };
  
    var _UpdateObjava = function (objava) {
        return $http.put(serviceBase + 'api/Objave/EditObjava/', objava).then(function (response) {

            return response;
        });

    };
    authServiceFactory.GetObjave = _GetObjave;
    authServiceFactory.PostObjava = _PostObjava;
    authServiceFactory.DeleteObjava = _DeleteObjava;
    authServiceFactory.UpdateObjava = _UpdateObjava;
   /* authServiceFactory.deleteCurrentUser = _deleteCurrentUser;
    authServiceFactory.editCurrentUser = _editCurrentUser;
    authServiceFactory.changePassword = _changePassword;*/

    return authServiceFactory;
}]);