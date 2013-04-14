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
            poller.ListenForData((data: DataPollerResponse) => {
                for (var i = 0; i < data.RecentDefects.length; i++) {
                    var defect = data.RecentDefects[i];
                    $('#statusBoard').append('<br/><span style="color: #' + defect.priority.color + '" >Name: ' + defect.name + ' Created: ' + defect.created_date_time + "</span>");
                }

                
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
