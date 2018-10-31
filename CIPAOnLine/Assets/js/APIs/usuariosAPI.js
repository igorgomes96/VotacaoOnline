angular.module('cipaApp').service('usuariosAPI', ['$http', 'config', function($http, config) {

    var self = this;
    var resource = 'Usuarios';

    self.getUsuarios = function(matriculaFuncionario) {
        return $http({method: 'GET', url:config.baseUrl + resource, params:{matriculaFuncionario:matriculaFuncionario}});
    }

    self.getUsuario = function(id) {
        return $http.get(config.baseUrl + resource + '/' + id);
    }

    self.getAdministradores = function() {
    	return $http.get(config.baseUrl + resource + '/Administradores');
    }

    self.postAdministrador = function(user) {
        return $http.post(config.baseUrl + resource + '/Administradores', user);
    }

    self.deleteUsuario = function(cpf) {
        return $http.delete(config.baseUrl + resource + '/' + cpf);
    }

    self.deleteAdministrador = function (cpf) {
        return $http.delete(config.baseUrl + resource + '/Administradores/' + cpf);
    }


}]);