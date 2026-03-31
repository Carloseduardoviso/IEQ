$(function () {

    // =========================
    // 🔧 INICIALIZAÇÃO
    // =========================
    function inicializarComponentes(context = document) {

        // Select2
        $(context).find('.select2').select2({
            width: '100%',
            dropdownParent: $('#modalAdicionar').length ? $('#modalAdicionar') : $(document.body)
        });

        // Máscara telefone
        $(context).find('#Contato').mask('(00) 00000-0000');

        // Desabilitar hierarquia
        $('#RegiaoId').prop('disabled', true);
        $('#IgrejaId').prop('disabled', true);
        $('#PastorId').prop('disabled', true);
    }


    // =========================
    // 🔥 ESTADO → CIDADE
    // =========================
    function carregarCidades(uf, cidadeSelecionada = null) {

        $('#Cidade').html('<option>🔄 Carregando cidades...</option>');

        if (!uf) return;

        $.get('/Membro/GetCidades', { uf }, function (data) {

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

    $(document).on('change', '#Estado', function () {
        carregarCidades($(this).val());
    });


    // =========================
    // 🔥 SUPERINTENDENTE → REGIÃO
    // =========================
    $(document).on('change', '#SuperintendenteRegionalId', function () {

        let superId = $(this).val();

        $('#RegiaoId')
            .prop('disabled', true)
            .html('<option>🔄 Carregando regiões...</option>');

        $('#IgrejaId')
            .prop('disabled', true)
            .html('<option>Selecione a região</option>');

        $('#PastorId')
            .prop('disabled', true)
            .html('<option>Selecione a igreja</option>');

        if (!superId) return;

        $.get('/Usuario/GetRegioes', { superintendenteId: superId }, function (data) {

            $('#RegiaoId')
                .prop('disabled', false)
                .empty()
                .append('<option value="">Selecione</option>');

            $.each(data, function (i, item) {
                $('#RegiaoId').append(new Option(item.text, item.id));
            });
        });
    });


    // =========================
    // 🔥 REGIÃO → IGREJA
    // =========================
    $(document).on('change', '#RegiaoId', function () {

        let regiaoId = $(this).val();

        $('#IgrejaId')
            .prop('disabled', true)
            .html('<option>🔄 Carregando igrejas...</option>');

        $('#PastorId')
            .prop('disabled', true)
            .html('<option>Selecione a igreja</option>');

        if (!regiaoId) return;

        $.get('/Usuario/GetIgrejas', { regiaoId }, function (data) {

            $('#IgrejaId')
                .prop('disabled', false)
                .empty()
                .append('<option value="">Selecione</option>');

            $.each(data, function (i, item) {
                $('#IgrejaId').append(new Option(item.text, item.id));
            });
        });
    });


    // =========================
    // 🔥 IGREJA → PASTOR
    // =========================
    $(document).on('change', '#IgrejaId', function () {

        let igrejaId = $(this).val();

        $('#PastorId')
            .prop('disabled', true)
            .html('<option>🔄 Carregando pastores...</option>');

        if (!igrejaId) return;

        $.get('/Usuario/GetPastores', { igrejaId }, function (data) {

            $('#PastorId')
                .prop('disabled', false)
                .empty()
                .append('<option value="">Selecione</option>');

            $.each(data, function (i, item) {
                $('#PastorId').append(new Option(item.text, item.id));
            });
        });
    });


    // =========================
    // 🔥 VALIDAÇÃO VISUAL
    // =========================
    $(document).on('blur change', 'input, select', function () {

        if ($(this).prop('required')) {

            if (!$(this).val()) {
                $(this).addClass('is-invalid').removeClass('is-valid');
            } else {
                $(this).addClass('is-valid').removeClass('is-invalid');
            }
        }
    });


    // =========================
    // 🔥 MODAL (NOVO)
    // =========================
    $(document).on('click', '#btnNovo', function () {

        $.ajax({
            type: 'GET',
            url: $(this).data('url'),
            success: function (response) {

                $('#modal').empty().append(response);

                let modal = new bootstrap.Modal($('#modalAdicionar'));
                modal.show();

                inicializarComponentes('#modalAdicionar');
                rebindValidators($('#modalAdicionar'));
                $('#Contato').mask('(00) 00000-0000');
            }
        });
    });


    // =========================
    // 🔥 MODAL (EDITAR)
    // =========================
    $(document).on('click', '.edit-button', function (e) {
        e.preventDefault();

        $.ajax({
            type: 'GET',
            url: $(this).attr('href'),
            success: function (response) {

                $('#modal').empty().append(response);

                let modal = new bootstrap.Modal($('#modalAdicionar'));
                modal.show();

                inicializarComponentes('#modalAdicionar');
                rebindValidators($('#modalAdicionar'));
                $('#Contato').mask('(00) 00000-0000');

                // 🔥 carregar cidade automaticamente
                let estado = $('#Estado').val();
                let cidadeSelecionada = $('#CidadeSelecionada').val();

                if (estado) {
                    carregarCidades(estado, cidadeSelecionada);
                }
            },
            error: function () {
                notification('error', 'Erro ao carregar formulário.');
            }
        });
    });


    // =========================
    // 🔥 ATIVAR / DESATIVAR
    // =========================
    $(document).on('click', '.ativar-button', function (e) {
        e.preventDefault();

        let url = $(this).attr('href');

        Swal.fire({
            title: "Deseja realizar esta operação?",
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


    // =========================
    // 🔥 REMOVER
    // =========================
    $(document).on('click', '.remove-button', function (e) {

        e.preventDefault();

        let button = $(this);
        let usuarioId = button.data('id');

        Swal.fire({
            title: "Deseja realmente remover?",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Sim, remover!",
            cancelButtonText: "Cancelar"
        }).then((result) => {

            if (result.isConfirmed) {

                $.ajax({
                    type: 'POST',
                    url: button.data('url'),
                    data: { usuarioId },
                    success: function (response) {

                        button.closest('tr').remove();
                        notification("success", response.message);
                    },
                    error: function (response) {
                        notification('error', response.responseText || "Erro ao remover.");
                    }
                });
            }
        });
    });


    // =========================
    // 🚀 INIT GLOBAL
    // =========================
    inicializarComponentes();

});