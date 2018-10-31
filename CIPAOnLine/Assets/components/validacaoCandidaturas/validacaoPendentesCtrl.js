angular.module('cipaApp').controller('validacaoPendentesCtrl', ['$scope', '$state', 'sharedDataService', 'candidatosAPI', 'eleicoesAPI', '$stateParams', function($scope, $state, sharedDataService, candidatosAPI, eleicoesAPI, $stateParams) {

	var self = this;

	self.candidatos = null;
	self.codEleicao = null;
	self.error = null;
	var usuario = sharedDataService.getUsuario();

	var loadCandidatosEleicao = function() {
		candidatosAPI.getCandidatoValidacao(self.codEleicao)
		.then(function(dado) {
			self.candidatos = dado.data;
			self.error = null;
		}, function(error) {
			// swal("Inválido!", error.data, "error");
			self.error =  error.data;
		});
	}



	// ************* COMPARTILHADO *************
	$scope.$emit('activeMenuEvent', {label: 'Validação de Candidaturas'});
	var stateRedirect = 'navContainer.pendente';

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





	self.aprovarCandidatura = function(matricula, codEleicao) {
		candidatosAPI.aprovarCandidatura(matricula, codEleicao)
		.then(function() {
			swal("Sucesso!", "Candidatura Aprovada!", "success")
			.then(function() {
				loadCandidatosEleicao();
			});
		}, function(error) {
			if (error.data && error.data.Message) {
				swal("Erro!", error.data.Message, "error");
			} else if (error.data) {
				swal("Erro!", error.data, "error");
			} else {
				swal("Erro!", "Erro ao validar candidatura!", "error");
			}
		});
	}

	self.reprovarCandidatura = function(matricula, codEleicao, motivo) {
		var reprovacao = {
			CodigoEleicao: codEleicao,
			MatriculaFuncionario: matricula,
			Motivo: motivo
		};

		candidatosAPI.reprovarCandidatura(matricula, codEleicao, reprovacao)
		.then(function() {
			swal("Sucesso!", "Candidatura Reprovada!", "success")
			.then(function() {
				loadCandidatosEleicao();
			});
		}, function(error) {
			if (error.data && error.data.Message) {
				swal("Erro!", error.data.Message, "error");
			} else if (error.data) {
				swal("Erro!", error.data, "error");
			} else {
				swal("Erro!", "Erro ao validar candidatura!", "error");
			}
		});
	}

	self.aprovarTodos = function() {
		swal({title: "Atenção!", text: "Todas as candidaturas serão aprovadas, e você não poderá desfazer essa ação. Deseja confirmar?", icon:"warning", buttons: {cancel: "Cancelar", confirmar: true}, dangerMode:true})
		.then(function(value) {
			if (value) {
				var dados = self.candidatos.map(function(x) {
					return {
						MatriculaFuncionario: x.MatriculaFuncionario,
						CodigoEleicao: x.CodigoEleicao,
						HorarioCandidatura: x.HorarioCandidatura,
						Validado: true
					};
				});
				candidatosAPI.aprovarCandidaturaTodos(dados)
				.then(function() {
					swal("Sucesso!", "Todas as candidaturas foram aprovadas!", "success");
					loadCandidatosEleicao();
				}, function(error) {
					if (error.data && error.data.Message) {
						swal("Erro!", error.data.Message, "error");
					} else if (error.data) {
						swal("Erro!", error.data, "error");
					} else {
						swal("Erro!", "Erro ao validar candidatura!", "error");
					}
				});
			}
		});
	}

	//loadCandidatosEleicao();

}]);