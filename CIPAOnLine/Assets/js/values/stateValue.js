angular.module('cipaApp').value('stateValue', {
	states: {
		Administrador: [
			{
				state: 'navContainer.home',
				label: 'Início',
				active: false,
				icon: 'fa fa-home'
			},
			{
				state: 'navContainer.dashboards',
				label: 'Dashboard',
				active: false,
				icon: 'fa fa-bar-chart'
			},
			{
				state: 'navContainer.eleicoes',
				label: 'Eleições',
				active: false,
				icon: 'fa fa-tags'
			},
			{
				state: 'navContainer.cadastroFuncionarios',
				label: 'Funcionários',
				active: false,
				icon: 'fa fa-address-card'
			},
			{
				label: 'Validação de Candidaturas',
				active: false,
				icon: 'fa fa-thumbs-o-up',
				children: [
					{
						state: 'navContainer.pendentes',
						label: 'Pendentes',
						active: false,
					},
					{
						state: 'navContainer.aprovados',
						label: 'Aprovadas',
						active: false,
					}
					,
					{
						state: 'navContainer.reprovados',
						label: 'Reprovadas',
						active: false,
					}
				]
			},
			{
				state: 'navContainer.emails',
				label: 'Comunicados',
				active: false,
				icon: 'fa fa-envelope'
            },
            {
                state: 'navContainer.administradores',
                label: 'Administradores',
                active: false,
                icon: 'fa fa-users'
            },
            {
                state: 'navContainer.baseGeral',
                label: 'Base Geral',
                active: false,
                icon: 'fa fa-database'
            }
		],
		Eleitor: [
			{
				state: 'navContainer.home',
				label: 'Início',
				active: false,
				icon: 'fa fa-home'
			},
			{
				state: 'navContainer.candidaturas',
				label: 'Candidatura',
				active: false,
				icon: 'fa fa-address-card'
			},
			{
				state: 'navContainer.votacoes',
				label: 'Votação',
				active: false,
				icon: 'fa fa-thumbs-o-up'
			}
		]
	}
});