var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblAdminUser').DataTable({
        "ajax": {
            "url": "/Admin/User/GetAllAdmin"
        },
        "columns": [
            { "data": "firstName", "width": "15%" },
            { "data": "lastName", "width": "15%" },
            { "data": "email", "width": "15%" },
            { "data": "role", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/Admin/User/ViewAdmin/${data}" class="btn btn-success text-white" style="cursor:pointer; width:150px;">
                                <i class="ri-search-2-line"></i> &nbspView
                            </a>
                        </div>
                    `;
                },
                "width": "20%"
            }
        ]
    });
}