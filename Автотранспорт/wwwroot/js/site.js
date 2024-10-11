// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let inputPhone = document.getElementById("inputPhone");
inputPhone.oninput = () => phoneMask(inputPhone)
function phoneMask(inputEl) {
    let patStringArr = "+7 (___) ___-__-__".split('');
    let arrPush = [4, 5, 6, 9, 10, 11, 13, 14, 16, 17]
    let val = inputEl.value;
    let arr = val.replace(/\D+/g, "").split('').splice(1);
    let n;
    let ni;
    arr.forEach((s, i) => {
        n = arrPush[i];
        patStringArr[n] = s
        ni = i
    });
    arr.length < 10 ? inputEl.style.color = 'red' : inputEl.style.color = 'green';
    inputEl.value = patStringArr.join('');
    n ? inputEl.setSelectionRange(n + 1, n + 1) : inputEl.setSelectionRange(19, 19)
}
