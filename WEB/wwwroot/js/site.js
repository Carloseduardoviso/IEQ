// =======================
// Document Ready
// =======================
$(document).ready(function () {

    // 🔹 Inicializa todos os selects com Select2
    $('.select2').select2({
        placeholder: "Selecione os cargos",
        width: '100%',
        allowClear: true
    });

    // 🔹 Modal Notificação
    $(document).on("click", "#btn-notificacao", function () {
        $('#modalMensagem').show();
    });

    $(document).on("click", ".btn-fecha", function () {
        $('#modalMensagem').hide();
    });

    // 🔹 Limpar campos do formulário e resetar status
    $(".btn-limpar").on("click", function (e) {
        limparCamposETrazerStatus();
    });
});

// =======================
// Função: Limpar campos e resetar status
// =======================
function limparCamposETrazerStatus() {
    let currentUrl = window.location.href;

    // Exemplo: resetar selects múltiplos e inputs
    $("form select").val("1,2,4,5").trigger('change'); // trigger para Select2 atualizar
    $("form input:not([name='__RequestVerificationToken'])").val("");

    // Recarrega a página
    window.location.href = currentUrl;
}

// =======================
// Função: Notificação com SweetAlert
// =======================
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
}

// =======================
// Função: Rebind de validação de formulário
// =======================
function rebindValidators($form) {
    $form.unbind();
    $form.data("validator", null);
    $.validator.unobtrusive.parse($form);
}

// =======================
// Scrollbar customizada para sidebar
// =======================
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