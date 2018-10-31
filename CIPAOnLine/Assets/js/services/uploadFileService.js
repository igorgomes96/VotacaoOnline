angular.module('cipaApp').service('uploadFileService', ['messagesService', function(messagesService) {

	var self = this;

	self.sendFile = function(url, formData, token) {

        return settings = {
          "async": true,
          "crossDomain": true,
          "url": url,
          "method": "POST",
          "headers": {
            "authorization": "Basic " + token,
            "cache-control": "no-cache"
          },
          "processData": false,
          "contentType": false,
          "mimeType": "multipart/form-data",
          "data": formData
        };

	}

}]);