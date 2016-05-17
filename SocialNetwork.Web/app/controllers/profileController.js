'use strict';

app.controller('profileController', ['$scope', '$location', '$timeout', 'authService', 'userService', '$routeParams', 'Upload','objaveService', function ($scope, $location, $timeout, authService, userService, $routeParams, Upload,objaveService) {


    $scope.savedSuccessfully = false;
    $scope.ChangedSuccessfully = false;
    $scope.ChangedPasswordSuccessfully = false;
    $scope.message = "";
    $scope.authentication = authService.authentication;
    $scope.messageEdit = "";
    $scope.messagePasswordChange = "";
    $scope.upload = [];
    $scope.fileUploadObj = { testString1: "Test string 1", testString2: "Test string 2" };

    
    $scope.statusObjaveShow = true

    $scope.objave = new Array();
    
    var objave = new Array();

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
    

    
    $scope.upload = function (dataUrl, name) {
        Upload.upload({
            url: serviceBase + 'api/Profile/Upload/',
            method: "POST",
            data: {
                file: Upload.dataUrltoBlob(dataUrl, name)
            },
        }).then(function (response) {
            $timeout(function () {
                $scope.result = response.data;
            });
        }, function (response) {
            if (response.status > 0) $scope.errorMsg = response.status
                + ': ' + response.data;
        }, function (evt) {
            $scope.progress = parseInt(100.0 * evt.loaded / evt.total);
        });
    };
    
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
    
   $scope.objavi = function () {
            $scope.statusObjaveShow= false
            var objava = {
                tekst: "objava iz angulara sa minimalno 20 karaktera jer tako mora",
                urlSlike: "nema",
                datumObjave: "2015-01-01T00:00:00",
                pozGlasovi: "10",
                negGlasovi: "0",
                oznake: "nema oznaka",
                ProfilId: "b5648d7f-86f1-4e71-b164-a8c0ab22cae8"
            };
            objaveService.PostObjava(objava).then(function (response) {
                $scope.statusObjave = "Posted successfully";
                $timeout(function () { $scope.statusObjaveShow = true; $scope.statusObjave = ""; }, 3000);

            });
            
           
        
   };

   $scope.GetObjave = function () {
       objaveService.GetObjave().then(function (response) {
           objave = response.data;
           for (var i = 0; i < objave.length; i++) {
               var objava = {
                   tekst:"",
                   urlSlike:"",
                   datumObjave: "",
                   pozGlasovi: "",
                   negGlasovi: "",
                   oznake: "",
                   ProfilId:""
               };
               objava.tekst = objave[i].tekst;
               objava.urlSlike = objave[i].urlSlike;
               objava.datumObjave = objave[i].datumObjave;
               objava.pozGlasovi = objave[i].pozGlasovi;
               objava.negGlasovi = objave[i].negGlasovi;
               objava.oznake = objave[i].oznake;
               objava.ProfilId = objave[i].ProfilId;
               $scope.objave.push(objava);
               alert(JSON.stringify(objava));
           }
       });
   };
    $scope.GetObjave();
    
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