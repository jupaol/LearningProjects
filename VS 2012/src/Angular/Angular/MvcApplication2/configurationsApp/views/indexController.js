IGS.IndexController = function ($scope, $routeParams, ProductsService, environmentRootPath) {
    $scope.isBusy = true;
    $scope.environmentRootPath = environmentRootPath;

    ProductsService.getProducts(function (result) {
        $scope.products = result;
        $scope.isBusy = false;
    });
    
    $scope.gridOptions = {
        data: "products",
        columnDefs: [
            {
                field: 'Name',
                displayName: 'Name'
                //cellTemplate: '<div class="ngCellText" ng-class="col.colIndex()"><span ng-cell-text>{{row.getProperty(col.field)}}</span><i class="icon-search summary-filter" ng-click="addProductFilter(row.getProperty(col.field))"></i></div>'
            }
        ],
        showGroupPanel: true,
        enableColumnResize: true,
        enableSorting: true,
        multiSelect: false,
        showFilter: false,
        showColumnMenu: false,
        enableCellSelection: false
        //plugins: [new ngGridCsvExportPlugin()]
    };
}