angular.module('cipaApp').service('gestoresAPI', ['$http', 'config', function($http, config) {

	var self = this;
	var resource = 'Gestores';

    self.getGestores = function(codModulo) {
        return $http({method: 'GET', url:config.baseUrl + resource});
    }

    self.getGestor = function(id) {
        return $http.get(config.baseUrl + resource + '/' + id);
    }

    self.postGestor = function(gestor) {
        return $http.post(config.baseUrl + resource, gestor);
    }

    self.putGestor = function(id, gestor) {
        return $http.put(config.baseUrl + resource + '/' + id, gestor);
    }

    self.deleteGestor = function(id) {
        return $http.delete(config.baseUrl + resource + '/' + id);
    }

}]);