document.addEventListener("DOMContentLoaded", function () {
     let lastScrollTop = 0;
     const navbar = document.querySelector(".navbar");
     const sidebar = document.getElementById("offcanvasSidebar");
     const menuButton = document.querySelector(".navbar-toggler");

     window.addEventListener("scroll", function () {
          let scrollTop = window.scrollY || document.documentElement.scrollTop;

          if (scrollTop > lastScrollTop) {
               // Scrolling Down - Hide Navbar
               navbar.style.transform = "translateY(-100%)";
          } else {
               // Scrolling Up - Show Navbar
               navbar.style.transform = "translateY(0)";
          }

          lastScrollTop = scrollTop;
     });

     document.addEventListener("DOMContentLoaded", function () {
          var myCarousel = document.querySelector("#heroCarousel");
          var carousel = new bootstrap.Carousel(myCarousel, {
               interval: 5000, // Slide every 5 seconds
               pause: "hover"
          });
     });

     // Ensure Sidebar Button Visibility Works Properly
     if (sidebar && menuButton) {
          sidebar.addEventListener("shown.bs.offcanvas", function () {
               menuButton.style.opacity = "0";
          });

          sidebar.addEventListener("hidden.bs.offcanvas", function () {
               menuButton.style.opacity = "1";
          });
     }
});

