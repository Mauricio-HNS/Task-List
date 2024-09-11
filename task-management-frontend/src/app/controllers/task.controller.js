// app/controllers/task.controller.js
angular.module('taskApp').controller('TaskController', function($scope, TaskService) {
    $scope.tasks = [];
    $scope.newTask = {};

    $scope.addTask = function() {
        TaskService.addTask($scope.newTask).then(function(response) {
            $scope.tasks.push(response.data);
            $scope.newTask = {};
        });
    };

    $scope.updateTask = function(task) {
        TaskService.updateTask(task).then(function(response) {
            // Handle update response
        });
    };

    $scope.deleteTask = function(taskId) {
        TaskService.deleteTask(taskId).then(function() {
            $scope.tasks = $scope.tasks.filter(task => task.id !== taskId);
        });
    };

    // Initial load
    TaskService.getTasks().then(function(response) {
        $scope.tasks = response.data;
    });
});
