'use strict';
app.controller('friendsController', ['$scope', '$location', '$timeout', 'authService', 'userService', '$routeParams', '$http', function ($scope, $location, $timeout, authService, userService, $routeParams, $http) {
    $scope.friends = [];
    var user = authService.authentication.userName;
    $scope.getFriends = function () {
        $http.get(serviceBase + 'api/Prijatelji/GetFriends/' + user).success(function (data) {
            $scope.friends = data;
        });
    };
    $scope.getFriends();
}]);