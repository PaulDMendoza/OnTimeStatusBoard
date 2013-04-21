/// <reference path="_references.ts" />

// Module
module Visual {

    // Class
    export class VisualController {
        // Constructor
        constructor() {
            
        }

        init() {
            
            var poller = new Visual.DataPoller();
            
            var newsTicker = new Visual.NewsTicker();
            var defectsWorkflowSteps = new Visual.DefectsWorkflowSteps();

            poller.ListenForData((data: DataPollerResponse) => {
                
                newsTicker.poll(data);
                defectsWorkflowSteps.poll(data);
            });
            poller.StartPolling();

            
            
        }
    }
}

$(function () {
    // Local variables
    var controller: Visual.VisualController = new Visual.VisualController();
    controller.init();
});
