$(document).ready(function () {
    loadDataTable();
});

var dataTable;

function loadDataTable() {
    dataTable = $('#tableData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { data: 'title', "width": "5%" },
            {
                // Функция render для отображения изображения
                data: 'imageUrl',
                "width": "10%",
                "render": function (data, type, row) {
                    return '<img src="' + data + '" alt="Image" style="width: 100%;">';
                }
            },
            { data: 'author', "width": "5%" },
            { data: 'description', "width": "20%" },
            { data: 'categoryName.name', "width": "5%" },
            { data: 'isbn', "width": "5%" },
            { data: 'listPrice', "width": "2%" },
            { data: 'price', "width": "2%" },
            { data: 'price50', "width": "2%" },
            { data: 'price100', "width": "2%" },
            {
                data: 'id',
                "width": "2%",
                "render": function (data) {
                    return `<div class='w-100 btn-group' role='group'> 
                                <a href="/admin/product/upsert?id=${data}" class="btn btn-primary"><i class="bi bi-pencil-square"></i></a> 
                                <a onClick=Delete("/admin/product/delete/${data}") class="btn btn-danger"><i class="bi bi-trash3-fill"></i></a>
                            </div>`
                }
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: "Вы уверены?",
        text: "Вы не сможете восстановить книгу!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Да, удалить!"
    }).then((result) => {
        if (result.isConfirmed) {
                $.ajax({
                    url: url,
                    type: 'DELETE',
                    success: function (data) {
                        dataTable.ajax.reload();
                        toastr.sucess(data.message);
                    }
                });
        }
    });
}

