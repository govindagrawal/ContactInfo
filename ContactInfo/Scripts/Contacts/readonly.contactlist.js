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
            }
        ]
    });
});