var Visual;
(function (Visual) {
    var DataPoller = (function () {
        function DataPoller() {
            this._url = "/Visual/Data";
            this._listeners = [];
        }
        DataPoller.prototype.StartPolling = function () {
            this.Poll();
        };
        DataPoller.prototype.Poll = function () {
            var _this = this;
            var url = this._url;
            $.ajax({
                url: url,
                dataType: 'json',
                type: 'POST',
                success: function (response) {
                    for(var i = 0; i < _this._listeners.length; i++) {
                        var item = _this._listeners[i];
                        item(response);
                    }
                },
                error: function (err, x, y) {
                    console.log('Error: ' + err);
                }
            });
        };
        DataPoller.prototype.ListenForData = function (callback) {
            this._listeners.push(callback);
        };
        return DataPoller;
    })();
    Visual.DataPoller = DataPoller;    
})(Visual || (Visual = {}));
