﻿'use strict';
//profile definition
app.constant('PersonSchema', {
    type: 'object',
    properties: {
        Id: { type: 'string', title: 'Id' },
        firstName: { type: 'string', title: 'First Name' },
        lastName: { type: 'string', title: 'Last Name' },
        email: { type: 'string', title: 'Email' },
        emailConfirmed: { type: 'string', title: 'Email Confirmed' },
        phoneNumber: { type: 'string', title: 'Phone Number' },
        lockoutEnabled: { type: 'string', title: 'Banned' },
        lockoutEndDateUtc: { type: 'string', title: 'Banned Until' },
        accessFailedCount: { type: 'string', title: 'Access Failed' },
        userName: { type: 'string', title: 'User Name' },
        profileImage: { type: 'string', title: 'Profile Image' },
    }
})
//izbaciti ova dva kontrollera u zasebne fajlove kao  service
app.controller('MainCtrl', MainCtrl)
app.controller('RowEditCtrl', RowEditCtrl)
app.service('RowEditor', RowEditor)
;

MainCtrl.$inject = ['$http', 'RowEditor', '$scope','$q'];
function MainCtrl ($http, RowEditor,$scope,$q) {
    var vm = this;
    vm.editRow = RowEditor.editRow;
  //kolone tabele
    vm.gridOptions = {
        columnDefs: [
            //bilo field:'id'
          { field: 'action', name: 'Action', cellTemplate: '<div class="ui-grid-cell-contents">'+
    '<button style="margin:0" type="button" class="btn btn-xs btn-primary" ng-click="grid.appScope.vm.editRow(grid, row)">'+
       '<i class="fa fa-edit"></i>'+
    '</button>'+
'</div>', width: 100 },
          { name: 'id' },
          { name: 'firstName' },
          { name: 'lastName' },
          { name: 'email' },
          { name: 'emailConfirmed' },
          { name: 'phoneNumber' },
          { name: 'lockoutEnabled' },
          { name: 'lockoutEndDateUtc' },
          { name: 'accessFailedCount' },
          { name: 'profileImage' },
          { name: 'userName' },
        ]
    };
    $http.get(serviceBase + 'api/Profile/GetUsers/')
      .success(function (data) {
          vm.gridOptions.data = data;
          //alert(JSON.stringify(vm.gridOptions.data));
      });

    function reloadGrid() {
        $http.get(serviceBase + 'api/Profile/GetUsers/')
          .success(function (data) {
              vm.gridOptions.data = data;
              //alert(JSON.stringify(vm.gridOptions.data));
          });
    }
    vm.reloadGrid = reloadGrid;

    RowEditor.registerObserverCallback(reloadGrid);
}

RowEditor.$inject = ['$rootScope', '$modal','userService'];
function RowEditor($rootScope, $modal,userService) {
    var service = {};
    service.editRow = editRow;

    var modaltemp = '<div>' +
                            '<div class="modal-header">' +
                               '<h3 class="modal-title">Edit profile</h3>' +
                           ' </div>' +
                            '<div class="modal-body">' +
                               '<form sf-schema="vm.schema" sf-form="vm.form" sf-model="vm.entity"></form>' +
                            '</div>' +
                            '<div class="modal-footer">' +
                            '<button class="btn btn-warning" ng-click="vm.deleteX()">{{'+"'deleteX'|translate}}</button>" +
                               '<button class="btn btn-success" ng-click="vm.save()">{{' + "'saveX'|translate}}</button>" +
                                '<button class="btn btn-warning" ng-click="$close()">{{' + "'cancelX'|translate}}</button>" +
                           ' </div>' +
                        '</div>';
    function editRow(grid, row) {
        $modal.open({
            //svaki red zatvoriti unutar ' ' i dodati plus na kraj
            template: modaltemp,
            controller: ['$modalInstance', 'PersonSchema', 'grid', 'row','$http','RowEditor', RowEditCtrl],
            controllerAs: 'vm',
            resolve: {
                grid: function () { return grid; },
                row: function () { return row; }
            }
        });
    }

    // U slucaju izmjene otherUser ovo se koristi
    var observerCallbacks = [];

    //register an observer
    var _registerObserverCallback = function (callback) {
        observerCallbacks.push(callback);
    };

    //call this when you know 'foo' has been changed
    var _notifyObservers = function () {
        angular.forEach(observerCallbacks, function (callback) {
            callback();
        });
    };


    service.registerObserverCallback = _registerObserverCallback;
    service.notifyObservers = _notifyObservers;
  
    return service;
}

function RowEditCtrl($modalInstance, PersonSchema, grid, row, $http,RowEditor) {
    var vm = this;
  
    vm.schema = PersonSchema;
    vm.entity = angular.copy(row.entity);
    //alert(JSON.stringify(row.entity));
    vm.form = [
      'firstName',
      'lastName',
      'email',
      'emailConfirmed',
      'phoneNumber',
      'lockoutEnabled',
      'lockoutEndDateUtc',
      'accessFailedCount',
      'userName',
      'profileImage'
     ];
  
    vm.save = save;
    vm.deleteX = deleteX;
  
    function save() {
        // Copy row values over
        row.entity = angular.extend(row.entity, vm.entity);
        //alert(JSON.stringify(row.entity));
        $http.put(serviceBase + 'api/Profile/EditUser/', row.entity).then(function (response) {
            RowEditor.notifyObservers();
            $modalInstance.close(row.entity);
        },
        function (response) {
            var errors = [];
            for (var key in response.data.modelState) {
                if (key != '$id') {
                    for (var i = 0; i < response.data.modelState[key].length; i++) {
                        errors.push(response.data.modelState[key][i]);
                    }
                }
            }
            alert("Failed to change user due to: " + response.data.message);
        });
    }

    function deleteX() {
        // Copy row values over
        row.entity = angular.extend(row.entity, vm.entity);
        //alert(JSON.stringify(row.entity));
        $http.delete(serviceBase + 'api/Profile/DeleteUser/' + row.entity.id).then(function (response) {
            RowEditor.notifyObservers();
            $modalInstance.close(row.entity);
        },
        function (response) {
            var errors = [];
            for (var key in response.data.modelState) {
                if (key != '$id') {
                    for (var i = 0; i < response.data.modelState[key].length; i++) {
                        errors.push(response.data.modelState[key][i]);
                    }
                }
            }
            alert("Failed to delete user due to: " + response.data.message);
        });
    }
}


//podaci u tabelu
/*
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
}];*/