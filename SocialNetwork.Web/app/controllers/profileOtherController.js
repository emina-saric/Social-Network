app.controller('profileOtherController', ['$scope', '$location', '$timeout', 'authService', 'userService', '$routeParams', function ($scope, $location, $timeout, authService, userService, $routeParams) {
    
    //alert($scope.person.userName);
    $scope.otherUser = {
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
    $scope.getOtherUser = function () {
        userService.getCurrentUser('amar').then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message = "User found !";
            $scope.otherUser.userId = response.data['id'];
            $scope.otherUser.eMail = response.data['email'];
            $scope.otherUser.firstName = response.data['firstName'];
            $scope.otherUser.lastName = response.data['lastName'];
            $scope.otherUser.fullName = response.data['fullName'];
        });
    };

    $scope.getOtherUser();

}]);