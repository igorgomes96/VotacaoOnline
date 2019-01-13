//angular.module('cipaApp', ['uiCpfMaskApp']);

angular.module('cipaApp').controller('autenticacaoCtrl', ['$stateParams', 'autenticacaoAPI', '$rootScope', 'sharedDataService', '$state', 'sessionStorageService', 'autenticacaoAPI', '$window', '$timeout', '$q', function ($stateParams, autenticacaoAPI, $rootScope, sharedDataService, $state, sessionStorageService, autenticacaoAPI, $window, $timeout, $q) {

    var self = this;

    var setErro = function (messageErro) {
        self.erro = messageErro;
        $timeout(function () {
            self.erro = "";
        }, 7000);
    }

    //setErro($stateParams.error);


	self.modulos = [{Codigo: 1, Label: 'CIPA'}, {Codigo: 2, Label: 'Comissão Interna de Trabalhadores'}];
	self.modulo = self.modulos[0].Codigo;

	self.mostraCodigo = false;
    self.mostraLoader = false;
	self.primeiroAcesso = false;
	self.uri = '';
	self.tempUser = null;
	self.admin = null;
	self.cpfNaoEncontrado = false;
	self.matriculaIncorreta = false;

    self.recuperarSenha = function (usuario) {
	    self.mostraLoader = true;
    	if (self.mostraCodigo) {
			autenticacaoAPI.postRecuperarSenha(usuario)
			.then(function(dado) {
	            self.mostraLoader = false;
				swal('Sucesso!', dado.data, 'success');
				$state.go('login');
			}, function(error) {
	            self.mostraLoader = false;
				setErro((error.data && error.data.Message) || error.data ||  error);
				console.log(error);
			});
		} else {

			autenticacaoAPI.postEnviarCodigo(usuario)
			.then(function(dado) {
				self.mostraCodigo = true;
			}, function(error) {
				setErro((error.data && error.data.Message) || error.data ||  error);
				console.log(error);
			}).finally(function() {
	            self.mostraLoader = false;
			});
		}
	}

	self.keypressedSenha = function ($event, user) {
        if ($event.which == 13 && $state.current.name == 'login') {
            self.autentica(user);
        }
    }


    self.validaMatricula = function(matricula) {
    	if (self.tempUser && matricula == self.tempUser.MatriculaFuncionario) {
    		self.matriculaIncorreta = false;
    		self.user.Email = self.tempUser.Email;
    	} else if (matricula){
    		self.user.Email = null;
    		self.matriculaIncorreta = true;
    	}
    }

    self.buscaUsuario = function(login) {
    	//self.matriculaIncorreta = false;
    	if (!login) return;
		autenticacaoAPI.getFuncionario(login)
		.then(function(dado) {
			self.tempUser = dado.data;
			self.loginNaoEncontrado = false;
		}, function(error) {
			self.tempUser = null;
			self.user.MatriculaFuncionario = null;
			self.user.Email = null;
			if (error.status == 404)
				self.loginNaoEncontrado = true;
		});
    }

    self.autentica = function (user) {
        self.mostraLoader = true;
		autenticacaoAPI.postLogin(user)
		.then(function(dado) {

			//Se houver o código do módulo como parâmetro, guarda na seção
			sessionStorageService.saveCodigoModulo(self.modulo);
			sessionStorageService.saveUser(dado.data);
			sharedDataService.setUsuario(dado.data);

			var nextState = sharedDataService.getNextState();
			// if (nextState && nextState != 'login' && nextState != 'cadastro')
			// 	$state.go(nextState);
			// else
            self.mostraLoader = false;
			$rootScope.$broadcast('reloadStatesEvent');
			$state.go('navContainer.home', null, {reload: true});

		}, function(error) {

            self.mostraLoader = false;
			setErro((error.data && error.data.Message) || error.data ||  error);
			console.log(error);
			
		});

	}

	self.cadastrar = function(user) {

		self.mostraLoader = true;
		user.CodigoEmpresa = self.tempUser.CodigoEmpresa;
		autenticacaoAPI.postPrimeiroAcesso(user)
		.then(function(dado) {
			return autenticacaoAPI.postLogin(user);
		}).then(function(dado) {

			//Se houver o código do módulo como parâmetro, guarda na seção
			sessionStorageService.saveCodigoModulo(self.modulo);
			sessionStorageService.saveUser(dado.data);
			sharedDataService.setUsuario(dado.data);

			var nextState = sharedDataService.getNextState();
			// if (nextState && nextState != 'login' && nextState != 'cadastro')
			// 	$state.go(nextState);
			// else
            self.mostraLoader = false;
			$rootScope.$broadcast('reloadStatesEvent');
			$state.go('navContainer.home', null, {reload: true});

		}, function(error) {

            self.mostraLoader = false;
			setErro((error.data && error.data.Message) || error.data ||  error);

		});
	}

}]);