
// Write your JavaScript code.
$('#vehicle-list').change(function () {
    $("#vehicles").val($(this).val())

    $.ajax({
        type: "GET",
        url: "/Vehicle/GetVehicle/" + $(this).val(),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            $("#make").val(data.make)
            $("#model").val(data.model)
            $("#year").val(data.year)
        },

        failure: function (data) {
            alert(data.responseText);
        },
        error: function (data) {
            alert(data.responseText);
        }

    });

});

$('#sum-insured').change(function () {
    $("#rate").val(calculate_rate($(this).val()));
});

//Set rate
function calculate_rate(sumInsured) {
    let rate = 0;
    if (parseInt(sumInsured) >= 0 && parseInt(sumInsured) <= 200000) {
        rate = sumInsured * (0.5 / 100);
    }

    if (parseInt(sumInsured) > 200000 && parseInt(sumInsured) <= 500000) {
        rate = sumInsured * (0.5 / 100);
    }

    return rate;
}


