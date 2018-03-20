/***********************************************************************
************************************************************************
**Reference by      疯狂秀才 
**Modified by       Kaleyroy
**Modified Date     2011-11-20
***********************************************************************
***********************************************************************/
/*初始化JQuery*/
$(function () {
    //初始化左侧菜单
//    InitLeftMenu();
    /*初始化Tab右键菜单事件*/
	tabClose();
	tabCloseEven();
    
//   // 绑定Tab标签选中处理事件
//	$('#tabs').tabs({
//        //01:当Tab标签被选中
//        onSelect: function (title) {
//            var currTab = $('#tabs').tabs('getTab', title);
//            var iframe = $(currTab.panel('options').content);
//			var src = iframe.attr('src');
//			if (src)
//			    //02:刷新框架内容
//				$('#tabs').tabs('update', { tab: currTab, options: { content: createFrame(src)} });
//        }
//    });
  
})

/*初始化左侧菜单*/
function InitLeftMenu() {
	$("#nav").accordion({animate:false});
    //组装左侧菜单面板和子菜单
	$.each(_menus.menus, function (i, n) {
	    var menulist = '';
	    menulist += '<ul>';
	    $.each(n.menus, function (j, o) {
	        menulist += '<li><div><a ref="' + o.menuid + '" href="#" rel="' + o.url + '" ><span class="icon ' + o.icon + '" >&nbsp;</span><span class="nav">' + o.menuname + '</span></a></div></li> ';
	    })
	    menulist += '</ul>';
	    $('#nav').accordion('add', {
	        title: n.menuname,
	        content: menulist,
	        iconCls: 'icon ' + n.icon
	    });
	});
	//绑定左侧子菜单点击处理事件
	$('.easyui-accordion li a').click(function () {
        //01:当左侧子菜单被点击
		var tabTitle = $(this).children('.nav').text();
		var url = $(this).attr("rel");
		var menuid = $(this).attr("ref");
		var icon = getIcon(menuid, icon);
		//02:向中间区域添加响应Tab标签
		addTab(tabTitle,url,icon);
		$('.easyui-accordion li div').removeClass("selected");
		$(this).parent().addClass("selected");
	}).hover(function(){
		$(this).parent().addClass("hover");
	},function(){
		$(this).parent().removeClass("hover");
	});
	//设置默认打开左侧第一菜单面板
	var panels = $('#nav').accordion('panels');
	var t = panels[0].panel('options').title;
    $('#nav').accordion('select', t);
}

/*获取左侧导航的图标*/
function getIcon(menuid){
	var icon = 'icon ';
	$.each(_menus.menus, function(i, n) {
		 $.each(n.menus, function(j, o) {
		 	if(o.menuid==menuid){
				icon += o.icon;
			}
		 })
	})
	return icon;
}

/*向中间区域添加Tab标签*/
function addTab(subtitle,url,icon){
	if(!$('#tabs').tabs('exists',subtitle)){
		$('#tabs').tabs('add',{
			title:subtitle,
			content:createFrame(url),
			closable:true
		});
	}else{
		$('#tabs').tabs('select',subtitle);
		$('#mm-tabupdate').click();
	}
    //绑定相关关闭事件
	tabClose();
}

/*创建标签内容框架*/
function createFrame(url)
{
	var s = '<iframe scrolling="auto" frameborder="0"  src="'+url+'" style="width:100%;height:100%;"></iframe>';
	return s;
}

/*标签相关关闭事件:
双击关闭,右键菜单*/
function tabClose()
{
	//双击关闭TAB选项卡
	$(".tabs-inner").dblclick(function(){
		var subtitle = $(this).children(".tabs-closable").text();
		$('#tabs').tabs('close',subtitle);
	})
	//为选项卡绑定右键
	$(".tabs-inner").bind('contextmenu',function(e){
		$('#mm').menu('show', {
			left: e.pageX,
			top: e.pageY
		});

		var subtitle =$(this).children(".tabs-closable").text();

		$('#mm').data("currtab",subtitle);
		$('#tabs').tabs('select',subtitle);
		return false;
	});
}

/*绑定右键菜单事件*/
function tabCloseEven()
{
	//刷新
	$('#mm-tabupdate').click(function(){
		var currTab = $('#tabs').tabs('getSelected');
		var url = $(currTab.panel('options').content).attr('src');
		 if (typeof (url) == "undefined") { url="zhuye.aspx" }
		$('#tabs').tabs('update',{
			tab:currTab,
			options:{
				content:createFrame(url)
			}
		})
	})
	//关闭当前
	$('#mm-tabclose').click(function(){
		var currtab_title = $('#mm').data("currtab");
		$('#tabs').tabs('close',currtab_title);
	})
	//全部关闭
	$('#mm-tabcloseall').click(function(){
		$('.tabs-inner span').each(function(i,n){
			var t = $(n).text();
			$('#tabs').tabs('close',t);
		});
	});
	//关闭除当前之外的TAB
	$('#mm-tabcloseother').click(function(){
		$('#mm-tabcloseright').click();
		$('#mm-tabcloseleft').click();
	});
	//关闭当前右侧的TAB
	$('#mm-tabcloseright').click(function(){
		var nextall = $('.tabs-selected').nextAll();
		if(nextall.length==0){
			//msgShow('系统提示','后边没有啦~~','error');
		    msgShow('系统提示','无效操作','info');
			return false;
		}
		nextall.each(function(i,n){
			var t=$('a:eq(0) span',$(n)).text();
			$('#tabs').tabs('close',t);
		});
		return false;
	});
	//关闭当前左侧的TAB
	$('#mm-tabcloseleft').click(function(){
		var prevall = $('.tabs-selected').prevAll();
		if (prevall.length == 0) {
		    msgShow('系统提示', '无效操作', 'info');
//			alert('到头了，前边没有啦~~');
			return false;
		}
		prevall.each(function(i,n){
			var t=$('a:eq(0) span',$(n)).text();
			$('#tabs').tabs('close',t);
		});
		return false;
	});

	//退出
	$("#mm-exit").click(function(){
		$('#mm').menu('hide');
	})
}

//弹出信息窗口 title:标题 msgString:提示信息 msgType:信息类型 [error,info,question,warning]
function msgShow(title, msgString, msgType) {
	$.messager.alert(title, msgString, msgType);
}
