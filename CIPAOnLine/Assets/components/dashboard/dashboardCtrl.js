var optionsGraphColumnBar = {
    chart: {
        type: 'column',
    },
    legend: {
        enabled: false
    },
    title: {
        text: undefined
    },
    subtitle: {
        text: undefined
    },
    xAxis: {
        categories: [],
        crosshair: true
    },
    yAxis: {
        min: 0,
        title: {
            text: undefined
        }
    },
    scrollbar: {
        enabled: false
    },
    tooltip: {
        headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
        pointFormat: '<tr><td style="padding:0">{series.name}: </td>' +
            '<td style="padding:0"><b>{point.y}</b></td></tr>',
        footerFormat: '</table>',
        shared: true,
        useHTML: true
    },
    plotOptions: {
        column: {
            pointPadding: 0.2,
            borderWidth: 0
        }
    },
    series: []
};

var optionsGraphPie = {
    chart: {
        plotBackgroundColor: null,
        plotBorderWidth: null,
        plotShadow: false,
        type: 'pie'
    },
    title: {
        text: undefined
    },
    tooltip: {
        pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
    },
    plotOptions: {
        pie: {
            allowPointSelect: true,
            cursor: 'pointer',
            dataLabels: {
                enabled: true,
                format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                distance: 0
                /*,
                style: {
                    color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                }*/
            },
            size: 150
        }
    },
    series: [{
        name: 'Série',
        colorByPoint: true,
        data: [{
            name: 'Pedaço',
            y: 100
        }]
    }]
};


function carregaGrafico(idElement, options) {
    $('#' + idElement).highcharts(options);
}


