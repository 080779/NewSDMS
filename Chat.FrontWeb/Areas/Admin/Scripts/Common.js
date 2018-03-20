//格式化日期
function formatD(date) {
    var year, month, day;
    year = date.getFullYear();
    if (date.getMonth() + 1 < 10) {
        month = "0" + (date.getMonth() + 1);
    }
    else {
        month = date.getMonth() + 1;
    }
    if (date.getDate() < 10) {
        day = "0" + date.getDate();
    }
    else {
        day = date.getDate();
    }
    return year + "-" + month + "-" + day;
    //return date.getFullYear() + "-" + (date.getMonth()+1) + "-" + date.getDate();
}

//格式化开始时间，结束时间
function FormatTime(StartTimeID, EndTimeID) {
    $("#" + StartTimeID).datebox({
        formatter: formatD
    });
    $("#" + EndTimeID).datebox({
        formatter: formatD
    });
}

//弹出公告
function ShowNotice(id) {
    var url = 'NoticeEdit.aspx?ID=' + id;
    window.parent.OpenReg(url, '代理信息', 740, 640);
    return false;
}
//弹出代理信息
function ShowRegUserInfo(id) {
    var url = 'AdminReg.aspx?typeid=1&UpdateUser=' + id;
    window.parent.OpenReg(url, '代理信息', 740, 640);
    return false;
}

//弹出代理列表
function ShowAgentUserInfo(id) {
    var url = 'agentManage/UserList.aspx?agentId=' + id;
    window.parent.OpenReg(url, '代理列表', 740, 640);
    return false;
}

function AjaxFormValidator(DecUCodeID, UCodeID, RecUCodeID, ConUcodeID,BtnID) {
    $.formValidator.initConfig({ formID: "form1", theme: 'ArrowSolidBox', mode: 'AutoTip', onError: function(msg) { alert(msg) }, inIframe: true });
    $("#" + DecUCodeID).formValidator({ onShow: "请输入报单中心编号", onFocus: "报单中心编号不能为空", onCorrect: "输入正确" }).inputValidator({ min: 6, max: 18, onError: "编号输入错误" }).ajaxValidator({ data: { CheckValue: $("#" + DecUCodeID).val(), flag: "1" }, dataType: "html", async: true, url: "FormValidatorHandler.ashx", success: function(data) { if (data.indexOf("报单中心可以使用!") > 0) return true; return data; }, buttons: $("#" + BtnID), error: function(jqXHR, textStatus, errorThrown) { alert("服务器没有返回数据，可能服务器忙，请重试" + errorThrown); }, onError: "报单中心：不是报单中心或者不存在", onWait: "正在对报单中心编号进行合法性校验，请稍候..." });

    $("#" + UCodeID).formValidator({ onShow: "请输入代理编号", onFocus: "代理不能为空", onCorrect: "输入正确" }).inputValidator({ min: 6, max: 18, onError: "编号输入错误" }).ajaxValidator({ data: { CheckValue: $("#" + UCodeID).val(), flag: "2" }, dataType: "html", async: false, url: "FormValidatorHandler.ashx", success: function(data) { if (data.indexOf("可以使用!") > 0) return true; return data; }, buttons: $("#" + BtnID), error: function(jqXHR, textStatus, errorThrown) { alert("服务器没有返回数据，可能服务器忙，请重试" + errorThrown); }, onError: "该用户编号已存在!请重新输入", onWait: "正在对代理编号进行合法性校验，请稍候..." });

    $("#" + RecUCodeID).formValidator({ onShow: "请输入推荐代理编号", onFocus: "推荐代理编号不能为空", onCorrect: "输入正确" }).inputValidator({ min: 6, max: 18, onError: "编号输入错误" }).ajaxValidator({ data: { CheckValue: $("#" + RecUCodeID).val(), flag: "3" }, dataType: "html", async: true, url: "FormValidatorHandler.ashx", success: function(data) { if (data.indexOf("可以使用!") > 0) return true; return data; }, buttons: $("#" + BtnID), error: function(jqXHR, textStatus, errorThrown) { alert("服务器没有返回数据，可能服务器忙，请重试" + errorThrown); }, onError: "推荐人：不存在，请更换用户名", onWait: "正在对推荐代理编号进行合法性校验，请稍候..." });

    $("#" + ConUcodeID).formValidator({ onShow: "请输入接点代理编号", onFocus: "接点代理不能为空", onCorrect: "输入正确" }).inputValidator({ min: 6, max: 18, onError: "编号输入错误" }).ajaxValidator({ data: { CheckValue: $("#" + ConUcodeID).val(), flag: "4" }, dataType: "html", async: true, url: "FormValidatorHandler.ashx", success: function(data) { if (data.indexOf("可以使用!") > 0) return true; return data; }, buttons: $("#" + BtnID), error: function(jqXHR, textStatus, errorThrown) { alert("服务器没有返回数据，可能服务器忙，请重试" + errorThrown); }, onError: "接点人：不存在或者脚下已经满员", onWait: "正在对接点代理编号进行合法性校验，请稍候..." });
    $.formValidator.reloadAutoTip();
}

