angular.module('cipaApp').controller('administradoresCtrl', ['usuariosAPI', 'sharedDataService', '$scope', 'empresasAPI', 'funcionariosAPI', function(usuariosAPI, sharedDataService, $scope, empresasAPI, funcionariosAPI) {
	var self = this;

	self.administradores = [];
	self.empresas = [];
	self.admin = null;
	self.buscandoUsuario = false;
	self.form = null;

	$scope.$emit('activeMenuEvent', {label: 'Administradores'});

	self.usuario = sharedDataService.getUsuario();

	var loadAdministradores = function() {
		usuariosAPI.getAdministradores()
		.then(function(dado) {
			self.administradores = dado.data.filter(function(a) {
				return a.Login !== 'admin' && a.Login !== self.usuario.Login; 
            });
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

	var updateChekEmpresas = function(user) {
		self.empresas.forEach(function(empresa) {
			if (user.Empresas.some(function(e) { return e.Codigo === empresa.Codigo; })) {
				empresa['selecionado'] = true;
			} else {
				empresa['selecionado'] = false;
			}
		});
	}

	self.editar = function(user) {
		self.admin = user;
		updateChekEmpresas(self.admin);

		funcionariosAPI.getFuncionarioByLogin(self.admin.Login)
		.then(function(dado) {
			self.admin.MatriculaFuncionario = dado.data.MatriculaFuncionario;
			self.admin.Email = dado.data.Email;
			self.admin.CodigoEmpresa = dado.data.CodigoEmpresa;
		});

	}

	self.buscaUsuario = function(usuario) {
		if (!usuario || usuario === 'admin') return;
		self.buscandoUsuario = true;

		usuariosAPI.getUsuario(usuario)
		.then(function(dado) {
			self.admin = dado.data;
			updateChekEmpresas(self.admin);
			return funcionariosAPI.getFuncionarioByLogin(self.admin.Login);
		}).then(function(dado) {
			self.admin.MatriculaFuncionario = dado.data.MatriculaFuncionario;
			self.admin.Email = dado.data.Email;
			self.admin.CodigoEmpresa = dado.data.CodigoEmpresa;
		}).finally(function() {
			self.buscandoUsuario = false;
		});

	}


	self.salvar = function(usuario) {
		usuario.Empresas = self.empresas.filter(function(e) { return e.selecionado; });
		usuariosAPI.postAdministrador(usuario)
		.then(function(dado) {
			loadAdministradores();
			self.admin = null;
			self.form.$setPristine();
			self.empresas.forEach(function(e) { e.selecionado = false; });
			swal("Sucesso!", "Acesso administrador concedido com sucesso!" , "success");
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


	self.excluir = function(login) {
		if (login == self.usuario.Login) {
			swal("Inválido!", "Não é permitida a auto-exclusão!", "error");
		} else {
			swal({title: "Confirmar revogação de acesso?",text: "Essa ação não poderá ser desfeita!",icon: "warning",buttons: true, dangerMode: true,
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

var loadEmpresas = function() {
	empresasAPI.getEmpresas()
	.then(function(dado) {
		self.empresas = dado.data;
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

loadAdministradores();
loadEmpresas();

}]);