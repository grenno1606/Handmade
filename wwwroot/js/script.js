let searchIcon = document.querySelector("#search-icon");
let searchForm = document.querySelector(".search-form");

searchIcon.onclick = () => {
  searchIcon.classList.toggle("fa-times");
  searchForm.classList.toggle("active");
};
window.onscroll = () => {
  searchIcon.classList.remove("fa-times");
  searchForm.classList.remove("active");
};

// ---------------------------------------------

var swiper = new Swiper(".review-slider", {
  spaceBetween: 20,
  centeredSlides: true,

  pagination: {
    el: ".swiper-pagination",
    clickable: true,
  },
  autoplay: {
    delay: 2200,
    disableOnInteraction: false,
  },
  breakpoints: {
    640: {
      slidesPerView: 1,
    },
    768: {
      slidesPerView: 3,
    },
  },
  loop: true,
  grabCursor: true,
});
