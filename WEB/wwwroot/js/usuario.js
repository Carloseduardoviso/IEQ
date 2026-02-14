$(function () {
    $(document).on('click', '#btnNovo', function () {
        $.ajax({
            type: 'GET',
            url: $(this).data('url'),
            success: function (response) {
                $('#modal').empty().append(response)
                modal = new bootstrap.Modal($('#modalAdicionar'));
                modal.show();
                rebindValidators($('#modal'))
            }
        })
    })

    $(document).on('click', '.edit-button', function (e) {
        e.preventDefault();

        $.ajax({
            type: 'GET',
            url: $(this).attr('href'),
            success: function (response) {
                $('#modal').empty().append(response)
                modal = new bootstrap.Modal($('#modalAdicionar'));
                modal.show();
                rebindValidators($('#modal'))
                $('#Contato').mask('(00) 00000-0000');
            },
            error: function () {
                notification('error', 'Erro ao carregar formulário de edição.');
            }
        });
    });

    $(document).on('click', '.ativar-button', function (e) {
        e.preventDefault();

        let url = $(this).attr('href');

        Swal.fire({
            title: "Deseja realiza está operação?",
            text: "Essa ação pode ser revertida depois.",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Sim",
            cancelButtonText: "Cancelar"
        }).then((result) => {
            if (result.isConfirmed) {
                window.location.href = url;
            }
        });
    });


    $(document).on('click', '.remove-button', function (e) {
        e.preventDefault();
        let button = $(this);
        let usuarioId = $(this).data('id');

        Swal.fire({
            title: "Deseja realmente remover?",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Sim, remover!",
            cancelButtonText: "Não, cancelar!"
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: 'POST',
                    url: button.data('url'),
                    data: { usuarioId: usuarioId },
                    success: (response) => {
                        button.closest('tr').remove();

                        notification("success", response.message);
                    },
                    error: (response) => {
                        notification('error', response.responseText || "Erro ao remover o item.");
                    }
                });
            }
        });
    });
});