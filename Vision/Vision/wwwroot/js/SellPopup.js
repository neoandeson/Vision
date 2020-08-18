$(document).ready(function () {
    $('#SO_Symbol').change(function () {
        ClearTablePriceSectionToSell();
        LoadPriceSectionToSell($('#SO_Symbol').val());
    });

    $('#SO_Volume').change(function () {
        $('#ps_notAssigned').text(this.value);
    });

    $('#tbl_priceSectionToSell').on('change', ':checkbox', function () {
        debugger;
        var $tr = $(this).parent().parent();
        var $td_colT0 = $($tr).find('td.colT0');

        var colT0 = parseInt($td_colT0.text());
        var ps_notAssigned = parseInt($('#ps_notAssigned').text());

        if ($(this).is(':checked')) {
            ApplySelectedPriceSection(colT0, ps_notAssigned, $td_colT0);
        } else {
            var colVolume = parseInt(($tr).find('td.colVolume').text());
            UnApplySelectedPriceSection(colT0, ps_notAssigned, colVolume, $td_colT0)
        }
    });
});

function ApplySelectedPriceSection(colT0, ps_notAssigned, $td_colT0) {
    if (ps_notAssigned > 0) {
        var diff = ps_notAssigned - colT0;

        if (diff > 0) {
            $('#ps_notAssigned').text(diff);
            $td_colT0.text(0);
        } else if (diff <= 0) {
            $('#ps_notAssigned').text(0);
            $td_colT0.text(Math.abs(diff));
        }
    }
}

function UnApplySelectedPriceSection(colT0, ps_notAssigned, colVolume, $td_colT0) {
    if (ps_notAssigned >= 0) {
        $td_colT0.text(colVolume);

        var diff = colVolume - colT0;
        $('#ps_notAssigned').text(diff);
    }
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
                    { "data": "volume", "width": "5%", "className": "dt-right colVolume" },
                    { "data": "t0", "width": "5%", "className": "dt-right bg-success colT0" },
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
    $('#ps_notAssigned').text('0');

    ClearTablePriceSectionToSell();
}

function SaveSellOut() {

}

function PrepareSellOutModel() {

}
