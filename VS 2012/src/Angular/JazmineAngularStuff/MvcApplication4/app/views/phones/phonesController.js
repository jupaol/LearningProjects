IGS.PhonesController = function($scope, $http, environmentRootPath) {
    //$scope.phones = [
    //    {
    //        name: 'IPhone',
    //        description: 'Super IPhone',
    //        age: 2
    //    },
    //    {
    //        name: 'Galaxy 4',
    //        description: 'even better',
    //        age: 15
    //    }];

    $http.get('http://localhost:49981/api/phones').success(function (data) {
        $scope.phones = data;
        $scope.isbusy = false;
    });

    $scope.isbusy = true;
    $scope.orderProp = 'age';
};