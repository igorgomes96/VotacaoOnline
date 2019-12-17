angular.module('cipaApp').service('votosAPI', ['$http', 'config', function($http, config) {

    var self = this;
    var resource = 'Votos';

    self.getVotos = function() {
        return $http({method: 'GET', url:config.baseUrl + resource});
    }

    self.postVoto = function(voto) {
        return $http.post(config.baseUrl + resource, voto);
    }

    self.putVoto = function(eleitor, candidato, ano, voto) {
        return $http.put(config.baseUrl + resource + '/' + eleitor + '/' + candidato + '/' + ano, voto);
    }

    self.deleteVoto = function(eleitor, candidato, ano) {
        return $http.delete(config.baseUrl + resource + '/' + eleitor + '/' + candidato + '/' + ano);
    }

    //Dashboard
    self.getQtdaVotantes = function(codEleicao) {
        return $http.get(config.baseUrl + resource + '/QtdaVotantes/' + codEleicao);
    }

    self.getVotos = function(codEleicao) {
        return $http.get(config.baseUrl + resource + '/QtdaVotosPorCandidato/' + codEleicao);
    }

    self.getApuracaoEleitos = function(codEleicao) {
        return $http.get(config.baseUrl + resource + '/Resultado/' + codEleicao);
    }

    self.getRelatorioEleitores = function(codEleicao, pesquisa, pageNumber) {
        if (!pageNumber) pageNumber = 1;
        return $http.get(config.baseUrl + resource + '/Relatorio/Eleitores/' + codEleicao,
            { params: { pesquisa: pesquisa, pageNumber: pageNumber } });
    }

    self.getEleitoresPaginationInfo = function(codEleicao, pesquisa) {
        return $http.get(config.baseUrl + resource + '/Relatorio/Eleitores/' + codEleicao + '/PaginationInfo', { params: { pesquisa: pesquisa } });
    }


}]);