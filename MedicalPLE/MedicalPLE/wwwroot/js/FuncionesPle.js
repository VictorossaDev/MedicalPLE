function openNav() {
    document.getElementById("mySidenav").style.width = "280px";
    document.getElementById("main").style.marginLeft = "280px";
    document.getElementById("main1").style.marginLeft = "280px";
}

function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
    document.getElementById("main").style.marginLeft = "0";
    document.getElementById("main1").style.marginLeft = "0";
}

var acc = document.getElementsByClassName("accordionple");
var i;

for (i = 0; i < acc.length; i++) {
    acc[i].addEventListener("click", function () {
        this.classList.toggle("active");
        var panel = this.nextElementSibling;
        if (panel.style.maxHeight) {
            panel.style.maxHeight = null;
        } else {
            panel.style.maxHeight = panel.scrollHeight + "px";
        }
    });
}

var dropdown = document.getElementsByClassName("dropdown-btn-ple");
var i;

for (i = 0; i < dropdown.length; i++) {
    dropdown[i].addEventListener("click", function () {
        this.classList.toggle("active");
        var dropdownContent = this.nextElementSibling;
        if (dropdownContent.style.display === "block") {
            dropdownContent.style.display = "none";
        } else {
            dropdownContent.style.display = "block";
        }
    });
}


/* When the user clicks on the button, 
toggle between hiding and showing the dropdown content */
function myFunction1() {
    document.getElementById("myDropdown1").classList.toggle("show");
    document.getElementById("myDropdown2").classList.remove("show");
    document.getElementById("myDropdown3").classList.remove("show");
}


/* When the user clicks on the button, 
toggle between hiding and showing the dropdown content */
function myFunction2() {
    document.getElementById("myDropdown2").classList.toggle("show");
    document.getElementById("myDropdown1").classList.remove("show");
    document.getElementById("myDropdown3").classList.remove("show");
}


/* When the user clicks on the button, 
toggle between hiding and showing the dropdown content */
function myFunction3() {
    document.getElementById("myDropdown3").classList.toggle("show");
    document.getElementById("myDropdown1").classList.remove("show");
    document.getElementById("myDropdown2").classList.remove("show");
}

// Close the dropdown if the user clicks outside of it
window.onclick = function (event) {
    if (!event.target.matches('.dropbtn')) {
        var dropdowns = document.getElementsByClassName("dropdown-content");
        var i;
        for (i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i];
            if (openDropdown.classList.contains('show')) {
                openDropdown.classList.remove('show');
            }
        }
    }
}
