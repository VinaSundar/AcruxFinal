
//$(function () {
//    socketManager.register();
//});

//Global variables
var _socket;
var _socketServer = "ws://acrux-hl.australiaeast.cloudapp.azure.com:3000/";

//var _socketServer = "ws://acrux01.eastus.cloudapp.azure.com:3000/";
var timer;

var socketManager = {
    registersocketcus:  function(){
        _socket = new WebSocket(_socketServer);
        _socket.onopen = console.log('connected');

        //_socket.onerror = socketManager.onerror(event.data);
       
        _socket.addEventListener('message', function (event) {
            socketManager.onmessage(event.data);          
        }); 
        
        //var data = '{"$class":"fis.global.smartbond.OfferNotification","offer":"resource:fis.global.smartbond.Offer#0aaa3d76-e8f7-44bb-8c19-180877eef16f","eventId":"d6082749db55cf1f1b8fa4f0e3a4d9bbffe5faff1c0efd01dc2bfb685a745c27#0","timestamp":"2018-05-10T06:09:27.675Z"}';       
        //socketManager.onmessage(data);
    },
    onsend:  function (data) {

    },
    onclose:  function () {

    },
    onmessage: function (data) {
        console.log(data);
        //Render HTML
        notificationHtml.getEventInfo(data);
    },
    onerror: function (message) {
        //console.log(message);
        //if (_socket.readyState == WebSocket.OPEN)
        //    _socket.close();

        //socketManager.register();
    }
}

var notificationHtml = {
    refreshgrid: function (data) {
       
        var element = $('#notify');
       
        console.log(data);
        if (data !== 'undefined' && data !== null) {

            if (data.BorrowTraderUsername === _user
                || data.LendTraderUsername === _user) {
                var $html = '<li><div class="block"><div class="block_content"><div class="byline"><span>' + new Date() + '</span></div><p class="excerpt">' + data.BorrowOfferId + '</p></div></div> </li>';
                console.log($html);

                element.append($html);
            }

        }
                     
    },
    getEventInfo: function(data) {
       
        var _eventData = JSON.parse(data);
        var _offer = _eventData.offer.replace("resource:fis.global.smartbond.Offer#", "");
     
        $.ajax({
            url: _url + '?offer=' + _offer ,
            cache: false,
            contentType: 'application/json',
            type: 'GET',                    
        }).done(function (data) {
            notificationHtml.refreshgrid(data) 
            //$(this).addClass("done");
        });
    }
}

function init_chart_doughnut() {

    if (typeof (Chart) === 'undefined') { return; }

    console.log('init_chart_doughnut');

    if ($('.canvasDoughnut').length) {

        var chart_doughnut_settings = {
            type: 'doughnut',
            tooltipFillColor: "rgba(51, 51, 51, 0.55)",
            data: {
                labels: [
                    "Expired",
                    "Open",
                    "Matched"
                ],
                datasets: [{
                    data: [30, 30, 40],
                    backgroundColor: [
                        "#BDC3C7",
                        "#9B59B6",
                        "#E74C3C",
                        "#26B99A",
                        "#3498DB"
                    ],
                    hoverBackgroundColor: [
                        "#CFD4D8",
                        "#B370CF",
                        "#E95E4F",
                        "#36CAAB",
                        "#49A9EA"
                    ]
                }]
            },
            options: {
                legend: false,
                responsive: false
            }
        }

        $('.canvasDoughnut').each(function () {

            var chart_element = $(this);
            var chart_doughnut = new Chart(chart_element, chart_doughnut_settings);

        });

    }

}

