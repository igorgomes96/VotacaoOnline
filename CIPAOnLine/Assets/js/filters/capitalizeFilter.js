angular.module('cipaApp').filter('capitalize', function() {

    return function(input) {
    	var retorno = '';
        var inWords = ['ana', 'eva'];
    	if (input) {
    		input.split(' ').forEach(function(x) {
    			if (x.length > 3 || inWords.indexOf(x.toLowerCase()) > -1)
    				retorno += x.charAt(0).toUpperCase() + x.substr(1).toLowerCase() + ' ';
    			else {
    				var stopWords = ['de', 'da', 'das', 'do', 'dos', 'e', 'em', 'no', 'na', 'a', 'o'];
    				var temp = x.toLowerCase();
    				if (stopWords.indexOf(temp) > -1)
    					retorno += x.toLowerCase() + ' ';
    				else 
    					retorno += x + ' ';
    			}
    		});
    	} 
    	return retorno.trim();
    }
});