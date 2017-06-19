var ClienteControllers = angular.module("ClienteControllers", []);
// este controller chama a api metodo para exibir os clientes  
// na list.html  
ClienteControllers.controller("ListController", ['$scope', '$http',
    function ($scope, $http) {
        $http.get('http://localhost:1075/api/clientes').success(function (data) {
            $scope.clientes = data;
            alert(data);
        });
    }
]);
// este controller chama a api metodo para exibir o cliente selecionado  
// no delete.html  
ClienteControllers.controller("DeleteController", ['$scope', '$http', '$routeParams', '$location',
    function ($scope, $http, $routeParams, $location) {
        $scope.id = $routeParams.id;
        $http.get('http://localhost:1075/api/clientes/' + $routeParams.id).success(function (data) {
            $scope.nome = data.Nome;
            $scope.codigo = data.Codigo;
            $scope.cpf = data.CPF;
            $scope.telefone = data.Telefone;
        });
        $scope.delete = function () {
            $http.delete('http://localhost:1075/api/clientes/' + $scope.id).success(function (data) {
                $location.path('/list');
            }).error(function (data) {
                $scope.error = "Erro ao apagar cliente " + data;
            });
        };
    }
]);
// este controller chama a api metodo para exibir o cliente selecionado   
// no edit.html para criar ou editar um cliente  
ClienteControllers.controller("EditController", ['$scope', '$filter', '$http', '$routeParams', '$location',
    function ($scope, $filter, $http, $routeParams, $location) {
          $scope.save = function () {
            var obj = {
                ClienteId: $scope.clienteId,
                Nome: $scope.nome,
                Codigo: $scope.codigo,
                Telefone: $scope.telefone,
                CPF: $scope.cpf,
            };
            if ($scope.ClienteId == 0) {
                $http.post('http://localhost:1075/api/clientes/', obj).success(function (data) {
                    $location.path('/list');
                }).error(function (data) {
                    $scope.error = "Erro ao incluir cliente! " + data.ExceptionMessage;
                });
            }
            else {
                $http.put('http://localhost:1075/api/clientes/', obj).success(function (data) {
                    $location.path('/list');
                }).error(function (data) {
                    console.log(data);
                    $scope.error = "Erro ao editar cliente! " + data.ExceptionMessage;
                });
            }
        }
          if ($routeParams.clienteId) {
              $scope.ClienteId = $routeParams.clienteId;
            $scope.title = "Editar Clientes";
            $http.get('http://localhost:1075/api/clientes/' + $routeParams.id).success(function (data) {
                $scope.nome = data.Nome;
                $scope.codigo = data.Codigo;
                $scope.cpf = data.CPF;
                $scope.telefone = data.Telefone;
            });
        }
        else {
            $scope.title = "Novo Cliente";
        }
    }
]);