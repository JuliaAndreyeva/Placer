$(document).ready(function () {
    $('#sidebarCollapse').on('click', function () {
        $('#sidebar').toggleClass('active');
    });
});
function showRegisterMessage() {
    alert("Please log in to book a tour.");
}