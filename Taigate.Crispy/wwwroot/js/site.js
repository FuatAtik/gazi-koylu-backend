// Lethe

var CrispyAdmin = {
    loadWaiting: false,
    test:'',

    init: function (test) {
        this.loadWaiting = false;
    },

    setLoadWaiting: function (display) {
        this.displayAjaxLoading(display);
        this.loadWaiting = display;
    },
    displayAjaxLoading: function (display) {
        //display loader
    },

    //add a product to the cart/wishlist from the product details page
    testpost: function (urladd, formselector) {
        this.displayAjaxLoading(true);
        $.ajax({
            cache: false,
            url: urladd,
            data: $(formselector).serialize(),
            type: "POST",
            success: this.success_process,
            complete: this.resetLoadWaiting,
            error: this.ajaxFailure
        });
    },
    success_process: function (response) {
        // success
    },

    resetLoadWaiting: function () {
        this.displayAjaxLoading(false);
    },

    ajaxFailure: function (err) {
        alert('Bir şeyler ters gitti');
    }
};
