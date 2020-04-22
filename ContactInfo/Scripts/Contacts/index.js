$(document).ready(function () {
    $("#contacts").DataTable({
        ajax: {
            url: "/api/contacts",
            dataSrc: ""
        },
        columns: [
            {
                data: null,
                render: function (data, type, contact) {
                    return "<a href='/contacts/details/" + contact.id + "'>" + data.firstName + " " + data.lastName + "</a>";
                }
            },
            {
                data: "email"
            },
            {
                data: "phoneNumber"
            },
            {
                data: "status"
            },
            {
                data: "id",
                render: function (data) {
                    return "<button class='btn-link js-edit' data-contact-id=" + data + ">Edit</button>" +
                        " | " + "<button class='btn-link js-delete' data-contact-id=" + data + ">Delete</button>";
                }
            }
        ]
    });

    $("#contacts").on("click", ".js-edit", function () {
        location.href = "/contacts/edit/" + $(this).attr("data-contact-id");
    });

    $("#contacts").on("click", ".js-delete", function () {
        var deleteButton = $(this);

        bootbox.confirm("Are you sure you want to delete this contact?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/contacts/" + deleteButton.attr("data-contact-id"),
                    method: "DELETE",
                    success: function () {
                        deleteButton.parents("tr").remove();
                    }
                });
            }
        });
    });
});