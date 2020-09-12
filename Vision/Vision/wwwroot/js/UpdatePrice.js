function UpdatePrice() {
    $.ajax({
        url: WebURL + 'AutoJob/UpdateManual',
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