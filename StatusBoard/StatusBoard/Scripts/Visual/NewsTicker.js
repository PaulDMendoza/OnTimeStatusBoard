var Visual;
(function (Visual) {
    var NewsTicker = (function () {
        function NewsTicker() {
            this.self = this;
            $('#scrollingNewsTicker').vTicker({
                speed: 500,
                pause: 4000,
                animation: 'fade',
                mousePause: false,
                showItems: 2
            });
        }
        NewsTicker.prototype.poll = function (responseData) {
        };
        return NewsTicker;
    })();
    Visual.NewsTicker = NewsTicker;    
})(Visual || (Visual = {}));
