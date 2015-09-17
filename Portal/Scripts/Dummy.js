
//<![CDATA[
$(window).load(function () {
    function getRandomOptions() {
        // this could obviously be a lot more random
        var doIt = Math.floor(Math.random() * 1001) % 2 == 0;
        // set random options supported by the goto method
        // http://www.drewgreenwell.com/projects/metrojs#liveTileMethods
        return {
            index: "next",
            delay: 3000,
            animationDirection: doIt ? 'forward' : 'backward',
            direction: doIt ? 'vertical' : 'horizontal'
        };
    }
    // setup the tile and then call goto on it the first time
    $("#tile3").liveTile({
        animationComplete: function (tileData) {
            $(this).liveTile("goto", getRandomOptions());
        }
    }).liveTile("goto", getRandomOptions());


});
