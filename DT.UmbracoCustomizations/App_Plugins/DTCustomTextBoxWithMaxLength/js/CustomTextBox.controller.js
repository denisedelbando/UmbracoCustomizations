function CustomTextboxController($scope) {
    $scope.validation =
    {
        mandatory: $scope.model.config.isrequired,
        pattern: new RegExp('.*')
    };
    
    if ($scope.model.config.valexpression != null)
    {
        $scope.validation.pattern = new RegExp($scope.model.config.valexpression);
    }
    $scope.maxlength = 70;//default max length value

    if ($scope.model.config.maxlength != null) {
        $scope.maxlength = $scope.model.config.maxlength;
    }
}

angular.module("umbraco").controller("CustomTextboxController", CustomTextboxController);
