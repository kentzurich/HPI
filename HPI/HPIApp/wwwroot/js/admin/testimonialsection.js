var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblTestimonialSection').DataTable({
        "ajax": {
            "url": "/Admin/TestimonialSection/GetAll"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "applicationUser.firstName", "width": "15%" },
            { "data": "applicationUser.lastName", "width": "15%" },
            { "data": "testimony", "width": "10%", className: "testimonyClass" },
            { "data": "isAdded", "width": "15%" },
            {
                "data": { id: "id", isAdded: "isAdded" },
                "render": function (data) {
                    if (data.isAdded) {
                        return `
                        <div class="w-100 btn-group" role="group">
                            <a onclick="return ViewTestimony('${data.id}')" class="btn btn-primary mx-2" data-bs-toggle="modal" data-bs-target="#modalDialogScrollable">
                                <i class="ri-search-2-line"></i> &nbspView
                            </a>
                            <a onclick="return AddTestimony('${data.id}')" class="btn btn-danger mx-2">
                                <i class="bi bi-trash"></i> &nbspRemove
                            </a>
                            <a onClick="return Delete('/Admin/TestimonialSection/Delete/${data.id}')" class="btn btn-danger mx-2">
                                <i class="bi bi-trash"></i> &nbspDelete
                            </a>
                        </div>
                    `
                    }
                    else
                    {
                        return `
                        <div class="w-100 btn-group" role="group">
                            <a onclick="return ViewTestimony('${data.id}')" class="btn btn-primary mx-2" data-bs-toggle="modal" data-bs-target="#modalDialogScrollable">
                                <i class="ri-search-2-line"></i> &nbspView
                            </a>
                            <a onclick="return AddTestimony('${data.id}')" class="btn btn-secondary mx-2">
                                <i class="bi bi-plus-circle"></i> &nbspAdd
                            </a>
                            <a onClick="return Delete('/Admin/TestimonialSection/Delete/${data.id}')" class="btn btn-danger mx-2">
                                <i class="bi bi-trash"></i> &nbspDelete
                            </a>
                        </div>
                    `
                    }
                    
                },
                "width": "15%"
            }
        ]
    });
}

function ViewTestimony(id) {
    $.ajax({
        type: "GET",
        url: "/Admin/TestimonialSection/ViewTestimony",
        data: { id: id },
        contentType: "application/json",
        success: function (data) {
            var testimonial = data.data;

            if (testimonial != null)
            {
                $('#name').remove();
                $('#img').remove();
                $('#testimony').remove();

                $('#nameId').append(`<p id="name">${testimonial.applicationUser.firstName} ${testimonial.applicationUser.lastName}</p>`);
                $('#imgId').append(`<img id="img" src="${testimonial.applicationUser.memberPhotoUrl}" style="border-radius:5px; border:1px solid #bbb9b9; width: 125px; height: 125px;" />`);
                $('#testimonialId').append(`<textarea id="testimony" readonly rows="10" class="form-control border-0 shadow">${testimonial.testimony}</textarea>`);
            }
        }
    });
}

function AddTestimony(id) {
    $.ajax({
        type: "POST",
        url: "/Admin/TestimonialSection/AddTestimony",
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload();
            }
        }
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