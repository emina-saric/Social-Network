'use strict';
app.controller('friendsController', ['$scope', '$location', '$timeout', 'authService', 'userService', '$routeParams', '$http','searchService', function ($scope, $location, $timeout, authService, userService, $routeParams, $http,searchService) {
    $scope.friends = [];
    var user = authService.authentication.userName;
    $scope.getFriends = function () {
        $http.get(serviceBase + 'api/Prijatelji/GetFriends/' + user).success(function (data) {
            $scope.friends = data;
        });
    };

    $scope.deleteFriend = function (user) {
       $http.delete(serviceBase + 'api/Prijatelji/DeleteFriend/' + user).success(function (response) {
           $scope.getFriends();
        });
    };

    $scope.goToProfile = function (userName) {
        //var user = $scope.person.userName;
        searchService.takeDataX(userName);
        $location.path('/profileOther');
    }

    $scope.getFriends();
}]);