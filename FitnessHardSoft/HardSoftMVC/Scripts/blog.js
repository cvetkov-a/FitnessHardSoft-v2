(function() {
  "use strict";

  let main = function() {

    jQuery(window).scroll(function() {
      if (jQuery(this).scrollTop() >= 50) {
        jQuery('body > section').removeClass('s-l')

        jQuery('.navBar').css({
          'position': 'fixed',
          'bottom': 'auto',
          'top': 0,
        })
      }
      else{
        jQuery('body > section').addClass('s-l')
      }
    })

    let toggleNavbar = function() {
      jQuery('.sideBar').animate({
        'left': 0
      })

      jQuery('#home').animate({
        'left': '220px'
      })
    }

    let toggleNavbar2 = function() {
      jQuery('.sideBar').animate({
        'left': '-220px'
      })

      jQuery('#home').animate({
        'left': 0
      })
    }

    jQuery('.navbar-toggle').click(toggleNavbar)
    jQuery('.navbartogg').click(toggleNavbar2)
  }

  new WOW().init()

  jQuery(document).ready(main)

})();