function FormValidator(DecUCodeID, UCodeID, RecUCodeID, ConUcodeID, UPassID, UPassAgainID, UPassID2, UPassAgainID2, UPassID3, UPassAgainID3, BankBranchID, BankCodeID, BankUNameID, UNameID, UCodeNumID, UPhoneID, UAddressID) {
    $.formValidator.initConfig({ formID: "form1", theme: 'ArrowSolidBox', mode: 'AutoTip', onError: function(msg) { alert(msg) }, inIframe: true });
    $("#" + DecUCodeID).formValidator({ onShow: "请输入报单中心编号", onFocus: "报单中心编号不能为空", onCorrect: "输入正确" }).inputValidator({ min: 6, max: 18, onError: "编号输入错误" });
    $("#" + UCodeID).formValidator({ onShow: "请输入代理编号", onFocus: "代理不能为空", onCorrect: "输入正确" }).inputValidator({ min: 6, max: 18, onError: "编号输入错误" });
    $("#" + RecUCodeID).formValidator({ onShow: "请输入推荐代理编号", onFocus: "推荐代理编号不能为空", onCorrect: "输入正确" }).inputValidator({ min: 6, max: 18, onError: "编号输入错误" });
    $("#" + ConUcodeID).formValidator({ onShow: "请输入接点代理编号", onFocus: "接点代理不能为空", onCorrect: "输入正确" }).inputValidator({ min: 6, max: 18, onError: "编号输入错误" });
    $("#" + UPassID).formValidator({ onShow: "请输入密码", onFocus: "密码不能为空", onCorrect: "密码合法" }).inputValidator({ min: 6, max: 18, onError: "密码长度请保持在：6-18之间" });
    $("#" + UPassAgainID).formValidator({ onShow: "输再次输入密码", onFocus: "密码不能为空", onCorrect: "密码一致" }).inputValidator({ min: 6, max: 18, onError: "密码长度请保持在：6-18之间" }).compareValidator({ desID: UPassID, operateor: "=", onError: "2次密码不一致,请确认" });
    $("#" + UPassID2).formValidator({ onShow: "请输入二级密码", onFocus: "二级密码不能为空", onCorrect: "密码合法" }).inputValidator({ min: 6, max: 18, onError: "密码长度请保持在：6-18之间" });
    $("#" + UPassAgainID2).formValidator({ onShow: "输再次输入密码", onFocus: "二级密码不能为空", onCorrect: "密码一致" }).inputValidator({ min: 6, max: 18, onError: "密码长度请保持在：6-18之间" }).compareValidator({ desID: UPassID2, operateor: "=", onError: "2次密码不一致,请确认" });
    $("#" + UPassID3).formValidator({ onShow: "请输入二级密码", onFocus: "二级密码不能为空", onCorrect: "密码合法" }).inputValidator({ min: 6, max: 18, onError: "密码长度请保持在：6-18之间" });
    $("#" + UPassAgainID3).formValidator({ onShow: "输再次输入密码", onFocus: "二级密码不能为空", onCorrect: "密码一致" }).inputValidator({ min: 6, max: 18, onError: "密码长度请保持在：6-18之间" }).compareValidator({ desID: UPassID3, operateor: "=", onError: "2次密码不一致,请确认" });
    $("#" + BankBranchID).formValidator({ onShow: "请输入支行名称", onFocus: "支行名称不能为空", onCorrect: "输入正确" }).inputValidator({ min: 3, onError: "请输入支行名称" });
    $("#" + BankCodeID).formValidator({ onShow: "请输入银行账号", onFocus: "银行账号不能为空", onCorrect: "输入正确" }).inputValidator({ min: 3, onError: "请输入银行账号" });
    $("#" + BankUNameID).formValidator({ onShow: "请输入开户名", onFocus: "开户名不能为空", onCorrect: "输入正确" }).inputValidator({ min: 3, onError: "请输入银行开户名" });
    $("#" + UNameID).formValidator({ onShow: "请输入姓名", onFocus: "姓名不能为空", onCorrect: "输入正确" }).inputValidator({ min: 3, onError: "请输入姓名" });
    $("#" + UCodeNumID).formValidator({ onShow: "请输入身份证号", onFocus: "身份证号不能为空", onCorrect: "输入正确" }).inputValidator({ min: 3, onError: "请输入正确的身份证号" });
    $("#" + UPhoneID).formValidator({ onShow: "请输入联系电话", onFocus: "联系电话不能为空", onCorrect: "输入正确" }).inputValidator({ min: 3, onError: "请输入正确的联系电话" });
    $("#" + UAddressID).formValidator({ onShow: "请输入联系地址号", onFocus: "联系地址不能为空", onCorrect: "输入正确" }).inputValidator({ min: 6, onError: "请输入正确的联系地址" });
    $.formValidator.reloadAutoTip();
}

