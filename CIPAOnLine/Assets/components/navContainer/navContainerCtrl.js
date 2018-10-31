angular.module('cipaApp').controller('navContainerCtrl', ['stateValue', '$scope', '$state', 'sharedDataService', 'sessionStorageService', 'autenticacaoAPI', function (stateValue, $scope, $state, sharedDataService, sessionStorageService, autenticacaoAPI) {
	
	var self = this;

	self.user = sharedDataService.getUsuario();
	self.perfil = sharedDataService.getPerfil();

	if (!self.user) {
		$state.go('login');
		sharedDataService.setNextState($state.current.name);
		return;
    }


    self.exibeModalSenha = function () {
        $('#modalNovaSenha').modal('show');
    }

    self.alterarSenha = function () {
        autenticacaoAPI.postAlterarSenha(self.novaSenha)
        .then(function () {
            swal('Sucesso!', 'Senha Alterada com Sucesso!', 'success');
            $('#modalNovaSenha').modal('hide');
        }, function (error) {
            swal('Erro!', (error.Message && error.Message.Data) || error.Message || error, 'error');
        });
    }

	var loadStates = function() {
		self.states = stateValue.states[self.perfil];
	}

	self.modoAdministrador = function() {
		sharedDataService.setPerfil('Administrador');
		self.perfil = sharedDataService.getPerfil();
		loadStates();
		$state.go('navContainer.home', null, {reload: true});
	}

	self.modoEleitor = function() {
		sharedDataService.setPerfil('Eleitor');
		self.perfil = sharedDataService.getPerfil();
		loadStates();
		$state.go('navContainer.home', null, {reload: true});
	}

	var activeMenu = function(obj) {
		if (!self.user) return;
		self.states.forEach(function(x) { 
			x.active = false; 
			if (x.children) {
				x.children.forEach(function(y) {
					y.active = false;
				});
			}
		});

		self.states.forEach(function(state) {
			var result = true;
			for (var p in obj) {
				if (state[p] != obj[p]) {
					result = false;
					break;
				}
			}
			if (result) {
				state.active = true;
				return;
			}
		});
	}

	var unbindActiveMenuEvent = $scope.$on('activeMenuEvent', function(ev, data) {
		activeMenu(data);
	});

	var unbindLoadStatesEvent = $scope.$on('reloadStatesEvent', function(ev) {
		loadStates();
	});

	// $scope.$on('$destroy', function() {
	// 	unbindActiveMenuEvent();
	// 	unbindLoadStatesEvent();
	// });

	self.logout = function() {
		sessionStorageService.deleteUser();
		$state.go('login');
	}

	self.redirect = function(state) {
		$state.go(state);
	}

	loadStates();

}]);