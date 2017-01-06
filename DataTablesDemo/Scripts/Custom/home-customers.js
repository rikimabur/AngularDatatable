//home-customers.js

var homeCustomersModule = angular.module("homeCustomers", ["ngRoute", 'datatables']); //[] => Configuration Data

//Routes
homeCustomersModule.config(["$routeProvider", function ($routeProvider) {

    $routeProvider.when("/", {
        controller: "customersController",
        templateUrl: "/ViewTemplates/customersView.html"
    });

    //If I can't determine from the "when" parameter which URI you are looking for:
    $routeProvider.otherwise({
        redirectTo: "/"
    });
}]);

//Servive
homeCustomersModule.factory("dataService", ["$http", "$q", function ($http, $q) {

    var _customers = [];
    var _isInit = false;

    var _isReady = function () {
        return _isInit;
    }

    //Get the customers from the server and add it to the local collection
    var _getCustomers = function () {

        //Implement a promise ($q)
        var deferred = $q.defer();

        $http.get("/api/CustomersApi")
          .then(function (result) {
              //Successful            
              angular.copy(result.data, _customers);
              _isInit = true;                   //Tell anyone that binds to the topics that it has been initialised
              deferred.resolve(_customers);     //Data can be returned as parameters
          },
        function () {
            //Error - We dont want the data service to interact with the UI directly
            deferred.reject();
        });

        return deferred.promise;
    };

    //Variables to be exposed to other functions
    return {
        customers: _customers,
        getCustomers: _getCustomers,
        isReady: _isReady,
    };
}]);

//Customers Controller
var customersController = ["$scope", "$http", "dataService", "$compile", "DTOptionsBuilder", "DTColumnBuilder", "DTInstances",
    homeCustomersModule.controller("customersController", function ($scope, $http, dataService, $compile, DTOptionsBuilder, DTColumnBuilder, DTInstances) {
        $scope.data = dataService;
        $scope.isBusy = false;

        $scope.edit = edit;
        $scope.delete = deleteRow;
        $scope.message = "";

        if (dataService.isReady() == false) {
            $scope.isBusy = true;
            dataService.getCustomers()
                .then(function () {
                    //Success
                    //TablesDatatables.init();
                },
                function () {
                    alert("could not load customers");
                })
            .then(function () {
                $scope.isBusy = false;
            });
        }

        $scope.dtOptions = DTOptionsBuilder.fromFnPromise(dataService.getCustomers()).withPaginationType('full_numbers').withOption('createdRow', createdRow);
        $scope.dtColumns = [
            DTColumnBuilder.newColumn('CustomerID').withTitle('ID'),
            DTColumnBuilder.newColumn('FirstName').withTitle('First name'),
            DTColumnBuilder.newColumn('LastName').withTitle('Last name'),
            DTColumnBuilder.newColumn('Title').withTitle('Title'),
            DTColumnBuilder.newColumn('Email').withTitle('E-mail'),
            DTColumnBuilder.newColumn('CompanyName').withTitle('Company Name'),

            DTColumnBuilder.newColumn(null).withTitle('Actions').notSortable().renderWith(actionsHtml).withClass("text-center")
        ];

        DTInstances.getLast().then(function (dtInstance) {
            vm.dtInstance = dtInstance;
        });

        function edit(id) {
            //alert("inEdit");
            $scope.message = 'You are trying to edit the row with ID: ' + id;
            // Edit some data and call server to make changes...
            // Then reload the data so that DT is refreshed
            $scope.dtInstance.reloadData();
        }
        function deleteRow(id) {
            //alert("inDelete");
            $scope.message = 'You are trying to remove the row with ID: ' + id;
            // Delete some data and call server to make changes...
            // Then reload the data so that DT is refreshed
            $scope.dtInstance.reloadData();
        }
        function createdRow(row, data, dataIndex) {
            // Recompiling so we can bind Angular directive to the DT
            $compile(angular.element(row).contents())($scope);
        }
        function actionsHtml(data, type, full, meta) {
            return '<div class="text-center">' +
            '<button class="btn btn-warning" data-ng-click="edit(' + data.CustomerID + ')">' +
                '   <i class="fa fa-edit"></i>' +
                '</button>&nbsp;' +
                '<button class="btn btn-danger" data-ng-click="delete(' + data.CustomerID + ')">' +
                '   <i class="fa fa-trash-o"></i>' +
                '</button>' +
                '</div>';
        }
    })];

