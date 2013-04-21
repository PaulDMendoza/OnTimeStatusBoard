/// <reference path="_references.ts" />

module Visual {

    export interface DataPollerResponse {
         RecentDefects : OnTime.Defect[];   
    }
    
    // Class
    export class DataPoller  {
        
        public self: DataPoller;
        private _url: string = "/Visual/Data";
        private _listeners: { (param: DataPollerResponse): void; }[] = [];

        constructor () {
            
        }

        StartPolling() {
            //this.Poll();
            //setInterval(() => {
            //    this.Poll();
            //}, 1000 * 60 * 10);
        }

        Poll() {
            var url = this._url;
            $.ajax({
                url: url,
                dataType: 'json',
                type: 'POST',
                success: (response: DataPollerResponse) => {
                    for (var i = 0; i < this._listeners.length; i++) {
                        var item = this._listeners[i];
                        item(response);
                    }
                },
                error: (err, x, y) => {
                    console.log('Error: ' + err);
                    }
            });            
        }

        ListenForData(callback: (DataPollerResponse) => void ) {
            this._listeners.push(callback);
        }

    }
}
