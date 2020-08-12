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