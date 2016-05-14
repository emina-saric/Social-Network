'use strict';
app.controller('profileController', ['$scope', '$location', '$timeout', 'authService', 'userService', '$routeParams', '$http', function ($scope, $location, $timeout, authService, userService, $routeParams, $http) {
    $scope.friends = [];
    user = userService.getCurrentUser;
    $http.get('Prijatelji/GetFriends/' + user.Id).success(function (data) {
        $scope.friends = data;
    });
}]);