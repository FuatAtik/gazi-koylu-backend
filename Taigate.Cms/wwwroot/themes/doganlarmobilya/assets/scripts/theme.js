(function ($) {
  "use strict";
  // zoom-image-head
  (function () {
    ymaps.ready(function () {
      var myMap = new ymaps.Map("map", {
        center: [40.947382, 29.123840],
        zoom: 15,
        /**
         * Please note that in the API 2.1, the map is created with controls by default.
         * If you don't need to add them to the map, pass an empty array in the "controls" field in its parameters.
         */
        controls: [],
      });

      var myPlacemark = new ymaps.Placemark(
        myMap.getCenter(),
        {
          balloonContentBody: [
            "<address>",
            "<strong>Doganlar Mobilya</strong>",
            "<br/>",
            '<a href="https://www.google.com/maps/dir//Küçükyalı,+Doğtaş+Exclusive+Küçükyalı,+İdealtepe+Mah,+Rıfkı+Tongsir+Cd.+No:107,+34841+Maltepe%2Fİstanbul/@40.9473274,29.1241823,18z/data=!4m16!1m6!3m5!1s0x14cac68ef861102d:0xa0965c07355fb98f!2zRG_En3RhxZ8gRXhjbHVzaXZlIEvDvMOnw7xreWFsxLE!8m2!3d40.947343!4d29.1238744!4m8!1m0!1m5!1m1!1s0x14cac68ef861102d:0xa0965c07355fb98f!2m2!1d29.1238744!2d40.9473429!3e3">Yol Tarifi Al</a>',
            "</address>",
          ].join(""),
        },
        {
          preset: "islands#redDotIcon",
        }
      );

      myMap.geoObjects.add(myPlacemark);
    });
  })();

  $(window).scroll(function () {
    if ($(this).scrollTop() > 500) {
      $(".sticky-contact").css({
        visibility: "visible",
      });
    }
  });

})(jQuery);
