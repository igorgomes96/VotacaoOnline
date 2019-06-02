angular.module('cipaApp').service('eleicoesAPI', ['$http', 'config', function($http, config) {

    var self = this;
    var resource = 'Eleicoes';

    self.getEleicoes = function(codigoModulo, aberta) {
        return $http({method: 'GET', url:config.baseUrl + resource, params:{codigoModulo:codigoModulo, aberta:aberta}});
    }

    self.getFuncionarios = function(codEleicao, pesquisa = null, pageNumber = 1) {
        return $http({method: 'GET', url:config.baseUrl + resource + '/' + codEleicao + '/Funcionarios', params: { pesquisa: pesquisa, pageNumber: pageNumber }});
    }

    self.getFuncionariosPaginationInfo = function(codEleicao, pesquisa) {
        return $http({method: 'GET', url:config.baseUrl + resource + '/' + codEleicao + '/Funcionarios/PaginationInfo', params: { pesquisa: pesquisa }});
    }

    self.getGestoes = function(codigoModulo) {
        return $http({method: 'GET', url:config.baseUrl + resource + '/Gestoes/' + codigoModulo});
    }

    self.putEleicao = function(eleicao) {
        return $http.put(config.baseUrl + resource + '/' + eleicao.Codigo, eleicao);
    }

    self.getEleicao = function(id) {
        return $http.get(config.baseUrl + resource + '/' + id);
    }

    self.getEleicaoCorrente = function (codigoModulo) {
        return $http({ method: 'GET', url: config.baseUrl + resource + '/Corrente', params: { codigoModulo: codigoModulo }});
    }

    self.getFiltrosEleicoes = function (codigoModulo) {
        return $http.get(config.baseUrl + 'Filtro/' + resource + '/' + codigoModulo);
    }

    self.putPrazoEtapa = function(id, prazo) {
        return $http.put(config.baseUrl + resource + '/' + id + '/PrazosEtapas', prazo);
    }

    self.getEleicaoPorGestaoPorUnidade = function(codigoModulo, gestao, codigoEleicao) {
        return $http.get(config.baseUrl + resource + '/PorGestao/PorUnidade/' + codigoModulo + '/' + gestao + '/' + codigoEleicao);
    }

    self.setProximaEtapa = function(codEleicao) {
        return $http.put(config.baseUrl + resource + '/ProximaEtapa/' + codEleicao);
    }

    self.setProximaEtapaConfirmaEmails = function(codEleicao, emails) {
        return $http.put(config.baseUrl + resource + '/ProximaEtapa/' + codEleicao + '/ConfirmaEmails', emails);
    }

    self.getFuncionarioCadastrado = function(codEleicao) {
        return $http.get(config.baseUrl + resource + '/' + codEleicao + '/Cadastrado');
    }

    self.postEleicao = function(eleicao) {
        return $http.post(config.baseUrl + resource, eleicao);
    }

    self.deleteEleicao = function(id) {
        return $http.delete(config.baseUrl + resource + '/' + id);
    }

    self.addFuncionario = function(id, funcionarioId) {
        return $http.post(config.baseUrl + resource + '/' + id + '/AddFuncionario/' + funcionarioId);
    }

    self.getTotalFuncionarioEleitores = function(codEleicao) {
        return $http.get(config.baseUrl + resource + '/TotalFuncionariosEleitores/' + codEleicao);
    }

    self.deleteFuncionario = function(codEleicao, funcionarioId) {
        return $http.put(config.baseUrl + resource + '/' + codEleicao + '/RemoveFuncionario/' + funcionarioId);
    }

    self.deleteTodosFuncionarios = function(codEleicao) {
        return $http.delete(config.baseUrl + resource + '/' + codEleicao + '/RemoveTodosFuncionarios');
    }

}]);