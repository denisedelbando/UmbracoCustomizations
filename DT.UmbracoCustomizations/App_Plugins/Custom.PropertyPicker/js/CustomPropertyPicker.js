function apiHelper($http) {
    var apiRoot = "/umbraco/api/ContentProperty/";

    return {
        getContentProperty: function () {
            return $http.get(apiRoot + "GetContentProperty");
        }
    };
}
angular.module('umbraco.resources').factory('customPropertyPickerResource', apiHelper);


function CustomPropertyPickerController($scope, customPropertyPickerResource) {

    customPropertyPickerResource.getContentProperty().then(function (resp) {
        $scope.items = resp.data;
    });
}

angular.module("umbraco").controller("Custom.PropertyPickerController", CustomPropertyPickerController);