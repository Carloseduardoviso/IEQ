
$(document).on("click", "#btn-notificacao", function () {
    $('#modalMensagem').show();
});

$(document).on("click", "#btn-notificacao", function () {
    $('#modalMensagem').show();
});

$(document).on("click", ".btn-fecha", function () {
    $('#modalMensagem').hide();
});

function limparCamposETrazerStatus() {
    let currentUrl = window.location.href;

    $("form select").val("1,2,4,5");
    $("form input:not([name='__RequestVerificationToken'])").val("");

    window.location.href = currentUrl;
}

$(".btn-limpar").on("click", function (e) {
    limparCamposETrazerStatus();
});

function notification(icon, title) {
    Swal.mixin({
        toast: true,
        position: "top-end",
        showConfirmButton: false,
        timer: 5000,
        timerProgressBar: true,
        didOpen: (toast) => {
            toast.onmouseenter = Swal.stopTimer;
            toast.onmouseleave = Swal.resumeTimer;
        }
    }).fire({
        icon: icon,
        title: title
    });
};

function rebindValidators($form) {
    $form.unbind();
    $form.data("validator", null);
    $.validator.unobtrusive.parse($form);
};

const SELECTOR_SIDEBAR_WRAPPER = '.sidebar-wrapper';
const Default = {
    scrollbarTheme: 'os-theme-light',
    scrollbarAutoHide: 'leave',
    scrollbarClickScroll: true,
};
document.addEventListener('DOMContentLoaded', function () {
    const sidebarWrapper = document.querySelector(SELECTOR_SIDEBAR_WRAPPER);
    if (sidebarWrapper && typeof OverlayScrollbarsGlobal?.OverlayScrollbars !== 'undefined') {
        OverlayScrollbarsGlobal.OverlayScrollbars(sidebarWrapper, {
            scrollbars: {
                theme: Default.scrollbarTheme,
                autoHide: Default.scrollbarAutoHide,
                clickScroll: Default.scrollbarClickScroll,
            },
        });
    }
});