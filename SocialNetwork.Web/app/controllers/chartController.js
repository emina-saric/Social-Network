'use strict';
/**
 * @ngdoc function
 * @name sbAdminApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the sbAdminApp
 */

app.controller('chartController', ['$scope', '$timeout','chartService', function ($scope, $timeout,chartService) {

    $scope.UserConfirmedStats = {
        labels: ["Confirmed", "Not Confirmed"],
        data: [300, 500],
        total: 0
    };

    $scope.UserImageChangeStats = {
        labels: ["Default", "Personal"],
        data: [300, 500],
        total: 0
    };

    //GetUserConfirmedStats

    $scope.GetUserConfirmedStats = function () {
        chartService.GetUserConfirmedStats().then(function (response) {
            $scope.UserConfirmedStats.data = [response.data['confirmed'], response.data['notConfirmed']];
            $scope.UserConfirmedStats.total = response.data['total'];
        });
    };

    //GetUserProfileImageStats
    $scope.GetUserProfileImageStats = function () {
        chartService.GetUserProfileImageStats().then(function (response) {
            var total = response.data['total'];
            var defaultpng = response.data['confirmed'];
            var changedProfileImage = response.data['notConfirmed'];
            $scope.UserImageChangeStats.data = [defaultpng,changedProfileImage];
            $scope.UserImageChangeStats.total = total;
        });
    };
    $scope.GetUserConfirmedStats();
    $scope.GetUserProfileImageStats();

}]);