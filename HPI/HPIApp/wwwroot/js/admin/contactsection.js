var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblContactSection').DataTable({
        "ajax": {
            "url": "/Admin/ContactSection/GetAll"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "email", "width": "20%" },
            { "data": "subject", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-100 btn-group" role="group">
                            <a href="/Admin/ContactSection/ViewMessage/${data}" class="btn btn-primary mx-2">
                                <i class="ri-search-2-line"></i> &nbspView
                            </a>
                        </div>
                    `
                },
                "width": "15%"
            }
        ]
    });
}