angular.module('cipaApp').controller('baseGeralCtrl', ['$scope', 'sharedDataService', 'funcionariosAPI', 'gestoresAPI', function($scope, sharedDataService, funcionariosAPI, gestoresAPI) {

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

	// ************* COMPARTILHADO *************
	$scope.$emit('activeMenuEvent', {label: 'Base Geral'});
	var stateRedirect = 'navContainer.baseGeral';

	self.codigoModulo = sharedDataService.getCodigoModulo();
	// \************* COMPARTILHADO *************

	self.pesquisa = function(pesquisa) {
		if (self.editando) return;
		var call = null;
		if ($.isNumeric(pesquisa))
			call = funcionariosAPI.getFuncionario;
		else
			call = funcionariosAPI.getFuncionarioByLogin;

		call(pesquisa)
		.then(function(dado) {
			dado.data.DataAdmissao = new Date(dado.data.DataAdmissao); 
			dado.data.DataNascimento = new Date(dado.data.DataNascimento); 
			self.atual = dado.data;
		}, function(error) {
			if (error.data && error.data.Message)
				swal("Inválido!", error.data.Message, "error");
			else if(error.data) 
				swal("Inválido!", error.data, "error");
			else
				swal("Inválido!", error, "error");
		});
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

	self.excluirFuncionario = function(matricula) {
		funcionariosAPI.deleteFuncionario(matricula)
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
		funcionariosAPI.putFuncionario(funcionario.MatriculaFuncionario, funcionario)
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

}]);