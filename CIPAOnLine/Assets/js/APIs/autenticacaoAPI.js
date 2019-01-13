angular.module('cipaApp').service('autenticacaoAPI', ['$http', 'config', function($http, config) {

	this.postLogin = function(user) {
		return $http.post(config.baseUrl + 'Autenticacao/Login', user);
	}

	this.postPrimeiroAcesso = function(user) {
		return $http.post(config.baseUrl + 'Autenticacao/PrimeiroAcesso', user);
	}

	this.postRecuperarSenha = function(usuario) {
		return $http.post(config.baseUrl + 'Autenticacao/RecuperarSenha', usuario);
    }

    this.postEnviarCodigo = function(usuario) {
		return $http.post(config.baseUrl + 'Autenticacao/EnviarCodigo', usuario);
    }

    this.postAlterarSenha = function (usuario) {
        return $http.post(config.baseUrl + 'Autenticacao/AlterarSenha', usuario);
    }

	this.getFuncionario = function(login) {
        return $http.post(config.baseUrl + 'findbylogin', { login: login });
    }


}]);