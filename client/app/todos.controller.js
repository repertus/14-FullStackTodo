(function() {
    'use strict';

    angular
        .module('myApp')
        .controller('TodoController', TodoController);

    TodoController.$inject = ['$filter', 'todoFactory'];

    /* @ngInject */
    function TodoController($filter, todoFactory) {
        var vm = this;
        var todos = {};
        var edit = {};

        activate();

        ////////////////

        function activate() {
        	// Adds the user input to the table
			vm.addNew = function() {
				vm.saving = true;
				todoFactory.addTodo(vm.newTodo).then(
					function() {
						vm.saving = false;
						alert('Successfully added');
						// Clears input after submission
						vm.newTodo.task = null;
						//Called the get function to insure the list is in sync 
						//with the database index
						todoFactory.getTodo().then(
				    		function (data) {
				    			vm.todos = data;
				    		},
				    		function(error) {
				                alert('Error getting todo list');
			    		});
					},
					function() {
						alert('Error saving todo')
					}
				);
			};

			// Initiates the todo list from the dB server
	    	todoFactory.getTodo().then(
	    		function (data) {
	    			vm.todos = data;
	    		},
	    		function(error) {
	                alert('Error getting todo list');
    		});

	    	// Removes the user input from the todo list
			vm.removeRow = function(todo){				
				vm.saving = true;
				// deletion = angular.toJson(todo);
				todoFactory.deleteTodo(todo).then(
					function() {
						vm.saving = false;
						alert('Successfully deleted');
						//Called the get function to insure the list is in sync 
						//with the database index
						todoFactory.getTodo().then(
				    		function (data) {
				    			vm.todos = data;
				    		},
				    		function(error) {
				                alert('Error getting todo list');
			    		});
					},
					function() {
						alert('Error deleting todo')
					}
				);
			};

	    	// Updates the user input from the todo list
			vm.editRow = function(id, todo){				
				vm.saving = true;
				edit = angular.toJson(todo); //Removes the $$hashkey syntax
				todoFactory.editTodo(id, edit).then(
					function() {
						vm.saving = false;
						alert('Successfully updated');
						//Called the get function to insure the list is in sync 
						//with the database index
						todoFactory.getTodo().then(
				    		function (data) {
				    			vm.todos = data;
				    		},
				    		function(error) {
				                alert('Error getting todo list');
			    		});
					},
					function() {
						alert('Error updating todo')
					}
				);
			};





			// Forces the list to only ve re-sorted vertically through drag and drop plug-in
			vm.sortableOptions = {
				'ui-floating': true
			};


			//Sorting functions since orderBy() needs to run in controller when drag and drop plugin is installed
			vm.todos = todos;

		 	console.log(vm.todos);
			vm.sortButton = function(sortList) {
		    console.log(sortList);
		    vm.reverse = (sortList !== null && vm.sortList === sortList) ? !vm.reverse : false;
		    vm.sortList = sortList;
		    vm.todos = $filter('orderBy')(vm.todos, vm.sortList, vm.reverse);
		  	};
        }
    }
})();
