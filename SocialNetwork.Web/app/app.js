/// <reference path="views/profileDelete.html" />
var app = angular.module("AngularApp", ['ngRoute', 'LocalStorageModule', 'angular-loading-bar', 'pascalprecht.translate', 'AxelSoft', 'ngFileUpload', 'ngImgCrop','ui.grid', 'ui.grid.edit', 'ui.bootstrap', 'schemaForm']);

app.constant('PersonSchema', {
    type: 'object',
    properties: {
        name: { type: 'string', title: 'Name' },
        company: { type: 'string', title: 'Company' },
        phone: { type: 'string', title: 'Phone' },
        'address.city': { type: 'string', title: 'City' }
    }
})

app.controller('MainCtrl', MainCtrl)
app.controller('RowEditCtrl', RowEditCtrl)
app.service('RowEditor', RowEditor)
;

MainCtrl.$inject = ['$http', 'RowEditor'];
function MainCtrl ($http, RowEditor) {
    var vm = this;
  
    vm.editRow = RowEditor.editRow;
  
    vm.gridOptions = {
        columnDefs: [
          { field: 'id', name: '', cellTemplate: 'app/views/edit-button.html', width: 34 },
          { name: 'firstName' },
          { name: 'lastName' },
          { name: 'phone' },
          { name: 'City', field: 'address.city' },
        ]
    };
  
    /*$http.get('http://ui-grid.info/data/500_complex.json')
      .success(function (data) {
          vm.gridOptions.data = data;
      });*/
   
    /*var getList = function () {
        return $http.get('http://ui-grid.info/data/500_complex.json').then(function (response) {
            vm.gridOptions.data = response;
            alert("fer");
        });
    }*/
    vm.gridOptions.data =
    [
    {
        "id": 0,
        "guid": "de3db502-0a33-4e47-a0bb-35b6235503ca",
        "isActive": false,
        "balance": "$3,489.00",
        "picture": "http://placehold.it/32x32",
        "age": 30,
        "name": "Sandoval Mclean",
        "gender": "male",
        "company": "Zolavo",
        "email": "sandovalmclean@zolavo.com",
        "phone": "+1 (902) 569-2412",
        "address": {
            "street": 317,
            "city": "Blairstown",
            "state": "Maine",
            "zip": 390
        },
        "about": "Fugiat velit laboris sit est. Amet eu consectetur reprehenderit proident irure non. Adipisicing mollit veniam enim veniam officia anim proident excepteur deserunt consectetur aliquip et irure. Elit aliquip laborum qui elit consectetur sit proident adipisicing.\r\n",
        "registered": "1991-02-21T23:02:31+06:00",
        "friends": [
            {
                "id": 0,
                "name": "Rosanne Barrett"
            },
            {
                "id": 1,
                "name": "Nita Chase"
            },
            {
                "id": 2,
                "name": "Briggs Stark"
            }
        ]
    },
    {
        "id": 1,
        "guid": "9f507483-5ecc-4af4-800f-349306820585",
        "isActive": false,
        "balance": "$2,407.00",
        "picture": "http://placehold.it/32x32",
        "age": 22,
        "name": "Nieves Mack",
        "gender": "male",
        "company": "Oulu",
        "email": "nievesmack@oulu.com",
        "phone": "+1 (812) 535-2614",
        "address": {
            "street": 155,
            "city": "Cherokee",
            "state": "Kentucky",
            "zip": 4723
        },
        "about": "Culpa anim anim nulla deserunt dolor exercitation eu in anim velit. Consectetur esse cillum ea esse ullamco magna do voluptate sit ut cupidatat ullamco. Et consequat eu excepteur do Lorem aute est quis proident irure.\r\n",
        "registered": "1989-07-26T15:52:15+05:00",
        "friends": [
            {
                "id": 0,
                "name": "Brewer Maxwell"
            },
            {
                "id": 1,
                "name": "Ayala Franks"
            },
            {
                "id": 2,
                "name": "Hale Nichols"
            }
        ]
    },
    {
        "id": 2,
        "guid": "58c66190-15be-4e75-9b09-183599403241",
        "isActive": false,
        "balance": "$3,409.00",
        "picture": "http://placehold.it/32x32",
        "age": 20,
        "name": "Terry Clay",
        "gender": "female",
        "company": "Freakin",
        "email": "terryclay@freakin.com",
        "phone": "+1 (965) 462-3681",
        "address": {
            "street": 124,
            "city": "Wright",
            "state": "Pennsylvania",
            "zip": 8002
        },
        "about": "Exercitation exercitation adipisicing eu cupidatat reprehenderit laborum incididunt reprehenderit Lorem anim. Velit aliquip dolore qui excepteur dolor non occaecat aute et. Consectetur anim veniam irure ea id aliqua amet. Nostrud tempor ullamco velit labore consequat aute nostrud nostrud veniam cupidatat amet nostrud quis. Qui exercitation eiusmod esse eu officia officia Lorem Lorem ullamco voluptate excepteur fugiat nulla et. Ea ipsum ut do culpa labore non duis commodo sit. Id sint dolor ipsum consectetur nostrud nulla consectetur esse deserunt.\r\n",
        "registered": "2000-12-02T22:19:28+06:00",
        "friends": [
            {
                "id": 0,
                "name": "Etta Hawkins"
            },
            {
                "id": 1,
                "name": "Zamora Barlow"
            },
            {
                "id": 2,
                "name": "Lynette Vinson"
            }
        ]
    },
    {
        "id": 3,
        "guid": "0a1b0539-73ec-473a-846a-71a58e04551c",
        "isActive": false,
        "balance": "$3,567.00",
        "picture": "http://placehold.it/32x32",
        "age": 21,
        "name": "Bishop Carr",
        "gender": "male",
        "company": "Digirang",
        "email": "bishopcarr@digirang.com",
        "phone": "+1 (860) 463-2942",
        "address": {
            "street": 824,
            "city": "Homeworth",
            "state": "Oklahoma",
            "zip": 5215
        },
        "about": "Nulla ullamco sint exercitation minim ea sunt. Excepteur minim tempor velit in. Proident id reprehenderit nisi officia in anim elit laboris aute sint amet voluptate. Deserunt et nostrud magna eu esse ea adipisicing non quis sint fugiat consectetur enim sint. Magna elit mollit eiusmod non voluptate sunt.\r\n",
        "registered": "2012-10-15T19:03:24+05:00",
        "friends": [
            {
                "id": 0,
                "name": "Young Gentry"
            },
            {
                "id": 1,
                "name": "Dean Lopez"
            },
            {
                "id": 2,
                "name": "Mccray Bradford"
            }
        ]
    }];
}

