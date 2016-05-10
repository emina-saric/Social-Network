'use strict';
app.controller('searchController', ['$scope', '$location', '$timeout', 'authService','$routeParams','searchService', function ($scope, $location, $timeout, authService,$routeParams,searchService) {

                    

           
/*$scope.people = [
    { FirstName: 'John ', LastName: 'Doe', picture: 'http://www.saintsfc.co.uk/images/common/bg_player_profile_default_big.png' },
    { FirstName: 'Axel ', LastName: 'Zarate', picture: 'https://avatars0.githubusercontent.com/u/4431445?s=60' },
    { FirstName: 'Walter White', LastName: 'White', picture: 'http://upstreamideas.org/wp-content/uploads/2013/10/ww.jpg' },
    { FirstName: 'Walter White', LastName: 'White', picture: 'http://upstreamideas.org/wp-content/uploads/2013/10/ww.jpg' },
    { FirstName: 'Walter White', LastName: 'White', picture: 'http://upstreamideas.org/wp-content/uploads/2013/10/ww.jpg' },
{ FirstName: 'Axel Zarate', LastName: 'Zarate', picture: 'https://avatars0.githubusercontent.com/u/4431445?s=60' },
{ FirstName: 'John Doe', LastName: 'Doe', picture: 'http://www.saintsfc.co.uk/images/common/bg_player_profile_default_big.png' }
];*/
var profili = searchService.getAllUsers();
for (var i = 0; i < profili.length; i++) {
    var profil = [{ FirstName: profili[i].FirstName, LastName: profili[i].LastName, picture: 'http://upstreamideas.org/wp-content/uploads/2013/10/ww.jpg' }];
    $scope.people.concat(profil);
    console.log($scope.people[i].FirstName);
}
                    
                   
}]);