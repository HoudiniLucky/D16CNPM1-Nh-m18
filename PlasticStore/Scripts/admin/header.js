

// Current Date
var today = new Date();
let date = `Hôm nay: ${today.getDate()}/${today.getMonth() + 1
    }/${today.getFullYear()}`;
document.getElementById('today').innerHTML = date;

let fname = document.querySelector('.icon-user-fullname');
let fullName = fname.textContent;
let nameSlice = fullName.slice(fullName.lastIndexOf(' ') + 1);
fname.innerHTML = `Xin chào, ${nameSlice} <i class='bx bx-chevron-down'></i>`;
