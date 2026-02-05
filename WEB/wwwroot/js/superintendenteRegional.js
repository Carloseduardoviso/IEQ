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

    $(document).on('click', '.excluir-button', function (e) {
        e.preventDefault();

        let url = $(this).attr('href');

        Swal.fire({
            title: "Deseja Excluir?",
            text: "Essa ação pode ser revertida depois.",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Sim, Excluir",
            cancelButtonText: "Cancelar"
        }).then((result) => {
            if (result.isConfirmed) {

                $.post(url, function (response) {
                    Swal.fire("Excluído!", response.message, "success")
                        .then(() => location.reload());
                })
                    .fail(function () {
                        Swal.fire("Erro!", "Erro ao remover.", "error");
                    });

            }
        });
    });
});