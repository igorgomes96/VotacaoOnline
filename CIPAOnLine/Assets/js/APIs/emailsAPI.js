angular.module('cipaApp').service('emailsAPI', ['$http', 'config', function($http, config) {

    var self = this;
    var resource = 'Emails';

    // self.getEmails = function(codModulo) {
    //     return $http({method: 'GET', url:config.baseUrl + resource + '/' + codModulo});
    // }

    // self.getEmail = function(id) {
    //     return $http.get(config.baseUrl + resource + '/' + id);
    // }

    self.postEmail = function(email) {
        return $http.post(config.baseUrl + resource, email);
    }

    self.getEmailAddressesAll = function(codEleicao) {
        return $http.get(config.baseUrl + resource + '/Addresses/' + codEleicao + '/All');
    }

    self.getEmailAddressesCandidatos = function(codEleicao) {
        return $http.get(config.baseUrl + resource + '/Addresses/' + codEleicao + '/Candidatos');
    }

    // self.putEmail = function(id, Email) {
    //     return $http.put(config.baseUrl + resource + '/' + id, Email);
    // }

    // self.deleteEmail = function(id) {
    //     return $http.delete(config.baseUrl + resource + '/' + id);
    // }
}]);