angular.module('cipaApp').service('candidatosAPI', ['$http', 'config', 'sharedDataService', 'uploadFileService', function($http, config, sharedDataService, uploadFileService) {

	var self = this;
	var resource = 'Candidatos';

    self.getCandidatos = function(codEleicao) {
        return $http({method: 'GET', url:config.baseUrl + resource, params:{codEleicao:codEleicao}});
    }

    self.getCandidatosVotos = function(codEleicao) {
        return $http({method: 'GET', url:config.baseUrl + resource + '/Votos/' + codEleicao});
    }

    self.getCandidatoValidacao = function(codEleicao, aprovado) {
        return $http({method: 'GET', url:config.baseUrl + resource + '/Validacao/' + codEleicao, params:{aprovado:aprovado}});
    }

    self.getCandidato = function(matricula, codEleicao) {
        return $http.get(config.baseUrl + resource + '/' + matricula + '/' + codEleicao);
    }

    self.addOrUpdateCandidato = function(candidato, foto) {
        var payload = new FormData();

        payload.append("candidato", JSON.stringify(candidato));
        payload.append('foto', foto);

        var user = sharedDataService.getUsuario();
        var token = null;
        if (user)
            token = user.Token;

        return $.ajax(uploadFileService.sendFile(config.baseUrl + resource + '/AddOrUpdate', payload, token));
    }

    self.aprovarCandidatura = function(matricula, codEleicao) {
        return $http.put(config.baseUrl + resource + '/' + matricula + '/' + codEleicao + '/Aprovar');
    }

    self.reprovarCandidatura = function(matricula, codEleicao, reprovacao) {
        return $http.post(config.baseUrl + resource + '/' + matricula + '/' + codEleicao + '/Reprovar', reprovacao);
    }

    self.aprovarCandidaturaTodos = function(candidatos) {
        return $http.post(config.baseUrl + resource + '/AprovarTodos', candidatos);
    }

    self.deleteCandidato = function(matricula, codEleicao) {
        return $http.delete(config.baseUrl + resource + '/' + matricula + '/' + codEleicao);
    }


}]);