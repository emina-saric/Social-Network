﻿'use strict';
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
            return response;
        });

    };
    var _getRoles = function(id) {
        
        return $http.get(serviceBase + 'api/Account/GetRoles/' + id).then(function (response) {
            return response;
        });

    };
   

    var _editCurrentUser = function (user) {
        return $http.put(serviceBase + 'api/Profile/EditCurrentUser/',user).then(function (response) {
            return response;
        });
    };

    var _editUser = function (user) {
        return $http.put(serviceBase + 'api/Profile/EditUser/', user).then(function (response) {
            return response;
        });
    };

    var _changePassword = function (user) {
        return $http.put(serviceBase + 'api/Profile/ChangePassword/', user).then(function (response) {
            return response;
        });

    };

    var _deleteCurrentUser = function () {
        return $http.delete(serviceBase + 'api/Profile/DeleteCurrentUser/').then(function (response) {
            return response;
        });
    }


     var _getUserById = function (id) {
        
        return $http.get(serviceBase + 'api/Profile/GetUserById/'+id).then(function (response) {
            return response;
        });
        
    };

    authServiceFactory.getCurrentUser = _getCurrentUser;
    authServiceFactory.getUserById = _getUserById;
    authServiceFactory.deleteCurrentUser = _deleteCurrentUser;
    authServiceFactory.editCurrentUser = _editCurrentUser;
    authServiceFactory.editUser = _editUser;
    authServiceFactory.changePassword = _changePassword;
    authServiceFactory.getRoles = _getRoles;

    return authServiceFactory;
}]);