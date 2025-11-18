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
        let diaconatoId = $(this).data('id');

        $.ajax({
            type: 'GET',
            url: $(this).data('url'),
            data: { diaconatoId: diaconatoId },
            success: function (response) {
                $('#modal').empty().append(response)
                modal = new bootstrap.Modal($('#modalAdicionar'));
                modal.show();
                rebindValidators($('#modal'))
            },
            error: function () {
                notification('error', 'Erro ao carregar formulário de edição.');
            }
        });
    });
});