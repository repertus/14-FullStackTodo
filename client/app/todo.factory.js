(function() {
    'use strict';

    angular
        .module('myApp')
        .factory('todoFactory', todoFactory);

    todoFactory.$inject = ['$http', '$q'];

    /* @ngInject */
    function todoFactory($http, $q) {
        var service = {
            getTodo: getTodo
            // addTodo: addTodo
        };
        return service;

        ////////////////

        function getTodo() {
        	var defer = $q.defer();
            $http.get('http://localhost:64005/api/Todos').then(
            	function(response) {
                   if (typeof response.data === 'object') {
                       defer.resolve(response.data);
                   } else {
                       defer.reject(response.data);
                   }
               },
               function(error) {
                   defer.reject(error);
               }
           );

           return defer.promise;
        }

//         function addTopSpots (topspot) {
//         	var defer = $q.defer();
        	
//             $http.post('http://localhost:52160/api/TopSpots', topspot).then(
//             	function(response) {
// 	                defer.resolve(response.data);
//                },
//                function(error) {
// 	               defer.reject(error);
//                }
//            );

//            return defer.promise;
//         }
    }
})();