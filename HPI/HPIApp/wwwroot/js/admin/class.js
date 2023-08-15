var dataTable;

$(document).ready(function () {
    var url = window.location.href.split("/");
    var branchId = url.pop(); // get last element of array
    loadDataTable(branchId);
});

function loadDataTable(branchId) {
    dataTable = $('#tblClass').DataTable({
        "ajax": {
            "url": "/Admin/Branch/GetAllClass/" + branchId
        },
        "columns": [
            { "data": "id", "width": "15%" },
            { "data": "name", "width": "15%" },
            { "data": "slot", "width": "15%" },
            { "data": "branch.name", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                            <a href="/Admin/Class/Edit/${data}" class="btn btn-primary mx-2">
                                <i class="bi bi-pencil-square"></i> &nbspUpdate
                            </a>
                            <a onClick="return Delete('/Admin/Class/Delete/${data}')" class="btn btn-danger mx-2">
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