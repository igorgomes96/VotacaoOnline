angular.module('cipaApp').controller('baseGeralCtrl', ['$scope', 'sharedDataService', 'empresasAPI', 'funcionariosAPI', 'gestoresAPI', function($scope, sharedDataService, empresasAPI, funcionariosAPI, gestoresAPI) {

	var self = this;

	self.atual = null;
	self.editando = false;
	self.perfis = ['Administrador', 'Eleitor'];
	self.inconsistencias = null;
	self.gestores = [];
	self.editandoGestor = false;
	self.gestorSelecionado = null;
	self.novoGestor = null;
	self.error = null;
	self.empresas = [];
	self.codigoEmpresa = null;

	// ************* COMPARTILHADO *************
	$scope.$emit('activeMenuEvent', {label: 'Base Geral'});
	var stateRedirect = 'navContainer.baseGeral';

	self.codigoModulo = sharedDataService.getCodigoModulo();
	// \************* COMPARTILHADO *************

	self.pesquisa = function(pesquisa) {
		if (self.editando) return;
		if ($.isNumeric(pesquisa)) {
			funcionariosAPI.getFuncionarioByMatriculaEmpresa(pesquisa, self.codigoEmpresa)
			.then(function(dado) {
				dado.data.DataAdmissao = new Date(dado.data.DataAdmissao);
				dado.data.DataNascimento = new Date(dado.data.DataNascimento);
				self.atual = dado.data;
			}, function(error) {
				if (error.status == 404)
					swal("Não encontrado!", "Matrícula não encontrada!", "error");
				else if (error.data && error.data.Message)
					swal("Inválido!", error.data.Message, "error");
				else if(error.data) 
					swal("Inválido!", error.data, "error");
				else
					swal("Inválido!", error, "error");
			});
		} else {
			funcionariosAPI.getFuncionarioByLogin(pesquisa)
			.then(function(dado) {
				dado.data.DataAdmissao = new Date(dado.data.DataAdmissao); 
				dado.data.DataNascimento = new Date(dado.data.DataNascimento); 
				self.atual = dado.data;
			}, function(error) {
				if (error.status == 404)
					swal("Não encontrado!", "Login não encontrado!", "error");
				else if (error.data && error.data.Message)
					swal("Inválido!", error.data.Message, "error");
				else if(error.data) 
					swal("Inválido!", error.data, "error");
				else
					swal("Inválido!", error, "error");
			});
		}
	}

	self.keypressed = function(event, pesquisa) {
		if (event.keyCode == 13)
			self.pesquisa(pesquisa);
	}

	self.editarGestor = function(gestor) {
		self.editandoGestor = true;
		self.novoGestor = gestor;
	}

	self.salvarGestor = function(gestor) {
		gestoresAPI.postGestor(gestor)
		.then(function(dado) {
			self.editandoGestor = false;
			self.novoGestor = null;
			loadGestores();
		}, function(error) {
			if (error.data && error.data.Message)
				swal("Inválido!", error.data.Message, "error");
			else if(error.data) 
				swal("Inválido!", error.data, "error");
			else
				swal("Inválido!", error, "error");
		});
	}

	self.deleteGestor = function(codigo) {
		gestoresAPI.deleteGestor(codigo)
		.then(function() {
			loadGestores();
		}, function(error) {
			if (error.data && error.data.Message)
				swal("Inválido!", error.data.Message, "error");
			else if(error.data) 
				swal("Inválido!", error.data, "error");
			else
				swal("Inválido!", error, "error");
		});
	}

	var loadEmpresas = function() {
		empresasAPI.getEmpresas()
		.then(function(dado) {
			self.empresas = dado.data;
			if (self.empresas && self.empresas.length)
				self.codigoEmpresa = self.empresas[0].Codigo;
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


	var loadGestores = function() {
		gestoresAPI.getGestores()
		.then(function(dado) {
			self.gestores = dado.data;
		}, function(error) {
			if (error.data && error.data.Message)
				swal("Inválido!", error.data.Message, "error");
			else if(error.data) 
				swal("Inválido!", error.data, "error");
			else
				swal("Inválido!", error, "error");
		});
	}

	self.selecionarGestor = function(codigo) {
		if (!self.atual)
			self.atual = {};
		self.atual.CodigoGestor = codigo;
		self.gestorSelecionado = null;
		$('#modalGestores').modal('hide');
	}

	self.excluirFuncionario = function(funcionarioId) {
		funcionariosAPI.deleteFuncionario(funcionarioId)
		.then(function() {
			self.atual = null;
			swal("Sucesso!", "Funcionário removido com sucesso!", "success");
		}, function(error) {
			if (error.data && error.data.Message)
				swal("Inválido!", error.data.Message, "error");
			else if(error.data) 
				swal("Inválido!", error.data, "error");
			else
				swal("Inválido!", error, "error");
		});
	}

	self.salvarFuncionario = function(funcionario) {
		funcionariosAPI.putFuncionario(funcionario.Id, funcionario)
		.then(function() {
			swal("Sucesso!", "Funcionário salvo com sucesso!", "success");
		}, function(error) {
			if (error.data && error.data.Message)
				swal("Erro ao carregar dados!", error.data.Message, "error");
			else if(error.data) 
				swal("Erro ao carregar dados!", error.data, "error");
			else
				swal("Inválido!", error, "error");
		});
	}

	self.cancelar = function() {
		self.editando = false;
	}

	self.editar = function() {
		self.editando = true;
	}

	loadGestores();
	loadEmpresas();

}]);