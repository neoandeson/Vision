function UpdatePrice() {
    $.ajax({
        url: 'http://localhost:54214/AutoJob/Update',
        method: "POST",
        data: { },
        xhrFields: {
            withCredentials: true
        },
        success: function (rs) {
            alert(rs);
        }
    });
}