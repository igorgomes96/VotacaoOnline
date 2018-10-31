angular.module('cipaApp').service('unidadesAPI', ['$http', 'config', function($http, config) {

    var self = this;
    var resource = 'Unidades';

    self.getUnidades = function() {
        return $http({method: 'GET', url:config.baseUrl + resource});
    }

    self.getUnidade = function(id) {
        return $http.get(config.baseUrl + resource + '/' + id);
    }

    self.postUnidade = function(unidade) {
        return $http.post(config.baseUrl + resource, unidade);
    }

    self.deleteUnidade = function(id) {
        return $http.delete(config.baseUrl + resource + '/' + id);
    }
}]);