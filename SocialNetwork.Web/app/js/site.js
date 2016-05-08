// site.js


(function () {
    sideBarKill(false);
})();

function sideBarKill(test) {
    var $sidebarAndWrapper = $('#sidebar,#wrapper');
    var $icon = $('#sidebarToggle i.fa');
    if (!test) {
        $('#sidebarToggle').on('click', function () {
            $sidebarAndWrapper.toggleClass('hide-sidebar');
            if ($sidebarAndWrapper.hasClass('hide-sidebar')) {
                $icon.removeClass('fa-angle-left');
                $icon.addClass('fa-angle-right');
            } else {
                $icon.addClass('fa-angle-left');
                $icon.removeClass('fa-angle-right');
            }
        });
    } else {
        $sidebarAndWrapper.addClass('hide-sidebar');
        $icon.removeClass('fa-angle-left');
        $icon.addClass('fa-angle-right');
    }
}