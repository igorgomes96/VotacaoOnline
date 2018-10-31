angular.module("uiCpfMaskApp", []);
angular.module("uiCpfMaskApp").directive("uiCpfMask", function ($filter) {
	return {
		require: "ngModel",
		link: function (scope, element, attrs, ctrl) {

			var _formatCpf = function (cpf) {
				if (!cpf) return cpf;
				cpf = cpf.replace(/[^0-9]+/g, "");
				if(cpf.length > 3) {
					cpf = cpf.substring(0,3) + "." + cpf.substring(3);
				}

				if(cpf.length > 7) {
					cpf = cpf.substring(0,7) + "." + cpf.substring(7,12);
				}

				if (cpf.length > 11) {
					cpf = cpf.substring(0,11) + "-" + cpf.substring(11, 14);
				}
				return cpf;
			};

			scope.$watch(attrs.ngModel, function (v) {
				//console.log('teste');
                ctrl.$setViewValue(_formatCpf(ctrl.$viewValue));
                ctrl.$render();
            });

			// element.on('change', function() {
			// 	console.log('change');
			// });

			element.on("keyup", function () {
				ctrl.$setViewValue(_formatCpf(ctrl.$viewValue));
				ctrl.$render();
			});

			ctrl.$parsers.push(function (value) {
				if (value.length === 14) {
					return value.replace(/[^0-9]+/g,'');
				}
			});

			/*ctrl.$formatters.push(function (value) {
				return $filter("date")(value, "dd/MM/yyyy");
			});*/
		}
	};
});