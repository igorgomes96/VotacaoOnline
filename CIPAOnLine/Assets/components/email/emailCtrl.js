angular.module('cipaApp').controller('emailCtrl', ['emailsAPI', 'templatesEmailsAPI', 'sharedDataService', '$state', 'eleicoesAPI', '$scope', '$stateParams', function(emailsAPI, templatesEmailsAPI, sharedDataService, $state, eleicoesAPI, $scope, $stateParams) {

	var self = this;
	self.error = null;
	self.templates = null;
	self.template = null;
	self.email = {};
	self.codEleicao = null;
	self.loading = false;

	self.enviar = function(e) {
		self.loading = true;
		var email = angular.copy(e);
		email.Message = $('.summernote').summernote('code');
		email.To = email.To ? email.To.split(';').map(function(x) { return x.trim(); }).filter(function(x) { return x; }).filter(function(x) { return x; }) : [];
		email.Copy = email.Copy ? email.Copy.split(';').map(function(x) { return x.trim(); }).filter(function(x) { return x; }) : [];
		email.Bcc = email.Bcc ? email.Bcc.split(';').map(function(x) { return x.trim(); }).filter(function(x) { return x; }) : [];
		emailsAPI.postEmail(email)
		.then(function(dado) {
			swal('Sucesso!', 'E-mail enviado com sucesso!', 'success');
			if ($stateParams.codTemplate)
				$state.go('navContainer.eleicao', {codEleicao: self.codEleicao});
		}, function(error) {
			self.error = (error.data && error.data.Message) || error.data || error;
		}).finally(function() {
			self.loading = false;
		});
	}

	var loadTemplates = function() {
		templatesEmailsAPI.getTemplatesEmails()
		.then(function(dado) {
			self.templates = dado.data;
			if ($stateParams.codTemplate) {
				var q = self.templates.filter(function(x) {
					return x.Id == $stateParams.codTemplate;
				});
				if (q.length > 0) self.templateClick(q[0]);
			}
			self.error = null;
		}, function(error) {
			self.error = (error.data && error.data.Message) || error.data || error;
		});
	}

	self.templateClick = function(template) {
		self.template = template;
		self.email.Subject = template.Nome;
		$('.summernote').summernote('code', template.Template);
	}

	self.salvarTemplate = function() {
		if (self.template) {
			swal({title: 'Confirmação',
			  text: 'Deseja atualizar o template ou criar um novo?',
			  icon: 'info',
			  buttons: {
			  	atualizar: {
			      text: 'Atualizar',
			      value: 'atualizar',
			    },
			    novo: {
			      text: 'Criar Novo',
			      value: 'novo',
			    },
			    cancel: 'Cancelar'
			  },
			  dangerMode: true,
			})
			.then(function(resposta) {
				if (resposta == 'novo')
					self.salvarNovoTemplate(self.template)
					// $('#modalEmails').modal('show');
				else
					atualizarTemplate(self.template);
			});
		} else {
			self.salvarNovoTemplate(self.template)
		}
	}

	self.deleteTemplate = function(id) {
		templatesEmailsAPI.deleteTemplateEmail(id)
		.then(function(dado) {
			swal('Sucesso!', 'Excluído com sucesso!', 'success');
			loadTemplates();
		}, function(error) {
			error = (error.data && error.data.Message) || error.data || error;
			swal('Erro!', error, 'error');
		});
	}

	self.salvarNovoTemplate = function(template) {
		if (!template) 
			template = {};
		template.Template = $('.summernote').summernote('code');
		template.Nome = self.email.Subject;
		templatesEmailsAPI.postTemplateEmail(template)
		.then(function(dado) {
			swal('Sucesso!', 'Salvo com sucesso!', 'success');
			loadTemplates();
		}, function(error) {
			error = (error.data && error.data.Message) || error.data || error;
			swal('Erro!', error, 'error');
		});
	}

	var atualizarTemplate = function(template) {
		template.Template = $('.summernote').summernote('code');
		template.Nome = self.email.Subject;
		templatesEmailsAPI.putTemplateEmail(template.Id, template)
		.then(function(dado) {
			swal('Sucesso!', 'Salvo com sucesso!', 'success');
		}, function(error) {
			error = (error.data && error.data.Message) || error.data || error;
			swal('Erro!', error, 'error');
		});
	}

	// ************* COMPARTILHADO *************
	$scope.$emit('activeMenuEvent', {label: 'Comunicados'});
	var stateRedirect = 'navContainer.email';

	self.codigoModulo = sharedDataService.getCodigoModulo();
	self.codEleicao = $stateParams.codEleicao;

	if (!self.codEleicao) {
		self.codEleicao = sharedDataService.getCodigoEleicao();
		if (self.codEleicao)
			$state.go(stateRedirect, {codEleicao: self.codEleicao}, {reload: true});
	} else {
		loadTemplates();
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
			//messagesService.exibeMensagemErro(error.status, 'Erro ao carregar os filtros.');
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

	var joinAddresses = function(list) {
		return list.join('; ');
	}

	var splitAddresses = function(addresses) {
		return addresses.split('; ');
	}

	self.removerTodos = function(prop) {
		switch(prop){
			case 'to':
				self.email.To = ""; 
				break;
			case 'copy':
				self.email.Copy = "";
				break;
			case 'cc':
				self.email.Bcc = "";
		}
	} 

	var setAddresess = function(prop, ad) {
		if (!ad || !prop) return;
		if (prop == 'to')
			self.email.To = self.email.To ? self.email.To + '; ' + ad : self.email.To = ad;
		else if (prop == 'copy')
			self.email.Copy = self.email.Copy ? self.email.Copy + '; ' + ad : self.email.Copy = ad;
		else
			self.email.Bcc = self.email.Bcc ? self.email.Bcc + '; ' + ad : self.email.Bcc = ad;
	}

	self.getAllAddresses = function(prop) {
		emailsAPI.getEmailAddressesAll(self.codEleicao)
		.then(function(dado) {
			var ad = joinAddresses(dado.data);
			setAddresess(prop, ad);
		}, function(error) {
			self.error = (error.data && error.data.Message) || error.data || error;
		});
	}

	self.getCandidatosAddresses = function(prop) {
		emailsAPI.getEmailAddressesCandidatos(self.codEleicao)
		.then(function(dado) {
			var ad = joinAddresses(dado.data);
			setAddresess(prop, ad);
		}, function(error) {
			self.error = (error.data && error.data.Message) || error.data || error;
		});
	}

	self.getSindicatoAddress = function(prop) {
		setAddresess(prop, (self.eleicaoAtual && self.eleicaoAtual.SindicatoObj) ? self.eleicaoAtual.SindicatoObj.Email : '');
	}


}]);