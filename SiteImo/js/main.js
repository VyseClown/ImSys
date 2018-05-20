$(document).ready(function() {
	// Header Scroll
	$(window).on('scroll', function() {
		var scroll = $(window).scrollTop();

		if (scroll >= 50) {
			$('#header').addClass('fixed');
		} else {
			$('#header').removeClass('fixed');
		}
	});

	// Waypoints
	$('.work').waypoint(function() {
		$('.work').addClass('animated fadeIn');
	}, {
		offset: '75%'
	});
	$('.download').waypoint(function() {
		$('.download .btn').addClass('animated tada');
	}, {
		offset: '75%'
	});

	// Fancybox
	$('.work-box').fancybox();

	// Flexslider
	$('.flexslider').flexslider({
		animation: "fade",
		directionNav: false,
	});

	// Page Scroll
	var sections = $('section')
		nav = $('nav[role="navigation"]');

	$(window).on('scroll', function () {
	  	var cur_pos = $(this).scrollTop();
	  	sections.each(function() {
	    	var top = $(this).offset().top - 76
	        	bottom = top + $(this).outerHeight();
	    	if (cur_pos >= top && cur_pos <= bottom) {
	      		nav.find('a').removeClass('active');
	      		nav.find('a[href="#'+$(this).attr('id')+'"]').addClass('active');
	    	}
	  	});
	});
	nav.find('a').on('click', function () {
	  	var $el = $(this)
	    	id = $el.attr('href');
		$('html, body').animate({
			scrollTop: $(id).offset().top - 75
		}, 500);
	  return false;
	});

	// Mobile Navigation
	$('.nav-toggle').on('click', function() {
		$(this).toggleClass('close-nav');
		nav.toggleClass('open');
		return false;
	});	
	nav.find('a').on('click', function() {
		$('.nav-toggle').toggleClass('close-nav');
		nav.toggleClass('open');
	});

	//$('input[name="trtipo"]').on('change', function () {
	//    if ($(this).val() === 'aluguel')
	//        return alert('aluguel');
	//   return alert('venda');
	//});

//	<asp:DropDownList ID="ddlValor" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlValor_SelectedIndexChanged">
//    <asp:ListItem Value="0">- Selecione um valor -</asp:ListItem>
    //<asp:ListItem Value="12">Valores para venda</asp:ListItem>
    //<asp:ListItem Value="1">0 a 30 mil</asp:ListItem>
    //<asp:ListItem Value="2">30 mil a 60 mil</asp:ListItem>
    //<asp:ListItem Value="3">60 mil a 90 mil</asp:ListItem>
    //<asp:ListItem Value="4">90 mil a 120 mil</asp:ListItem>
    //<asp:ListItem Value="5">Acima de 120 mil</asp:ListItem>
    //<asp:ListItem Value="6">Valores para Aluguel</asp:ListItem>

//</asp:DropDownList>
	//$("input[type='checkbox']:checked").change(function () {

	//    var aluguel = '<select value="6">Valores para Aluguel</select>' +
 //                       '<select value="7">0 a 800</select>' +
 //                       '<select value="8">800 a 1600</select>' +
 //                       '<select value="9">1600 a 2400</select>' +
 //                       '<select value="10">2400 a 3000</select>' +
 //                       '<select value="11">Acima de 3000</select>';

	//    var venda = '<select value="12">Valores para venda</select>' +
 //                   '<select value="1">800 a 1600</select>' +
 //                   '<select value="2">1600 a 2400</select>' +
 //                   '<select Value="3">2400 a 3000</select>' +
 //                   '<select value="4">Acima de 3000</select>'+
	//                '<select value="5">Acima de 3000</select>'+
 //                   '<select value="6">Acima de 3000</select>'+
 //                   '<select value="4">Acima de 3000</select>'
	//                ;

	//    var essa = this.value;

	//    console.log(essa);

	//    if (essa === 'aluguel') {
	//        $('#ddlValor').html(aluguel);
	//        console.log(aluguel);
	//    } else {
	//        $('#ddlValor').html(venda);
 //       }
	//})
});