angular.module('cipaApp').service('sharedDataService', ['sessionStorageService', function(sessionStorageService) {

    var self = this;

    var usuario = null;
    var codigoModulo = null;
    var codigoEleicao = null;
    var nextState = null;
    var perfil = null;

    self.getCodigoEleicao = function() {
        return codigoEleicao;
    }

    self.setCodigoEleicao = function(codigo) {
        codigoEleicao = codigo;
    }

    self.setUsuario = function(user) {
        usuario = user;
        perfil = usuario.Perfil;
        if (perfil)
            sessionStorageService.savePerfil(perfil);
    }

    self.getUsuario = function() {
        if (!usuario) 
            usuario = sessionStorageService.getUser();

        return usuario;
    }

    self.getPerfil = function() {
        return perfil || sessionStorageService.getPerfil();
    }

    self.setPerfil = function(p) {
        perfil = p;
        sessionStorageService.savePerfil(perfil);
    }

    self.setNextState = function(state) {
        nextState = state;
    }

    self.getNextState = function() {
        return nextState;
    }

    self.setCodigoModulo = function(codigo) {
        codigoModulo = codigo;
        sessionStorageService.saveCodigoModulo(codigo);
    }

    self.getCodigoModulo = function() {
        if (!codigoModulo)
            codigoModulo = sessionStorageService.getCodigoModulo();

        return codigoModulo;

    }

}]);