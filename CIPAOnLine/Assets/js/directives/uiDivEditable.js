angular.module('cipaApp').directive('uiDivEditable', function() {

	function link(scope, element, attrs) {

	    var container = $("<div class='editable'></div>");
	    container[0].contentEditable = true;
	    $(element).append(container);

	    scope.$watch('content', function(valor) {
	    	$(container).empty();
	    	$(container).append($(valor));
	    });

	    $(container).on('keyup', function() {
	    	scope.content = $(this).html();
	    });

	    $(container).on('blur', function() {
	    	scope.$apply();
	    });

	}

	return {
		scope: {
			content: '=',
			update: '&'
		},
		restrict: 'EA',
		link: link,
		controller: ['$scope', function($scope) {
			$scope.update = function() {
				$scope.apply();
			}
		}]
	}
});