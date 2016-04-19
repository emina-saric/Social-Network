// Test fajl

angular.module('MyApp')
            .controller('LoginController', function ($scope, LoginService) {
                $scope.IsLogedIn = false;
                $scope.Message = '';
                $scope.Submitted = false;
                $scope.IsFormValid = false;

                $scope.LoginData = {
                    EMail: '',
                    Password: ''
                };

                //Check is Form Valid or Not // Here f1 is our form Name
                $scope.$watch('f1.$valid', function (newVal) {
                    $scope.IsFormValid = newVal;
                });

                $scope.Login = function () {
                    $scope.Submitted = true;
                    if ($scope.IsFormValid) {
                        LoginService.GetUser($scope.LoginData).then(function (d) {
                            if (d.data.EMail != null) {
                                $scope.IsLogedIn = true;
                                $scope.Message = "Successfully login done.";
                            }
                            else {
                                alert('Invalid Credential!');
                            }
                        });
                    }
                };

            })
            .factory('LoginService', function ($http) {
                var fac = {};
                fac.GetUser = function (d) {
                    return $http({
                        url: '/Account/Login',
                        method: 'POST',
                        data: JSON.stringify(d),
                        headers: { 'content-type': 'application/json' }
                    });
                };
                return fac;
            });