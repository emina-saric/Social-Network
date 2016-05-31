'use strict';
app.factory('accessService', ['$http' ,'$q', 'localStorageService', 'ngAuthSettings','userService','authService', function ($http, $q, localStorageService, ngAuthSettings,userService,authService) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    var authServiceFactory = {};

    var currentUser = {
        userName: "",
        userId: ""
    };
    var roles = [];

    return {
        authenticate: function () {

            currentUser.userName = authService.authentication.userName;
           
                var getCurrentUser = function () {

                    return userService.getCurrentUser(currentUser.userName).then(function (response) {

                        currentUser.userId = response.data['id'];
                        return userService.getRoles(currentUser.userId).then(function (response2) {

                            roles = response2.data;
                            //alert(roles[1]);
                            var authenticate = false;
                            for (var i = 0; i < roles.length; i++) {
                                if (roles[i] == "Admin" || roles[i] == "SuperAdmin") {
                                    return true;
                                }
                            }
                            $scope.authISADMIN = false;
                            return $q.reject('Not Authenticated');
                           
                        });
                    });
                    
                };
                return getCurrentUser();
                

            //alert(JSON.stringify(getCurrentUser));
                //Else send a rejection 
        }
    }

}]);