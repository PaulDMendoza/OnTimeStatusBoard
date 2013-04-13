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
                window.console.log(data);
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
