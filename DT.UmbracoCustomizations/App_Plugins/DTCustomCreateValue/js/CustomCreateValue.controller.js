function CustomCreateValueController($scope) {
    $scope.model.value = $scope.model.config.prevalue;
}

angular.module("umbraco").controller("Custom.CreateValueController", CustomCreateValueController);
