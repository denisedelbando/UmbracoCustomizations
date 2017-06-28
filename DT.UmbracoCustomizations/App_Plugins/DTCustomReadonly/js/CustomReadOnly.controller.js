function CustomReadOnlyController ($scope, assetsService, $timeout) {
    $scope.htmlPreValue = $scope.model.config.prevalueText;
    assetsService
    .load([
        "lib/markdown/markdown.converter.js"
    ])
    .then(function () {

        // we need a short delay to wait for the textbox to appear.
        setTimeout(function () {
            //this function will execute when all dependencies have loaded
            // but in the case that they've been previously loaded, we can only
            // init the md editor after this digest because the DOM needs to be ready first
            // so run the init on a timeout
            $timeout(function () {
                var converter2 = new Markdown.Converter();
                $scope.htmlPreValue = converter2.makeHtml($scope.model.config.prevalueText);
            }, 200);
        });

        //load the seperat css for the editor to avoid it blocking our js loading TEMP HACK
        assetsService.loadCss("lib/markdown/markdown.css");
    })
}

angular.module("umbraco").controller("Custom.ReadOnlyController", CustomReadOnlyController);
