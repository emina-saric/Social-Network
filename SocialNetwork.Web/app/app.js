var app = angular.module("AngularApp", ['ngRoute', 'LocalStorageModule', 'chieffancypants.loadingBar', 'pascalprecht.translate', 'AxelSoft', 'ngFileUpload', 'ngImgCrop', 'ui.grid', 'ui.grid.edit', 'ui.bootstrap', 'schemaForm', 'chart.js', 'angularUtils.directives.dirPagination']);


app.config(function (paginationTemplateProvider) {
    paginationTemplateProvider.setPath('Scripts/dirPagination.tpl.html');
});


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

    $routeProvider.when("/profile/changeimage", {
        controller: "profileController",
        templateUrl: "/app/views/profileImageChange.html"
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
    $routeProvider.when("/profileOther", {
        controller: "profileOtherController",
        templateUrl: "/app/views/profileOther.html"
    });
    $routeProvider.when("/profile/friends", {
        controller: "friendsController",
        templateUrl: "/app/views/friends.html"
    });
    $routeProvider.when("/showProfileImage", {
        controller: "profileController",
        templateUrl: "/App_Data/Tmp/FileUploads/"
    });
    $routeProvider.when("/admin/profili", {
        controller: "MainCtrl",
        templateUrl: "/app/views/adminProfili.html",
        resolve: {
            //This function is injected with the AuthService where you'll put your authentication logic
            'auth': function (accessService) {
                return accessService.authenticate();
            }
        }
    });

    $routeProvider.when("/charts", {
        controller: "chartController",
        templateUrl: "/app/views/chart.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });

});
var serviceBase = 'http://nwt-socialnetwork.azurewebsites.net/';
//var serviceBase = 'http://localhost:51622/';
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
app.run(function ($rootScope, $location) {
    //If the route change failed due to authentication error, redirect them out
    $rootScope.$on('$routeChangeError', function (event, current, previous, rejection) {
        if (rejection === 'Not Authenticated') {
            $location.path('/home');
        }
    })
});
       
app.config(['$httpProvider', function ($httpProvider) {
    $httpProvider.defaults.useXDomain = true;
    delete $httpProvider.defaults.headers.common['X-Requested-With'];
}
]);



app.config(function ($translateProvider) {
    $translateProvider.translations('en', {
        welcomeHome: 'Welcome to Social Network!',
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
        confirmPassword: 'Confirm Password',
        changeYourPassword: 'Change your Password',
        submit: 'Submit',
        yes: 'Yes',
        no: 'No',
        confirmMSGDeleteProfile: 'Are you sure you want to delete your profile?',
        lostPassword: 'Lost password?',
        socialLogins: 'Social Logins',
        socialLoginsText: 'Or you can login using one of the social logins below!',
        login: 'Login',
        loginText: 'If you have an account, you can use the button below to access the page.',
        signupText: 'Use the button below to create an account.',
        signup: 'Create Account',
        friends: "Friends",
        search: "Search",
        profileChangeImageIndex: "Change Profile Image"
    }).translations('ba', {
        welcomeHome: 'Dobro došli na Social Network!',
        profileIndex: 'Profil',
        profileMyProfileIndex: 'Moj profil',
        profileEditProfileIndex: 'Izmijeni profil',
        profileChangePasswordIndex: 'Izmijeni šifru',
        profileDeleteProfileIndex: 'Izbriši profil',
        welcomeIndex: 'Dobrodošao/la',
        logoutIndex: 'Odjavi se',
        userEmailProfile: 'E-mail',
        changeYDataProfileEdit: 'Izmijeni svoje podatke',
        firstName: 'Ime',
        lastName: 'Prezime',
        currentPassword: 'Trenutna šifra',
        password: 'Šifra',
        newPassword: 'Nova šifra',
        username: 'Korisničko ime',
        confirmNewPassword: 'Potvrda za novu šifru',
        confirmPassword: 'Potvrdi šifru',
        changeYourPassword: 'Izmijeni svoju šifru',
        submit: 'Potvrdi',
        yes: 'Da',
        no: 'Ne',
        confirmMSGDeleteProfile: 'Da li ste sigurni da želite da izbrišete svoj profil',
        lostPassword: 'Izgubljena šifra?',
        socialLogins: 'Socijalne prijave',
        socialLoginsText: 'Ili se možete prijaviti sa jednom od mreža ispod!',
        login: 'Prijava',
        loginText: 'Ako imate korisnički nalog, možete iskoristiti dugme ispod za prijavu.',
        signupText: 'Iskoristite dugme ispod za pravljenje korisničkog naloga.',
        signup: 'Napravi nalog',
        friends: 'Prijatelji',
        search: 'Pretraga',
        profileChangeImageIndex: "Izmijeni profilnu sliku"
    });
    $translateProvider.preferredLanguage('ba');
});