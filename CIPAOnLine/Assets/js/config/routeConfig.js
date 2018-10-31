angular.module('cipaApp').config(['$stateProvider', '$urlRouterProvider', '$locationProvider', function ($stateProvider, $urlRouterProvider, $locationProvider) {


    var isAllowed = function(eleicoesAPI, $stateParams) {
        return eleicoesAPI.getFuncionarioCadastrado($stateParams.codEleicao);
    }


    $locationProvider.hashPrefix('');

    $urlRouterProvider.otherwise('/home');
    
    $stateProvider

    .state('login', {
        url: '/login',
        templateUrl: 'Assets/components/autenticacao/login.html',
        controller: 'autenticacaoCtrl as ct',
        params: {
            error: null
        }
    })

    .state('loginAdmin', {
        url: '/loginAdmin',
        templateUrl: 'Assets/components/autenticacao/admin.html',
        controller: 'autenticacaoCtrl as ct'
    })

    .state('recuperarSenha', {
        url: '/recuperarSenha',
        templateUrl: 'Assets/components/autenticacao/recuperacaoSenha.html',
        controller: 'autenticacaoCtrl as ct'
    })

    .state('cadastro', {
        url: '/cadastro',
        templateUrl: 'Assets/components/autenticacao/register.html',
        controller: 'autenticacaoCtrl as ct'
    })

    .state('navContainer', {
        templateUrl: 'Assets/components/navContainer/navContainer.html',
        controller: 'navContainerCtrl as ctNav'
    })

    .state('navContainer.home', {
        url: '/home',
        templateUrl: 'Assets/components/home/home.html',
        controller: 'homeCtrl as ct'
    })

    .state('navContainer.novaEleicao', {
        url: '/novaEleicao',
        templateUrl: 'Assets/components/eleicoes/novaEleicao.html',
        controller: 'eleicoesCtrl as ct'
    })

    .state('navContainer.dashboards', {
        url: '/dashboard',
        templateUrl: 'Assets/components/dashboard/dashboard.html',
        controller: 'dashboardCtrl as ct',
        resolve: { isAllowed: function() { return true; } }
    })

    .state('navContainer.dashboard', {
        url: '/dashboard/:codEleicao',
        templateUrl: 'Assets/components/dashboard/dashboard.html',
        controller: 'dashboardCtrl as ct',
        resolve: { isAllowed: isAllowed }
    })

    .state('navContainer.eleicoes', {
        url: '/eleicoes',
        templateUrl: 'Assets/components/eleicoes/eleicoes.html',
        controller: 'eleicoesCtrl as ct'
    }) 

    .state('navContainer.eleicao', {
        url: '/eleicoes/:codEleicao',
        templateUrl: 'Assets/components/eleicoes/eleicoes.html',
        controller: 'eleicoesCtrl as ct'
    }) 

    .state('navContainer.cadastroFuncionarios', {
        url: '/cadastroFuncionarios',
        templateUrl: 'Assets/components/cadastroFuncionarios/cadastroFuncionarios.html',
        controller: 'cadastroFuncionariosCtrl as ct'
    })

    .state('navContainer.cadastroFuncionario', {
        url: '/cadastroFuncionarios/:codEleicao',
        templateUrl: 'Assets/components/cadastroFuncionarios/cadastroFuncionarios.html',
        controller: 'cadastroFuncionariosCtrl as ct'
    })

    .state('navContainer.pendentes', {
        url: '/validacaoCandidaturas/pendentes',
        templateUrl: 'Assets/components/validacaoCandidaturas/pendentes.html',
        controller: 'validacaoPendentesCtrl as ct'
    })

    .state('navContainer.pendente', {
        url: '/validacaoCandidaturas/pendentes/:codEleicao',
        templateUrl: 'Assets/components/validacaoCandidaturas/pendentes.html',
        controller: 'validacaoPendentesCtrl as ct'
    })

    .state('navContainer.aprovados', {
        url: '/validacaoCandidaturas/aprovados',
        templateUrl: 'Assets/components/validacaoCandidaturas/aprovados.html',
        controller: 'validacaoAprovadosCtrl as ct'
    })

    .state('navContainer.aprovado', {
        url: '/validacaoCandidaturas/aprovados/:codEleicao',
        templateUrl: 'Assets/components/validacaoCandidaturas/aprovados.html',
        controller: 'validacaoAprovadosCtrl as ct'
    })

    .state('navContainer.reprovados', {
        url: '/validacaoCandidaturas/reprovados',
        templateUrl: 'Assets/components/validacaoCandidaturas/reprovados.html',
        controller: 'validacaoReprovadosCtrl as ct'
    })

    .state('navContainer.reprovado', {
        url: '/validacaoCandidaturas/reprovados/:codEleicao',
        templateUrl: 'Assets/components/validacaoCandidaturas/reprovados.html',
        controller: 'validacaoReprovadosCtrl as ct'
    })

    .state('navContainer.candidaturas', {
        url: '/candidatura',
        templateUrl: 'Assets/components/candidatura/candidatura.html',
        controller: 'candidaturaCtrl as ct',
        resolve: { isAllowed: function() { return true; } }
    })

    .state('navContainer.candidatura', {
        url: '/candidatura/:codEleicao',
        templateUrl: 'Assets/components/candidatura/candidatura.html',
        controller: 'candidaturaCtrl as ct',
        resolve: { isAllowed: isAllowed }
    })


     .state('navContainer.administradores', {
         url: '/administradores',
         templateUrl: 'Assets/components/usuarios/administradores.html',
         controller: 'administradoresCtrl as ct'
     })

     .state('navContainer.baseGeral', {
         url: '/baseGeral',
         templateUrl: 'Assets/components/baseGeral/baseGeral.html',
         controller: 'baseGeralCtrl as ct'
     })

    .state('navContainer.emails', {
        url: '/email',
        templateUrl: 'Assets/components/email/email.html',
        controller: 'emailCtrl as ct'
    })

    .state('navContainer.email', {
        url: '/email/:codEleicao',
        templateUrl: 'Assets/components/email/email.html',
        controller: 'emailCtrl as ct',
        params: {
            codTemplate: null
        }
    })

    .state('navContainer.votacoes', {
        url: '/votacao',
        templateUrl: 'Assets/components/votacao/votacao.html',
        controller: 'votacaoCtrl as ct',
        resolve: { isAllowed: function() { return true; } }
    })

    .state('navContainer.votacao', {
        url: '/votacao/:codEleicao',
        templateUrl: 'Assets/components/votacao/votacao.html',
        controller: 'votacaoCtrl as ct',
        resolve: { isAllowed: isAllowed }
    });
    
}]);