$(document).ready(function () {
    var id = $("#Id").val();

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
                $(table[0].insertRow(-1)).append($("<th />").html("Status:")).append($("<td />").html(data.status));

                var name = $("<h2 />").html(data.firstName + " " + data.lastName);

                $("#details").append(
                    name,
                    table
                );
            }
        },
        error: function (xhr, status) {
            alert("Sorry, there was a problem!");
        }
    });
});