/**
** Burger menu
**/

let burgerMenu = document.querySelector('.burger__menu');
let navMenu = document.querySelector('nav');

burgerMenu.addEventListener('click', (event) => {
    event.currentTarget.classList.toggle('active');
    navMenu.classList.toggle('active');
});