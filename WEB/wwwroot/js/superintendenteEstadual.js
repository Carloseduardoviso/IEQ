$(function () {
    $(document).on('click', '#btnNovoTeste', function () {
        $.ajax({
            type: 'GET',
            url: $(this).data('url'),
            success: function (response) {
                $('#modal').empty().append(response)
                modal = new bootstrap.Modal($('#modalSuperintendenteEstadual'));
                modal.show();                
            }
        })
    })   
});