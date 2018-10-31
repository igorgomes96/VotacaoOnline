angular.module('cipaApp').filter('ellipsis', [function() {
	return function(text, leftSize, rightSize, enabled) {
		if (leftSize === undefined || leftSize === null) leftSize = 10;
		if (rightSize === undefined || rightSize=== null) leftSize = 0;
		if (enabled === undefined || enabled === null) enabled = true;
		if (!enabled) return text;
		if (!text || text.length < leftSize + rightSize + 4) return text;
		var left = text.substring(0, leftSize);
		var right = text.substring(text.length - rightSize, text.length);
		return left + '...' + right;
	}
}]);