$(document).ready(function () {
            $("#sidebar").mCustomScrollbar({
                theme: "minimal"
            });
            $('#sidebarCollapse').on('click', function () {
                $('#sidebar, #content').toggleClass('active');
                $('.collapse.in').toggleClass('in');
                $('a[aria-expanded=true]').attr('aria-expanded', 'false');
            });
});


$(document).ready(function () {
    $('nav ul li a').click(function (e) {
        $('nav li.active').removeClass('active');

        var $parent = $(this).parent();
        $parent.addClass('active');
        e.preventDefault();
    });
});