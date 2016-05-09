'use strict';
app.controller('profileController', ['$scope', '$location', '$timeout', 'authService', 'userService', '$routeParams', function ($scope, $location, $timeout, authService, userService, $routeParams) {

    $scope.savedSuccessfully = false;
    $scope.message = "";
    $scope.authentication = authService.authentication;

    var currentUser = {
        userName: "",
        userId: ""
    };
    
    currentUser = authService.authentication.userName;
    
    $scope.getCurrentUser = function () {
        userService.getCurrentUser($scope.currentUser).then(function (response) {
                $scope.savedSuccessfully = true;
                $scope.message = "User found !";
                currentUser.userId = userService;
            });
    };




    $scope.getCurrentUser();

    /*
    authService.confirmEmail(String($routeParams.userId),String($routeParams.code)).then(function (response) {

        $scope.savedSuccessfully = true;
        $scope.message = "Email has been confirmed successfully, you will be redicted to login page in 3 seconds.";
        startTimer();

    },
        function (response) {
            var errors = [];
            for (var key in response.data.modelState) {
                for (var i = 0; i < response.data.modelState[key].length; i++) {
                    errors.push(response.data.modelState[key][i]);
                }
            }
            $scope.message = "Failed to register user due to:" + errors.join(' ');
        });


    var startTimer = function () {
        var timer = $timeout(function () {
            $timeout.cancel(timer);
            $location.path('/login');
        }, 3000);
    }*/
}]);