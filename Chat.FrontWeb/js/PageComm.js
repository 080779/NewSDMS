(function ($) {
    $.fn.PageGrivView = function (options) {
        //合并默认参数和用户传过来的参数
        options = $.extend({}, $.fn.PageGrivView.defaults, options || {});
        //默认参数
        $.fn.PageGrivView.defaults = {
            totalPage: null,
            showPageNum: null,
            url: null,
            obj: null,
            css: "css-1"
        }; 
        $(this).whjPaging({
            css: options.css,
            totalPage: options.totalPage,
            showPageNum: options.showPageNum,
            callBack: function (currPage, pageSize) {
                
                $.ajax({
                    type: 'POST',
                    url: options.url,
                    data: { pageIndex: currPage, pageSize: pageSize },
                    async: false,
                    success: function (data) {
                        $(options.obj).replaceWith($(data).find(options.obj));
                        //alert(data);
                        console.log("请求成功");
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {//请求失败处理函数
                        console.log("请求失败");
                    }
                });
                console.log(options.showPageNum+ "=======" + options.showPageNum)
                console.log('totalPage:' + options.totalPage + '     showPageNum:' + options.showPageNum);
            }
        })
    }
})(jQuery);


