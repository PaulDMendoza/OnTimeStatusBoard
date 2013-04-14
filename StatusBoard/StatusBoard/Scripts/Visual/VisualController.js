var Visual;
(function (Visual) {
    var VisualController = (function () {
        function VisualController() {
        }
        VisualController.prototype.init = function () {
            var poller = new Visual.DataPoller();
            poller.ListenForData(function (data) {
                for(var i = 0; i < data.RecentDefects.length; i++) {
                    var defect = data.RecentDefects[i];
                    $('#statusBoard').append('<br/><span style="color: #' + defect.priority.color + '" >Name: ' + defect.name + ' Created: ' + defect.created_date_time + "</span>");
                }
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
