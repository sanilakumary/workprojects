$(document).ready(function () {
    $('.admin-secondary-tab').click(function () {

        $('.admin-secondary-tab').removeClass('active');
        $(this).addClass('active');

        $.ajax({
            method: "Get",
            url: "Admin/GetFunctionGroups",
            success: function (data) {
                $('.admin-workarea').html(data);
                var functionGroupTable = $('#adminfunctiongroup-table').DataTable({
                    "ordering": true,
                    "paging": true,
                    "searching": true,
                    "info": true,
                    "deferRender": true,
                    "iDisplayLength": 100,
                    "fixedHeader": true,
                    "sDom": '<"top">rt<"bottom"lp><"clear">',
                    "order": [1, 'asc'],
                    "fnDrawCallback": function (settings) {
                    }
                });
            }
        });
    });
});