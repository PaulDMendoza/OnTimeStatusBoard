/// <reference path="_references.ts" />

module Visual {


    // Class
    export class NewsTicker {

        public self: NewsTicker;

        constructor() {
            this.self = this;

            $('#scrollingNewsTicker').vTicker({
                speed: 500,
                pause: 4000,
                animation: 'fade',
                mousePause: false,
                showItems: 2
            });
        }

        poll(responseData: Visual.DataPollerResponse) {
            //$('#scrollingNewsTicker ul').empty();
            //$('#scrollingNewsTicker ul').append('<li></li>');
            //for (var i = 0; i < responseData.RecentDefects.length; i++) {
            //    var defect = responseData.RecentDefects[i];
            //    $('#scrollingNewsTicker ul').append('<li>' + defect.name + '</li>');
            //}
        }
    }
}