angular.module('cipaApp').controller('dashboardCtrl', ['isAllowed', '$scope', '$state', 'sharedDataService', 'eleicoesAPI', 'votosAPI', 'dateFilter', 'unidadesAPI', '$stateParams', 'isAllowed', function (isAllowed, $scope, $state, sharedDataService, eleicoesAPI, votosAPI, dateFilter, unidadesAPI, $stateParams, isAllowed) {

    var self = this;
    self.eleicaoAtual = null;
    self.candidatos = [];
    self.codigoModulo = sharedDataService.getCodigoModulo();
    self.votantes = null;
    self.apuracaoEleitos = null;
    self.eleitores = [];
    self.erroCandidatosInsuficientes = null;
    self.votos = [];
    self.codEleicao = null;
    self.error = null;
    self.filtroEleitores = null;
    self.pageNumber = 1;
    self.pagination = { Total: 0, PageSize: 200, TotalPages: 0 };
    var usuario = sharedDataService.getUsuario();

    var loadApuracaoEleitos = function () {
        //var spinnerListApuracao = exibeSpinner('#list-apuracao');
        votosAPI.getApuracaoEleitos(self.codEleicao)
            .then(function (dado) {
                self.apuracaoEleitos = dado.data;
                //spinnerListApuracao();
            }, function (error) {
                self.erroCandidatosInsuficientes = error.data;
            });

    }

    var loadEleicaoAtual = function (codigo) {
        eleicoesAPI.getEleicao(codigo)
            .then(function (dado) {
                if (dado.data) {
                    dado.data.PrazosEtapasObj.forEach(function (x) {
                        if (x.AberturaProposto) x.AberturaProposto = new Date(x.AberturaProposto);
                        if (x.FechamentoProposto) x.FechamentoProposto = new Date(x.FechamentoProposto);
                        if (x.DataAbertura) x.DataAbertura = new Date(x.DataAbertura);
                        if (x.DataFechamento) x.DataFechamento = new Date(x.DataFechamento);
                    });
                    self.eleicaoAtual = dado.data;
                    loadGraficos(self.eleicaoAtual.Codigo);
                } else {
                    //ocultaLoader();
                }
            }, function (error) {
                if (error.data && error.data.Message)
                    swal("Erro ao carregar dados!", error.data.Message, "error");
                else if (error.data)
                    swal("Erro ao carregar dados!", error.data, "error");
                else
                    swal("Erro ao carregar dados!", "Contate o administrador.", "error");

                //ocultaLoader();
            });
    }

    var loadGraficos = function (codigo) {

        votosAPI.getQtdaVotantes(codigo)
            .then(function (retorno) {

                self.votantes = retorno.data;
                self.votantes['Total'] = self.votantes.Votantes + self.votantes.NaoVotantes;
                self.votantes['PercentualVotantes'] = (self.votantes.Votantes / self.votantes.Total) * 100;
                self.votantes['PercentualNaoVotantes'] = 100 - self.votantes['PercentualVotantes'];

                return votosAPI.getVotos(codigo);
            }).then(function (retorno) {

                //Etabelece o tamanho do gráfico com 50 + quantidade de candidatos * 20. Height mín: 400
                var heightGraf = 50 + (retorno.data ? retorno.data.length * 21 : 0);
                if (heightGraf < 400)
                    heightGraf = 400;

                self.votos = retorno.data;
                //spinnerGraficoRelatorioVotos();

                var optionsApuracao = angular.copy(optionsGraphColumnBar);
                optionsApuracao.chart.type = 'bar';
                optionsApuracao.chart.height = heightGraf;
                optionsApuracao.title.text = 'Qtda de Votos';
                optionsApuracao.subtitle.text = 'Atualizado em ' + dateFilter(new Date(), 'dd/MMM HH:mm:ss');
                optionsApuracao.yAxis.title.text = 'Qtda';
                //optionsApuracao.xAxis.rotation = -45;
                optionsApuracao.series = [{
                    name: 'Qtda',
                    data: retorno.data.map(function (x) {
                        return x.QtdaVotos;
                    })
                }];
                optionsApuracao.xAxis.categories = retorno.data.map(function (x) {
                    return x.Candidato.Nome;
                });
                carregaGrafico('graficoApuracaoGeral', optionsApuracao);


                //ocultaLoader();
            }, function (error) {
                self.votantes = null;

                if (error.data && error.data.Message)
                    swal("Erro ao carregar dados!", error.data.Message, "error");
                else if (error.data)
                    swal("Erro ao carregar dados!", error.data, "error");
                else
                    swal("Erro ao carregar dados!", "Contate o administrador.", "error");
            });
    }

    $scope.$watch('filtroEleitores', function (newValue) {
        if (newValue !== self.filtroEleitores && self.codEleicao) {
            self.filtroEleitores = newValue;
            loadRelatorioEleitores();
        }
    });

    var loadRelatorioEleitores = function () {
        loadPaginationInfo();
        votosAPI.getRelatorioEleitores(self.codEleicao, self.filtroEleitores, self.pageNumber)
            .then(function (dado) {
                self.eleitores = dado.data;
                //spinner();
            }, function (error) {
                console.log(error);
                //spinner();
                if (error.data && error.data.Message)
                    swal("Erro ao carregar dados!", error.data.Message, "error");
                else if (error.data)
                    swal("Erro ao carregar dados!", error.data, "error");
                else
                    swal("Erro ao carregar dados!", "Contate o administrador.", "error");
            });
    }

    var loadPaginationInfo = function () {
        votosAPI.getEleitoresPaginationInfo(self.codEleicao, self.filtroEleitores)
            .then(function (dado) {
                self.pagination = dado.data;
                if (self.pagination.TotalPages < self.pageNumber && self.pagination.TotalPages != 0) {
                    self.pageNumber = self.pagination.TotalPages;
                    votosAPI.getRelatorioEleitores(self.codEleicao, self.filtroEleitores, self.pageNumber)
                        .then(function (dado) {
                            self.eleitores = dado.data;
                        });
                }
            }, function (error) {
                console.error(error);
            });
    }

    self.proximaPagina = function () {
        if (self.pagination.TotalPages > self.pageNumber) {
            self.pageNumber++;
        } else {
            self.pageNumber = 1;
        }
        loadRelatorioEleitores();
    }

    self.paginaAnterior = function () {
        if (self.pageNumber <= 1) {
            self.pageNumber = self.pagination.TotalPages;
        } else {
            self.pageNumber--;
        }
        loadRelatorioEleitores();
    }


    // ************* COMPARTILHADO *************
    $scope.$emit('activeMenuEvent', { label: 'Dashboard' });
    var stateRedirect = 'navContainer.dashboard';

    self.codigoModulo = sharedDataService.getCodigoModulo();
    self.codEleicao = $stateParams.codEleicao;

    if (!self.codEleicao) {
        self.codEleicao = sharedDataService.getCodigoEleicao();
        if (self.codEleicao)
            $state.go(stateRedirect, { codEleicao: self.codEleicao }, { reload: true });
    } else {
        if ((usuario && usuario.Perfil === 'Administrador') || isAllowed.data) {
            loadEleicaoAtual(self.codEleicao);
            loadApuracaoEleitos();
            loadRelatorioEleitores();
        } else
            self.error = "Você não está cadastrado nessa eleição!";
        sharedDataService.setCodigoEleicao(self.codEleicao);
    }

    self.statusSelecionado = null;
    self.unidadeSelecionada = null;
    self.gestaoSelecionada = null;
    self.eleicoesFiltro = [];

    var loadFiltroEleicoes = function () {
        eleicoesAPI.getFiltrosEleicoes(self.codigoModulo)
            .then(function (dado) {
                self.eleicoesFiltro = dado.data;
                if (self.codEleicao) {
                    var eleicao = findEleicao(self.codEleicao);
                    if (eleicao)
                        setEleicaoAtual(eleicao);
                }
            }, function (error) {
                self.error = 'Erro ao carregar os filtros. ' + (error.data && error.data.Message) || error.data || error;
            });
    }

    var findEleicao = function (codigo) {
        var eleicoes = null;

        self.eleicoesFiltro.some(function (status) {
            status.Unidades.some(function (unidade) {
                eleicoes = unidade.Eleicoes.filter(function (eleicao) {
                    return eleicao.Codigo == codigo;
                });
                if (eleicoes && eleicoes.length)
                    return true;
                return false;
            });
            if (eleicoes && eleicoes.length)
                return true;
            return false;
        });

        if (eleicoes && eleicoes.length)
            return eleicoes[0];
        return null;
    }

    var setEleicaoAtual = function (eleicao) {
        eleicao.PrazosEtapasObj.forEach(function (x) {
            x.DataProposta = new Date(x.DataProposta);
        });
        self.eleicaoAtual = eleicao;
        updateFilter();
    }

    var updateFilter = function () {
        self.statusSelecionado = self.eleicoesFiltro.filter(function (x) {
            return (x.Label == 'Abertas' && !self.eleicaoAtual.DataFechamento) || (x.Label == 'Fechadas' && self.eleicaoAtual.DataFechamento);
        })[0];

        self.unidadeSelecionada = self.statusSelecionado.Unidades.filter(function (x) {
            return x.Unidade.Codigo == self.eleicaoAtual.CodigoUnidade;
        })[0];

        self.gestaoSelecionada = self.unidadeSelecionada.Eleicoes.filter(function (x) {
            return x.Codigo == self.eleicaoAtual.Codigo;
        })[0];
    }

    self.alteraGestao = function () {
        if (self.gestaoSelecionada && self.gestaoSelecionada.Codigo) {
            self.codEleicao = self.gestaoSelecionada.Codigo;
            sharedDataService.setCodigoEleicao(self.gestaoSelecionada.Codigo);
            $state.go(stateRedirect, { codEleicao: self.gestaoSelecionada.Codigo }, { reload: true });
        }
    }

    loadFiltroEleicoes();

    // \************* COMPARTILHADO *************

}]);
