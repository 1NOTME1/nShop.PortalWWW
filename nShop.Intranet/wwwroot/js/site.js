document.addEventListener("DOMContentLoaded", function () {
    const navLinks = document.querySelectorAll('.nav-link');

    navLinks.forEach(link => {
        link.addEventListener('click', function () {
            // Usuń klasę 'active' z wszystkich linków
            navLinks.forEach(l => l.classList.remove('active'));

            // Dodaj klasę 'active' do klikniętego linku
            link.classList.add('active');
        });
    });
});
