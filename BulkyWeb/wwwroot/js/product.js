$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { data: 'title' },
            { data: 'isbn'},
            { data: 'listPrice'},
            { data: 'author'},
            { data: 'category.name'},
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a href="/admin/product/upsert?id=${data}" class="btn btn-primary me-2">
                            <i class="bi bi-pencil-square"></i> Edit
                        </a>

                        <a href="/admin/product/delete/${data}" class="btn btn-danger">
                            <i class="bi bi-trash-fill"></i> Delete
                        </a>
                    
                    </div>`
                },
            },
        ]
    });
}

