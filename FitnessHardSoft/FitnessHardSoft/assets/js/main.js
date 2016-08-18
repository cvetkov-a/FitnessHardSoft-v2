(function() {
  "use strict";

  let main = function() {
    jQuery('.nav > ul > li > a').click(function(){
      jQuery('html, body').animate({
          scrollTop: jQuery(jQuery(this).attr('href')).offset().top
      }, 500);

      return false;
    });

    let height = (jQuery('.slider').height() + jQuery('header').height()) - jQuery('.navBar').height()

    jQuery(window).scroll(function() {
      if (jQuery(this).scrollTop() >= height) {
        jQuery('body > section').removeClass('s-l')

        jQuery('.navBar').css({
          'position': 'fixed',
          'bottom': 'auto',
          'top': 0,
          'background-color': '#000000'
        })
      }
      else{
        jQuery('body > section').addClass('s-l')

        jQuery('.navBar').css({
          'position': 'absolute',
          'bottom': 0,
          'top': 'auto',
          'background-color': 'rgba(0, 0, 0, 0.45)'
        })
      }
    })

    let clickCloseButton = function() {
      jQuery('header .barSocial').fadeOut()
    }

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

    jQuery('.cls').click(clickCloseButton)
    jQuery('.navbar-toggle').click(toggleNavbar)
    jQuery('.navbartogg').click(toggleNavbar2)
  }

  new WOW().init()

  jQuery(document).ready(main)

})();