RowEditor.$inject = ['$rootScope', '$modal'];
function RowEditor($rootScope, $modal) {
    var service = {};
    service.editRow = editRow;
  
    function editRow(grid, row) {
        $modal.open({
            templateUrl: 'app/views/edit-modal.html',
            controller: ['$modalInstance', 'PersonSchema', 'grid', 'row', RowEditCtrl],
            controllerAs: 'vm',
            resolve: {
                grid: function () { return grid; },
                row: function () { return row; }
            }
        });
    }
  
    return service;
}

function RowEditCtrl($modalInstance, PersonSchema, grid, row) {
    var vm = this;
  
    vm.schema = PersonSchema;
    vm.entity = angular.copy(row.entity);
    vm.form = [
      'name',
      'company',
      'phone',
      {
          'key': 'address.city',
          'title': 'City'
      },
    ];
  
    vm.save = save;
  
    function save() {
        // Copy row values over
        row.entity = angular.extend(row.entity, vm.entity);
        $modalInstance.close(row.entity);
    }
}

/*

{
    "id": 0,
    "guid": "de3db502-0a33-4e47-a0bb-35b6235503ca",
    "isActive": false,
    "balance": "$3,489.00",
    "picture": "http://placehold.it/32x32",
    "age": 30,
    "name": "Sandoval Mclean",
    "gender": "male",
    "company": "Zolavo",
    "email": "sandovalmclean@zolavo.com",
    "phone": "+1 (902) 569-2412",
    "address": {
        "street": 317,
        "city": "Blairstown",
        "state": "Maine",
        "zip": 390
    },
    "about": "Fugiat velit laboris sit est. Amet eu consectetur reprehenderit proident irure non. Adipisicing mollit veniam enim veniam officia anim proident excepteur deserunt consectetur aliquip et irure. Elit aliquip laborum qui elit consectetur sit proident adipisicing.\r\n",
    "registered": "1991-02-21T23:02:31+06:00",
    "friends": [
        {
            "id": 0,
            "name": "Rosanne Barrett"
        },
        {
            "id": 1,
            "name": "Nita Chase"
        },
        {
            "id": 2,
            "name": "Briggs Stark"
        }
    ]
}
    
*/



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
        templateUrl: "/app/views/adminProfili.html"
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
        profileChangeImageIndex: "Izmjeni Profilnu Sliku"
    });
    $translateProvider.preferredLanguage('ba');
});