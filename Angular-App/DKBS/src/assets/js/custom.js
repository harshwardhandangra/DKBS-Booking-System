

jQuery(document).ready(function() {

   
    jQuery('.show-hide-sidebar').click(function(e) {
        e.preventDefault();
        jQuery('body').toggleClass('collapsed-sidebar');

        if (jQuery('body').hasClass('collapsed-sidebar')) {
            jQuery('#sidebar .nav-submenu').css('display', 'none');
			
			
        }
        else {
            jQuery('#sidebar .active').parent().find('.nav-submenu').css('display', 'block');
			
		}
    });
			
	$(".subnav-title").click(function() {
		if ( $(this).hasClass('current') ) {
        $(this).removeClass('current');
		} else {
			$('li a.current').removeClass('current');
			$(this).addClass('current');    
		}
		$(".dropdown-subnav").hide(500);
		
	if($(this).hasClass("current"))
	    $(this).parent().children(".dropdown-subnav").slideToggle("slow"); });
	
	$('ul.dropdown-subnav li a.active_submenu').parents('ul.dropdown-subnav').addClass("active");



	//////////////////////////
    // SIDEBAR SUBMENU ///////
    //////////////////////////
	jQuery('#sidebar .nav#main-nav > li > ul').each(function() {
		var _t = jQuery(this);
		var _li = _t.parent();
		var _a = _li.find('> a');

		_a.click(function(e) {
			e.preventDefault();

            var s_width = jQuery( window ).width();
            if ((s_width >= 768) && (!jQuery('body').hasClass('collapsed-sidebar')) ) {
                if (!_a.hasClass('active')) {
                    jQuery('#sidebar .nav a.active').removeClass('active').parent().find('> ul').slideToggle();
                }

    			_a.toggleClass('active');
    			_t.slideToggle();
            }
		})

        if (_t.find('.active_submenu').length > 0) {
            _a.click();
        }
	});

});

$( ".sidebar_scroll" ).wrap( "<div class='sidebarscroll'></div>" );

