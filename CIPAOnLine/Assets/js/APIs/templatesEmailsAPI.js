angular.module('cipaApp').service('templatesEmailsAPI', ['$http', 'config', function($http, config) {

    var self = this;
    var resource = 'TemplatesEmails';

    self.getTemplatesEmails = function() {
        return $http({method: 'GET', url:config.baseUrl + resource});
    }

    self.getTemplateEmail = function(id) {
        return $http.get(config.baseUrl + resource + '/' + id);
    }

    self.postTemplateEmail = function(templateEmail) {
        return $http.post(config.baseUrl + resource, templateEmail);
    }

    self.putTemplateEmail = function(id, templateEmail) {
        return $http.put(config.baseUrl + resource + '/' + id, templateEmail);
    }

    self.deleteTemplateEmail = function(id) {
        return $http.delete(config.baseUrl + resource + '/' + id);
    }
}]);