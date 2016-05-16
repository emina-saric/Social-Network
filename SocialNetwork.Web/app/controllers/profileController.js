'use strict';
app.controller('profileController', ['$scope', '$location', '$timeout', 'authService', 'userService', '$routeParams','objaveService', function ($scope, $location, $timeout, authService, userService, $routeParams,objaveService) {

    $scope.savedSuccessfully = false;
    $scope.ChangedSuccessfully = false;
    $scope.ChangedPasswordSuccessfully = false;
    $scope.message = "";
    $scope.authentication = authService.authentication;
    $scope.messageEdit = "";
    $scope.messagePasswordChange = "";

    
    $scope.statusObjaveShow = true
    $scope.objave = new Array();

    $scope.currentUser = {
        userName: "",
        userId: "",
        eMail: "",
        firstName: "",
        lastName: "",
        fullName: "",
        currentPassword: "",
        newPassword: "",
        confirmNewPassword: ""
    };
    
    $scope.currentUser.userName = authService.authentication.userName;
    
    $scope.getCurrentUser = function () {
        userService.getCurrentUser($scope.currentUser.userName).then(function (response) {
                $scope.savedSuccessfully = true;
                $scope.message = "User found !";
                $scope.currentUser.userId = response.data['id'];
                $scope.currentUser.eMail = response.data['email'];
                $scope.currentUser.firstName = response.data['firstName'];
                $scope.currentUser.lastName = response.data['lastName'];
                $scope.currentUser.fullName = response.data['fullName'];
            });
    };

    $scope.deleteCurrentUser = function () {
        userService.deleteCurrentUser().then(function (response) {
            authService.logOut();
            $scope.goHome();
            $window.location.reload();
        });
    };


    $scope.editCurrentUser = function () {
        userService.editCurrentUser($scope.currentUser).then(function (response) {
            $scope.currentPassword = "";
            $scope.newPassword = "";
            $scope.newConfirmPassword = "";
            $scope.getCurrentUser();
            $scope.ChangedSuccessfully = true;
            $scope.messageEdite = "Changes saved. Redirect in 2 seconds.";
            startTimer();

        },
        function (response) {
            $scope.ChangedSuccessfully = false;
            $scope.currentPassword = "";
            $scope.newPassword = "";
            $scope.newConfirmPassword = "";
            var errors = [];
            for (var key in response.data.modelState) {
                if (key != '$id') {
                    for (var i = 0; i < response.data.modelState[key].length; i++) {
                        errors.push(response.data.modelState[key][i]);
                    }
                }
            }
            $scope.messageEdit = "Failed to change user due to: " + errors.join(' ');
            $scope.getCurrentUser();
        });
    };

    $scope.changePassword = function () {
        userService.changePassword($scope.currentUser).then(function (response) {
            $scope.currentPassword = "";
            $scope.getCurrentUser();
            $scope.ChangedPasswordSuccessfully = true;
            $scope.messagePasswordChange = "Changes saved. Redirect in 2 seconds.";
            startTimer();

        },
        function (response) {
            $scope.ChangedPasswordSuccessfully = false;
            $scope.currentPassword = "";
            var errors = [];
            for (var key in response.data.modelState) {
                if (key != '$id') {
                    for (var i = 0; i < response.data.modelState[key].length; i++) {
                        errors.push(response.data.modelState[key][i]);
                    }
                }
            }
            $scope.messagePasswordChange = "Failed to change user due to: " + errors.join(' ');
            $scope.getCurrentUser();
        });
    };
    $scope.goHome = function() {
        $location.url(serviceBase);
    };

    var startTimer = function () {
        var timer = $timeout(function () {
            $timeout.cancel(timer);
            $location.path('/profile');
        }, 2000);
    }

    $scope.getCurrentUser();
    
   $scope.objavi = function (objava) {
            $scope.statusObjaveShow= false
            $scope.statusObjave = "Posted successfully";
            $timeout(function () { $scope.statusObjaveShow = true; $scope.statusObjave = ""; }, 3000);
            objaveService.postObjava(objava).then(function (response) {
                
            });
            
           
        
   };
    //ne dovrseno
   $scope.getObjave = function () {
       objaveService.getObjave().then(function (response) {
           objave = response.data;
           for (var i = 0; i < objave.length; i++) {
               var objava = {
               };
               $scope.people.objave(objava);
           }
       });
   };
    
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