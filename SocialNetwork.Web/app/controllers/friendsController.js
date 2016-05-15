'use strict';
app.controller('profileController', ['$scope', '$location', '$timeout', 'authService', 'userService', '$routeParams', '$http', function ($scope, $location, $timeout, authService, userService, $routeParams, $http) {
    $scope.friends = [];
    user = userService.getCurrentUser;
    $http.get(serviceBase + 'Prijatelji/GetFriends', { params: { "userId": user.Id } }).success(function (data) {
        $scope.friends = data;
    });
}]);