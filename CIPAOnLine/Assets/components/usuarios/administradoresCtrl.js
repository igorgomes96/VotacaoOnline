angular.module('cipaApp').controller('administradoresCtrl', ['usuariosAPI', 'sharedDataService', '$scope', function(usuariosAPI, sharedDataService, $scope) {
	var self = this;

	self.editando = false;
	self.novo = false;
	self.administradores = [];

	$scope.$emit('activeMenuEvent', {label: 'Administradores'});

	self.usuario = sharedDataService.getUsuario();

	var loadAdministradores = function() {
		usuariosAPI.getAdministradores()
		.then(function(dado) {
			self.administradores = dado.data;
		}, function(error) {
			if (error.data && error.data.Message) {
				swal("Erro!", error.data.Message, "error");
			} else if (error.data) {
				swal("Erro!", error.data, "error");
			} else {
				swal("Erro!", "Erro ao carregar usuários", "error");
			}
		});
	}

	self.editarNovo = function() {
		self.editando = true;
		self.novo = true;
		self.userSelecionado = null;
	}

	self.editar = function() {
		self.editando = true;
	}

	self.cancelarEdicao = function() {
		self.editando = false;
		self.novo = false;
		self.userSelecionado = null;
	}

	self.salvar = function(usuario) {
		usuariosAPI.postAdministrador(usuario)
		.then(function(dado) {
			loadAdministradores();
			swal("Sucesso!", "Usuário salvo com sucesso!" , "success");
		}, function(error) {
			if (error.data && error.data.Message) {
				swal("Erro!", error.data.Message, "error");
			} else if (error.data) {
				swal("Erro!", error.data, "error");
			} else {
				swal("Erro!", "Erro ao salvar usuário!", "error");
			}
		});
	}

	self.keypressedSenha = function ($event, user) {
        if ($event.which == 13) {
            self.salvar(user);
            self.novoUser = null;
        }
    }

	// self.salvar = function() {
	// 	var func = null;
	// 	if (self.novo)
	// 		func = usuariosAPI.postAdministrador(self.userSelecionado);
	// 	else
	// 		func = usuariosAPI.putAdministrador(self.userSelecionado.Login, self.userSelecionado);

	// 	func.then(function(dado) {
	// 		self.novo = false;
	// 		self.editando = false;
	// 		self.userSelecionado = null;
	// 		loadAdministradores();
	// 		swal("Sucesso!", "Usuário salvo com sucesso!" , "success");
	// 	}, function(error) {
	// 		if (error.data && error.data.Message) {
	// 			swal("Erro!", error.data.Message, "error");
	// 		} else if (error.data) {
	// 			swal("Erro!", error.data, "error");
	// 		} else {
	// 			swal("Erro!", "Erro ao salvar usuário!", "error");
	// 		}
	// 	});
	// }

	self.excluir = function(login) {
		if (login == self.usuario.Login) {
			swal("Inválido!", "Não é permitida a auto-exclusão!", "error");
		} else {
			swal({title: "Confirmar Exclusão?",text: "Essa ação não poderá ser desfeita!",icon: "warning",buttons: true, dangerMode: true,
			}).then(function(willDelete) {
				if (willDelete) {
			  		
					usuariosAPI.deleteAdministrador(login)
					.then(function(dado) {
						swal("Sucesso!", "Acesso de administrador revogado com sucesso!", "success");
						loadAdministradores();
					}, function(error) {
						if (error.data && error.data.Message) {
							swal("Erro!", error.data.Message, "error");
						} else if (error.data) {
							swal("Erro!", error.data, "error");
						} else {
							swal("Erro!", "Erro ao revogar acesso de administrador!", "error");
						}
					});

			  	}
			});
		}
	}

	loadAdministradores();

}]);