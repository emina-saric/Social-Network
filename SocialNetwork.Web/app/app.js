
var app = angular.module("AngularApp", ['ngRoute', 'LocalStorageModule', 'angular-loading-bar','AxelSoft']);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/views/login.html"
    });
        
    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/app/views/signup.html"
    });

    $routeProvider.when("/refresh", {
        controller: "refreshController",
        templateUrl: "/app/views/refresh.html"
    });

    $routeProvider.when("/tokens", {
        controller: "tokensManagerController",
        templateUrl: "/app/views/tokens.html"
    });

    $routeProvider.when("/associate", {
        controller: "associateController",
        templateUrl: "/app/views/associate.html"
    });
    $routeProvider.when("/profile", {
        controller: "profileController",
        templateUrl: "/app/views/profile.html"
    });
    $routeProvider.when("/profile/edit", {
        controller: "profileController",
        templateUrl: "/app/views/profileEdit.html"
    });
    $routeProvider.when("/profile/delete", {
        controller: "profileController",
        templateUrl: "/app/views/profileDelete.html"
    });

    $routeProvider.when("/confirmEmail/:userId/:code", {
        controller: "confirmEmailController",
        templateUrl: "/app/views/confirmEmail.html"
    });
    $routeProvider.when("/forgotPassword", {
        controller: "forgotPasswordController",
        templateUrl: "/app/views/forgotPassword.html"
    });
    $routeProvider.when("/resetPassword/:userId/:code", {
        controller: "resetPasswordController",
        templateUrl: "/app/views/resetPassword.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });

});

var serviceBase = 'http://localhost:51622/';
//var serviceBase = 'http://localhost:57409/';
//var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';
app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);
app.config(['$httpProvider', function ($httpProvider) {
    $httpProvider.defaults.useXDomain = true;
    delete $httpProvider.defaults.headers.common['X-Requested-With'];
}
]);
/*
app.config(function ($httpProvider) {
    $httpProvider.defaults.headers.common = {};
    $httpProvider.defaults.headers.post = {};
    $httpProvider.defaults.headers.put = {};
    $httpProvider.defaults.headers.patch = {};
});

*/