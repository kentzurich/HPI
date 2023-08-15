﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblFAQ').DataTable({
        "ajax": {
            "url": "/Admin/FAQSection/GetAll"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "question", "width": "15%" },
            { "data": "answer", "width": "40%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-100 btn-group" role="group">
                            <a href="/Admin/FAQSection/Upsert/${data}" class="btn btn-primary mx-2">
                                <i class="bi bi-pencil-square"></i> &nbspUpdate
                            </a>
                            <a onClick="return Delete('/Admin/FAQSection/Delete/${data}')" class="btn btn-danger mx-2">
                                <i class="bi bi-trash"></i> &nbspDelete
                            </a>
                        </div>
                    `
                },
                "width": "15%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: "Delete",
                success: function (data) {
                    if (data.success == true) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    });
}