function selectPro(row) {
    $("#promotionId").val(row.Id);
	$("#promotionType").val(row.PromotionType);
    $("#promotionName").val(row.PromotionName);
	appendSku(row.Id);
}


function appendSku(id) {
    $.ajaxCommit("/Promotion/GetSkuByPro", { id: id }, function (result) {
        var data = result.Data;
        var html = [];
        for (var i = 0; i < data.length; i++) {
            html += '<tr id="tr' + data[i].Id + '" >';
            html += '<td>';
            html += '<input type="hidden" data-name="Skus[iiii].PromotionId" value="' + data[i].PromotionId + '" />';
            html += '<input type="hidden" data-name="Skus[iiii].SkuId" value="' + data[i].SkuId + '" />';
            html += '<input type="hidden" class="num" data-name="Skus[iiii].ProductNum" value="' + data[i].ProductNum + '" />';
            html += '' + data[i].SkuCode + '';
            html += '</td > ';
            html += '<td>' + data[i].ProductName + '</td>';
            html += '<td>' + data[i].SkuName + '</td>';
            html += '<td>' + data[i].ProductPrice + '</td>';
			html += '<td>' + data[i].Price + '</td>';
            html += '<td>' + data[i].ProductNum + '</td>';
			if($("#promotionType").val()==4)
			{
			    html += '<td><input type="number"  class="form-control currentSendNum" min="' + data[i].ProductNum + '" data-name="Skus[iiii].Num" value="" /></td>';
			}
			else
			{
			    html += '<td><input type="number"  class="form-control currentSendNum" min="1" data-name="Skus[iiii].Num" value="" /></td>';
			}

            html += '</tr>';
        }
        $('#tbodyProduct').empty().append(html);
    });
}

$(function () {
    $("#saveForm").validate({
        rules: {
            PromotionId: {
                required: true
            },
            UserId: {
                required: true
            }
        }
    });

    $("#account").buyerComplete();

    $("#btnPromo").click(function () {
        $.openWindow("/Promotion/SelectProList", "选择活动");
    });


    $("#btnSave").bindSubmit({
		before:function(){
			var flag = true;
      var arr = [];
			$("#tbodyProduct").each(function () {
        var trs = $(this).find("tr").not(".hidden");
        var i = 0;
			  var type = $("#promotionType").val();
        trs.each(function () {
				var num = $(this).find(".num").val();
				var current = $(this).find(".currentSendNum").val();
				var intNum = 0;
				var intCurrent = 0;
				if(num!="")
				{
					intNum = parseInt(num);
				}
				if(current!="")
				{
					intCurrent = parseInt(current);
				}
        if(intCurrent%num==0)
        {
          arr.push(intCurrent/num);
        }
				if(type=="4")
				{
					if(intCurrent<intNum||intCurrent%intNum!=0)
					{
						$.alert("此活动为套餐类型，购买数量必须为套餐数量的倍数!");
						flag = false;
					}
				}
				else
				{
					if(intCurrent<intNum&&current!="")
					{
						$.alert("购买数量必须大于或等于套餐数量!");
						flag = false;
					}
				}
				if(current!="")
				{
					var inp = $(this).find("input");
					if (inp.length > 0) {
                    inp.each(function (index, target) {
                        target = $(target);
                        var name = target.data("name").replace("iiii", i);
                        target.attr("name", name);
                    });
                    i++;
					}
				}
            });
        });
      var distinct = $.unique(arr.sort());
      if(distinct.length>1||distinct[0]==-1)
      {
          $.alert("商品购买数量的倍数不一致!");      
      }
		return flag;
		}
	});
});