$(function () {
    function inicializarModal() {

        // Select2 dentro do modal
        $('#modalAdicionar .select2').select2({
            dropdownParent: $('#modalAdicionar'),
            width: '100%'
        });

        // Máscara telefone
        $('#Contato').mask('(00) 00000-0000');

        // 🔥 Se estiver editando → carregar cidades automaticamente
        let estado = $('#Estado').val();
        let cidadeSelecionada = $('#CidadeSelecionada').val();

        if (estado) {
            carregarCidades(estado, cidadeSelecionada);
        }
    }

    // 🔥 Função para carregar cidades
    function carregarCidades(uf, cidadeSelecionada = null) {

        $('#Cidade').empty().append('<option>Carregando...</option>');

        $.get('/Membro/GetCidades', { uf: uf }, function (data) {

            $('#Cidade').empty().append('<option value="">Selecione</option>');

            $.each(data, function (i, item) {

                let selected = cidadeSelecionada === item.id;

                $('#Cidade').append(
                    new Option(item.text, item.id, selected, selected)
                );
            });

            $('#Cidade').trigger('change');
        });
    }

    // 🔥 Evento ao trocar estado
    $(document).on('change', '#Estado', function () {
        let uf = $(this).val();
        carregarCidades(uf);
    });

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
});