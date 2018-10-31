angular.module("cipaApp").factory("errorInterceptor", ['$q', '$state', 'sharedDataService', function($q, $state, sharedDataService) {		//$q implementação do angular para promisse
	return {
		responseError: function(rejection) {
			if (rejection.status === 401) {
				sharedDataService.setNextState($state.current.name);
                $state.go('login', { error: rejection.statusText});
			}
			return $q.reject(rejection);
		}
	}
}]);