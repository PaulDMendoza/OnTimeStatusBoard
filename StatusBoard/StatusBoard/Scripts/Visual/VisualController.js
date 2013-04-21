var Visual;
(function (Visual) {
    var VisualController = (function () {
        function VisualController() {
        }
        VisualController.prototype.init = function () {
            var poller = new Visual.DataPoller();
            var newsTicker = new Visual.NewsTicker();
            var defectsWorkflowSteps = new Visual.DefectsWorkflowSteps();
            poller.ListenForData(function (data) {
                newsTicker.poll(data);
                defectsWorkflowSteps.poll(data);
            });
            poller.StartPolling();
        };
        return VisualController;
    })();
    Visual.VisualController = VisualController;    
})(Visual || (Visual = {}));
$(function () {
    var controller = new Visual.VisualController();
    controller.init();
});
