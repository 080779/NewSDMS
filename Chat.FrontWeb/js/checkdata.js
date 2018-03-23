function checkdata(data) {
    if ((/^(\+|-)?\d+$/.test(data)) && data > 0) {
        return true;
    }
    else {
        return false;
    }
}