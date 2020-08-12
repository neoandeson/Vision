function ResetBuyInPopup() {
    $('#BO_Number').val('');
    $('#BO_Date').val('');
    $('#BO_Symbol').val('');
    $('#BO_Type').val('');
    $('#BO_Volume').val('');
    $('#BO_Price').val('');
    $('#BO_TradingFee').val('');
    $('#BO_Time').val('');
    $('#BO_Note').val('');
    $('#BO_TimerSellDays').val('2');
}

function ResetSellOutPopup() {
    $('#SO_Number').val('');
    $('#SO_Date').val('');
    $('#SO_Symbol').val('');
    $('#SO_Time').val('');
    $('#SO_Tax').val('');
    $('#SO_Price').val('');
    $('#SO_TradingFee').val('');
    $('#SO_Note').val('');
    $('#SO_Volume').val('');

    ClearTablePriceSectionToSell();
}

function SaveBuyIn() {
    $.ajax({
        url: 'http://localhost:54214/BuyOrder/BuyIn',
        method: "POST",
        data: { rqDto: PrepareBuyInModel() },
        xhrFields: {
            withCredentials: true
        },
        success: function (rs) {
            alert(rs.message);
        }
    });
}

function SaveSellOut() {

}

function PrepareBuyInModel() {
    var model = {
        Id: 0,
        OrderNumber: $('#BO_Number').val(),
        Date: $('#BO_Date').val(),
        Symbol: $('#BO_Symbol').val(),
        Type: $('#BO_Type').val(),
        Volume: $('#BO_Volume').val(),
        Price: $('#BO_Price').val(),
        TradingFee: $('#BO_TradingFee').val(),
        Time: $('#BO_Time').val(),
        MatchedVol: $('#BO_Volume').val(),
        T2: 0,
        T1: 0,
        T0: 0,
        Note: $('#BO_Note').val(),
        TimerSellDays: $('#BO_TimerSellDays').val(),
        PriceSectionId: 0,
        Sold: 0,
        IsActive: true,
        UserId: 1//TODO: Session userid
    };

    return model;
}

function PrepareSellOutModel() {

}

function PriceSectionOnCheck() {

}

function LoadPriceSectionToSell(symbol) {
    $.ajax({
        url: 'http://localhost:54214/PriceSection/GetAllBySymbol',
        method: "POST",
        data: { symbol: symbol },
        xhrFields: {
            withCredentials: true
        },
        success: function (rs) {
            var ds = rs.data;
            $('#tbl_priceSectionToSell').DataTable({
                "aaData": ds,
                "bProcessing": true,
                "columns": [
                    {
                        "data": "id", "width": "5%", render: function (data, type, row) {
                            return '<input id="cbk_ps_' + data + '" type="checkbox" onchange="PriceSectionOnCheck()">';
                        }
                    },
                    { "data": "price", "width": "5%", "className": "dt-right" },
                    { "data": "volume", "width": "5%", "className": "dt-right" },
                    { "data": "t0", "width": "5%", "className": "dt-right" },
                    { "data": "note" },
                    { "data": "t0", "width": "5%", "className": "dt-right" }
                    //{
                    //    "data": "id", render: function (data, type, row) {
                    //        return '<a href="PriceSection/' + data + '">Detail</button>';
                    //    }
                    //}
                ]
            });
        }
    });
}

function ClearTablePriceSectionToSell() {
    var dataTable = $("#tbl_priceSectionToSell").DataTable();

    //clear datatable
    dataTable.clear().draw();

    //destroy datatable
    dataTable.destroy();
}

$(document).ready(function () {
    $('#SO_Symbol').change(function () {
        debugger;
        LoadPriceSectionToSell($('#SO_Symbol').val());
    });
});