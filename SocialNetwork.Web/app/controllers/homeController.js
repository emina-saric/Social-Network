'use strict';
app.controller('homeController', ['$scope','$location', 'authService', function ($scope, authService) {
    $scope.authentication = authService.authentication;
    
}]);