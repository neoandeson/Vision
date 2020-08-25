function LoadBuyOrder(priceSectionId) {
    ClearDataTable('#tbl_buyOrder');

    $.ajax({
        url: 'http://localhost:54214/BuyOrder/GetAllByPriceSectionId',
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
                    { "data": "volume", "className": "dt-right" },
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
        url: 'http://localhost:54214/AccountState/GetById',
        method: "POST",
        data: { id: accountStateId },
        xhrFields: {
            withCredentials: true
        },
        success: function (rs) {
            var data = rs.data;
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
        Id: 0,
        Symbol: $('#BO_Symbol').val(),
        Description: $('#BO_Number').val(),
        Note: $('#BO_Date').val(),
        Type: $('#BO_Time').val(),
        Department: $('#BO_InvestType').val()
    };

    $.ajax({
        url: 'http://localhost:54214/AccountState/Update',
        method: "POST",
        data: { model: model },
        xhrFields: {
            withCredentials: true
        },
        success: function (rs) {
            $('#stateSymbol').text(rs.Symbol);
            $('#stateDepartment').text(rs.Symbol);
            $('#stateType').text(rs.Symbol);
            $('#stateDescription').text(rs.Symbol);
            $('#stateNote').text(rs.Symbol);
        }
    });
}