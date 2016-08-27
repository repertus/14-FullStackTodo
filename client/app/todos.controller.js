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

		// Matrix for table population testing
  //   	var todos = [
		// 	{
		// 		'task': 'hello',
		// 		'priority':'c_low'
		// 	},
		// 	{
		// 		'task': 'bye',
		// 		'priority':'b_medium'
		// 	},
		// 	{
		// 		'task': 'zebra',
		// 		'priority':'b_medium'
		// 	},
		// 	{
		// 		'task': 'horse',
		// 		'priority':'a_high'
		// 	}
		// ];

        activate();

        ////////////////

        function activate() {
        	// Adds the user input to the table
			// vm.addNew = function() {
			// 	vm.todos.push({ 'task' : vm.task, 'priority' : vm.priority});
			// 	// Clears input after submission
	  //  			vm.task = null;
			// };


	    	todoFactory.getTodo().then(
	    		function (data) {
	    			vm.todos = data;
	    		},
	    		function(error) {
	                console.log(error);
	    		});





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

		  	// Removes the user input from the todo list
			vm.removeRow = function(todo){				
				var index = -1;		
				var todoArr = eval( vm.todos );
				for( var i = 0; i < todoArr.length; i++ ) {
					if( todoArr[i] === todo ) {
						index = i;
						break;
					}
				}	
				vm.todos.splice( index, 1 );		
			};

			// Edits the user input for the todo list
			vm.editTask = {};

			vm.editRow = function(){
				vm.editTask = true;
			};

			vm.updateRow = function() {
				vm.editTask = false;
			};
        }
    }
})();
