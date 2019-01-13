angular.module('cipaApp').service('sessionStorageService', ['$window', function($window) {
	var self = this;
	
	self.saveUser = function(user) {
		$window.sessionStorage.setItem('user', JSON.stringify(user));
	}

	self.getUser = function() {
		var temp = $window.sessionStorage.getItem('user');
		if (temp) temp = JSON.parse(temp);
		return temp; 
	}

	self.deleteUser = function() {
		$window.sessionStorage.removeItem('user');
	}

	self.saveCodigoModulo = function(codigo) {
		$window.sessionStorage.setItem('codModulo', codigo);
	}

	self.getCodigoModulo = function() {
		return $window.sessionStorage.getItem('codModulo');
	}

	self.deleteCodigoModulo = function() {
		$window.sessionStorage.removeItem('codModulo');
	}


	self.savePerfil = function(perfil) {
		$window.sessionStorage.setItem('perfil', perfil);
	}

	self.getPerfil = function() {
		return $window.sessionStorage.getItem('perfil');
	}

	self.saveEmpresa = function(empresa) {
		$window.sessionStorage.setItem('empresa', empresa);
	}

	self.getEmpresa = function() {
		return $window.sessionStorage.getItem('empresa');
	}



}]);