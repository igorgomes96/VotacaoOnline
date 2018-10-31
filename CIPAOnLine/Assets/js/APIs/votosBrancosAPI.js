angular.module('cipaApp').service('votosBrancosAPI', ['$http', 'config', function($http, config) {

    var self = this;
    var resource = 'VotosBrancos';

    self.getVotosBrancos = function() {
        return $http({method: 'GET', url:config.baseUrl + resource});
    }

    // self.getVotoBranco = function(id) {
    //     return $http.get(config.baseUrl + resource + '/' + id);
    // }

    self.postVotoBranco = function(votoBranco) {
        return $http.post(config.baseUrl + resource, votoBranco);
    }

    // self.deleteVotoBranco = function(id) {
    //     return $http.delete(config.baseUrl + resource + '/' + id);
    // }
}]);