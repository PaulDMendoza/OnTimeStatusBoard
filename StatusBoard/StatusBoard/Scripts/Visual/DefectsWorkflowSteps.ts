/// <reference path="_references.ts" />

module Visual {
    
    // Class
    export class DefectsWorkflowSteps {

        public self: DefectsWorkflowSteps;
        
        public $workflowDiv: JQuery;

        constructor() {
            this.self = this;
            this.$workflowDiv = $('#defectsWorkflowSteps');
        }

        poll(responseData: Visual.DataPollerResponse) {
            
            var $table = $('tbody', this.$workflowDiv);

            console.log($table.length);

            var workflowStates = Enumerable.From(responseData.RecentDefects)
                .GroupBy(s => s.workflow_step.id, s => s)
                .ToArray();

            for (var i = 0; i < workflowStates.length; i++) {
                var defect : OnTime.MiniDefect = workflowStates[i].source[0]; // Get first defect in group
                console.log(defect.workflow_step);
                var $tr = $('<tr></tr>');
                var $tdName = $('<td>' + defect.workflow_step.name + '</td>');
                var $tdCount = $('<td>' + workflowStates[i].source.length + '</td>');
                $tr.append($tdName);
                $tr.append($tdCount);
                $table.append($tr);
            }
        }
    }
}
