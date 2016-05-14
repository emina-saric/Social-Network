'use strict';
app.factory('searchService', ['$http', '$q', 'localStorageService', 'ngAuthSettings', function ($http, $q, localStorageService, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    var authServiceFactory = {};
    var _otherUser = {
        FirstName: "",
        LastName: "",
        picture: "",
        userName: "",
        userId: ""
    };

     var _getAllUsers = function () {
            return $http.get(serviceBase + 'api/Profile/GetUsers/').then(function (response) {
            return response;
        });

    };

     var _takeData = function (data) {
         _otherUser.userName = data.userName;
         _notifyObservers();
         //alert(otherUser.userName)
     }
    

    // U slucaju izmjene otherUser ovo se koristi
     var observerCallbacks = [];

    //register an observer
     var _registerObserverCallback = function (callback) {
         observerCallbacks.push(callback);
     };

    //call this when you know 'foo' has been changed
     var _notifyObservers = function () {
         angular.forEach(observerCallbacks, function (callback) {
             callback();
         });
     };

     authServiceFactory.registerObserverCallback = _registerObserverCallback;
     authServiceFactory.notifyObservers = _notifyObservers;
     authServiceFactory.getAllUsers = _getAllUsers;
     authServiceFactory.takeData = _takeData;
     authServiceFactory.otherUser = _otherUser;

    return authServiceFactory;
}]);