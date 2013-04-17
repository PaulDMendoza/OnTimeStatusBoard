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
            $('#scrollingNewsTicker ul').empty();
            $('#scrollingNewsTicker ul').append('<li></li>');
            for(var i = 0; i < responseData.RecentDefects.length; i++) {
                var defect = responseData.RecentDefects[i];
                $('#scrollingNewsTicker ul').append('<li>' + defect.name + '</li>');
            }
        };
        return NewsTicker;
    })();
    Visual.NewsTicker = NewsTicker;    
})(Visual || (Visual = {}));
