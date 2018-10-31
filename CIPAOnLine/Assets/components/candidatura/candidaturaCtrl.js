var imgSizeCandidatura = 285;
angular.module('cipaApp').controller('candidaturaCtrl', ['etapasValue', 'sharedDataService', 'usuariosAPI', 'messagesService', 'candidatosAPI', 'eleicoesAPI', '$timeout', '$state', '$q', '$stateParams', '$scope', 'isAllowed', function(etapasValue, sharedDataService, usuariosAPI, messagesService, candidatosAPI, eleicoesAPI, $timeout, $state, $q, $stateParams, $scope, isAllowed) {

	var self = this;
	self.usuario = null;
	self.eleicaoAtual = null;
	self.candidato = null;
	self.labelBotao = "Candidatar-se";
	self.codigoModulo = sharedDataService.getCodigoModulo();
	self.error = null;
	var usuario = sharedDataService.getUsuario();

	var load = function() {
		eleicoesAPI.getEleicao(self.codEleicao)
		.then(function(dado) {
			self.eleicaoAtual = dado.data;
			if (self.eleicaoAtual.CodigoEtapa != etapasValue.ETAPA_CANDIDATURA_CIT && self.eleicaoAtual.CodigoEtapa != etapasValue.ETAPA_CANDIDATURA_CIPA) {
				self.error = 'A eleição está fora do período de candidaturas!';
				return $q.reject('Reject');
			}
			return usuariosAPI.getUsuario(usuario.Login);
		}).then(function(dado) {
			dado.data.DataAdmissao = new Date(dado.data.DataAdmissao);
			self.usuario = dado.data;

			if (self.eleicaoAtual) {
				candidatosAPI.getCandidato(self.usuario.MatriculaFuncionario, self.eleicaoAtual.Codigo)
				.then(function(retorno) {

					if (retorno.data && retorno.data.MotivoReprovacao)
						self.labelBotao = "Recandidatar";
					else if (retorno.data)
						self.labelBotao = "Salvar Alterações";

					self.candidato = retorno.data;

					var preview = $('#fotoCandidatura');

					if (self.candidato.Foto) {
						preview[0].src = "data:image;base64," + self.candidato.Foto;
			   		}

				}, function() {});
			}
		}, function(error) {
			if (error == 'Reject') return;

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


	// ************* COMPARTILHADO *************
	$scope.$emit('activeMenuEvent', {label: 'Candidatura'});
	var stateRedirect = 'navContainer.candidatura';

	self.codigoModulo = sharedDataService.getCodigoModulo();
	self.codEleicao = $stateParams.codEleicao;

	if (self.codEleicao) {
		if (!isAllowed.data)
			self.error = 'Você não está cadastrado nessa eleição!';
		else 
			load();
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



	self.candidatar = function() {
		//exibeLoader();

		var candidato = {
			MatriculaFuncionario: self.usuario.MatriculaFuncionario,
			CodigoEleicao: self.eleicaoAtual.Codigo,
			LoginFuncionario: self.usuario.Login,
			NomeFuncionario: self.usuario.Nome,
			CargoFuncionario: self.usuario.Cargo,
			AreaFuncionario: self.usuario.Area,
			DataAdmissaoFuncionario: self.usuario.DataAdmissao,
			Sobre: self.usuario.Sobre
		};

        if (!$('#fotoCandidatura')[0].src || window.location.href.split('#')[0] == $('#fotoCandidatura')[0].src || $('#fotoCandidatura')[0].src.indexOf('Assets/img/user.png') > 0) {
			//ocultaLoader();
			swal("Inválido!", "Escolha uma foto para se candidatar!", "error");
		} else {

			candidatosAPI.addOrUpdateCandidato(candidato, dataURItoBlob($('#fotoCandidatura')[0].src))
			.done(function (response) {
				//ocultaLoader();
				if (self.labelBotao == "Salvar Alterações") {
					swal("Sucesso!", "Os dados de sua candidatura foram atualizados com sucesso.", "success")
					.then(function() {
						$state.go('navContainer.home');	
					});
				} else {
					if (usuario.Perfil == 'Administrador') {
						swal("Candidatura Realizada!", "Sua candidatura foi realizada com sucesso!", "success")
						.then(function() {
							$state.go('navContainer.home');	
						});
					} else {
						swal("Candidatura Realizada!", "Sua candidatura agora será submetida a uma validação.", "success")
						.then(function() {
							$state.go('navContainer.home');	
						});
					}
				}
				self.labelBotao = "Salvar Alterações";
			}).fail(function(jqXHR, textStatus, errorThrown) {
				//ocultaLoader();
				if (jqXHR && jqXHR.status && jqXHR.responseText) {
					var e = JSON.parse(jqXHR.responseText);
					if (e.Message) {
						swal("Erro ao candidatar (" + jqXHR.status + ")!", e.Message, "error");
					} else {
						messagesService.exibeMensagemErro(jqXHR.status, jqXHR.responseText);
						swal("Erro ao candidatar (" + jqXHR.status + ")!", jqXHR.responseText, "error");
					}
				} else {
					swal("Erro ao candidatar!", "Ocorreu um erro inesperado! Contate o administrador.", "error");
				}

			});
		}

	}

	function dataURItoBlob(dataURI) {
      	var binary = atob(dataURI.split(',')[1]);
      	var mimeString = dataURI.split(',')[0].split(':')[1].split(';')[0];
      	var array = [];
      	for (var i = 0; i < binary.length; i++) {
        	array.push(binary.charCodeAt(i));
      	}

      	return new Blob([new Uint8Array(array)], {
        	type: mimeString
      	});
    }

	
}]);



var previewFile = function(){

   	var preview = $('#fotoCandidatura'); //selects the query named img
   	var file = document.querySelector('input[type=file]').files[0]; //sames as here
   	var reader = new FileReader();

   	reader.onloadend = function (ev) {

   		//Reset o tamanho da imagem
   		// $(preview).css('width', 'initial');
   		// $(preview).css('height', 'initial');

    	preview[0].src = ev.srcElement.result;
    	//Sem o timeout, a função, na maioria das vezes, é executada antes da imagem ser carregada
    	// setTimeout(function() {
    	// 	if ($(preview)[0].height > $(preview)[0].width) {
	   	// 		$(preview).css('width', imgSizeCandidatura + 'px');
	   	// 		$(preview).css('margin-bottom', (($(preview)[0].height - imgSizeCandidatura) / 2) * -1 + 'px');
	   	// 	} else {
	   	// 		$(preview).css('height', imgSizeCandidatura + 'px');
	   	// 		$(preview).css('margin-left', (($(preview)[0].width - imgSizeCandidatura) / 2) * -1 + 'px');
	   	// 	}
    	// }, 10);
    	
   	}

   	if (file) {
    	reader.readAsDataURL(file); //reads the data as a URL
   	} else {
        preview[0].src = "";
   	}
}