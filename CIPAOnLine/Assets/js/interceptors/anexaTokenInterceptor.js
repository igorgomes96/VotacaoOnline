angular.module("cipaApp").factory("anexaTokenInterceptor", ['sessionStorageService', function(sessionStorageService) {
	return {
		request: function(config) {
			var user = sessionStorageService.getUser();
			if (user && user.Token) 
                config.headers['Authorization'] = 'Bearer ' + user.Token;
			return config;
		}
	}
}]);