var Visual;
(function (Visual) {
    var VisualController = (function () {
        function VisualController() {
        }
        VisualController.prototype.init = function () {
            var poller = new Visual.DataPoller();
            poller.ListenForData(function (data) {
                window.console.log(data);
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
