'use strict';

app.controller('profileController', ['$scope', '$location', '$timeout', 'authService', 'userService', '$routeParams', 'Upload', 'objaveService', '$sce', function ($scope, $location, $timeout, authService, userService, $routeParams, Upload, objaveService, $sce) {


    $scope.savedSuccessfully = false;
    $scope.ChangedSuccessfully = false;
    $scope.ChangedPasswordSuccessfully = false;
    $scope.PostedSuccessfully = false;
    $scope.DeletedSuccessfully = false;

    $scope.message = "";
    $scope.authentication = authService.authentication;
    $scope.messageEdit = "";
    $scope.messagePasswordChange = "";
    $scope.postDelete = "";
    $scope.upload = [];
    $scope.fileUploadObj = { fullFileName: "Test string 1" };

   
    var objave = new Array();
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
        confirmNewPassword: "",
        profileImage: $sce.trustAsResourceUrl('/app/images/Default.png')
    };
    
    $scope.isAdmin = false;
    $scope.currentUser.userName = authService.authentication.userName;
    

    
    $scope.upload = function (dataUrl, name) {
        //$scope.fileUploadObj.fullFileName = "Test";
        Upload.upload({
            url: serviceBase + 'api/Profile/Upload/',
            method: "POST",
            data: {
                fullFileName: name,
                userName : $scope.currentUser.userName
            },
            file: Upload.dataUrltoBlob(dataUrl, name)
        }).then(function (response) {
            $timeout(function () {
                $scope.currentUser.profileImage = ' ';
                console.log(response.data);
                $scope.result = response.data;
                userService.getCurrentUser($scope.currentUser.userName).then(function (response) {
                    var random = (new Date()).toString();
                    $scope.currentUser.profileImage = $sce.trustAsResourceUrl('/app/images/' + response.data['profileImage'] + '?cb=' + random);
                    window.location.reload();
                });
            });
        }, function (response) {
            console.log(response.data);
            if (response.status > 0) $scope.errorMsg = response.status
                + ': ' + response.data;
        }, function (evt) {
            console.log('percent: ' + parseInt(100.0 * evt.loaded / evt.total));
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
                $scope.currentUser.profileImage = $sce.trustAsResourceUrl('/app/images/' + response.data['profileImage']);
                $scope.getRoles();
        });
    };
    var roles = [];
    $scope.getRoles = function () {
        userService.getRoles($scope.currentUser.userId).then(function (response2) {
            roles = response2.data;
            //alert(roles[1]);
            var authenticate = false;
            for (var i = 0; i < roles.length; i++) {
                if (roles[i] == "Admin" || roles[i] == "SuperAdmin") {
                    $scope.isAdmin = true;
                } else {
                    $scope.isAdmin = false;
                }
            }
            

        });
    }


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
        
        if ($scope.objavaTekst == null || $scope.objavaTekst.length < 1) {
               $scope.PostedSuccessfully = false;
               $scope.messageEdit = "You must enter at least one characters!";
               skloniPoruku();
               return;
        }
        var objava = {
            id: "",
            tekst: "",
            urlSlike: "",
            datumObjave: "",
            pozGlasovi: "",
            negGlasovi: "",
            oznake: "",
            profilId: "",
            userName: ""

        };
            objava.urlSlike = "nema";
            objava.datumObjave = new Date();
            objava.pozGlasovi = 0;
            objava.negGlasovi = 0;
            objava.oznake = "nema";
            objava.ProfilId = $scope.currentUser.userId;
            objava.userName = $scope.currentUser.userName;
            objava.tekst = $scope.objavaTekst;

            $scope.objave.unshift(objava);

            objaveService.PostObjava(objava).then(function (response) {
                $scope.PostedSuccessfully = true;
                $scope.messageEdit = "Posted successfully.";
                $scope.objavaTekst="";
                skloniPoruku();

            });
           
            
   };
   
    $scope.GetObjave = function () {
       objaveService.GetObjave().then(function (response) {
           objave = response.data;
           for (var i = 0; i < objave.length; i++) {
               var objava = {
                   id:"",
                   tekst: "",
                   urlSlike: "",
                   datumObjave: "",
                   pozGlasovi: "",
                   negGlasovi: "",
                   oznake: "",
                   profilId: "",
                   userName: ""
               };

               objava.id = objave[i].id;
               objava.tekst = objave[i].tekst;
               objava.urlSlike = objave[i].urlSlike;
               objava.datumObjave = objave[i].datumObjave;
               objava.pozGlasovi = objave[i].pozGlasovi;
               objava.negGlasovi = objave[i].negGlasovi;
               objava.oznake = objave[i].oznake;
               objava.profilId = objave[i].profilId;
               objava.userName = objave[i].userName;

               $scope.objave.unshift(objava);
              // alert(JSON.stringify(objava));
         
           }
       });
       
      
   };
    $scope.GetObjave();
   
    $scope.remove = function (objava) {
       // alert(JSON.stringify(objava));
        var index = $scope.objave.indexOf(objava)
        $scope.objave.splice(index, 1);
        objaveService.DeleteObjava(objava.id).then(function (response) {
            $scope.DeletedSuccessfully = true;
            $scope.postDelete = "Deleted successfully!"
            skloniPoruku();
       });

    }
    var skloniPoruku = function () {
        var timer = $timeout(function () {
            $scope.messageEdit = ""; $scope.postDelete="";
        }, 3000);
    }

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