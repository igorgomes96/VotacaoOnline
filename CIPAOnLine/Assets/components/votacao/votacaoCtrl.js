angular.module('cipaApp').controller('votacaoCtrl', ['votosBrancosAPI', '$scope', 'candidatosAPI', 'eleicoesAPI', 'sharedDataService', 'votosAPI', '$state', 'funcionariosAPI', '$stateParams', 'isAllowed', function(votosBrancosAPI, $scope, candidatosAPI, eleicoesAPI, sharedDataService, votosAPI, $state, funcionariosAPI, $stateParams, isAllowed) {
	var self = this;

	self.codEleicao = null;
	self.candidatos = null;
	self.error = null;
	var usuario = sharedDataService.getUsuario();
	

	var loadCandidatosEleicaoAtual = function() {
		candidatosAPI.getCandidatosVotos(self.codEleicao)
		.then(function(dado) {
			self.error = null;
			self.candidatos = dado.data;
		}, function(error) {
			self.error = error.data;
		});
	}


	// ************* COMPARTILHADO *************
	$scope.$emit('activeMenuEvent', {label: 'Votação'});
	var stateRedirect = 'navContainer.votacao';

	self.codigoModulo = sharedDataService.getCodigoModulo();
	self.codEleicao = $stateParams.codEleicao;

	if (self.codEleicao) {
		if (!isAllowed.data)
			self.error = 'Você não está cadastrado nessa eleição!';
		else 
			loadCandidatosEleicaoAtual();
		sharedDataService.setCodigoEleicao(self.codEleicao);
	} else {
		eleicoesAPI.getEleicaoCorrente(self.codigoModulo)
		.then(function(dado) {
			if (dado.data.length <= 0)
				self.error = 'Você não está cadastrado em nenhuma eleição aberta!';
			else
				$state.go(stateRedirect, {codEleicao: dado.data.Codigo}, {reload: true});
		}, function(error) {
			if (error.data && error.data.Message)
				swal("Erro ao carregar dados!", error.data.Message, "error");
			else if(error.data) 
				swal("Erro ao carregar dados!", error.data, "error");
			else {
				swal("Inválido!", error, "error")
				.then(function() {
					$state.go('navContainer.home');	
				});
			}
		});
	}

	// \************* COMPARTILHADO *************



	self.votoBranco = function() {
		swal({title: "Atenção!", text: "Você não poderá anular seu voto posteriarmente. Deseja confirmar?", icon:"warning", buttons: {cancel: "Cancelar", confirmar: true}, dangerMode:true})
		.then(function(value) {
			if (value) {

				var voto = {
					FuncionarioIdEleitor: usuario.FuncionarioId,
					CodigoEleicao: self.codEleicao
				}

				votosBrancosAPI.postVotoBranco(voto)
				.then(function() {
					swal("Sucesso!", "Seu voto foi registrado com sucesso.", "success")
					.then(function() {
						$state.go('navContainer.home');
					});
				}, function(error) {
					if (error.data && error.data.Message)
						swal("Erro ao registrar Voto!", error.data.Message, "error");
					else if(error.data) 
						swal("Erro ao registrar Voto!", error.data, "error");
					else
						swal("Erro ao registrar Voto!", "Error: " + error.status + ". Contate o administrador.", "error");
				});
			}
		});

	}


	self.votar = function(candidato) {

		swal({title: "Atenção!", text: "Você não poderá anular seu voto posteriarmente. Deseja confirmar?", icon:"warning", buttons: {cancel: "Cancelar", confirmar: true}, dangerMode:true})
		.then(function(value) {
			if (value) {
				var voto = {
					FuncionarioIdEleitor: usuario.FuncionarioId,
					FuncionarioIdCandidato: candidato.Id,
					CodigoEleicao: candidato.CodigoEleicao
				}

				votosAPI.postVoto(voto)
				.then(function() {
					swal("Sucesso!", "Seu voto foi registrado com sucesso.", "success")
					.then(function() {
						$state.go('navContainer.home');
					});
				}, function(error) {
					if (error.data && error.data.Message)
						swal("Erro ao registrar Voto!", error.data.Message, "error");
					else if(error.data) 
						swal("Erro ao registrar Voto!", error.data, "error");
					else
						swal("Erro ao registrar Voto!", "Error: " + error.status + ". Contate o administrador.", "error");
				});
			}
		});

	}

	//loadCandidatosEleicaoAtual();


}]);