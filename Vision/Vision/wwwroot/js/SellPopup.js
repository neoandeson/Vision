$(document).ready(function () {
    $('#SO_Symbol').change(function () {
        ClearDataTable('#tbl_priceSectionToSell');
        LoadPriceSectionToSell($('#SO_Symbol').val());
    });

    $('#SO_Volume').change(function () {
        $('#ps_notAssigned').text(this.value);
        ResetPriceSectionToSellTable();
    });

    $('#tbl_priceSectionToSell').on('change', ':checkbox', function () {
        var $tr = $(this).parent().parent();
        var $tdcolBalance = $($tr).find('td.tdcolBalance');

        var tdcolBalance = parseInt($tdcolBalance.text());
        var ps_notAssigned = parseInt($('#ps_notAssigned').text());

        if ($(this).is(':checked')) {
            ApplySelectedPriceSection(tdcolBalance, ps_notAssigned, $tdcolBalance);
        } else {
            var tdcolAvailable = parseInt(($tr).find('td.tdcolAvailable').text());
            UnApplySelectedPriceSection(tdcolBalance, ps_notAssigned, tdcolAvailable, $tdcolBalance)
        }
    });
});

function ApplySelectedPriceSection(tdcolBalance, ps_notAssigned, $tdcolBalance) {
    if (ps_notAssigned > 0) {
        var diff = ps_notAssigned - tdcolBalance;

        if (diff > 0) {
            $('#ps_notAssigned').text(diff);
            $tdcolBalance.text(0);
        } else if (diff <= 0) {
            $('#ps_notAssigned').text(0);
            $tdcolBalance.text(Math.abs(diff));
        }
    }
}

function UnApplySelectedPriceSection(tdcolBalance, ps_notAssigned, tdcolAvailable, $tdcolBalance) {
    if (ps_notAssigned >= 0) {
        $tdcolBalance.text(tdcolAvailable);

        var diff = tdcolAvailable - tdcolBalance;
        $('#ps_notAssigned').text(ps_notAssigned + diff);
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
                    { "data": "volume", "width": "5%", "className": "dt-right tdcolVolume" },
                    { "data": "t0", "width": "5%", "className": "dt-right tdcolAvailable" },
                    { "data": "t0", "width": "5%", "className": "dt-right table-success tdcolBalance" },
                    { "data": "note" }
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

    ClearDataTable('#tbl_priceSectionToSell');
}

function ResetPriceSectionToSellTable() {
    $('#tbl_priceSectionToSell > tbody > tr').each(function (i, el) {
        var $row = $(el);
        var $cbk = $($row.find('td > input[type="checkbox"]'));

        $cbk.prop('checked', false);
        var t0Volume = $row.find('td.tdcolAvailable').text();
        $row.find('td.tdcolBalance').text(t0Volume);
    });
}

function SaveSellOut() {
    var arrSelectedPS = PrepareSelectedSection();
    var sellOrderModel = PrepareSellOrderModel();

    $.ajax({
        url: 'http://localhost:54214/SellOrder/SellOut',
        method: "POST",
        data: {
            sellOrderDTO: sellOrderModel,
            arrSelectedPS: arrSelectedPS
        },
        xhrFields: {
            withCredentials: true
        },
        success: function (rs) {
            alert("Sell out success");
        }
    });
}

function PrepareSelectedSection() {
    var arrSelectedPriceSection = [];

    $('#tbl_priceSectionToSell > tbody > tr').each(function (i, el) {
        var $row = $(el);
        var $cbk = $($row.find('td > input[type="checkbox"]'));

        if ($cbk.is(':checked')) {
            var tdcolAvailable = parseInt(($row).find('td.tdcolAvailable').text());
            var tdcolBalance = parseInt($($row).find('td.tdcolBalance').text());

            arrSelectedPriceSection.push(
                {
                    PriceSectionId: $cbk.attr('id').split('_')[2],
                    SoldVolume: tdcolAvailable - tdcolBalance
                }
            )
        }
    });

    return arrSelectedPriceSection;
}

function PrepareSellOrderModel() {
    var sellOrderDTO = {
        Id: 0,
        OrderNumber: $('#SO_Number').val(),
        Date: $('#SO_Date').val(),
        Symbol: $('#SO_Symbol').val(),
        Volume: $('#SO_Volume').val(),
        Price: $('#SO_Price').val(),
        TradingFee: $('#SO_TradingFee').val(),
        Tax: $('#SO_Tax').val(),
        Value: 0,//Process at backend
        Time: $('#SO_Time').val(),
        Note: $('#SO_Note').val()
    };

    return sellOrderDTO;
}
