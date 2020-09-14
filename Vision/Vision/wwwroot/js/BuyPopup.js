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
    InitElements();
}

function InitElements() {
    $("#BO_Date").datepicker({
        changeMonth: true,
        changeYear: true
    });
}

function SaveBuyIn() {
    $.ajax({
        url: WebURL + 'BuyOrder/BuyIn',
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
