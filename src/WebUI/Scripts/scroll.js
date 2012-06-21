
$(function(){
		   $('#scroll').mouseover(function(){$(this).attr("scrollamount","0");})
		   $('#scroll').mouseout(function(){$(this).attr("scrollamount","4");})
		   $('#test').click(function(){$('#test').addClass("bg1");$('#teach').removeClass("bg1");$('#1').animate({left:"-300px"},500);})
		   $('#teach').click(function(){$(this).addClass("bg1");$('#test').removeClass("bg1");$('#1').animate({left:"0px"},500);})
		   $('#movies').click(function(){$(this).addClass("bg1");$('#cyclopaedia').removeClass("bg1");$('#2').animate({left:"-300px"},500);})
		   $('#cyclopaedia').click(function(){$(this).addClass("bg1");$('#movies').removeClass("bg1");$('#2').animate({left:"0px"},500);})
		   })
