// Random Test for future use.
(function () {
    var app = angular.module('myApp', []);
    app.controller('LoginController', function ($scope, $http) {
        
        $scope.eMailValidation = "";
        $scope.passwordValidation = "";
        $scope.data = [];
        $scope.validation = [];
        $http.post("/Account/Login")
        .then(function (result) {
            //Success
            angular.copy(result.data, $scope.data);
            alert($scope.data);
        }, function () {
            alert("Error");
        });


    });
})();