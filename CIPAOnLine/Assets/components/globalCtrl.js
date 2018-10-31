angular.module('cipaApp').controller('globalCtrl', ['$state', function($state) {

	var self = this;

	self.currentState = $state;

}])