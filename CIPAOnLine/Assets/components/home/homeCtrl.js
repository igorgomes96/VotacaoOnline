angular.module('cipaApp').controller('homeCtrl', ['$scope', 'eleicoesAPI', 'sharedDataService', 'etapasValue', function($scope, eleicoesAPI, sharedDataService, etapasValue) {
	
	var self = this;

	self.etapaVotacao = false;
	self.etapaCandidatura = false;
	self.eleicoes = [];
	self.eleicoesFechadas = [];
	self.gestoes = [];
	self.codigoModulo = sharedDataService.getCodigoModulo();

	$scope.$emit('activeMenuEvent', {label: 'Início'});

	var loadEleicoes = function() {
		eleicoesAPI.getEleicoes(self.codigoModulo, true)
		.then(function(dado) {
			dado.data.forEach(function(eleicao) {
				eleicao.PrazosEtapasObj.forEach(function(x) {
					x.DataProposta = new Date(x.DataProposta);
				});
			});
			self.eleicoes = dado.data;
			self.eleicoes.forEach(function(x) {
				x.etapaVotacao = x.CodigoEtapa == etapasValue.ETAPA_VOTACAO_CIPA || x.CodigoEtapa == etapasValue.ETAPA_VOTACAO_CIT;
				x.etapaCandidatura = x.CodigoEtapa == etapasValue.ETAPA_CANDIDATURA_CIT || x.CodigoEtapa == etapasValue.ETAPA_CANDIDATURA_CIPA;
				x.passouEtapaVotacao = x.CodigoEtapa >= etapasValue.ETAPA_VOTACAO_CIT || (x.CodigoEtapa >= etapasValue.ETAPA_VOTACAO_CIPA && x.CodigoEtapa < etapasValue.ETAPA_INICIO_CIT);
				x.passouEtapaCandidatura = x.CodigoEtapa >= etapasValue.ETAPA_CANDIDATURA_CIT || (x.CodigoEtapa >= etapasValue.ETAPA_CANDIDATURA_CIPA && x.CodigoEtapa < etapasValue.ETAPA_INICIO_CIT)
			});

		}, function(error) {
			if (error.status !== 401) { 
				if (error.data && error.data.Message) {
					swal("Erro!", error.data.Message, "error");
				} else if (error.data) {
					swal("Erro!", error.data, "error");
				} else {
					swal("Erro!", "Erro ao carregar eleições!", "error");
				}
			}
		});


	}

	self.carregaEleicoesFechadas = function(modulo) {
		self.eleicoesFechadas = [];
		self.loadGestoes(modulo);
		self.modulo = modulo;
		eleicoesAPI.getEleicoes(modulo, false)
		.then(function(dado) {
			self.eleicoesFechadas = dado.data;
			$('#modalEleicoesFechadas').modal('show');
		}, function(error) {
			if (error.data && error.data.Message) {
				swal("Erro!", error.data.Message, "error");
			} else if (error.data) {
				swal("Erro!", error.data, "error");
			} else {
				swal("Erro!", "Erro ao carregar eleições!", "error");
			}
		});
	}

	self.loadGestoes = function(modulo) {
		eleicoesAPI.getGestoes(modulo)
		.then(function(dado) {
			self.gestoes = dado.data;
		}, function(error) {
			if (error.data && error.data.Message) {
				swal("Erro!", error.data.Message, "error");
			} else if (error.data) {
				swal("Erro!", error.data, "error");
			} else {
				swal("Erro!", "Erro ao carregar eleições!", "error");
			}
		});
	}

	//loadEleicoes();
}]);