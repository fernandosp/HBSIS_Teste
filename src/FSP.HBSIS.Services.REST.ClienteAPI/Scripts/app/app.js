var ClienteApp = angular.module('ClienteApp', ['ngRoute', 'ClienteControllers']);
ClienteApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/list',
    {
        templateUrl: '~/Views/ClientesAngular/list.html',
        controller: 'ListController'
    }).
    when('/create',
    {
        templateUrl: 'Views/ClientesAngular/edit.html',
        controller: 'EditController'
    }).
    when('/edit/:id',
    {
        templateUrl: 'Views/ClientesAngular/edit.html',
        controller: 'EditController'
    }).
    when('/delete/:id',
    {
        templateUrl: 'Views/ClientesAngular/delete.html',
        controller: 'DeleteController'
    }).
    otherwise(
    {
        redirectTo: '/list'
    });
}]);