angular.module('cipaApp').service('gruposAPI', ['$http', 'config', 'sharedDataService', 'uploadFileService', function($http, config, sharedDataService, uploadFileService) {

	var self = this;

	self.getGrupos = function() {
        return $http({method: 'GET', url:config.baseUrl + 'Grupos'});
    }

}]);
