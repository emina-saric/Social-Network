app.controller('translationsController', function ($translate, $scope) {
    $scope.language = "BA";
    $scope.changeLanguage = function () {
        var langKey = "";
        if ($scope.language == "BA") { langKey = "en"; $scope.language = "EN"; }
        else { langKey = "ba"; $scope.language = "BA"; }
        $translate.use(langKey);
    };
})