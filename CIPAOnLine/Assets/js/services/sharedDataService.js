angular.module('cipaApp').service('sharedDataService', ['sessionStorageService', '$rootScope', function(sessionStorageService, $rootScope) {

    var self = this;

    var usuario = null;
    var codigoEleicao = null;
    var nextState = null;
    var perfil = null;

    self.getCodigoEleicao = function() {
        return codigoEleicao;
    }

    self.setCodigoEleicao = function(codigo) {
        codigoEleicao = codigo;
        $rootScope.$emit('eleicaoAlterada', codigoEleicao);
    }

    self.setUsuario = function(user) {
        usuario = user;
        perfil = usuario.Perfil;
        if (usuario.hasOwnProperty('CodigoEmpresa'))
            self.setEmpresa(usuario.CodigoEmpresa);
        
        if (perfil)
            sessionStorageService.savePerfil(perfil);
    }

    self.getUsuario = function() {
        if (!usuario) 
            usuario = sessionStorageService.getUser();

        return usuario;
    }

    self.getEmpresa = function() {
        return sessionStorageService.getEmpresa();
    }

    self.setEmpresa = function(codigoEmpresa) {
        return sessionStorageService.saveEmpresa(codigoEmpresa);
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
        sessionStorageService.saveCodigoModulo(codigo);
    }

    self.getCodigoModulo = function() {
        return sessionStorageService.getCodigoModulo();

    }

}]);