var IGS = IGS || {};

IGS.app.factory('ProductsService', function ($http, environmentRootPath) {
    return {
        getProducts: function (callback) {
            $http.get(environmentRootPath + 'api/values').then(function (response) {
                callback(response.data);
            });
        }
    };
});