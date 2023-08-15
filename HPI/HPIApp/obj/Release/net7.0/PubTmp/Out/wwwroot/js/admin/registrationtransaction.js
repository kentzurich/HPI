var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblRegistrationTxn').DataTable({
        "ajax": {
            "url": "/Admin/Registration/GetRegistrationTxn"
        },
        "columns":
        [
            { "data": "applicationUser.firstName", "width": "20%" },
            { "data": "applicationUser.lastName", "width": "20%" },
            { "data": "paymentRefNo", "width": "25%" },
            {
                "data": "transactionDate",
                "width": "15%",  
                "render": function (data) {
                    var txnDate = new Date(data);
                    return FormatDate(txnDate);
                }
            },
            {
                "data": "amount", "width": "15%",
                "render": function (data) {
                    return `${data.toFixed(2)}`;
                }
            },
            { "data": "paymentMethod.name", "width": "25%" },
            { "data": "status", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                            <a href="/Admin/Registration/RegistrationApproval/${data}" class="btn btn-primary mx-10">
                                <i class="bi bi-pencil-square"></i> &nbspApproval
                            </a>
                        </div>
                    `
                },
                "width": "100%"
            }
        ]
    });
}

function FormatDate(inputDate) {
    let date, month, year;

    date = inputDate.getDate();
    month = inputDate.getMonth() + 1;
    year = inputDate.getFullYear();

    date = date
        .toString()
        .padStart(2, '0');

    month = month
        .toString()
        .padStart(2, '0');

    return `${month}/${date}/${year}`;
}

$(function () {
    $('.pop').on('click', function () {
        $('.imagepreview').attr('src', $(this).find('img').attr('src'));
        $('#imagemodal').modal('show');
    });
});