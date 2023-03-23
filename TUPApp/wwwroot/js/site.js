// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const text = document.querySelector("#copy-email");
const popup = document.querySelector(".popup");

text.addEventListener("click", () => {
    popup.classList.add("active");
    copyToClipBoard();
});
popup.addEventListener("animationend", () => {
    popup.classList.remove("active");
});

function copyToClipBoard() {
    const textarea = document.createElement("textarea");
    textarea.setAttribute("readonly", "");
    textarea.value = text.innerText;
    textarea.style.position = "absolute";
    document.body.appendChild(textarea);
    textarea.select();
    //document.execCommand("copy");
    document.body.removeChild(textarea);
}