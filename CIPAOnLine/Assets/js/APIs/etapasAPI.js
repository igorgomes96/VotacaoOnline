angular.module('cipaApp').service('etapasAPI', ['$http', 'config', function($http, config) {

    var self = this;
    var resource = 'Etapas';

    self.getEtapas = function(codModulo) {
        return $http({method: 'GET', url:config.baseUrl + resource + '/' + codModulo});
    }

    // self.getEtapa = function(id) {
    //     return $http.get(config.baseUrl + resource + '/' + id);
    // }

    // self.postEtapa = function(etapa) {
    //     return $http.post(config.baseUrl + resource, etapa);
    // }

    // self.putEtapa = function(id, etapa) {
    //     return $http.put(config.baseUrl + resource + '/' + id, etapa);
    // }

    // self.deleteEtapa = function(id) {
    //     return $http.delete(config.baseUrl + resource + '/' + id);
    // }
}]);