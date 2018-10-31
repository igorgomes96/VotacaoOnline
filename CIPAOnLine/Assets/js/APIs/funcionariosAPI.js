angular.module('cipaApp').service('funcionariosAPI', ['$http', 'config', 'sharedDataService', 'uploadFileService', function($http, config, sharedDataService, uploadFileService) {

    var self = this;
    var resource = 'Funcionarios';

    self.getFuncionario = function(id) {
        return $http.get(config.baseUrl + resource + '/' + id);
    }

    self.importarFuncionarios = function(arquivo, codEleicao) {
        var payload = new FormData();

        payload.append("arquivo", arquivo);

        var user = sharedDataService.getUsuario();
        var token = null;
        if (user)
            token = user.Token;

        return $.ajax(uploadFileService.sendFile(config.baseUrl + resource + '/Importacao/' + codEleicao, payload, token));
    }

    self.getFuncionarioByLogin = function(login) {
        return $http.get(config.baseUrl + resource + '/Login/' + login);
    }

    self.postFuncionario = function(funcionario) {
        return $http.post(config.baseUrl + resource, funcionario);
    }

    self.saveAll = function(funcionarios) {
        return $http.post(config.baseUrl + resource + '/SaveAll', funcionarios);
    }

    self.putFuncionario = function(id, funcionario) {
        return $http.put(config.baseUrl + resource + '/' + id, funcionario);
    }

    self.deleteFuncionario = function(id) {
        return $http.delete(config.baseUrl + resource + '/' + id);
    }
}]);