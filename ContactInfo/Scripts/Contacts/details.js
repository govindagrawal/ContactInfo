$(document).ready(function () {
    var id = $("#Id").val();
    var statusActive = "Active";
    var statusInactive = "Inactive";
    var buttonActivate = "Activate";
    var buttonDeactivate = "Deactivate";

    $.ajax({
        url: "/api/contacts/" + id,
        method: "GET",
        success: function (data) {
            if (data) {
                var table = $("<table />").attr("id", "contactDetails");

                $(table[0].insertRow(-1)).append($("<th />").html("Email Address:")).append($("<td />").html(data.email));
                $(table[0].insertRow(-1)).append($("<th />").html("Phone Number:")).append($("<td />").html(data.phoneNumber));
                if (data.address) {
                    $(table[0].insertRow(-1)).append($("<th />").html("Address:")).append($("<td />").html(data.address));
                }
                if (data.city) {
                    $(table[0].insertRow(-1)).append($("<th />").html("City:")).append($("<td />").html(data.city));
                }
                if (data.state) {
                    $(table[0].insertRow(-1)).append($("<th />").html("State:")).append($("<td />").html(data.state));
                }
                if (data.country) {
                    $(table[0].insertRow(-1)).append($("<th />").html("Country:")).append($("<td />").html(data.country));
                }
                if (data.postCode) {
                    $(table[0].insertRow(-1)).append($("<th />").html("Post Code:")).append($("<td />").html(data.postCode));
                }
                $(table[0].insertRow(-1)).append($("<th />").html("Status:")).append($("<td />").attr("id", "status").html(data.status));

                var name = $("<h2 />").html(data.firstName + " " + data.lastName);

                var toggleStatusButton = $("<h4 />").append($("<button />")
                    .addClass("btn-link js-toggleStatus")
                    .attr("id", "toggleStatus")
                    .eq(0)
                    .html(data.status === statusActive ? buttonDeactivate : buttonActivate)
                );

                $("#details").append(
                    name,
                    table,
                    toggleStatusButton
                );
            }
        },
        error: function (xhr, status) {
            alert("Sorry, there was a problem!");
        }
    });

    $("#details").on("click", ".js-toggleStatus", function () {
        $.ajax({
            url: "/api/contacts/activatedeactivatecontact/" + id,
            method: "PUT",
            data: id,
            success: function () {
                toastr.success("Contact status changed successfully");

                if ($("#toggleStatus").text() === buttonActivate) {
                    $("#toggleStatus").html(buttonDeactivate);
                    $("#status").html(statusActive);
                } else {
                    $("#toggleStatus").html(buttonActivate);
                    $("#status").html(statusInactive);
                }
            },
            error: function () {
                toastr.error("Contact status changed failed");
            }
        });
    });
});