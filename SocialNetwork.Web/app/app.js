/// <reference path="views/profileDelete.html" />
var app = angular.module("AngularApp", ['ngRoute', 'LocalStorageModule', 'angular-loading-bar','pascalprecht.translate','AxelSoft']);


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

    $routeProvider.when("/profile/changepassword", {
        controller: "profileController",
        templateUrl: "/app/views/profileChangePassword.html"
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


app.config(function ($translateProvider) {
    $translateProvider.translations('en', {
        welcomeHome: 'Welcome to Social Network !',
        profileIndex: 'Profile',
        profileMyProfileIndex: 'My Profile',
        profileEditProfileIndex: 'Edit Profile',
        profileChangePasswordIndex: 'Change Password',
        profileDeleteProfileIndex: 'Delete Profile',
        welcomeIndex: 'Welcome',
        logoutIndex: 'Log Out',
        userEmailProfile: 'User E-Mail:',
        changeYDataProfileEdit: 'Change your Data',
        firstName: 'First Name',
        lastName: 'Last Name',
        currentPassword: 'Current Password',
        password: 'Password',
        newPassword: 'New Password',
        username: 'Username',
        confirmNewPassword: 'Confirm New Password',
        confirmPassword: 'Confirm Pasword',
        changeYourPassword: 'Change your Password',
        submit: 'Submit',
        yes: 'Yes',
        no: 'No',
        confirmMSGDeleteProfile: 'Are you sure, you want to delete your profile',
        lostPassword: 'Lost password?',
        socialLogins: 'Social Logins',
        socialLoginsText: 'Or you can login using one of the social logins below!',
        login: 'Login',
        loginText: 'If you have account, you can use the button below to access the page.',
        signupText: 'Use the button below to create account.',
        signup: 'Create Account'
    }).translations('ba', {
        welcomeHome: 'Dobrodosli na Social Network !',
        profileIndex: 'Profil',
        profileMyProfileIndex: 'Moj Profil',
        profileEditProfileIndex: 'Izmjeni Profil',
        profileChangePasswordIndex: 'Izmjeni Sifru',
        profileDeleteProfileIndex: 'Izbrisi Profil',
        welcomeIndex: 'Dobrodosao/la',
        logoutIndex: 'Odjavi se',
        userEmailProfile: 'Korisnicki E-Mail:',
        changeYDataProfileEdit: 'Izmjeni svoje podatke',
        firstName: 'Ime',
        lastName: 'Prezime',
        currentPassword: 'Sadasnja Sifra',
        password: 'Sifra',
        newPassword: 'Nova Sifra',
        username: 'Korisnicko Ime',
        confirmNewPassword: 'Potvrda za Novu Sifru',
        confirmPassword: 'Potvrdi Sifru',
        changeYourPassword: 'Izmjeni svoju Sifru',
        submit: 'Potvrdi',
        yes: 'Da',
        no: 'Ne',
        confirmMSGDeleteProfile: 'Da li ste sigurni da zelite da izbrisete svoj profil',
        lostPassword: 'Izgubljena Sifra?',
        socialLogins: 'Socijalne Prijave',
        socialLoginsText: 'Ili se mozete prijaviti sa jednom od mreza ispod !',
        login: 'Prijava',
        loginText: 'Ako imate korisnicki nalog, mozete iskoristiti dugme ispod za prijavu.',
        signupText: 'Iskoristite dugme ispod za pravljenje korisnickog naloga.',
        signup: 'Napravi nalog'

    });
    $translateProvider.preferredLanguage('ba');
});