function LoadBuyOrder(priceSectionId) {
    ClearDataTable('#tbl_buyOrder');

    $.ajax({
        url: WebURL + 'BuyOrder/GetAllByPriceSectionId',
        method: "POST",
        data: { priceSectionId: priceSectionId },
        xhrFields: {
            withCredentials: true
        },
        success: function (rs) {
            var ds = rs.data;
            $('#tbl_buyOrder').DataTable({
                "aaData": ds,
                "bProcessing": true,
                "columns": [
                    { "data": "orderNumber", "width": "5%", "className": "dt-right" },
                    {
                        "data": "date", "className": "dt-right", render: function (data, type, row) {
                            return data.slice(0, 10);
                        }
                    },
                    { "data": "t0", "className": "dt-right" },
                    { "data": "t1", "className": "dt-right" },
                    { "data": "t2", "className": "dt-right" },
                    { "data": "matchedVol", "width": "5%", "className": "dt-right" },
                    { "data": "note" },
                    {
                        "data": "id", "width": "5%", render: function (data, type, row) {
                            return '<a href="PriceSection/' + data + '">Detail</button>';
                        }
                    }
                ]
            });
        }
    });
}

function LoadAccountStateDetail(accountStateId) {
    $.ajax({
        url: WebURL + 'AccountState/GetById',
        method: "POST",
        data: { id: accountStateId },
        xhrFields: {
            withCredentials: true
        },
        success: function (rs) {
            var data = rs.data;
            $('#stateId').val(data.id);
            $('#stateSymbol').text(data.symbol);
            $('#stateDepartment').val(data.department);
            $('#stateType').val(data.type);
            $('#stateDescription').val(data.description);
            $('#stateNote').val(data.note);
        }
    });
}

function SaveAccountState() {
    var model = {
        Id: $('#stateId').val(),
        Description: $('#stateDescription').val(),
        Note: $('#stateNote').val(),
        Type: $('#stateType').val(),
        Department: $('#stateDepartment').val()
    };

    $.ajax({
        url: WebURL + 'AccountState/Update',
        method: "POST",
        data: { updateVM: model },
        xhrFields: {
            withCredentials: true
        },
        success: function (rs) {
            alert(rs.Message)
        }
    });
}