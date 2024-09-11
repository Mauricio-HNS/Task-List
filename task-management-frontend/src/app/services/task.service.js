// app/services/task.service.js
angular.module('taskApp').factory('TaskService', function($http) {
    var baseUrl = '/api/tasks';

    return {
        getTasks: function() {
            return $http.get(baseUrl);
        },
        addTask: function(task) {
            return $http.post(baseUrl, task);
        },
        updateTask: function(task) {
            return $http.put(baseUrl + '/' + task.id, task);
        },
        deleteTask: function(taskId) {
            return $http.delete(baseUrl + '/' + taskId);
        }
    };
});
