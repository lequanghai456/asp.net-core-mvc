const container = document.querySelector(".container");
const seats = document.querySelectorAll(".row .seat:not(.occupied)");
var Danhsachghe = new Array();
// ?Seat click event
container.addEventListener("click", (e) => {
    if (e.target.classList.contains("seat") && !e.target.classList.contains("occupied")) {
        e.target.classList.toggle("selected");
        if ((Danhsachghe.length > 1) && Danhsachghe.indexOf(e.target.innerText) != -1) {
            Danhsachghe.splice(Danhsachghe.indexOf(e.target.innerText), 1);
        } else {
            Danhsachghe.push(e.target.innerText);
        }
    }
});