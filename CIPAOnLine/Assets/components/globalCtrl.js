angular.module('cipaApp').controller('globalCtrl', ['$state', '$rootScope', 'eleicoesAPI', 'sharedDataService', function($state, $rootScope, eleicoesAPI, sharedDataService) {

	var self = this;

	self.currentState = $state;

	$rootScope.$on('eleicaoAlterada', function(ev, eleicao) {
		if (eleicao) {
			eleicoesAPI.getEleicao(eleicao)
			.then(function(dado) {
				sharedDataService.setEmpresa(dado.data.UnidadeObj.CodigoEmpresa);
			});
		}
	});

}])