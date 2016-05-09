'use strict';
app.controller('resetPasswordController', ['$scope', '$location', '$timeout', 'authService', '$routeParams', function ($scope, $location, $timeout, authService, $routeParams) {

    $scope.savedSuccessfully = false;
    $scope.message = "";

    $scope.userData = {
        Email: "",
        Password: "",
        ConfirmPassword: "",
        Code: ""
    };


    $scope.resetPassword = function () {

        $scope.userData.Code = String($routeParams.code);

        authService.resetPassword($scope.userData).then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message = "Password has been reset, you will be redicted to login page in 5 seconds.";
            startTimer();

        },
            function (response) {
                var errors = [];
                for (var key in response.data.modelState) {
                    for (var i = 0; i < response.data.modelState[key].length; i++) {
                        errors.push(response.data.modelState[key][i]);
                    }
                }
                $scope.message = "Failed to reset password due to:" + errors.join(' ');
            });
    };

    var startTimer = function () {
        var timer = $timeout(function () {
            $timeout.cancel(timer);
            $location.path('/login');
        }, 5000);
    }
}]);