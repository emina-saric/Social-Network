'use strict';
app.controller('profileOtherController', ['$scope', '$location', '$timeout', 'authService', 'userService', '$routeParams', 'searchService', '$http','$sce', function ($scope, $location, $timeout, authService, userService, $routeParams, searchService, $http,$sce) {

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
        confirmNewPassword: "",
        profileImage: $sce.trustAsResourceUrl('/app/images/Default.png')
    };
    $scope.isFriend = false;

    $scope.getOtherUser = function () {
        userService.getCurrentUser(searchService.otherUser.userName).then(function (response) {
            $scope.savedSuccessfully = true;
            $scope.message = "User found !";
            $scope.otherUser.userId = response.data['id'];
            $scope.otherUser.eMail = response.data['email'];
            $scope.otherUser.firstName = response.data['firstName'];
            $scope.otherUser.lastName = response.data['lastName'];
            $scope.otherUser.fullName = response.data['fullName'];
            $scope.otherUser.profileImage = $sce.trustAsResourceUrl('/app/images/' + response.data['profileImage']);
            $scope.checkFriend();
        });
    };

    var updateFoo = function () {
        $scope.getOtherUser();
        $scope.checkFriend();
    };


    var _addFriend = function () {
        return $http.post('api/Prijatelji/AddFriend/' + $scope.otherUser.userId).then(function (response) {
            updateFoo();
            return response;
        });
    }
    $scope.addFriend = _addFriend;

    var _checkFriend = function () {
        return $http.post('api/Prijatelji/CheckFriend/' + $scope.otherUser.userId).then(function (response) {
            $scope.isFriend = response.data;
            console.log($scope.isFriend);
        });
    }
    
    $scope.checkFriend = _checkFriend;
    
    searchService.registerObserverCallback(updateFoo);
    //service now in control of updating foo

    $scope.getOtherUser();

}]);