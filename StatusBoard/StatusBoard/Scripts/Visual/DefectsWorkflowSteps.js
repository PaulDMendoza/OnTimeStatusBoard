var Visual;
(function (Visual) {
    var DefectsWorkflowSteps = (function () {
        function DefectsWorkflowSteps() {
            this.self = this;
            this.$workflowDiv = $('#defectsWorkflowSteps');
        }
        DefectsWorkflowSteps.prototype.poll = function (responseData) {
            var $table = $('tbody', this.$workflowDiv);
            console.log($table.length);
            var workflowStates = Enumerable.From(responseData.RecentDefects).GroupBy(function (s) {
                return s.workflow_step.id;
            }, function (s) {
                return s;
            }).ToArray();
            for(var i = 0; i < workflowStates.length; i++) {
                var defect = workflowStates[i].source[0];
                console.log(defect.workflow_step);
                var $tr = $('<tr></tr>');
                var $tdName = $('<td>' + defect.workflow_step.name + '</td>');
                var $tdCount = $('<td>' + workflowStates[i].source.length + '</td>');
                $tr.append($tdName);
                $tr.append($tdCount);
                $table.append($tr);
            }
        };
        return DefectsWorkflowSteps;
    })();
    Visual.DefectsWorkflowSteps = DefectsWorkflowSteps;    
})(Visual || (Visual = {}));
