angular.module('cipaApp').controller('cadastroFuncionariosCtrl', ['$state', '$scope', 'funcionariosAPI', 'messagesService', 'usuariosAPI', 'eleicoesAPI', '$stateParams', 'gestoresAPI', 'sharedDataService', function ($state, $scope, funcionariosAPI, messagesService, usuariosAPI, eleicoesAPI, $stateParams, gestoresAPI, sharedDataService) {

	var self = this;
	self.atual = null;
	self.novo = false;
	self.editando = false;
	self.perfis = ['Administrador', 'Eleitor'];
	self.inconsistencias = null;
	self.filtro = null;
	self.funcionarios = [];
	self.gestores = [];
	self.editandoGestor = false;
	self.gestorSelecionado = null;
	self.novoGestor = null;
	self.error = null;
	self.pageNumber = 1;
	self.pagination = { Total: 0, PageSize: 200, TotalPages: 0 };
	var preventEvent = false;

	$scope.$watch('filtro', function (newValue) {
		if (newValue !== self.filtro && self.codEleicao) {
			self.filtro = newValue;
			loadFuncionarios();
		}
	});

	var loadPaginationInfo = function () {
		eleicoesAPI.getFuncionariosPaginationInfo(self.codEleicao, self.filtro)
			.then(function (dado) {
				self.pagination = dado.data;
				if (self.pagination.TotalPages < self.pageNumber && self.pagination.TotalPages != 0) {
					self.pageNumber = self.pagination.TotalPages;
					eleicoesAPI.getFuncionarios(self.codEleicao, self.filtro, self.pageNumber)
						.then(function (dado) {
							self.funcionarios = dado.data;
						});
				}
			}, function (error) {
				console.error(error);
			});
	}

	var loadFuncionarios = function () {
		loadPaginationInfo();
		eleicoesAPI.getFuncionarios(self.codEleicao, self.filtro, self.pageNumber)
			.then(function (dado) {
				self.funcionarios = dado.data;
			}, function (error) {
				self.error = (error.Message && error.Message) || error;
				console.log(error);
			});
	}

	self.proximaPagina = function () {
		if (self.pagination.TotalPages > self.pageNumber) {
			self.pageNumber++;
		} else {
			self.pageNumber = 1;
		}
		loadFuncionarios();
	}

	self.paginaAnterior = function () {
		if (self.pageNumber <= 1) {
			self.pageNumber = self.pagination.TotalPages;
		} else {
			self.pageNumber--;
		}
		loadFuncionarios();
	}

	// ************* COMPARTILHADO *************
	$scope.$emit('activeMenuEvent', { label: 'Funcionários' });
	var stateRedirect = 'navContainer.cadastroFuncionario';

	self.codigoModulo = sharedDataService.getCodigoModulo();
	self.codEleicao = $stateParams.codEleicao;

	if (!self.codEleicao) {
		self.codEleicao = sharedDataService.getCodigoEleicao();
		if (self.codEleicao)
			$state.go(stateRedirect, { codEleicao: self.codEleicao }, { reload: true });
	} else {
		loadFuncionarios();
		sharedDataService.setCodigoEleicao(self.codEleicao);
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

		self.gestaoSelecionada = self.unidadeSelecionada.Eleicoes.filter(function (x) {
			return x.Codigo == self.eleicaoAtual.Codigo;
		})[0];
	}

	self.alteraGestao = function () {
		if (self.gestaoSelecionada && self.gestaoSelecionada.Codigo) {
			self.codEleicao = self.gestaoSelecionada.Codigo;
			sharedDataService.setCodigoEleicao(self.gestaoSelecionada.Codigo);
			$state.go(stateRedirect, { codEleicao: self.gestaoSelecionada.Codigo }, { reload: true });
		}
	}

	loadFiltroEleicoes();

	// \************* COMPARTILHADO *************

	self.refreshList = function () {
		loadGestores();
		loadFuncionarios();
	}

	self.editarGestor = function (gestor) {
		self.editandoGestor = true;
		self.novoGestor = gestor;
	}

	self.salvarGestor = function (gestor) {
		gestoresAPI.postGestor(gestor)
			.then(function (dado) {
				self.editandoGestor = false;
				self.novoGestor = null;
				loadGestores();
			}, function (error) {
				if (error.data && error.data.Message)
					swal("Inválido!", error.data.Message, "error");
				else if (error.data)
					swal("Inválido!", error.data, "error");
				else
					swal("Inválido!", error, "error");
			});
	}

	self.deleteGestor = function (codigo) {
		swal({
			title: "Atenção!",
			text: "Você não poderá desfazer essa ação. Confirmar?",
			icon: "warning",
			buttons: { cancel: "Cancelar", confirmar: true },
			dangerMode: true
		}).then(function (value) {
			if (value) {
				gestoresAPI.deleteGestor(codigo)
					.then(function () {
						loadGestores();
					}, function (error) {
						if (error.data && error.data.Message)
							swal("Inválido!", error.data.Message, "error");
						else if (error.data)
							swal("Inválido!", error.data, "error");
						else
							swal("Inválido!", error, "error");
					});
			}
		});
	}


	var loadGestores = function () {
		gestoresAPI.getGestores()
			.then(function (dado) {
				self.gestores = dado.data;
			}, function (error) {
				if (error.data && error.data.Message)
					swal("Inválido!", error.data.Message, "error");
				else if (error.data)
					swal("Inválido!", error.data, "error");
				else
					swal("Inválido!", error, "error");
			});
	}

	self.selecionarGestor = function (codigo) {
		if (!self.atual)
			self.atual = {};
		self.atual.CodigoGestor = codigo;
		self.gestorSelecionado = null;
		$('#modalGestores').modal('hide');
	}

	self.keydownBuscaFuncionario = function (event, busca) {
		if (event.which == 13) {
			self.buscaFuncionario(busca);
		}
	}

	self.removerTodosFuncionarios = function () {
		swal({ title: "Atenção!", text: "Você não poderá desfazer essa ação. Confirmar?", icon: "warning", buttons: { cancel: "Cancelar", confirmar: true }, dangerMode: true })
			.then(function (value) {
				if (value) {
					//$scope.loading = true;
					$('.ibox-content').addClass('sk-loading');
					$scope.$apply();
					eleicoesAPI.deleteTodosFuncionarios(self.codEleicao)
						.then(function () {
							loadFuncionarios();
							swal("Sucesso!", "Funcionários removidos com sucesso!", "success");
						}, function (error) {
							if (error.data && error.data.Message)
								swal("Inválido!", error.data.Message, "error");
							else if (error.data)
								swal("Inválido!", error.data, "error");
							else
								swal("Inválido!", error, "error");
						}).finally(function () {
							//$scope.loading = false;
							$('.ibox-content').removeClass('sk-loading');
						});
				}
			});
	}

	self.removerFuncionario = function (funcionarioId) {
		swal({
			title: "Atenção!",
			text: "Você não poderá desfazer essa ação. Confirmar?",
			icon: "warning",
			buttons: { cancel: "Cancelar", confirmar: true },
			dangerMode: true
		}).then(function (value) {
			if (value) {
				eleicoesAPI.deleteFuncionario(self.codEleicao, funcionarioId)
					.then(function () {
						self.atual = null;
						loadFuncionarios();
						swal("Sucesso!", "Funcionário removido com sucesso!", "success");
					}, function (error) {
						if (error.data && error.data.Message)
							swal("Inválido!", error.data.Message, "error");
						else if (error.data)
							swal("Inválido!", error.data, "error");
						else
							swal("Inválido!", error, "error");
					});
			}
		});
	}

	self.buscaFuncionario = function (matricula) {
		if (self.editando) return;
		funcionariosAPI.getFuncionarioByMatriculaEmpresa(matricula, sharedDataService.getEmpresa())
			.then(function (dado) {
				dado.data.DataAdmissao = new Date(dado.data.DataAdmissao);
				dado.data.DataNascimento = new Date(dado.data.DataNascimento);
				self.atual = dado.data;
			}, function (error) {
				if (error.data && error.data.Message)
					swal("Inválido!", error.data.Message, "error");
				else if (error.data)
					swal("Inválido!", error.data, "error");
				else
					swal("Inválido!", error, "error");
			});
	}


	self.importarFuncionarios = function () {
		$('.ibox-content').addClass('sk-loading');
		funcionariosAPI.importarFuncionarios($('#fileUpload')[0].files[0], self.codEleicao)
			.done(function (response, status, info) {
				if (info.status == 202) {
					self.inconsistencias = {};
					response = JSON.parse(response);
					$('#modalInconsistencias').modal('show');
				} else {
					swal("Sucesso!", 'Funcionários importados com sucesso! Clique em "Atualizar" para ver a lista de funcionário importados.', "success");
					setTimeout(function () {
						loadGestores();
						loadFuncionarios();
					}, 2000);
				}
				$scope.$apply();
			}).fail(function (jqXHR, textStatus, errorThrown) {
				if (jqXHR && jqXHR.status && jqXHR.responseText) {
					var e = JSON.parse(jqXHR.responseText);
					if (e && e.ExceptionMessage) {
						swal("Erro " + jqXHR.status + "!", e.ExceptionMessage, "error");
					} else if (e && e.Message) {
						swal("Erro " + jqXHR.status + "!", e.Message, "error");
					} else {
						swal("Erro " + jqXHR.status + "!", "Erro inesperado!", "error");
					}
				} else {
					swal("Erro!", "Ocorreu um erro inesperado!", "error");
				}
				$scope.$apply();
			}).always(function () {
				$('.ibox-content').removeClass('sk-loading');
			});
	}

	self.editar = function () {
		self.editando = true;
		self.busca = '';
	}

	self.novoFuncionario = function () {
		self.editando = true;
		self.novo = true;
		self.busca = '';
		self.atual = null;
	}

	self.saveAll = function (funcionarios) {
		funcionariosAPI.saveAll(funcionarios)
			.then(function (dado) {
				self.cancelarInconsistencias();
				loadFuncionarios();
				swal("Sucesso!", "Funcionários salvos com sucesso!", "success");
			}, function (error) {
				self.cancelarInconsistencias();
				if (error.data && error.data.Message)
					swal("Erro ao carregar dados!", error.data.Message, "error");
				else if (error.data)
					swal("Erro ao carregar dados!", error.data, "error");
				else
					swal("Inválido!", error, "error");
			});
	}

	self.salvarFuncionario = function (funcionario) {
		//atualizaProperties();

		if (!funcionario.MatriculaFuncionario)
			funcionario.MatriculaFuncionario = funcionario.Login;

		if (self.novo) {
			funcionario.CodigoEmpresa = sharedDataService.getEmpresa();
			console.log(funcionario);
			funcionariosAPI.postFuncionario(funcionario)
				.then(function (dado) {
					removeInconsistenciasPorMatricula(funcionario.MatriculaFuncionario);
					if (!self.inconsistencias) {
						self.cancelarInconsistencias();
					}
					return eleicoesAPI.addFuncionario(self.codEleicao, dado.data.Id);
				}).then(function () {
					swal("Sucesso!", "Funcionário salvo com sucesso!", "success");
					loadFuncionarios();
				}, function (error) {
					console.log(error);
					if (error.data && error.data.Message)
						swal("Erro ao carregar dados!", error.data.Message, "error");
					else if (error.data)
						swal("Erro ao carregar dados!", error.data, "error");
					else
						swal("Inválido!", error, "error");
				});
		}
		else {
			funcionariosAPI.putFuncionario(funcionario.Id, funcionario)
				.then(function () {
					removeInconsistenciasPorMatricula(funcionario.MatriculaFuncionario);
					if (!self.inconsistencias) {
						self.cancelarInconsistencias();
					}
					return eleicoesAPI.addFuncionario(self.codEleicao, funcionario.Id);
				}).then(function () {
					swal("Sucesso!", "Funcionário salvo com sucesso!", "success");
					loadFuncionarios();
				}, function (error) {
					if (error.data && error.data.Message)
						swal("Erro ao carregar dados!", error.data.Message, "error");
					else if (error.data)
						swal("Erro ao carregar dados!", error.data, "error");
					else
						swal("Inválido!", error, "error");
				});
		}

		self.editando = false;
		self.novo = false;
		self.atual = null;
		self.busca = '';

	}

	self.cancelarInconsistencias = function () {
		self.inconsistencias = null;
		$('#modalInconsistencias').modal('hide');
		$('body.modal-open').css('padding-right', '0px');
		$('body').removeClass('modal-open');
		$('.modal-backdrop').remove();
	}

	var removeInconsistenciasPorMatricula = function (matricula) {
		if (self.inconsistencias) {
			var v = self.inconsistencias.atuais.filter(function (x) {
				return x.MatriculaFuncionario == matricula;
			});

			if (v.length > 0)
				self.inconsistencias.atuais.splice(self.inconsistencias.atuais.indexOf(v[0]), 1);

			if (self.inconsistencias.atuais.length <= 0) {
				self.inconsistencias = null;
				return;
			}

			var v = self.inconsistencias.novos.filter(function (x) {
				return x.MatriculaFuncionario == matricula;
			});

			if (v.length > 0)
				self.inconsistencias.novos.splice(self.inconsistencias.novos.indexOf(v[0]), 1);
		}
	}

	self.cancelar = function () {
		self.editando = false;
		self.novo = false;
		self.atual = null;
	}

	$(document).ready(function () {

		$(document).on('change', '#fileUpload', function () {
			var input = $(this);
			var numFiles = input.get(0).files ? input.get(0).files.length : 1;

			if (numFiles) {
				self.importarFuncionarios();
				input.val('');
			}

		});

	});

	//loadFuncionarios();
	loadGestores();



}]);