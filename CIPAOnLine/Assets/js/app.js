angular.module('cipaApp', ['ui.router', 'uiCpfMaskApp']);

//Verifica se está autenticado
// angular.module('cipaApp').run(function() {

// 	if (!window.sessionStorage.getItem('user')) {
// 		window.location.replace('Assets/components/autenticacao/autenticacao.html' + window.location.hash);
// 	}

// });

//Loader.css
// var exibeLoader = function() {
//     $('body').append('<div class="loader"><div class="ball-scale-multiple"><div></div><div></div><div></div></div></div>');
// }
// var ocultaLoader = function() {
//     $('.loader').remove();
// }


var exibeSpinner = function(selector) {
	$(selector).parent().append('<div class="loading-spinner"><i class="fa fa-spinner fa-pulse fa-lg fa-fw"></i>Carregando...</div>');
	$(selector).hide();
	return function() {
		var spinner = $('div.loading-spinner');
		$(selector).show();
		$(selector).parent().find(spinner).remove();
	};
}


function addDays(date, days) {
  var result = new Date(date);
  result.setDate(result.getDate() + days);
  return result;
}

$(document).ready(function() {
	$(document).on('click', 'a.sobre-mim', function(ev) {
		$(ev.target).next('small.sobre-mim').toggle('fast');
	});
});	


