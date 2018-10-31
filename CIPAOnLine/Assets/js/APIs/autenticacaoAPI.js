angular.module('cipaApp').service('autenticacaoAPI', ['$http', 'config', function($http, config) {

	this.postLogin = function(user) {
		return $http.post(config.baseUrl + 'Autentica', user);
	}

	this.postLoginAdmin = function(user) {
		return $http.post(config.baseUrl + 'Autentica/Admin', user);
	}

	this.postPrimeiroAcesso = function(user) {
		return $http.post(config.baseUrl + 'Autenticacao/PrimeiroAcesso', user);
	}

	this.postLogout = function() {
		return $http.post(config.baseUrl + 'Logout');
	}

	this.postRecuperarSenha = function(usuario) {
		return $http.post(config.baseUrl + 'RecuperarSenha', usuario);
    }

    this.postAlterarSenha = function (usuario) {
        return $http.post(config.baseUrl + 'AlterarSenha', usuario);
    }

	this.postNovaSenhaAdmin = function(novaSenha) {
		return $http.post(config.baseUrl + 'Autentica/Administradores/NovaSenha', novaSenha);
	}

	this.getFuncionario = function(cpf) {
        return $http.get(config.baseUrl + 'Funcionarios/CPF/' + cpf);
    }


}]);