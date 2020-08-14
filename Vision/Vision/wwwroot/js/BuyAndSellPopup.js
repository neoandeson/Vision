function ResetBuyInPopup() {
    $('#BO_Number').val('');
    $('#BO_Date').val('');
    $('#BO_Symbol').val('');
    $('#BO_InvestType').val('');
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
    $('#SO_Volume').val('0');

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
        PriceSectionId: 0,
        Symbol: $('#BO_Symbol').val(),
        OrderNumber: $('#BO_Number').val(),
        Date: $('#BO_Date').val(),
        Time: $('#BO_Time').val(),
        InvestType: $('#BO_InvestType').val(),
        Volume: $('#BO_Volume').val(),
        Price: $('#BO_Price').val(),
        TradingFee: $('#BO_TradingFee').val(),
        MatchedVol: $('#BO_Volume').val(),
        T2: 0,
        T1: 0,
        T0: 0,
        Note: $('#BO_Note').val(),
        TimerSellDays: $('#BO_TimerSellDays').val(),
        Sold: 0
    };

    return model;
}

function PrepareSellOutModel() {

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
                            return '<input id="cbk_ps_' + data + '" type="checkbox" >';
                        }
                    },
                    { "data": "price", "width": "5%", "className": "dt-right" },
                    { "data": "volume", "width": "5%", "className": "dt-right" },
                    { "data": "t0", "width": "5%", "className": "dt-right bg-success t0_available" },
                    { "data": "note" },
                    { "data": "t0", "width": "5%", "className": "dt-right t0_balance" }
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
        LoadPriceSectionToSell($('#SO_Symbol').val());
    });

    $('#SO_Volume').change(function () {
        $('#ps_notAssigned').text(this.value);
    });

    $('#tbl_priceSectionToSell').on('change', ':checkbox', function () {
        debugger;
        var tr = $(this).parent().parent()
        var str_t0_available = $(tr).find('td.t0_available').text();
        var t0_available = parseInt(str_t0_available);

        var ps_notAssigned = parseInt($('#ps_notAssigned').text());
        if (ps_notAssigned > 0) {
            ps_notAssigned -= t0_available;

            $('#ps_notAssigned').text(ps_notAssigned);
        }
    });
});