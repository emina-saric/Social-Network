﻿'use strict';
app.controller('profileOtherController', ['$scope', '$location', '$timeout', 'authService', 'userService', '$routeParams', 'searchService', function ($scope, $location, $timeout, authService, userService, $routeParams, searchService) {
    
    //alert(searchService.otherUser.userName);  
    $scope.otherUser = {
        userName: "",
        userId: "",
        eMail: "",
        firstName: "",
        lastName: "",
        fullName: "",
        currentPassword: "",
        newPassword: "",
        confirmNewPassword: ""
    };
    $scope.getOtherUser = function () {
        userService.getCurrentUser(searchService.otherUser.userName).then(function (response) {
            $scope.savedSuccessfully = true;
            $scope.message = "User found !";
            $scope.otherUser.userId = response.data['id'];
            $scope.otherUser.eMail = response.data['email'];
            $scope.otherUser.firstName = response.data['firstName'];
            $scope.otherUser.lastName = response.data['lastName'];
            $scope.otherUser.fullName = response.data['fullName'];
        });
    };

    var updateFoo = function () {
        $scope.getOtherUser();
    };

    searchService.registerObserverCallback(updateFoo);
    //service now in control of updating foo

   $scope.getOtherUser();

}]);