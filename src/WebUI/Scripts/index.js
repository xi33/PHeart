$(function () {
	function slide(elem, slideRange, type, start, slideN, demoTimer, fadeTimer, slideSpeed, now) {
		this.elem = $("." + elem);
		this.type = type;
		this.slideSpeed = slideSpeed || 500;
		this.slideRange = slideRange;
		this.start = start;
		this.slideN = slideN;
		this.note = $("." + elem + " .text");
		this.tabButton = $(".button li");
		this.now = now || 1;
		this.demoTimer = demoTimer || 7000;
		this.fadeTimer = fadeTimer || 1500;
		this.fade = 0.6;
		this.elem.css('width', slideRange * slideN);
	}
	slide.prototype =
	{
		arrayImgRight: Array('', '0 0', '-60px 0', '-172px 0', '-212px 0', '-120px 22px', '-146px 22px'),
		arrayImgLeft: Array('', '-30px 0', '-90px 0', '-192px 0', '-233px 0', '-133px 22px', '-159px 22px'),
		sliding: function (i) {
			var _this = this;
			var n = this.now;
			var range = this.slideRange * (i - n);
			var sStart = this.start;
			range = range * (-1);
			range += sStart;
			var speed = this.slideSpeed * Math.abs(i - n);
			if (this.type == 'left') {
				this.elem.animate({ 'left': range }, speed, function () {
					for (var j = 0; j < _this.slideN; j++) {
						_this.note.eq(j).fadeOut(0)
					}
					_this.note.eq(i - 1).fadeTo(_this.fadeTimer, _this.fade)
				})
			}
			else {
				this.elem.animate({ 'top': range }, speed, function () {
					for (var j = 0; j < _this.slideN; j++) {
						_this.note.eq(j).fadeOut(0)
					}
					_this.note.eq(i - 1).fadeTo(_this.fadeTimer, _this.fade)
				})
			}
			this.start = range
		},
		tab: function (elemLeft, elemRight, n) {
			for (var i = 0; i < this.slideN; i++) {
				var _this = this;
				(function (i) {
					_this.tabButton.eq(i).bind('click', function () {
						_this.clear();
						_this.sliding(i + 1);
						_this.now = i + 1;
						_this.test(elemLeft, elemRight, n);
						_this.demo(elemLeft, elemRight, n)
					})
				})(i)
			}
		},
		demo: function (elemLeft, elemRight, n) {
			var _this = this;
			this.demoInterval = setInterval(function () {
				var i = _this.now % _this.slideN;
				_this.sliding(i + 1);
				_this.now = i + 1;
				_this.test(elemLeft, elemRight, n)
			}, this.demoTimer)
		},
		clear: function () {
			clearInterval(this.demoInterval)
		},
		clickTab: function (elemLeft, elemRight, n) {
			var _this = this;
			elemLeft.bind('click', function () {
				_this.clear();
				var i = _this.now + 1;
				if (i == _this.slideN + 1) {
					i = 1;
				}
				_this.sliding(i);
				_this.now = i;
				i++;
				_this.test(elemLeft, elemRight, n)
				if (n == 1) {
					_this.demo(elemLeft, elemRight, n)
				}
			})
			elemRight.bind('click', function () {
				_this.clear();
				var i = _this.now - 1;
				if (i == 0) {
					i = _this.slideN;
				}
				_this.sliding(i);
				_this.now = i; i--;
				_this.test(elemLeft, elemRight, n)
				if (n == 1) {
					_this.demo(elemLeft, elemRight, n)
				}
			})
		},
		test: function (elemLeft, elemRight, n) {
			var _this = this;
			if (_this.now > 1) {
				elemRight.css('background-position', _this.arrayImgRight[n + 1])
			}
			else {
				elemRight.css('background-position', _this.arrayImgRight[n])
			}
			if (_this.now < _this.slideN) {
				elemLeft.css('background-position', _this.arrayImgLeft[n + 1])
			}
			else {
				elemLeft.css('background-position', _this.arrayImgLeft[n])
			}
			if (n == 1) {
				for (var j = 0; j < _this.slideN; j++) {
					_this.tabButton.eq(j).removeClass("now");
				}
				_this.tabButton.eq(_this.now - 1).addClass("now");
			}
		},
		stopDemo: function (elemLeft, elemRight, n) {
			var _this = this; $("#slide .imgWrap img").bind('mouseover', function () { _this.clear() })
			$("#slide .imgWrap img").bind('mouseout', function () { _this.demo(elemLeft, elemRight, n) })
		}
	}
	var slideLength = $('#slide .imgWrap').length;
	var newsSlide = new slide('bigSlide', 640, 'left', 0, slideLength);
	newsSlide.tab($('#slide .rightMenu'), $('#slide .leftMenu'), 1);
	newsSlide.demo($('#slide .rightMenu'), $('#slide .leftMenu'), 1);
	newsSlide.clickTab($('#slide .rightMenu'), $('#slide .leftMenu'), 1);
	newsSlide.stopDemo($('#slide .rightMenu'), $('#slide .leftMenu'), 1);

	var toolLength = Math.ceil($('.toolSlide li').length / 3);
	var toolSlide = new slide('toolSlide', 237, 'left', 0, toolLength);
	toolSlide.clickTab($('#smallTools div').eq(2), $('#smallTools div').eq(0), 3);

	var fleaLength = Math.ceil($('.fleaSlide ul').length / 8);
	var fleaTab = new slide('fleaSlide', 324, 'left', 0, fleaLength);
	fleaTab.clickTab($('#flea .rightBar'), $('#flea .leftBar'), 5);

	var musicLength = Math.ceil($('.musicTab li').length / 3);
	var musicTab = new slide('musicTab', 207, 'left', 0, musicLength);
	musicTab.clickTab($('#music .rightBar'), $('#music .leftBar'), 5);

	var forumLength = Math.ceil($('.forumTab li').length / 7);
	var forumTab = new slide('forumTab', 560, 'left', 0, forumLength);
	forumTab.clickTab($('#forum .rightBar'), $('#forum .leftBar'), 5);

	var videoLength = Math.ceil($('.videoTab li').length / 3);
	var videoTab = new slide('videoTab', 219, 'left', 0, videoLength);
	videoTab.clickTab($('#video .rightBar'), $('#video .leftBar'), 5);

	function googlenav(elem, offset, top) {
		this.elem = elem;
		this.offset = offset;
		this.n = 0;
		this.top = top
	}
	googlenav.prototype =
	{
		overUp: function () {
			var left = 0;
			var _this = this;
			this.overSlowUp = setInterval(function () {
				_this.elem.css('backgroundPosition', left + 'px ' + _this.top + 'px');
				left -= _this.offset;
				if (left == -156) {
					$('#title').fadeIn(160);
					$('#title').animate({ top: -10 }, 20)
				}
				if (left == -260) {
					clearInterval(_this.overSlowUp);
					_this.overDown()
				}
			}, 80)
		},
		overDown: function () {
			var top = this.top;
			var _this = this;
			this.overAfterUp = setInterval(function () {
				_this.elem.css('backgroundPosition', '-208px ' + top + 'px');
				top++;
				if (top == _this.top + 6) {
					clearInterval(_this.overAfterUp)
				}
			}, 20)
		},
		outUp: function () {
			var left = -208;
			var _this = this;
			this.outAfterUp = setInterval(function () {
				_this.elem.css('backgroundPosition', left + 'px ' + _this.top + 'px');
				left += 52;
				if (left == 52) {
					clearInterval(_this.outAfterUp)
				}
			}, 80)
		},
		outDown: function () {
			var top = this.top + 5;
			var _this = this;
			this.outSlowUp = setInterval(function () {
				_this.elem.css('backgroundPosition', '-208px ' + top + 'px');
				top--;
				if (top == _this.top - 1) {
					clearInterval(_this.outSlowUp);
					_this.outUp()
				}
			}, 20)
		},
		run: function (elem) {
			var _this = this;
			elem.bind('mouseover', function (event) {
				_this.clear();
				_this.overUp();
				event.stopPropagation()
			})
			elem.bind('mouseout', function (event) {
				_this.clear();
				_this.outDown();
				event.stopPropagation()
			})
		},
		clear: function () {
			clearInterval(this.overAfterUp);
			clearInterval(this.overSlowUp);
			clearInterval(this.outAfterUp);
			clearInterval(this.outSlowUp)
		}
	}
	var google1 = new googlenav($("#nav1"), 52, 0);
	google1.run($('#mouseon1'));
	var google2 = new googlenav($("#nav2"), 52, -57);
	google2.run($('#mouseon2'));
	var google3 = new googlenav($("#nav3"), 52, -114);
	google3.run($('#mouseon3'));
	var google4 = new googlenav($("#nav4"), 52, -171);
	google4.run($('#mouseon4'));
	var google5 = new googlenav($("#nav5"), 52, -228);
	google5.run($('#mouseon5'));
	var google6 = new googlenav($("#nav6"), 52, -285);
	google6.run($('#mouseon6'));
	var google7 = new googlenav($("#nav7"), 52, -342);
	google7.run($('#mouseon7'));
	var google8 = new googlenav($("#nav8"), 52, -399);
	google8.run($('#mouseon8'));
	function basTab() {
		var _this = this;
		this.go = function () {
			var left = 0;
			var i = 1;
			this.slide = setInterval(function () {
				$('#flea h3 div:eq(0)').css('background-position', left + 'px 0');
				left += i * 2; i++;
				if (left >= 65) {
					$('#flea h3 div:eq(0)').css('background-position', 65 + 'px 0');
					clearInterval(slide)
				}
			}, 5)
		}
		this.back = function () {
			var left = 65;
			var i = 1;
			this.slide2 = setInterval(function () {
				$('#flea h3 div:eq(0)').css('background-position', left + 'px 0');
				left -= i * 2; i++; if (left <= 0) {
					$('#flea h3 div:eq(0)').css('background-position', 0 + 'px 0');
					clearInterval(slide2)
				}
			}, 5)
		}
		$('#flea span:eq(0)').bind('click', function () {
			clearInterval(_this.slide2);
			clearInterval(_this.slide);
			_this.back(); $('#buyShow').show(0); $('#sellShow').hide(0);
			$(this).addClass('show');
			$('#flea span:eq(1)').removeClass('show')
		})
		$('#flea span:eq(1)').bind('click', function () {
			clearInterval(_this.slide2);
			clearInterval(_this.slide);
			_this.go(); $('#buyShow').hide(0);
			$('#sellShow').show(0);
			$(this).addClass('show');
			$('#flea span:eq(0)').removeClass('show')
		})
		$('#news .news_tab li a:eq(0)').bind('click', function () {
			$("#news .news_tab li a").removeClass("show");
			$("#news .news_tab li a:eq(0)").addClass("show");
			$('#news .content>div').removeClass("show");
			$('#news .content>div:eq(0)').addClass("show");
			return false;
		})
		$('#news .news_tab li a:eq(1)').bind('click', function () {
			$("#news .news_tab li a").removeClass("show");
			$("#news .news_tab li a:eq(1)").addClass("show");
			$('#news .content>div').removeClass("show");
			$('#news .content>div:eq(1)').addClass("show");
			return false;
		})
		$('#news .news_tab li a:eq(2)').bind('click', function () {
			$("#news .news_tab li a").removeClass("show");
			$("#news .news_tab li a:eq(2)").addClass("show");
			$('#news .content>div').removeClass("show");
			$('#news .content>div:eq(2)').addClass("show");
			return false;
		})
	} basTab();
});

/*$(function () {
	$('#q').focus(function () {
		$('#sa').css('background-position', '-28px 0')
	});
	$('#q').blur(function () {
		$('#sa').css('background-position', '0 0')
	});
	$('#getWeather a').click();
});

function WeatherSuccess(data) {
	JsonResult(data, function (data) {
		$('#weatherBody li').first().html(data.w0);
		$('#weatherBody li').last().html(data.w1);
		$('#weatherBody img').attr('src', data.w2);
	});
}
function WeatherFailure(data) {
	JsonResult(data, function (data) {
		$('#weatherBody li').first().html(data.Msg);
	});
}*/