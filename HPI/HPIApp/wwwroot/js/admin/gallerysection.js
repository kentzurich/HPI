function ValidateInputImg() {
    if (document.getElementById("imgFile").value == "") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please upload an image!'
        });
        return false;
    }
    return true;
}

function Delete(id) {
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
                url: "/Admin/GallerySection/DeleteImage/" + id,
                type: "Delete",
                contentType: "application/json",
                success: function (data) {
                    if (data.success == true) {
                        $("#imageRow").load(window.location.href + " #imageRow");
                        toastr.success(data.message);
                    }
                    else
                        toastr.error(data.message);
                }
            })
        }
    });
}