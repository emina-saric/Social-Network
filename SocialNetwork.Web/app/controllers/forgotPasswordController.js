'use strict';
app.controller('forgotPasswordController', ['$scope', '$location', '$timeout', 'authService', '$routeParams', function ($scope, $location, $timeout, authService, $routeParams) {

    $scope.savedSuccessfully = false;
    $scope.message = "";

    $scope.userData = {
        Email: ""
    };

    $scope.forgotPassword = function () {

        console.log($scope.userData);
        authService.forgotPassword($scope.userData).then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message = "Please check your email to reset your password.";
            // startTimer();

        },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message = "Failed to send password reset link due to:" + errors.join(' ');
         });
    };

    var startTimer = function () {
        var timer = $timeout(function () {
            $timeout.cancel(timer);
            $location.path('/login');
        }, 2000);
    }
}]);