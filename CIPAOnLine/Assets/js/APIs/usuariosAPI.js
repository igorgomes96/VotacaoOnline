angular.module('cipaApp').service('usuariosAPI', ['$http', 'config', function($http, config) {

    var self = this;
    var resource = 'Usuarios';

    self.getUsuario = function(id) {
        return $http.get(config.baseUrl + resource + '?login=' + id);
    }

    self.getAdministradores = function() {
    	return $http.get(config.baseUrl + resource + '/Administradores');
    }

    self.postAdministrador = function(user) {
        return $http.post(config.baseUrl + resource + '/Administradores', user);
    }

    self.postPermissaoEmpresa = function(login, empresa) {
        return $http.post(config.baseUrl + resource + '/Empresa/' + empresa, { Login: login });
    }

    self.deleteUsuario = function(login) {
        return $http.delete(config.baseUrl + resource + '?login=' + login);
    }

    self.deleteAdministrador = function (login) {
        return $http.delete(config.baseUrl + resource + '/Administradores?login=' + login);
    }


}]);