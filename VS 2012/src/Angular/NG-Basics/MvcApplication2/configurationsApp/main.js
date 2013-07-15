var IGS = IGS || {};

IGS.app = angular.module('configurationApp', ['ngGrid']);

IGS.environmentRootPath = IGS.environmentRootPath || 'http://localhost:20559/';
IGS.app.value("environmentRootPath", IGS.environmentRootPath);

IGS.app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

    $locationProvider.html5Mode(false);

    $routeProvider.when('/', {
        templateUrl: IGS.environmentRootPath + 'configurationsApp/views/index.html',
        controller: IGS.IndexController
    });

    $routeProvider.otherwise({ redirectTo: '/notFound' });
}]);