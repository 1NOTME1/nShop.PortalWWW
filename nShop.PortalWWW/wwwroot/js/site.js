document.addEventListener('DOMContentLoaded', function () {
    const toggleDarkModeButton = document.getElementById('toggle-dark-mode');
    const body = document.body;

    if (toggleDarkModeButton) {
        console.log('Dark mode toggle button found');
        toggleDarkModeButton.addEventListener('click', () => {
            body.classList.toggle('dark-mode');
            console.log('Dark mode toggle clicked');

            if (body.classList.contains('dark-mode')) {
                localStorage.setItem('dark-mode', 'true');
                console.log('Dark mode enabled');
            } else {
                localStorage.setItem('dark-mode', 'false');
                console.log('Dark mode disabled');
            }
        });

        if (localStorage.getItem('dark-mode') === 'true') {
            body.classList.add('dark-mode');
            console.log('Dark mode loaded from localStorage');
        }
    } else {
        console.log('Dark mode toggle button not found');
    }
});


const slides = document.querySelectorAll('.slide');
let currentSlide = 0;

function showSlide(index) {
    slides.forEach((slide, idx) => {
        slide.style.display = idx === index ? 'block' : 'none';
        slide.style.transition = 'opacity 0.5s ease';
        slide.style.opacity = idx === index ? 1 : 0;
    });
}

showSlide(currentSlide);

const prevButton = document.querySelector('.prev-button');
const nextButton = document.querySelector('.next-button');

prevButton.addEventListener('click', () => {
    currentSlide = (currentSlide === 0) ? slides.length - 1 : currentSlide - 1;
    showSlide(currentSlide);
});

nextButton.addEventListener('click', () => {
    currentSlide = (currentSlide === slides.length - 1) ? 0 : currentSlide + 1;
    showSlide(currentSlide);
});

