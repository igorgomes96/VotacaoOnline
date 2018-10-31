angular.module('cipaApp').controller('validacaoReprovadosCtrl', ['$scope', '$state', 'eleicoesAPI', 'sharedDataService', 'candidatosAPI', '$stateParams', function($scope, $state, eleicoesAPI, sharedDataService, candidatosAPI, $stateParams) {

	var self = this;

	self.candidatos = null;
	self.codEleicao = null;
	self.error = null;

	var loadCandidatosEleicao = function() {
		candidatosAPI.getCandidatoValidacao(self.codEleicao, false)
		.then(function(dado) {
			self.error = null;
			self.candidatos = dado.data;
		}, function(error) {
			// swal("Inválido!", error.data, "error");
			self.error = error.data;
		});
	}



	// ************* COMPARTILHADO *************
	$scope.$emit('activeMenuEvent', {label: 'Validação de Candidaturas'});
	var stateRedirect = 'navContainer.reprovado';

	self.codigoModulo = sharedDataService.getCodigoModulo();
	self.codEleicao = $stateParams.codEleicao;

	if (!self.codEleicao) {
		self.codEleicao = sharedDataService.getCodigoEleicao();
		if (self.codEleicao)
			$state.go(stateRedirect, {codEleicao: self.codEleicao}, {reload: true});
	} else {
		loadCandidatosEleicao();
		sharedDataService.setCodigoEleicao(self.codEleicao);
	}

	self.statusSelecionado = null;
	self.unidadeSelecionada = null;
	self.gestaoSelecionada = null;
	self.eleicoesFiltro = [];

	var loadFiltroEleicoes = function() {
		eleicoesAPI.getFiltrosEleicoes(self.codigoModulo)
		.then(function(dado) {
			self.eleicoesFiltro = dado.data;
			if (self.codEleicao) {
				var eleicao = findEleicao(self.codEleicao);
				if (eleicao)
					setEleicaoAtual(eleicao);
			}
		}, function(error) {
			messagesService.exibeMensagemErro(error.status, 'Erro ao carregar os filtros.');
		});
	}

	var findEleicao = function(codigo) {
		var eleicoes = null;

		self.eleicoesFiltro.some(function(status) {
			status.Unidades.some(function(unidade) {
				eleicoes = unidade.Eleicoes.filter(function(eleicao) {
					return eleicao.Codigo == codigo;
				});
				if (eleicoes && eleicoes.length) 
					return true; 
				return false;
			});
			if (eleicoes && eleicoes.length) 
				return true;
			return false;
		});

		if (eleicoes && eleicoes.length) 
			return eleicoes[0];
		return null;
	}

	var setEleicaoAtual = function(eleicao) {
		eleicao.PrazosEtapasObj.forEach(function(x) {
			x.DataProposta = new Date(x.DataProposta);
		});
		self.eleicaoAtual = eleicao;
		updateFilter();
	}

	var updateFilter = function() {
		self.statusSelecionado = self.eleicoesFiltro.filter(function(x) {
			return (x.Label == 'Abertas' && !self.eleicaoAtual.DataFechamento) || (x.Label == 'Fechadas' && self.eleicaoAtual.DataFechamento);
		})[0];

		self.unidadeSelecionada = self.statusSelecionado.Unidades.filter(function(x) {
			return x.Unidade.Codigo == self.eleicaoAtual.CodigoUnidade;
		})[0];

		self.gestaoSelecionada = self.unidadeSelecionada.Eleicoes.filter(function(x) {
			return x.Codigo == self.eleicaoAtual.Codigo;
		})[0];
	}

	self.alteraGestao = function() {
		if (self.gestaoSelecionada && self.gestaoSelecionada.Codigo) {
			self.codEleicao = self.gestaoSelecionada.Codigo;
			sharedDataService.setCodigoEleicao(self.gestaoSelecionada.Codigo);
			$state.go(stateRedirect, {codEleicao: self.gestaoSelecionada.Codigo}, {reload: true});
		}
	}

	loadFiltroEleicoes();

	// \************* COMPARTILHADO *************
}]);