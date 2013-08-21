var IGS = IGS || {};

IGS.app = angular.module("app", []);

IGS.environmentRootPath = IGS.environmentRootPath || '';

IGS.app.value("environmentRootPath", IGS.environmentRootPath);

IGS.app.config(['$routeProvider', '$locationProvider', '$httpProvider', function ($routeProvider, $locationProvider, $httpProvider) {
    $locationProvider.html5Mode(false);

    $routeProvider.when('/', {
        templateUrl: IGS.environmentRootPath + 'app/views/phones/index.html',
        controller: IGS.PhonesController
    });

    $routeProvider.when('/phones/:phoneId', {
        templateUrl: IGS.environmentRootPath + 'app/views/phones/detail.html',
        controller: IGS.PhonesDetailController
    });

    $routeProvider.otherwise({
        redirectTo: '/'
    });
}]);