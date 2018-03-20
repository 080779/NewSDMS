function checkjoinin(name, gender, mobile, workUnits, duty, cityId, stayId, payId, invoiceUp, ein, address, contact, openBank, bankAccount) {
    if (name.length == 0)
    {
        alert("姓名不能为空");
        return false;
    }
    if(gender==0)
    {
        alert("请选择性别");
        return false;
    }
    if (mobile.length == 0) {
        alert("手机号不能为空");
        return false;
    }
    //reg = '/^\d{11}$/';
    //if(!reg.test(mobile))
    //{
    //    alert("手机号格式不正确，请输入正确的手机号");
    //    return false;
    //}
    if (workUnits.length == 0) {
        alert("工作单位不能为空");
        return false;
    }
    if (duty.length == 0) {
        alert("职务不能为空");
        return false;
    }
    if (cityId == 0) {
        alert("请选择工作地");
        return false;
    }
    if (stayId == 0) {
        alert("请选择住宿");
        return false;
    }
    if (payId == 0) {
        alert("请选择支付方式");
        return false;
    }
    if (invoiceUp.length == 0)
    {
        alert("发票抬头不能为空");
        return false;
    }
    if (ein.length == 0) {
        alert("税号不能为空");
        return false;
    }
    if (address.length == 0) {
        alert("详细地址不能为空");
        return false;
    }
    if (contact.length == 0) {
        alert("联系方式不能为空");
        return false;
    }
    if (openBank.length == 0) {
        alert("开户行不能为空");
        return false;
    }
    if (bankAccount.length == 0) {
        alert("银行账号不能为空");
        return false;
    }
    return true;
}