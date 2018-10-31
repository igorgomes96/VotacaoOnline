angular.module('cipaApp').service('sindicatosAPI', ['$http', 'config', function($http, config) {

    var self = this;
    var resource = 'Sindicatos';

    self.getSindicatos = function() {
        return $http({method: 'GET', url:config.baseUrl + resource});
    }

    self.getSindicato = function(id) {
        return $http.get(config.baseUrl + resource + '/' + id);
    }

    self.postSindicato = function(sindicato) {
        return $http.post(config.baseUrl + resource, sindicato);
    }

    self.deleteSindicato = function(id) {
        return $http.delete(config.baseUrl + resource + '/' + id);
    }
}]);