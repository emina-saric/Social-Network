'use strict';
app.controller('signupController', ['$scope', '$location', '$timeout', 'authService', function ($scope, $location, $timeout, authService) {

    $scope.savedSuccessfully = false;
    $scope.message = "";

    $scope.registration = {
        userName: "",
        password: "",
        firstName: "",
        lastName: "",
        confirmPassword: "",
        eMail: "",
        recaptcha: ""
    };


    $scope.signUp = function () {
        $scope.registration.recaptcha = grecaptcha.getResponse();
            authService.saveRegistration($scope.registration).then(function (response) {

                $scope.savedSuccessfully = true;
                $scope.message = "Email with the confirmation link has been sent to your email address. You must conirm your email before signing in!";
                startTimer();

            },
             function (response) {
                 var errors = [];
                 for (var key in response.data.modelState) {
                     if (key != '$id') {
                         for (var i = 0; i < response.data.modelState[key].length; i++) {
                         
                             errors.push(response.data.modelState[key][i]);

                         }
                     }
                 }
                 $scope.message = "Failed to register user due to: " + errors.join(' ');
             });
    };

    (function () {
        if (window.localStorage) {
            if (!localStorage.getItem('firstLoad')) {
                localStorage['firstLoad'] = true;
                window.location.reload();
            }
            else
                localStorage.removeItem('firstLoad');
        }
    })();

    var startTimer = function () {
        var timer = $timeout(function () {
            $timeout.cancel(timer);
            $location.path('/login');
        }, 5000);
    }

}]);