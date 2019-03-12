$(document).ready(function () {
    $('.admin-secondary-tab').click(function () {
        $('.admin-secondary-tab').removeClass('active');
        $(this).addClass('active');
        var functionGroupTable = $('#adminfunctiongroup-table').DataTable({
            ajax: {
                "url": "/AdminSample/GetFunctionGroups"
            },
            "columns": [
                 { "data": "id" },
                 { "data": "description" }
            ],
            "order": [1, 'asc']
        });
    });
});    