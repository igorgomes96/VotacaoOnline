angular.module('cipaApp').controller('eleicoesCtrl', ['eleicoesAPI', 'unidadesAPI', 'messagesService', 'sharedDataService', 'etapasAPI', 'sindicatosAPI', '$stateParams', '$state', '$scope', 'gruposAPI', 'empresasAPI', function (eleicoesAPI, unidadesAPI, messagesService, sharedDataService, etapasAPI, sindicatosAPI, $stateParams, $state, $scope, gruposAPI, empresasAPI) {

	var self = this;
	self.eleicaoAtual = {};
	self.editando = false;
	self.unidades = [];
	self.sindicatos = [];
	self.unidadeSelecionada = null;
	self.sindicatoSelecionado = null;
	self.abaConfirmaEmails = 0;
	self.editandoSindicato = false;
	self.editandoUnidade = false;
	self.empresas = [];
	self.grupos = [];


	var currentState = $state.current.name;

	// ************* COMPARTILHADO *************
	$scope.$emit('activeMenuEvent', { label: 'Eleições' });
	var stateRedirect = 'navContainer.eleicao';

	self.codigoModulo = sharedDataService.getCodigoModulo();
	self.codEleicao = $stateParams.codEleicao;

	if (currentState != 'navContainer.novaEleicao') {
		if (!self.codEleicao) {
			self.codEleicao = sharedDataService.getCodigoEleicao();
			if (self.codEleicao)
				$state.go(stateRedirect, { codEleicao: self.codEleicao }, { reload: true });
		} else {
			sharedDataService.setCodigoEleicao(self.codEleicao);
		}
	}

	self.statusSelecionado = null;
	self.unidadeSelecionada = null;
	self.gestaoSelecionada = null;
	self.eleicoesFiltro = [];

	var loadFiltroEleicoes = function () {
		eleicoesAPI.getFiltrosEleicoes(self.codigoModulo)
			.then(function (dado) {
				self.eleicoesFiltro = dado.data;
				if (self.codEleicao) {
					var eleicao = findEleicao(self.codEleicao);
					if (eleicao)
						setEleicaoAtual(eleicao);
				}
			}, function (error) {
				messagesService.exibeMensagemErro(error.status, 'Erro ao carregar os filtros.');
			});
	}

	var findEleicao = function (codigo) {
		var eleicoes = null;

		self.eleicoesFiltro.some(function (status) {
			status.Unidades.some(function (unidade) {
				eleicoes = unidade.Eleicoes.filter(function (eleicao) {
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

	var setEleicaoAtual = function (eleicao) {
		eleicao.PrazosEtapasObj.forEach(function (x) {
			x.DataProposta = new Date(x.DataProposta);
		});
		self.eleicaoAtual = eleicao;
		updateFilter();
	}

	var updateFilter = function () {
		self.statusSelecionado = self.eleicoesFiltro.filter(function (x) {
			return (x.Label == 'Abertas' && !self.eleicaoAtual.DataFechamento) || (x.Label == 'Fechadas' && self.eleicaoAtual.DataFechamento);
		})[0];

		self.unidadeSelecionada = self.statusSelecionado.Unidades.filter(function (x) {
			return x.Unidade.Codigo == self.eleicaoAtual.CodigoUnidade;
		})[0];

		if (self.unidadeSelecionada) {
			self.gestaoSelecionada = self.unidadeSelecionada.Eleicoes.filter(function (x) {
				return x.Codigo == self.eleicaoAtual.Codigo;
			})[0];
		}
	}

	self.alteraGestao = function () {
		if (self.gestaoSelecionada && self.gestaoSelecionada.Codigo) {
			sharedDataService.setCodigoEleicao(self.gestaoSelecionada.Codigo);
			$state.go(stateRedirect, { codEleicao: self.gestaoSelecionada.Codigo }, { reload: true });
			self.codEleicao = self.gestaoSelecionada.Codigo;
		}
	}

	loadFiltroEleicoes();


	// \************* COMPARTILHADO *************

	self.novaEleicao = function () {
		$state.go('navContainer.novaEleicao');
	}

	self.clicaAba = function (index) {
		self.email = self.emails[index];
		self.abaConfirmaEmails = index;
	}

	var loadEtapas = function () {
		etapasAPI.getEtapas(self.codigoModulo)
			.then(function (dado) {
				self.etapas = dado.data;
				if (currentState == 'navContainer.novaEleicao')
					self.cadastrarNova();
			});
	}

	var loadSindicatos = function () {
		sindicatosAPI.getSindicatos()
			.then(function (dado) {
				self.sindicatos = dado.data;
			}, function (error) {
				messagesService.exibeMensagemErro(error.status, 'Erro ao carregar os sindicatos.');
			});
	}

	var loadEmpresas = function () {
		empresasAPI.getEmpresas()
			.then(function (dado) {
				self.empresas = dado.data;
			}, function (error) {
				messagesService.exibeMensagemErro(error.status, 'Erro ao carregar as empresas.');
			});
	}

	self.salvarEleicao = function (eleicao) {
		eleicao.CodigoModulo = self.codigoModulo;
		eleicoesAPI.postEleicao(eleicao)
			.then(function (dado) {
				self.editando = false;
				sharedDataService.setCodigoEleicao(dado.data.Codigo);
				swal("Sucesso!", "A eleição foi aberta com sucesso!", "success")
					.then(function () {
						$scope.$emit('novaEleicao', dado.data.Codigo);
						$state.go('navContainer.eleicoes', { codEleicao: dado.data.Codigo });
					});
			}, function (error) {
				if (error.status === 500) {
					swal("Erro ao salvar dados!", "Ocorreu um erro desconhecido ao salvar a eleição! Contate o suporte.", "error");
				} else if (error.data && error.data.Message)
					swal("Erro ao salvar dados!", error.data.Message, "error");
				else if (error.data)
					swal("Erro ao salvar dados!", error.data, "error");
				else
					swal("Inválido!", error, "error");
			});
	}

	self.statusEtapa = function(etapa) {
		if (self.eleicaoAtual) {
			if (self.eleicaoAtual.DataFechamento || (self.eleicaoAtual.OrdemEtapa > etapa.Ordem))
				return 'finalizada';
			if (etapa.CodigoEtapa == self.eleicaoAtual.CodigoEtapa)
				return 'atual';
			return 'futura';
		}
	}

	var loadUnidades = function () {
		unidadesAPI.getUnidades()
			.then(function (dado) {
				self.unidades = dado.data;
			}, function (error) {
				messagesService.exibeMensagemErro(error.status, 'Erro ao carregar as unidades.');
			});
	}

	self.deleteSindicato = function (codigo) {
		sindicatosAPI.deleteSindicato(codigo)
			.then(function () {
				swal("Sucesso!", "Sindicato excluído da base!", "success");
				loadSindicatos();
			}, function (error) {
				if (error.data && error.data.Message)
					swal("Erro ao carregar dados!", error.data.Message, "error");
				else if (error.data)
					swal("Erro ao carregar dados!", error.data, "error");
				else
					swal("Inválido!", error, "error");
			});
	}

	self.deleteUnidade = function (codigo) {
		unidadesAPI.deleteUnidade(codigo)
			.then(function () {
				swal("Sucesso!", "Unidade excluída da base!", "success");
				loadUnidades();
			}, function (error) {
				if (error.data && error.data.Message)
					swal("Erro ao carregar dados!", error.data.Message, "error");
				else if (error.data)
					swal("Erro ao carregar dados!", error.data, "error");
				else
					swal("Inválido!", error, "error");
			});
	}

	self.buscaUnidadeEnter = function (ev, codigo) {
		if (ev.which == 13) {
			self.buscaUnidade(codigo);
		}
	}

	var loadGrupos = function () {
		gruposAPI.getGrupos()
			.then(function (dado) {
				self.grupos = dado.data;
			}, function (error) {
				if (error.data && error.data.Message)
					swal("Erro ao carregar dados!", error.data.Message, "error");
				else if (error.data)
					swal("Erro ao carregar dados!", error.data, "error");
				else
					swal("Inválido!", error, "error");
			});
	}

	self.buscaSindicatoEnter = function (ev, codigo) {
		if (ev.which == 13) {
			self.buscaSindicato(codigo);
		}
	}

	self.buscaUnidade = function (codigo) {
		unidadesAPI.getUnidade(codigo)
			.then(function (dado) {
				self.eleicaoAtual.UnidadeObj = dado.data;
			}, function (error) {
				if (error.status == 404)
					swal("Erro ao buscar unidade!", "Unidade não encontrada!", "error");
				else if (error.data && error.data.Message)
					swal("Erro ao carregar dados!", error.data.Message, "error");
				else if (error.data)
					swal("Erro ao carregar dados!", error.data, "error");
				else
					swal("Inválido!", error, "error");
			});
	}

	self.buscaSindicato = function (codigo) {
		sindicatosAPI.getSindicato(codigo)
			.then(function (dado) {
				self.eleicaoAtual.SindicatoObj = dado.data;
			}, function (error) {
				if (error.status == 404)
					swal("Erro ao buscar Sindicato!", "Sindicato não encontrado!", "error");
				else if (error.data && error.data.Message)
					swal("Erro ao carregar dados!", error.data.Message, "error");
				else if (error.data)
					swal("Erro ao carregar dados!", error.data, "error");
				else
					swal("Inválido!", error, "error");

			});
	}

	self.selecionarUnidade = function (unidade) {
		self.eleicaoAtual.UnidadeObj = unidade;
		self.eleicaoAtual.CodigoUnidade = unidade.Codigo;
		self.unidadeSelecionada = null;
		if (currentState == 'navContainer.eleicao')
			eleicoesAPI.putEleicao(self.eleicaoAtual);
		$('#modalUnidade').modal('hide');
	}

	self.selecionarUnidadeTabela = function (unidade) {
		self.unidadeSelecionada = unidade;
	}

	self.removerSindicato = function () {
		self.eleicaoAtual.CodigoSindicato = null;
		self.eleicaoAtual.SindicatoObj = null;
		if (currentState == 'navContainer.eleicao')
			eleicoesAPI.putEleicao(self.eleicaoAtual);
		$('#modalSindicato').modal('hide');
	}

	self.selecionarSindicato = function (sindicato) {
		self.eleicaoAtual.SindicatoObj = sindicato;
		self.eleicaoAtual.CodigoSindicato = sindicato.Codigo;
		self.sindicatoSelecionada = null;
		if (currentState == 'navContainer.eleicao')
			eleicoesAPI.putEleicao(self.eleicaoAtual);
		$('#modalSindicato').modal('hide');
	}

	self.selecionarSindicatoTabela = function (sindicato) {
		self.sindicatoSelecionado = sindicato;
	}

	self.setProximaEtapa = function (codigo) {
		swal({ title: "Atenção!", text: "Você não poderá voltar a essa etapa após a confirmação. Deseja confirmar?", icon: "warning", buttons: { cancel: "Cancelar", confirmar: true }, dangerMode: true })
			.then(function (value) {
				if (value) {
					eleicoesAPI.setProximaEtapa(codigo)
						.then(function (dado) {

							loadFiltroEleicoes();
							setEleicaoAtual(dado.data);
							if (self.eleicaoAtual.DataFechamento) {
								swal("Sucesso!", "A eleição foi finalizada!", "success")
									.then(function () {
										$state.go('navContainer.home');
									});
							}

							var q = self.eleicaoAtual.PrazosEtapasObj.filter(function (x) {
								return x.CodigoEtapa == self.eleicaoAtual.CodigoEtapa;
							});

							if (q.length > 0 && q[0].CodigoTemplate) {
								var etapaAtual = q[0];
								$state.go('navContainer.email', { codEleicao: self.eleicaoAtual.Codigo, codTemplate: etapaAtual.CodigoTemplate })
							}

						}, function (error) {
							if (error.data && error.data.Message)
								swal("Inválido!", error.data.Message, "error");
							else if (error.data)
								swal("Inválido!", error.data, "error");
							else
								swal("Inválido!", error, "error");

							var eleicao = findEleicao(self.codEleicao);
							if (eleicao)
								setEleicaoAtual(eleicao);

						});
				}
			});

	}

	self.enviaConfirmacao = function (eleicaoCod, emails) {
		emails.forEach(function (x) {
			x.To = x.ToJoined ? x.ToJoined.split(';') : [];
			x.Copy = x.CopyJoined ? x.CopyJoined.split(';') : [];
		});

		eleicoesAPI.setProximaEtapaConfirmaEmails(eleicaoCod, emails)
			.then(function (dado) {
				$('#modalConfirmaEmails').modal('hide');
				dado.data.PrazosEtapasObj.forEach(function (x) {
					x.DataProposta = new Date(x.DataProposta);
				});
				self.eleicaoAtual = dado.data;
				if (self.eleicaoAtual.DataFechamento) {
					swal("Sucesso!", "A eleição foi finalizada!", "success");
					self.eleicaoAtual = null;
				}
				//$scope.$emit('alteracaoEtapaEleicao', dado.data.CodigoEtapa);
			}, function (error) {
				if (error.data && error.data.Message)
					swal("Erro ao carregar dados!", error.data.Message, "error");
				else if (error.data)
					swal("Erro ao carregar dados!", error.data, "error");
				else
					swal("Inválido!", error, "error");
			});
	}

	self.cadastrarNova = function () {
		self.editando = true;
		var data = new Date();
		self.eleicaoAtual = {
			DataInicio: data,
			Gestao: (data.getYear() + 1900) + ' - ' + (data.getYear() + 1901),
			PrazosEtapasObj: angular.copy(self.etapas)
		};

		var acumulado = 0;
		self.eleicaoAtual.PrazosEtapasObj.forEach(function (x) {
			x.DataProposta = addDays(new Date(), acumulado);
			acumulado += x.DiasPrazo;
		});
	}

	self.cancelar = function () {
		$state.go('navContainer.home');
	}

	self.editarSindicato = function (sindicato) {
		self.editandoSindicato = true;
		self.novoSindicato = sindicato;
	}

	self.editarUnidade = function (unidade) {
		self.editandoUnidade = true;
		self.novaUnidade = unidade;
	}

	self.salvarUnidade = function (unidade) {
		unidadesAPI.postUnidade(unidade)
			.then(function (dado) {
				self.eleicaoAtual.CodigoUnidade = dado.data.Codigo;
				self.eleicaoAtual.UnidadeObj = dado.data;
				self.editandoUnidade = false;
				self.novaUnidade = null;
				return unidadesAPI.getUnidades();
			}).then(function (dado) {
				self.unidades = dado.data;
			}, function (error) {
				if (error.data && error.data.Message)
					swal("Erro ao carregar dados!", error.data.Message, "error");
				else if (error.data)
					swal("Erro ao carregar dados!", error.data, "error");
				else
					swal("Inválido!", error, "error");
			});
	}

	self.salvarSindicato = function (sindicato) {
		sindicatosAPI.postSindicato(sindicato)
			.then(function (dado) {
				self.eleicaoAtual.CodigoSindicato = dado.data.Codigo;
				self.eleicaoAtual.SindicatoObj = dado.data;
				self.editandoSindicato = false;
				self.novoSindicato = null;
				return sindicatosAPI.getSindicatos();
			}).then(function (dado) {
				self.sindicatos = dado.data;
			}, function (error) {
				if (error.data && error.data.Message)
					swal("Erro ao carregar dados!", error.data.Message, "error");
				else if (error.data)
					swal("Erro ao carregar dados!", error.data, "error");
				else
					swal("Inválido!", error, "error");
			});
	}

	self.salvarPrazoEtapa = function (prazo) {
		if (!prazo.DataProposta) {
			swal("Inválido!", "Informe uma data válida!", "error");
			loadEleicao(self.codEleicao);
			return;
		}

		eleicoesAPI.putPrazoEtapa(self.eleicaoAtual.Codigo, prazo)
			.then(function () { }, function (error) {
				if (error.data && error.data.Message)
					swal("Erro ao atualizar Cronograma!", error.data.Message, "error");
				else if (error.data)
					swal("Erro ao atualizar Cronograma!", error.data, "error");
				else
					swal("Erro!", error, "error");

				loadEleicao(self.codEleicao);
			});
	}

	loadEtapas();

	// if (self.codEleicao) 
	// loadEleicao(self.codEleicao);

	loadUnidades();
	loadSindicatos();
	loadGrupos();
	loadEmpresas();
	//loadFiltroEleicoes();


}]);